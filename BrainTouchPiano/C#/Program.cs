// Copyright (c) GHI Electronics, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using GHIElectronics.TinyCLR.BrainPad;

namespace BrainTouchPiano {

    class Program {

        SplashScreen open = new SplashScreen();

        public void BrainPadSetup() {
            open.Splash("BrainPiano");
        }

        public void BrainPadLoop() {
            switch (Menu.Show(new string[] { "Cm Blues Scale", "C#m Blues Scale", "Dm Blues Scale", "D#m Blues Scale", "Em Blues Scale", "more..." })) {
                case 1:
                    keyC.Run();

                    break;
                case 2:
                    keyCSharp.Run();

                    break;
                case 3:
                    keyDm.Run();

                    break;
                case 4:
                    keyDSharp.Run();

                    break;
                case 5:
                    keyEm.Run();

                    break;
                case 6:
                        BrainPad.Display.Clear();
                        switch (Menu.Show(new string[] { "Fm Blues Scale", "F#m Blues Scale ", "Gm Blues Scale", "Am Blues Scale", "Bm Blues Scale", "back" })) {
                            case 1:
                                keyFm.Run();

                                break;
                            case 2:
                                keyFSharp.Run();

                                break;
                            case 3:
                                keyGm.Run();

                                break;
                            case 4:
                                keyAm.Run();

                                break;
                            case 5:
                                keyBm.Run();

                                break;
                            case 6:
                                break;
                        }
                        break;
            }
        }
    }
}
