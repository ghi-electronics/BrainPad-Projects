# Snap Circuits Lift-Off!
---
![Snap Circuits](images/snap-circuits.gif)

**Difficulty: Easy.**

**Objective: Simple motor control.**

**Note: This project requires an Elenco Snap Circuits kit that includes the fan blade.**

<iframe width="560" height="315" src="https://www.youtube.com/embed/8tVkJDCwG3w?rel=0" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>

## How it Works

After pressing the up button on the BrainPad, the motor starts spinning and turns the fan blade (propeller). The BrainPad display starts counting down and at the end of the countdown the motor stops which releases the fan blade launching it into the air.

## The Code

### Microsoft MakeCode

Click [here](https://makecode.com/_gKkcjM3KbHce) to go directly to the program on Microsoft MakeCode. There is a tutorial for building the project [here](https://makecode.brainpad.com/projects/snap-circuits). You can also copy and paste the following JavaScript code into Microsoft MakeCode's JavaScript editor.

```
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

```

Microsoft MakeCode block program:

![Lift-off block program](images/lift-off-blocks.png)

### C# Code

This C# program actually does a little more than the Microsoft MakeCode program above.

> [!Tip]
> Make sure the namespace in your program matches your project's namespace.  Your project's namespace can be found in the BrainPad Helper file by clicking on the BrainPad1.cs tab.  [**More Info**](../go-beyond/csharp/intro.md#a-few-words-about-namespaces).

```
using GHIElectronics.TinyCLR.Devices.Gpio;

namespace ModifyThis {
    class Program {
        static GpioPin MotorControlPin = GpioController.GetDefault().OpenPin(GHIElectronics.TinyCLR.Pins.BrainPad.Expansion.GpioPin.An);

        static void Main() {
            MotorControlPin.SetDriveMode(GpioPinDriveMode.Output);

            while (true) {
                BrainPad.Display.Clear();
                BrainPad.Display.DrawText(38, 0, "Press");
                BrainPad.Display.DrawText(20, 20, "Up Button");
                BrainPad.Display.DrawText(17, 40, "to Start");
                BrainPad.Display.RefreshScreen();

                while (!BrainPad.Buttons.IsUpPressed()) BrainPad.Wait.Milliseconds(25);

                BrainPad.Display.Clear();
                BrainPad.Display.DrawText(12, 15, "Initiate");
                BrainPad.Display.DrawText(32, 35, "Motor");
                BrainPad.Display.RefreshScreen();
                BrainPad.LightBulb.TurnGreen();
                BrainPad.Wait.Seconds(2);
                BrainPad.LightBulb.TurnBlue();

                MotorControlPin.Write(GpioPinValue.High);

                BrainPad.Display.Clear();
                BrainPad.Display.DrawText(36, 15, "Begin");
                BrainPad.Display.DrawText(13, 35, "Countdown");
                BrainPad.Display.RefreshScreen();
                BrainPad.Wait.Seconds(2);

                for (int i = 10; i > 0; i--) {
                    BrainPad.Display.Clear();

                    if (i == 10) {
                        BrainPad.Display.DrawScaledText(20, 6, "" + i, 7, 7);
                        BrainPad.Display.RefreshScreen();
                    }
                    else {
                        BrainPad.Display.DrawScaledText(45, 6, "" + i, 7, 7);
                        BrainPad.Display.RefreshScreen();
                    }

                    BrainPad.Buzzer.StartBuzzing(50);
                    BrainPad.LightBulb.TurnBlue();
                    BrainPad.Wait.Seconds(.25);
                    BrainPad.Buzzer.StopBuzzing();
                    BrainPad.LightBulb.TurnOff();
                }

                BrainPad.LightBulb.TurnGreen();
                BrainPad.Display.DrawText(30, 24, "Launch");
                BrainPad.Display.RefreshScreen();

                MotorControlPin.Write(GpioPinValue.Low);
                BrainPad.Buzzer.StartBuzzing(300);
                BrainPad.Wait.Seconds(1);
                BrainPad.Buzzer.StopBuzzing();
                BrainPad.Wait.Seconds(4);
                BrainPad.LightBulb.TurnOff();
            }
        }
    }
}
```

## Snap Circuits Set Up

To build this circuit just follow the diagram below.

![Snap Circuits Lift-Off](images/snap-circuits-lift-off.gif)

