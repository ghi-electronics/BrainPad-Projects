// Copyright (c) GHI Electronics, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

servos.servo1.setAngle(110)
forever(function () {
    display.showString("Place ball and ", 2)
    display.showString("  press down", 4)
    display.showString("    button", 6)
    while (input.buttonDown.wasPressed()) {
        pause(20)
    }
    servos.servo1.setAngle(50)
    pause(200)
    for (let i = 0; i <= 60; i++) {
        servos.servo1.setAngle(50 + i)
        pause(14)
    }
})
