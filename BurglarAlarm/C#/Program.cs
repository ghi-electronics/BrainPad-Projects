// Copyright (c) GHI Electronics, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;

namespace BurglarAlarm {
    class Program {
        static void Main() {
            BrainPad.Display.DrawText(16, 0, "BrainPad");
            BrainPad.Display.DrawText(34, 18, "Alarm");
            BrainPad.Display.DrawSmallText(0, 37, "To arm alarm place on");
            BrainPad.Display.DrawSmallText(0, 47, "surface and press the");
            BrainPad.Display.DrawSmallText(0, 57, "left button.");
            BrainPad.Display.RefreshScreen();

            while (!BrainPad.Buttons.IsLeftPressed())
                BrainPad.Wait.Milliseconds(20);

            for (var CountDown = 10; CountDown > 0; CountDown -= 1) {
                BrainPad.Display.Clear();
                BrainPad.Display.DrawText(10, 0, "Arming...");
                BrainPad.Display.DrawNumber(59, 30, CountDown);
                BrainPad.Display.RefreshScreen();
                BrainPad.Wait.Seconds(0.5);
            }

            double x, y, z, sensitivity;
            x = BrainPad.Accelerometer.ReadX();
            y = BrainPad.Accelerometer.ReadY();
            z = BrainPad.Accelerometer.ReadZ();
            sensitivity = 0.035;

            BrainPad.Display.Clear();
            BrainPad.Display.DrawText(35, 22, "Armed");
            BrainPad.Display.RefreshScreen();

            while ((Math.Abs(BrainPad.Accelerometer.ReadX() - x) < sensitivity & Math.Abs(BrainPad.Accelerometer.ReadY() - y) < sensitivity & Math.Abs(BrainPad.Accelerometer.ReadZ() - z) < sensitivity))
                BrainPad.Wait.Milliseconds(20);

            BrainPad.Display.Clear();
            BrainPad.Display.DrawText(35, 22, "ALARM");
            BrainPad.Display.RefreshScreen();

            while (true) {
                for (var frequency = 1200; frequency <= 3200; frequency += 160) {
                    BrainPad.Buzzer.StartBuzzing(frequency);
                    BrainPad.Wait.Milliseconds(8);

                    LightColorChanger();
                }

                for (var frequency = 3200; frequency >= 1200; frequency += -160) {
                    BrainPad.Buzzer.StartBuzzing(frequency);
                    BrainPad.Wait.Milliseconds(8);

                    LightColorChanger();
                }
            }
        }

        public static void LightColorChanger() {
            var lightTimer = 0;

            lightTimer += 1;

            if (lightTimer == 15)
                BrainPad.LightBulb.TurnBlue();

            if (lightTimer == 30) {
                BrainPad.LightBulb.TurnRed();
                lightTimer = 0;
            }
        }
    }
}
