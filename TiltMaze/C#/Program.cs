// Copyright (c) GHI Electronics, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

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
                    BrainPad.Display.Clear();

                    BrainPad.Display.RefreshScreen();

                    TiltMazeOne.Run();
                    break;
                case 2:
                    BrainPad.Display.Clear();

                    BrainPad.Display.RefreshScreen();

                    TiltMazeTwo.Run();
                    break;
                case 3:
                    BrainPad.Display.Clear();

                    BrainPad.Display.RefreshScreen();

                    TiltMazeThree.Run();
                    break;
                case 4:
                    BrainPad.Display.Clear();

                    BrainPad.Display.RefreshScreen();

                    TiltMazeFour.Run();
                    break;
            }
        }
    }
}



