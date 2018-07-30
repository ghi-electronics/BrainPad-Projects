// Copyright (c) GHI Electronics, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace SpaceForceRobot {
    class Program {
        static void Main() {
            BrainPad.ServoMotors.ServoOne.ConfigureAsPositional(false);
            BrainPad.ServoMotors.ServoOne.ConfigurePulseParameters(0.5, 2.5);

            while (true) {
                BrainPad.ServoMotors.ServoOne.Set(110);
                BrainPad.Display.Clear();
                BrainPad.Display.DrawSmallText(5, 10, "Place ball and press");
                BrainPad.Display.DrawSmallText(30, 25, "down button");
                BrainPad.Display.RefreshScreen();

                while (!BrainPad.Buttons.IsDownPressed()) {
                    BrainPad.Wait.Milliseconds(20);
                }

                BrainPad.ServoMotors.ServoOne.Set(50);
                BrainPad.Wait.Milliseconds(200);

                for (int i = 50; i < 111; i++) {
                    BrainPad.ServoMotors.ServoOne.Set(i);
                    BrainPad.Wait.Milliseconds(14);
                }
            }
        }
    }
}
