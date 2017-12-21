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

using System;
using System.Threading;
using GHIElectronics.TinyCLR.Pins;
using GHIElectronics.TinyCLR.Devices.I2c;
using GHIElectronics.TinyCLR.Devices.Gpio;
using GHIElectronics.TinyCLR.BrainPad;

namespace BrainRadio {
    class Program {
        Click.Radio.RadioFM1 radio = new Click.Radio.RadioFM1();

        SplashScreen open = new SplashScreen();

        double currentStation = 101.1;
        double selectedStation = 101.1;
        int volume = 0;
        int volumeGraph = 0;

        public void BrainPadSetup() {

            open.Splash();

            radio.Channel = currentStation;
            radio.Volume = volume;
            
            BrainPad.Display.ClearScreen();

            BrainPad.Display.DrawSmallText(20, 3, "BrainPad Radio");

            BrainPad.Display.DrawText(30, 25, currentStation.ToString("F1"));

            BrainPad.Display.DrawSmallText(2, 55, "Volume:");

            BrainPad.Display.ShowOnScreen();
        }

        public void BrainPadLoop() {
            if (BrainPad.Buttons.IsUpPressed()) {
                currentStation = currentStation + 0.2;

                BrainPad.Display.ClearPartOfScreen(13, 18, 128, 16);

                BrainPad.Display.DrawText(30, 25, currentStation.ToString("F1"));

                BrainPad.Display.ShowOnScreen();
            }
            if (BrainPad.Buttons.IsDownPressed()) {
                currentStation = currentStation - 0.2;

                BrainPad.Display.ClearPartOfScreen(13, 18, 128, 16);

                BrainPad.Display.DrawText(30, 25, currentStation.ToString("F1"));

                BrainPad.Display.ShowOnScreen();
            }
            if (BrainPad.Buttons.IsRightPressed()) {
                if (volume >= 15) {
                    volume = 15;
                }
                else {
                    volume = volume + 1;
                    volumeGraph = volumeGraph + 5;

                    BrainPad.Display.ClearPartOfScreen(2, 55, 128, 8);

                    BrainPad.Display.DrawSmallText(2, 55, "Volume:");

                    for (int i = 55; i < 62; i++)
                        BrainPad.Display.DrawLine(44, i, 44 + volumeGraph, i);

                    BrainPad.Display.ShowOnScreen();
                }
            }
            if (BrainPad.Buttons.IsLeftPressed()) {
                if (volume <= 0) {
                    volume = 0;
                }
                else {
                    volume = volume - 1;
                    volumeGraph = volumeGraph - 5;

                    BrainPad.Display.ClearPartOfScreen(2, 55, 128, 8);

                    BrainPad.Display.DrawSmallText(2, 55, "Volume:");

                    for (int i = 55; i < 62; i++)
                        BrainPad.Display.DrawLine(44, i, 44 + volumeGraph, i);

                    BrainPad.Display.ShowOnScreen();
                }
            }
            if (currentStation == selectedStation) {
            //Does nothing if they match, so radio channel changes only if the user changes the channel. Prevents clicking everytime program loops
            }
            else {
                radio.Channel = currentStation;
                selectedStation = currentStation;
            }
            radio.Volume = volume;
        }
    }
}

