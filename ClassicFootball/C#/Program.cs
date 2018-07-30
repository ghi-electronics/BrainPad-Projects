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
                    BrainPad.Display.ClearScreen();

                    BrainPad.Display.ShowOnScreen();

                    Football.Run(true);

                    break;
                case 2:
                    BrainPad.Display.ClearScreen();

                    BrainPad.Display.ShowOnScreen();

                    Football.Run(false);

                    break;
            }
        }
    }
}

