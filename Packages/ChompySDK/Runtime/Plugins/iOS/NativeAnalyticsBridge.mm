#import <Foundation/Foundation.h>
#import "UnityFramework/UnityFramework-Swift.h"

extern "C" {

void _init() {
    NSLog(@"Called _init from bridge!");
    
    [NativeAnalyticsModule.shared initialize];
}

/*
 * C# function:
 * _logEvent(
 *  string eventName,
 *  string[] paramKeys,
 *  string[] paramValues,
 *  string[] paramTypes,
 *  int paramCount
 * );
 */
void _logEvent(
               char *eventName,
               char **paramKeys,
               char **paramValues,
               char **paramTypes,
               int paramCount) {
    NSLog(@"Called _logEvent from bridge!");
    
    NSString *eventNameStr = [NSString stringWithUTF8String:eventName];
    NSMutableArray *paramKeysArray = [[NSMutableArray alloc] initWithCapacity:paramCount];
    NSMutableArray *paramValuesArray = [[NSMutableArray alloc] initWithCapacity:paramCount];
    NSMutableArray *paramTypesArray = [[NSMutableArray alloc] initWithCapacity:paramCount];
    
    for (int i = 0; i < paramCount; i++) {
        NSString *key = [NSString stringWithUTF8String:paramKeys[i]];
        NSString *value = [NSString stringWithUTF8String:paramValues[i]];
        NSString *type = [NSString stringWithUTF8String:paramTypes[i]];
        
        paramKeysArray[i] = key;
        paramValuesArray[i] = value;
        paramTypesArray[i] = type;
    }
    
    
    [NativeAnalyticsModule.shared logEventWithEventName:eventNameStr
                                              paramKeys:paramKeysArray
                                            paramValues:paramValuesArray
                                             paramTypes:paramTypesArray
                                             paramCount:paramCount];
}

}
