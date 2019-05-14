// Copyright (c) GHI Electronics, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace TiltEtchASketch {
    class Program {
        static void Main() {
            BrainPad.Display.DrawSmallText(0, 57, "Tilt: Draw - D: Erase");
            BrainPad.Display.DrawLine(0, 55, 127, 55);
            int x = 64, y = 32;
            const double ACC_TOLERANCE = 20;

            while (true) {
                if (BrainPad.Accelerometer.ReadY() > -ACC_TOLERANCE) y--;
                if (BrainPad.Accelerometer.ReadY() < ACC_TOLERANCE) y++;
                if (BrainPad.Accelerometer.ReadX() > ACC_TOLERANCE) x++;
                if (BrainPad.Accelerometer.ReadX() < -ACC_TOLERANCE) x--;

                if (x < 0) x = 0;
                if (y < 0) y = 0;
                if (x > 127) x = 127;
                if (y > 50) y = 50;

                BrainPad.Display.ClearPoint(x, y);
                BrainPad.Display.RefreshScreen();

                if (BrainPad.Buttons.IsDownPressed())
                    BrainPad.Display.ClearPart(0, 0, 128, 55);

                BrainPad.Wait.Minimum();

                BrainPad.Display.DrawPoint(x, y);
                BrainPad.Display.RefreshScreen();
            }
        }
    }
}
