import Foundation

@objc(NativeAnalyticsModule)
class NativeAnalyticsModule: NSObject {
    @objc
    public let shared = NativeAnalyticsModule();
    
    private override init() {
        
    }
    
    @objc
    public private(set) var isInitialized: Bool = false
    
    @objc
    public func initialize() {
        print("initialize called from Swift")
    }
    
    @objc
    public func logEvent() {
        print("logEvent called from Swift")
    }
}
