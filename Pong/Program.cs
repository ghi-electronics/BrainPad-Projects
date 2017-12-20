using GHIElectronics.TinyCLR.BrainPad;
using System.Runtime.CompilerServices;
using System;

namespace Pong {

    class Program {
        SplashScreen open = new SplashScreen();

        public void BrainPadSetup() {
            open.Splash(" BrainPong");
        }

        public void BrainPadLoop() {
            switch (Menu.Show(new string[] {"One Player", "Two Players","Tilty Pong"})) {
                case 1:
                    Pong1Player.Run();
                    break;
                case 2:
                    Pong2Player.Run();
                    break;
                case 3:
                    TiltyPong.Run();
                    break;
            }
        }
    }
}