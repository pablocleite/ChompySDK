import Foundation

@objc(NativeAnalyticsModule)
public class NativeAnalyticsModule: NSObject {
    private let processingQueue: DispatchQueue = DispatchQueue(label: "NativeAnalyticsModule.processingQueue", qos: .utility)
    var timer: DispatchSourceTimer?
    
    private var isProcessingEvents = false
    private var eventQueue: [NativeAnalyticsEvent] = []
    
    
    @objc
    public static let shared = NativeAnalyticsModule();
    
    private override init() {
        
    }
    
    @objc
    public private(set) var isInitialized: Bool = false
    
    @objc
    public func initialize() {
        print("initialize called from Swift")
        
        startProcessing()
        
        isInitialized = true
    }
    
    private func startProcessing() {
        loadStoredEvents()
        guard timer == nil else { return; }
        
        timer = DispatchSource.makeTimerSource(queue: processingQueue)
        timer?.schedule(deadline: .now() + .seconds(30), repeating: .seconds(30))
        timer?.setEventHandler { [weak self] in
            guard self?.isProcessingEvents == false else { return }
            self?.isProcessingEvents = true
            
            for var analyticsEvent in self?.eventQueue ?? [] {
                guard analyticsEvent.isSent == false else { continue }

                //Here the logic to send event to providers should be called
                analyticsEvent.isSent = true
                
                print("Sent event \(analyticsEvent.name) to providers")
                self?.deleteEvent(analyticsEvent)
            }
            
            self?.eventQueue.removeAll(where: { event in
                event.isSent == true
            })
        }
        timer?.resume()
    }
    
    private func loadStoredEvents() {
        // Here events would be loaded from FS and loaded into the queue
    }
    
    private func deleteEvent(_ event: NativeAnalyticsEvent) {
        // Delete event from local storage
    }
    
    @objc
    public func logEvent(eventName: String, paramKeys: [String], paramValues: [String], paramTypes: [String], paramCount: Int) {
        print("logEvent called from Swift")
        var parameters: [NativeAnalyticsParam] = []
        parameters.reserveCapacity(paramCount)
        
        for i in (0..<paramCount) {
            let paramValueString = paramValues[i]
            let paramValue: Any?
            let paramType = NativeParamType.from(paramTypes[i]) ?? .string
            
            switch paramType {
            case .string:
                paramValue = paramValueString
            case .integer:
                paramValue = Int(paramValueString) ?? 0
            case .float:
                paramValue = Float(paramValueString) ?? 0.0
            case .boolean:
                paramValue = (paramValueString.lowercased() == "true")
            case .date:
                let formatter = ISO8601DateFormatter()
                paramValue = formatter.date(from: paramValueString) ?? Date(timeIntervalSince1970: 0)
            case .object:
                if let jsonData = paramValueString.data(using: .utf8) {
                    paramValue = try? JSONSerialization.jsonObject(with: jsonData, options: [])
                } else {
                    paramValue = paramValueString
                }
            case .array:
                if let jsonData = paramValues[i].data(using: .utf8) {
                    paramValue = (try? JSONSerialization.jsonObject(with: jsonData, options: [])) as? [Any] ?? []
                } else {
                    paramValue = [paramValueString]
                }
            }

            
            parameters[i] = NativeAnalyticsParam(name: paramKeys[i], value: paramValue ?? paramValueString, type: paramType)
        }
        
        let event = NativeAnalyticsEvent(name: eventName, params: parameters)
        
        enqueEvent(event)
    }
    
    private func enqueEvent(_ event: NativeAnalyticsEvent) {
        self.processingQueue.async { [weak self] in
            //Here the event should be stored in filesystem, to prevent data loss
            self?.eventQueue.append(event)
        }
    }
}
