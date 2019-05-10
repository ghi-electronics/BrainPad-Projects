// Copyright (c) GHI Electronics, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using GHIElectronics.TinyCLR.BrainPad;

namespace ClassicFootball {

    class Program {

        SplashScreen open = new SplashScreen();

        public void BrainPadSetup() {
            open.Splash(" Football");
        }

        public void BrainPadLoop() {
            
            switch (Menu.Show(new string[] { "Football", "No Sound" })) {
                case 1:
                    BrainPad.Display.Clear();

                    BrainPad.Display.RefreshScreen();

                    Football.Run(true);

                    break;
                case 2:
                    BrainPad.Display.Clear();

                    BrainPad.Display.RefreshScreen();

                    Football.Run(false);

                    break;
            }
        }
    }

    public static class Ext
    {
        public static void ClearPart(this GHIElectronics.TinyCLR.BrainPad.Display self, int x, int y, int width, int height)
        {
            if (x == 0 && y == 0 && width == BrainPad.Display.Width && height == BrainPad.Display.Height)
                self.Clear();
            for (var lx = x; lx < width + x; lx++)
                for (var ly = y; ly < height + y; ly++)
                    self.ClearPoint(lx, ly);
        }
    }
}

