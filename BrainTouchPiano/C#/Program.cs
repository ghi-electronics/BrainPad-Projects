// Copyright GHI Electronics, LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

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
                        BrainPad.Display.ClearScreen();
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
