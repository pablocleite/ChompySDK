#import <Foundation/Foundation.h>
//#import "Unity-iPhone-swift.h"

extern "C" {
    void _init() {
        NSLog(@"Called _init from bridge!");
    }
}
