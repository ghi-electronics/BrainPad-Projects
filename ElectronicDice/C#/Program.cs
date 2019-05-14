// Copyright (c) GHI Electronics, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;

namespace ElectronicDice {
    class Program {
        const int Dice_Base_X = 55;
        const int Dice_Base_Y = 10;

        static void Main() {
            var Rnd = new Random();
            while (true) {
                BrainPad.Display.DrawSmallText(10, 55, "Shake or Up to roll");
                BrainPad.Display.DrawRectangle(Dice_Base_X - 5, Dice_Base_Y - 5, 31, 31);

                for (var i = 0; i < 100; i += 5) {
                    ShowDice(Rnd.Next(6) + 1);
                    BrainPad.Buzzer.Beep();
                    BrainPad.Wait.Milliseconds(i);
                    BrainPad.Display.RefreshScreen();
                }
                while (BrainPad.Accelerometer.ReadX() < 100 && BrainPad.Buttons.IsUpPressed() == false) BrainPad.Wait.Minimum();
                BrainPad.Wait.Minimum();
            }
        }

        static void ShowDice(int num) {
            BrainPad.Display.ClearPart(Dice_Base_X + 3, Dice_Base_Y + 3, 16, 16);

            switch (num) {
                case 1:
                    BrainPad.Display.DrawCircle(Dice_Base_X + 10, Dice_Base_Y + 10, 2);
                    break;

                case 2:
                    BrainPad.Display.DrawCircle(Dice_Base_X + 5, Dice_Base_Y + 5, 2);
                    BrainPad.Display.DrawCircle(Dice_Base_X + 15, Dice_Base_Y + 15, 2);
                    break;

                case 3:
                    BrainPad.Display.DrawCircle(Dice_Base_X + 5, Dice_Base_Y + 5, 2);
                    BrainPad.Display.DrawCircle(Dice_Base_X + 10, Dice_Base_Y + 10, 2);
                    BrainPad.Display.DrawCircle(Dice_Base_X + 15, Dice_Base_Y + 15, 2);
                    break;

                case 4:
                    BrainPad.Display.DrawCircle(Dice_Base_X + 5, Dice_Base_Y + 5, 2);
                    BrainPad.Display.DrawCircle(Dice_Base_X + 5, Dice_Base_Y + 15, 2);
                    BrainPad.Display.DrawCircle(Dice_Base_X + 15, Dice_Base_Y + 15, 2);
                    BrainPad.Display.DrawCircle(Dice_Base_X + 15, Dice_Base_Y + 5, 2);
                    break;

                case 5:
                    BrainPad.Display.DrawCircle(Dice_Base_X + 5, Dice_Base_Y + 5, 2);
                    BrainPad.Display.DrawCircle(Dice_Base_X + 5, Dice_Base_Y + 15, 2);
                    BrainPad.Display.DrawCircle(Dice_Base_X + 15, Dice_Base_Y + 15, 2);
                    BrainPad.Display.DrawCircle(Dice_Base_X + 15, Dice_Base_Y + 5, 2);
                    BrainPad.Display.DrawCircle(Dice_Base_X + 10, Dice_Base_Y + 10, 2);
                    break;

                case 6:
                    BrainPad.Display.DrawCircle(Dice_Base_X + 5, Dice_Base_Y + 5, 2);
                    BrainPad.Display.DrawCircle(Dice_Base_X + 5, Dice_Base_Y + 10, 2);
                    BrainPad.Display.DrawCircle(Dice_Base_X + 5, Dice_Base_Y + 15, 2);
                    BrainPad.Display.DrawCircle(Dice_Base_X + 15, Dice_Base_Y + 5, 2);
                    BrainPad.Display.DrawCircle(Dice_Base_X + 15, Dice_Base_Y + 10, 2);
                    BrainPad.Display.DrawCircle(Dice_Base_X + 15, Dice_Base_Y + 15, 2);
                    break;
            }
        }
    }
}
