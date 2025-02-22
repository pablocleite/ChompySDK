#import <Foundation/Foundation.h>
//#import "Unity-iPhone-swift.h"

extern "C" {
void _init() {
    NSLog(@"Called _init from bridge!");
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
}
}
