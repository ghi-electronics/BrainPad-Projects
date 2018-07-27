// Copyright (c) GHI Electronics, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Pong {
    class Program {
        static void Main() {
            double BallX = 10, BallY = 10, BallDX = 2.3, BallDY = 2.8;
            int ScoreL = 0, ScoreR = 0;
            int PlayerPos = 30;
            int CompPos = 30;

            BrainPad.Display.DrawRectangle(0, 0, 128, 64);

            while (true) {
                // The Ball
                BrainPad.Display.ClearPart((int)BallX, (int)BallY, 4, 4);
                BallX += BallDX;
                BallY += BallDY;

                if (BallX < 10) {
                    BallDX *= -1;

                    if (BallY >= CompPos - 1 && BallY <= CompPos + 12) {
                        // hit back
                        BrainPad.Buzzer.Beep();
                    }
                    else {
                        //win
                        for (int i = 0; i < 3; i++) {
                            for (int f = 1000; f < 6000; f += 500) {
                                BrainPad.Buzzer.StartBuzzing(f);
                                BrainPad.Wait.Minimum();
                            }
                        }
                        ScoreR++;
                        BrainPad.Buzzer.StopBuzzing();
                        BrainPad.Wait.Seconds(0.5);
                    }
                }

                if (BallX > 115) {
                    BallDX *= -1;

                    if (BallY >= PlayerPos - 1 && BallY <= PlayerPos + 12) {
                        // hit back
                        BrainPad.Buzzer.Beep();
                    }
                    else {
                        // Loss
                        for (int f = 2000; f > 200; f -= 200) {
                            BrainPad.Buzzer.StartBuzzing(f);
                            BrainPad.Wait.Minimum();
                        }
                        ScoreL++;
                        BrainPad.Wait.Seconds(0.5);
                        BrainPad.Buzzer.StopBuzzing();
                    }
                }

                if (BallY < 5 || BallY > 55) {
                    BallDY *= -1;
                    BrainPad.Buzzer.Beep();
                }

                BrainPad.Display.DrawFilledRectangle((int)BallX, (int)BallY, 4, 4);
                // The Field
                for (var y = 0; y < 64; y += 10) {
                    // net
                    BrainPad.Display.DrawLine(64, y, 64, y + 5);
                }

                // Player
                BrainPad.Display.ClearPart(120, PlayerPos, 2, 10);
                if (BrainPad.Buttons.IsUpPressed()) PlayerPos -= 4;
                if (BrainPad.Buttons.IsDownPressed()) PlayerPos += 4;
                if (PlayerPos < 5) PlayerPos = 5;
                if (PlayerPos > 50) PlayerPos = 50;
                BrainPad.Display.DrawFilledRectangle(120, PlayerPos, 2, 10);

                // Computer
                BrainPad.Display.ClearPart(10, CompPos, 2, 10);
                if (BallY > CompPos + 10) CompPos += 2;
                if (BallY < CompPos) CompPos -= 2;
                if (CompPos < 5) CompPos = 5;
                if (CompPos > 50) CompPos = 50;
                BrainPad.Display.DrawFilledRectangle(10, CompPos, 2, 10);

                // Score
                BrainPad.Display.DrawSmallNumber(50, 5, ScoreL);
                BrainPad.Display.DrawSmallNumber(74, 5, ScoreR);

                if (ScoreL >= 5) {
                    BrainPad.Display.DrawScaledText(0, 40, "You Lose!", 3, 1);
                    BrainPad.Display.RefreshScreen();
                    BrainPad.Wait.Seconds(-1);
                }

                if (ScoreR >= 5) {
                    BrainPad.Display.DrawScaledText(0, 40, "You Win!", 3, 1);
                    BrainPad.Display.RefreshScreen();
                    while (true) BrainPad.Wait.Seconds(1);
                }

                BrainPad.Display.RefreshScreen();
                BrainPad.Wait.Minimum();
            }
        }
    }
}