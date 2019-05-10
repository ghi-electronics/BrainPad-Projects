// Copyright (c) GHI Electronics, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

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
            
            BrainPad.Display.Clear();

            BrainPad.Display.DrawSmallText(20, 3, "BrainPad Radio");

            BrainPad.Display.DrawText(30, 25, currentStation.ToString("F1"));

            BrainPad.Display.DrawSmallText(2, 55, "Volume:");

            BrainPad.Display.RefreshScreen();
        }

        public void BrainPadLoop() {
            if (BrainPad.Buttons.IsUpPressed()) {
                currentStation = currentStation + 0.2;

                BrainPad.Display.ClearPart(13, 18, 128, 16);

                BrainPad.Display.DrawText(30, 25, currentStation.ToString("F1"));

                BrainPad.Display.RefreshScreen();
            }
            if (BrainPad.Buttons.IsDownPressed()) {
                currentStation = currentStation - 0.2;

                BrainPad.Display.ClearPart(13, 18, 128, 16);

                BrainPad.Display.DrawText(30, 25, currentStation.ToString("F1"));

                BrainPad.Display.RefreshScreen();
            }
            if (BrainPad.Buttons.IsRightPressed()) {
                if (volume >= 15) {
                    volume = 15;
                }
                else {
                    volume = volume + 1;
                    volumeGraph = volumeGraph + 5;

                    BrainPad.Display.ClearPart(2, 55, 128, 8);

                    BrainPad.Display.DrawSmallText(2, 55, "Volume:");

                    for (int i = 55; i < 62; i++)
                        BrainPad.Display.DrawLine(44, i, 44 + volumeGraph, i);

                    BrainPad.Display.RefreshScreen();
                }
            }
            if (BrainPad.Buttons.IsLeftPressed()) {
                if (volume <= 0) {
                    volume = 0;
                }
                else {
                    volume = volume - 1;
                    volumeGraph = volumeGraph - 5;

                    BrainPad.Display.ClearPart(2, 55, 128, 8);

                    BrainPad.Display.DrawSmallText(2, 55, "Volume:");

                    for (int i = 55; i < 62; i++)
                        BrainPad.Display.DrawLine(44, i, 44 + volumeGraph, i);

                    BrainPad.Display.RefreshScreen();
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

