// Copyright (c) GHI Electronics, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace EtchASketch {
    class Program {
        static void Main() {
            BrainPad.Display.DrawSmallText(8, 57, "Use Buttons to Draw");
            BrainPad.Display.DrawLine(0, 55, 127, 55);
            int x = 64, y = 32;

            while (true) {
                if (BrainPad.Buttons.IsDownPressed()) y++;
                if (BrainPad.Buttons.IsUpPressed()) y--;
                if (BrainPad.Buttons.IsLeftPressed()) x--;
                if (BrainPad.Buttons.IsRightPressed()) x++;

                if (x < 0) x = 0;
                if (y < 0) y = 0;
                if (x > 127) x = 127;
                if (y > 50) y = 50;

                BrainPad.Display.ClearPoint(x, y);
                BrainPad.Display.RefreshScreen();
                BrainPad.Wait.Minimum();

                BrainPad.Display.DrawPoint(x, y);
                BrainPad.Display.RefreshScreen();
            }
        }
    }
}
