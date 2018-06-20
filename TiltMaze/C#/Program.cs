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

namespace TiltMaze {
    class Program {

        SplashScreen open = new SplashScreen();

        public void BrainPadSetup() {
            open.Splash("Tilty Maze");
        }

        public void BrainPadLoop() {
            //Put your program code here. It runs repeatedly after the BrainPad starts up.

            switch (Menu.Show(new string[] { "Tilt Beginner", "Tilt Expert", "Button Beginner", "Button Expert" })) {
                case 1:
                    BrainPad.Display.ClearScreen();

                    BrainPad.Display.ShowOnScreen();

                    TiltMazeOne.Run();
                    break;
                case 2:
                    BrainPad.Display.ClearScreen();

                    BrainPad.Display.ShowOnScreen();

                    TiltMazeTwo.Run();
                    break;
                case 3:
                    BrainPad.Display.ClearScreen();

                    BrainPad.Display.ShowOnScreen();

                    TiltMazeThree.Run();
                    break;
                case 4:
                    BrainPad.Display.ClearScreen();

                    BrainPad.Display.ShowOnScreen();

                    TiltMazeFour.Run();
                    break;
            }
        }
    }
}



