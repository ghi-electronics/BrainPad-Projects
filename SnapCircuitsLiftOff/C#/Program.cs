// Copyright (c) GHI Electronics, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using GHIElectronics.TinyCLR.Devices.Gpio;

namespace SnapCircuitsLiftOff {
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
