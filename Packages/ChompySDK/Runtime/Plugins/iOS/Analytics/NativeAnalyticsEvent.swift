import Foundation

enum NativeParamType: String {
    case string
    case integer
    case float
    case boolean
    case date
    case object
    case array
    
    static func from(_ string: String) -> NativeParamType? {
        return NativeParamType(rawValue: string.lowercased())
    }
}

struct NativeAnalyticsParam {
    public let name: String
    public let value: Any
    public let type: NativeParamType
}

struct NativeAnalyticsEvent {
    public let uuid = UUID().uuidString
    
    public let name: String
    public let params: [NativeAnalyticsParam]
    public var isSent: Bool = false
}
