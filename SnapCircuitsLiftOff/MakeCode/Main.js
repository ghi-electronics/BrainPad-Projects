// Copyright (c) GHI Electronics, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

let count = 0
forever(function () {
    display.clear()
    display.showString("Press up button", 2)
    display.showString("   to start", 4)
    while (!(input.buttonUp.wasPressed())) {
        pause(25)
    }
    music.playSound(music.sounds(Sounds.JumpUp))
    pins.AN.digitalWrite(true)
    count = 10
    while (count >= 0) {
        display.clear()
        display.showValue(" Countdown", count, 3)
        count += -1
        music.playTone(262, music.beat(BeatFraction.Half))
        pause(500)
    }
    pins.AN.digitalWrite(false)
})
