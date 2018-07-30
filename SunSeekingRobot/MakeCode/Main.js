// Copyright (c) GHI Electronics, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

let Direction = 0
input.onLightConditionChanged(LightCondition.Dark, function () {
    if (Direction == 0) {
        pins.SERVO2.servoWrite(90)
        Direction = 1
    } else {
        pins.SERVO1.servoWrite(90)
        Direction = 0
    }
})
input.onLightConditionChanged(LightCondition.Bright, function () {
    pins.SERVO1.servoWrite(180)
    pins.SERVO2.servoWrite(0)
})
input.setLightThreshold(LightCondition.Dark, 250)
pins.SERVO1.servoWrite(180)
pins.SERVO2.servoWrite(0)
