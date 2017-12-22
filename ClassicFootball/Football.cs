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
using System.Collections;
using System.Text;
using System.Threading;

namespace ClassicFootball {
    class Football {

        static public void Run(bool sound) {

            int player1Score = 0;
            int player2Score = 0;
            int down = 1;
            int yardLine = 20;
            int YTG = 10;
            int milliseconds = 0;
            int seconds = 0;
            int minutes = 5;
            bool pastMidField = false;
            //Which player has the ball
            int possession = 1; 

            Player player = new Player(13, 42);

            DefensePlayer def1 = new DefensePlayer(46, 32);

            DefensePlayer def2 = new DefensePlayer(46, 42);

            DefensePlayer def3 = new DefensePlayer(46, 52);

            DefensePlayer def4 = new DefensePlayer(68, 42);

            DefensePlayer def5 = new DefensePlayer(101, 42);

            drawField();

            drawScoreBoard();

            BrainPad.Display.DrawCircle(13, player.getY(), 2);

            if (sound) {
                touchDownSong();
            }

            //The offset is used in Clear player circle from the radius center.
            int offset = 2;

            while (true) {

                if (BrainPad.Buttons.IsUpPressed()) {
                    BrainPad.Display.ClearPartOfScreen(player.getX() - offset, player.getY() - offset, 6, 5);

                    BrainPad.Display.ShowOnScreen();

                    player.setY(player.getY() - 10);

                    if (player.getY() <= 32) {
                        player.setY(32);
                    }

                    drawPlayerPosition();
                }

                if (BrainPad.Buttons.IsDownPressed()) {
                    BrainPad.Display.ClearPartOfScreen(player.getX() - offset, player.getY() - offset, 6, 5);

                    BrainPad.Display.ShowOnScreen();

                    player.setY(player.getY() + 10);

                    if (player.getY() >= 52) {
                        player.setY(52);
                    }

                    drawPlayerPosition();
                }

                if (BrainPad.Buttons.IsRightPressed()) {
                    BrainPad.Display.ClearPartOfScreen(player.getX() - offset, player.getY() - offset, 6, 5);

                    player.setX(player.getX() + 11);

                    if (pastMidField) {
                        yardLine = yardLine - 1;

                        drawPlayerPosition();

                        checkForTouchDown();
                    }
                    else {
                        yardLine = yardLine + 1;

                        drawPlayerPosition();
                    }

                    YTG = YTG - 1;
                    if (YTG <= 0) {
                        YTG = 0;
                    }
                    drawScoreBoard();

                    //Returns the Player to the otherside of the of the field
                    if (player.getX() >= 110) {
                        BrainPad.Display.ClearPartOfScreen(player.getX() - offset, player.getY() - offset, 6, 5);

                        BrainPad.Display.ShowOnScreen();

                        player.setX(13);

                        drawPlayerPosition();
                    }
                }

                if (BrainPad.Buttons.IsLeftPressed()) {
                    BrainPad.Display.ClearPartOfScreen(player.getX() - offset, player.getY() - offset, 6, 5);

                    BrainPad.Display.ShowOnScreen();

                    player.setX(player.getX() - 11);

                    if (pastMidField) {
                        yardLine = yardLine + 1;

                        drawPlayerPosition();

                        checkForTouchDown();
                    }
                    else {
                        yardLine = yardLine - 1;

                        drawPlayerPosition();
                    }

                    YTG = YTG + 1;

                    if (YTG <= 0) {

                        YTG = 0;
                    }

                    drawScoreBoard();

                    if (player.getX() <= 13) {
                        yardLine = yardLine + 1;
                        YTG = YTG + 1;

                        player.setX(13);
                    }

                    drawPlayerPosition();
                }
                isPlayerTackled();

                drawDefensePositions();

                isPlayerTackled();

                drawGameClock();

                milliseconds++;
            }

            void drawPlayerPosition()
            {
                BrainPad.Display.DrawCircle(player.getX(), player.getY(), 2);

                BrainPad.Display.ShowOnScreen();
            }

            void drawDefensePositions()
            {
                BrainPad.Wait.Milliseconds(10);

                Random rndDefensePlayer = new Random();

                Random defenseMove = new Random();


                if (sound) {
                    BrainPad.Buzzer.StartBuzzing(36.71);
                }

                int DefensePlayer = rndDefensePlayer.Next(5);

                int defMove = defenseMove.Next(4); // 1 = UP. 2 = RIGHT, 3 = DOWN, 4 = LEFT

                switch (DefensePlayer) {
                    case 0:

                        if (defMove == 0) {

                            def1.setY(def1.getY() - 10);

                            if (isSpaceOpen()) {
                                BrainPad.Display.ClearPartOfScreen(def1.getX(), def1.getY() + 10, 4, 2);

                                BrainPad.Display.ShowOnScreen();

                                if (def1.getY() <= 32) {
                                    def1.setY(32);
                                }
                            }
                            else {
                                def1.setY(def1.getY() + 10);

                                break;
                            }
                        }
                        else if (defMove == 1) {

                            def1.setX(def1.getX() + 11);

                            if (isSpaceOpen()) {
                                BrainPad.Display.ClearPartOfScreen(def1.getX() - 11, def1.getY(), 4, 2);

                                BrainPad.Display.ShowOnScreen();

                                if (def1.getX() >= 112) {
                                    def1.setX(112);
                                }
                            }
                            else {
                                def1.setX(def1.getX() - 11);
                                break;
                            }
                        }
                        else if (defMove == 2) {

                            def1.setY(def1.getY() + 10);

                            if (isSpaceOpen()) {
                                BrainPad.Display.ClearPartOfScreen(def1.getX(), def1.getY() - 10, 4, 2);

                                BrainPad.Display.ShowOnScreen();

                                if (def1.getY() >= 52) {
                                    def1.setY(52);
                                }
                            }
                            else {
                                def1.setY(def1.getY() - 10);
                                break;
                            }
                        }
                        else if (defMove == 3) {

                            def1.setX(def1.getX() - 11);

                            if (isSpaceOpen()) {
                                BrainPad.Display.ClearPartOfScreen(def1.getX() + 11, def1.getY(), 4, 2);

                                BrainPad.Display.ShowOnScreen();

                                if (def1.getX() <= 13) {
                                    def1.setX(13);
                                }
                            }
                            else {
                                def1.setX(def1.getX() + 11);
                                break;
                            }
                        }
                        break;

                    case 1:
                        if (defMove == 0) {

                            def2.setY(def2.getY() - 10);

                            if (isSpaceOpen()) {
                                BrainPad.Display.ClearPartOfScreen(def2.getX(), def2.getY() + 10, 4, 2);

                                BrainPad.Display.ShowOnScreen();

                                if (def2.getY() <= 32) {
                                    def2.setY(32);
                                }
                            }
                            else {
                                def2.setY(def2.getY() + 10);

                                break;
                            }
                        }
                        else if (defMove == 1) {

                            def2.setX(def2.getX() + 11);

                            if (isSpaceOpen()) {
                                BrainPad.Display.ClearPartOfScreen(def2.getX() - 11, def2.getY(), 4, 2);

                                BrainPad.Display.ShowOnScreen();

                                if (def2.getX() >= 112) {
                                    def2.setX(112);
                                }
                            }
                            else {
                                def2.setX(def2.getX() - 11);

                                break;
                            }
                        }
                        else if (defMove == 2) {

                            def2.setY(def2.getY() + 10);

                            if (isSpaceOpen()) {
                                BrainPad.Display.ClearPartOfScreen(def2.getX(), def2.getY() - 10, 4, 2);

                                BrainPad.Display.ShowOnScreen();

                                if (def2.getY() >= 52) {
                                    def2.setY(52);
                                }
                            }
                            else {
                                def2.setY(def2.getY() - 10);

                                break;
                            }
                        }
                        else if (defMove == 3) {

                            def2.setX(def2.getX() - 11);

                            if (isSpaceOpen()) {
                                BrainPad.Display.ClearPartOfScreen(def2.getX() + 11, def2.getY(), 4, 2);

                                BrainPad.Display.ShowOnScreen();

                                if (def2.getX() <= 13) {
                                    def2.setX(13);
                                }
                            }
                            else {
                                def2.setX(def2.getX() + 11);
                                break;
                            }
                        }
                        break;

                    case 2:
                        if (defMove == 0) {

                            def3.setY(def3.getY() - 10);

                            if (isSpaceOpen()) {
                                BrainPad.Display.ClearPartOfScreen(def3.getX(), def3.getY() + 10, 4, 2);

                                BrainPad.Display.ShowOnScreen();

                                if (def3.getY() <= 32) {
                                    def3.setY(32);
                                }
                            }
                            else {
                                def3.setY(def3.getY() + 10);

                                break;
                            }
                        }
                        else if (defMove == 1) {

                            def3.setX(def3.getX() + 11);

                            if (isSpaceOpen()) {
                                BrainPad.Display.ClearPartOfScreen(def3.getX() - 11, def3.getY(), 4, 2);

                                BrainPad.Display.ShowOnScreen();

                                if (def3.getX() >= 112) {
                                    def3.setX(112);
                                }
                            }
                            else {
                                def3.setX(def3.getX() - 11);

                                break;
                            }
                        }
                        else if (defMove == 2) {

                            def3.setY(def3.getY() + 10);

                            if (isSpaceOpen()) {
                                BrainPad.Display.ClearPartOfScreen(def3.getX(), def3.getY() - 10, 4, 2);

                                BrainPad.Display.ShowOnScreen();

                                if (def3.getY() >= 52) {
                                    def3.setY(52);

                                }
                            }
                            else {
                                def3.setY(def3.getY() - 10);

                                break;
                            }
                        }
                        else if (defMove == 3) {

                            def3.setX(def3.getX() - 11);

                            if (isSpaceOpen()) {
                                BrainPad.Display.ClearPartOfScreen(def3.getX() + 11, def3.getY(), 4, 2);

                                BrainPad.Display.ShowOnScreen();

                                if (def3.getX() <= 13) {
                                    def3.setX(13);
                                }
                            }
                            else {
                                def3.setX(def3.getX() + 11);

                                break;
                            }
                        }
                        break;
                    case 3:
                        if (defMove == 0) {

                            def4.setY(def4.getY() - 10);

                            if (isSpaceOpen()) {
                                BrainPad.Display.ClearPartOfScreen(def4.getX(), def4.getY() + 10, 4, 2);

                                BrainPad.Display.ShowOnScreen();

                                if (def4.getY() <= 32) {
                                    def4.setY(32);
                                }
                            }
                            else {
                                def4.setY(def4.getY() + 10);

                                break;
                            }
                        }
                        else if (defMove == 1) {

                            def4.setX(def4.getX() + 11);

                            if (isSpaceOpen()) {
                                BrainPad.Display.ClearPartOfScreen(def4.getX() - 11, def4.getY(), 4, 2);

                                BrainPad.Display.ShowOnScreen();

                                if (def4.getX() >= 112) {
                                    def4.setX(112);
                                }
                            }
                            else {
                                def4.setX(def4.getX() - 11);

                                break;
                            }
                        }
                        else if (defMove == 2) {

                            def4.setY(def4.getY() + 10);

                            if (isSpaceOpen()) {
                                BrainPad.Display.ClearPartOfScreen(def4.getX(), def4.getY() - 10, 4, 2);

                                BrainPad.Display.ShowOnScreen();

                                if (def4.getY() >= 52) {
                                    def4.setY(52);

                                }
                            }
                            else {
                                def4.setY(def4.getY() - 10);

                                break;
                            }
                        }
                        else if (defMove == 3) {

                            def4.setX(def4.getX() - 11);

                            if (isSpaceOpen()) {
                                BrainPad.Display.ClearPartOfScreen(def4.getX() + 11, def4.getY(), 4, 2);

                                BrainPad.Display.ShowOnScreen();

                                if (def4.getX() <= 13) {
                                    def4.setX(13);
                                }
                            }
                            else {
                                def4.setX(def4.getX() + 11);

                                break;
                            }
                        }
                        break;
                    case 4:
                        if (defMove == 0) {

                            def5.setY(def5.getY() - 10);

                            if (isSpaceOpen()) {
                                BrainPad.Display.ClearPartOfScreen(def5.getX(), def5.getY() + 10, 4, 2);

                                BrainPad.Display.ShowOnScreen();

                                if (def5.getY() <= 32) {
                                    def5.setY(32);
                                }
                            }
                            else {
                                def5.setY(def5.getY() + 10);

                                break;
                            }
                        }
                        else if (defMove == 1) {

                            def5.setX(def5.getX() + 11);

                            if (isSpaceOpen()) {
                                BrainPad.Display.ClearPartOfScreen(def5.getX() - 11, def5.getY(), 4, 2);

                                BrainPad.Display.ShowOnScreen();

                                if (def5.getX() >= 112) {
                                    def5.setX(112);
                                }
                            }
                            else {
                                def5.setX(def5.getX() - 11);

                                break;
                            }
                        }
                        else if (defMove == 2) {

                            def5.setY(def5.getY() + 10);

                            if (isSpaceOpen()) {
                                BrainPad.Display.ClearPartOfScreen(def5.getX(), def5.getY() - 10, 4, 2);

                                BrainPad.Display.ShowOnScreen();

                                if (def5.getY() >= 52) {
                                    def5.setY(52);

                                }
                            }
                            else {
                                def5.setY(def5.getY() - 10);

                                break;
                            }
                        }
                        else if (defMove == 3) {

                            def5.setX(def5.getX() - 11);

                            if (isSpaceOpen()) {
                                BrainPad.Display.ClearPartOfScreen(def5.getX() + 11, def5.getY(), 4, 2);

                                BrainPad.Display.ShowOnScreen();

                                if (def5.getX() <= 13) {
                                    def5.setX(13);
                                }
                            }
                            else {
                                def5.setX(def5.getX() + 11);
                                break;
                            }
                        }
                        break;

                    default:

                        break;
                }

                BrainPad.Buzzer.StopBuzzing();

                BrainPad.Display.DrawFilledRectangle(def1.getX(), def1.getY(), 4, 2);

                BrainPad.Display.DrawFilledRectangle(def2.getX(), def2.getY(), 4, 2);

                BrainPad.Display.DrawFilledRectangle(def3.getX(), def3.getY(), 4, 2);

                BrainPad.Display.DrawFilledRectangle(def4.getX(), def4.getY(), 4, 2);

                BrainPad.Display.DrawFilledRectangle(def5.getX(), def5.getY(), 4, 2);

                BrainPad.Display.ShowOnScreen();
            }

            void checkForTouchDown()
            {
                if (pastMidField && yardLine <= 0) {

                    if (possession == 1) {
                        player1Score = player1Score + 7;

                        BrainPad.Display.ClearScreen();
                        //Scoreboard
                        BrainPad.Display.DrawLine(30, 2, 98, 2);

                        BrainPad.Display.DrawLine(98, 2, 98, 21);

                        BrainPad.Display.DrawLine(30, 2, 30, 21);

                        BrainPad.Display.DrawLine(30, 21, 98, 21);

                        BrainPad.Display.DrawLine(48, 2, 48, 21);

                        BrainPad.Display.DrawLine(80, 2, 80, 21);

                        drawScoreBoard();

                        drawGameClock();

                        BrainPad.Display.DrawText(2, 32, "TouchDown!");

                        BrainPad.Display.DrawSmallText(6, 50, "Any Button to Kick");

                        BrainPad.Display.ShowOnScreen();

                        if (sound) {
                            touchDownSong();
                        }

                        possession = 2;

                        while (true) {
                            if (BrainPad.Buttons.IsRightPressed() || BrainPad.Buttons.IsLeftPressed() || BrainPad.Buttons.IsUpPressed() || BrainPad.Buttons.IsDownPressed()) {
                                kickOff();

                                return;
                            }
                        }
                    }
                    else {
                        player2Score = player2Score + 7;

                        BrainPad.Display.ClearScreen();
                        //Scoreboard
                        BrainPad.Display.DrawLine(30, 2, 98, 2);

                        BrainPad.Display.DrawLine(98, 2, 98, 21);

                        BrainPad.Display.DrawLine(30, 2, 30, 21);

                        BrainPad.Display.DrawLine(30, 21, 98, 21);

                        BrainPad.Display.DrawLine(48, 2, 48, 21);

                        BrainPad.Display.DrawLine(80, 2, 80, 21);

                        drawScoreBoard();

                        drawGameClock();

                        BrainPad.Display.DrawText(2, 32, "TouchDown!");

                        BrainPad.Display.DrawSmallText(6, 50, "Any Button to Kick");

                        BrainPad.Display.ShowOnScreen();

                        if (sound) {
                            touchDownSong();
                        }

                        possession = 1;

                        while (true) {

                            if (BrainPad.Buttons.IsRightPressed() || BrainPad.Buttons.IsLeftPressed() || BrainPad.Buttons.IsUpPressed() || BrainPad.Buttons.IsDownPressed()) {
                                kickOff();

                                return;
                            }
                        }
                    }
                }
            }

            void kickOff()
            {
                Random rnd = new Random();

                int num = rnd.Next(6);

                switch (num) {

                    case 0:
                        yardLine = 5;
                        down = 1;
                        YTG = 10;
                        pastMidField = false;
                        break;

                    case 1:
                        yardLine = 10;
                        down = 1;
                        YTG = 10;
                        pastMidField = false;
                        break;

                    case 2:
                        yardLine = 15;
                        down = 1;
                        YTG = 10;
                        pastMidField = false;
                        break;

                    case 3:
                        yardLine = 20;
                        down = 1;
                        YTG = 10;
                        pastMidField = false;
                        break;

                    case 4:
                        yardLine = 25;
                        down = 1;
                        YTG = 10;
                        pastMidField = false;
                        break;

                    case 5:
                        yardLine = 30;
                        down = 1;
                        YTG = 10;
                        pastMidField = false;
                        break;

                    case 6:
                        yardLine = 35;
                        down = 1;
                        YTG = 10;
                        pastMidField = false;
                        break;

                }

                BrainPad.Display.ClearScreen();

                drawScoreBoard();

                drawGameClock();

                drawField();

                resetPlay();

                drawPlayerPosition();

                drawDefensePositions();
            }

            void tryFieldGoal()
            {

                Random rnd = new Random();

                drawField();

                drawGameClock();

                drawScoreBoard();

                int num = rnd.Next(yardLine);

                if (num <= 10 && pastMidField) {
                    //90%
                    int num2 = rnd.Next(10);

                    if (num2 > 1) {
                        //FieldGoal is good
                        fieldGoalGood();
                    }
                    else {
                        //FieldGoal is nogood
                        fieldGoalNoGood();
                    }
                }
                else if (num >= 11 && num <= 20 && pastMidField) {
                    //80%
                    int num2 = rnd.Next(10);

                    if (num2 > 2) {
                        //FieldGoal is good
                        fieldGoalGood();
                    }
                    else {
                        //FieldGoal is nogood
                        fieldGoalNoGood();
                    }
                }
                else if (num >= 21 && num <= 30 && pastMidField) {
                    //70%
                    int num2 = rnd.Next(10);

                    if (num2 > 3) {
                        //FieldGoal is good
                        fieldGoalGood();
                    }
                    else {
                        //FieldGoal is nogood
                        fieldGoalNoGood();
                    }
                }
                else if (num >= 31 && num <= 40 && pastMidField) {
                    //60%
                    int num2 = rnd.Next(10);

                    if (num2 > 4) {
                        //FieldGoal is good
                        fieldGoalGood();
                    }
                    else {
                        //FieldGoal is nogood
                        fieldGoalNoGood();
                    }
                }
                else if (num >= 41 && num <= 50 && pastMidField) {
                    //50%
                    int num2 = rnd.Next(10);

                    if (num2 > 5) {
                        //FieldGoal is good
                        fieldGoalGood();
                    }
                    else {
                        //FieldGoal is nogood
                        fieldGoalNoGood();
                    }
                }
                else {
                    int num2 = rnd.Next(10);

                    if (num2 > 9) {
                        //FieldGoal is good
                        fieldGoalGood();
                    }
                    else {
                        //FieldGoal is nogood
                        fieldGoalNoGood();
                    }
                }
            }

            void fieldGoalGood()
            {
                BrainPad.Display.DrawText(10, 35, "It's Good");

                BrainPad.Display.ShowOnScreen();

                if (sound) {
                    touchDownSong();
                }

                if (possession == 1) {
                    player1Score = player1Score + 3;
                    possession = 2;
                    down = 1;
                    YTG = 10;

                    kickOff();
                }

                else {
                    player2Score = player2Score + 3;
                    possession = 1;
                    down = 1;
                    YTG = 10;

                    kickOff();
                }
            }

            void fieldGoalNoGood()
            {
                BrainPad.Display.DrawText(28, 35, "No Good!");

                BrainPad.Display.ShowOnScreen();

                if (sound) {
                    BrainPad.Buzzer.StartBuzzing(100);

                    BrainPad.Wait.Milliseconds(50);

                    BrainPad.Buzzer.StartBuzzing(50);

                    BrainPad.Wait.Milliseconds(200);

                    BrainPad.Buzzer.StopBuzzing();
                }

                BrainPad.Wait.Seconds(2);

                BrainPad.Display.ClearScreen();

                if (possession == 1)
                    possession = 2;
                else
                    possession = 1;

                if (pastMidField) {
                    pastMidField = false;
                }
                else
                    pastMidField = true;

                down = 1;
                YTG = 10;

                drawField();
            }

            void drawScoreBoard()
            {
                //Clears PlayerOne Score
                BrainPad.Display.ClearPartOfScreen(6, 4, 10, 10);
                //Clears PlayerTwo Score
                BrainPad.Display.ClearPartOfScreen(103, 4, 10, 10);

                BrainPad.Display.ClearPartOfScreen(59, 13, 10, 10);

                BrainPad.Display.ClearPartOfScreen(35, 8, 10, 10);

                BrainPad.Display.ClearPartOfScreen(84, 8, 12, 10);
                //Draws Box around Player who controls the ball. 
                if (possession == 1) {
                    BrainPad.Display.DrawLine(1, 1, 28, 1);

                    BrainPad.Display.DrawLine(1, 1, 1, 23);

                    BrainPad.Display.DrawLine(1, 23, 28, 23);

                    BrainPad.Display.DrawLine(28, 23, 28, 1);
                }
                else {
                    BrainPad.Display.DrawLine(100, 1, 127, 1);

                    BrainPad.Display.DrawLine(100, 1, 100, 23);

                    BrainPad.Display.DrawLine(100, 23, 127, 23);

                    BrainPad.Display.DrawLine(127, 23, 127, 1);
                }

                if (player1Score < 10) {
                    //PlayerOne Score 1 digit number
                    BrainPad.Display.DrawNumber(11, 5, player1Score);
                }
                else {
                    //PlayerOne Score 2 digit number
                    BrainPad.Display.DrawNumber(4, 4, player1Score);
                }

                if (player2Score < 10) {
                    //PlayerTwo Score 1 digit number
                    BrainPad.Display.DrawNumber(108, 5, player2Score);
                }
                else {
                    //PlayerTwo Score 2 digit number
                    BrainPad.Display.DrawNumber(103, 4, player2Score);
                }

                //DownMarker
                BrainPad.Display.DrawScaledText(35, 8, "" + down, 2, 1);

                if (yardLine >= 50) {
                    // Clears the direction >
                    BrainPad.Display.ClearPartOfScreen(52, 13, 30, 8);

                    BrainPad.Display.ShowOnScreen();

                    pastMidField = true;
                }
                else {

                    if (pastMidField) {
                        BrainPad.Display.ClearPartOfScreen(71, 13, 8, 8);
                        //Position Marker
                        BrainPad.Display.DrawScaledText(71, 13, ">", 1, 1);

                        BrainPad.Display.ShowOnScreen();
                    }
                    else {
                        BrainPad.Display.ClearPartOfScreen(52, 13, 15, 8);
                        //Position Marker
                        BrainPad.Display.DrawScaledText(52, 13, "<", 1, 1);

                        BrainPad.Display.ShowOnScreen();
                    }
                }

                if (yardLine < 10) {
                    BrainPad.Display.DrawScaledText(59, 12, "0" + yardLine, 1, 1);
                }
                else
                    BrainPad.Display.DrawScaledText(59, 12, "" + yardLine, 1, 1);

                BrainPad.Display.DrawScaledText(35, 8, "" + down, 2, 1);

                //Yards to go
                if (YTG >= 10)
                    BrainPad.Display.DrawScaledText(84, 8, "" + YTG, 1, 1);
                else
                    BrainPad.Display.DrawScaledText(87, 8, "" + YTG, 1, 1);

                BrainPad.Display.ShowOnScreen();
            }

            void isPlayerTackled()
            {
                if (player.getX() == def1.getX() && player.getY() == def1.getY()) {
                    endPlay();
                }
                else if (player.getX() == def2.getX() && player.getY() == def2.getY()) {
                    endPlay();
                }
                else if (player.getX() == def3.getX() && player.getY() == def3.getY()) {
                    endPlay();
                }
                else if (player.getX() == def4.getX() && player.getY() == def4.getY()) {
                    endPlay();
                }
                else if (player.getX() == def5.getX() && player.getY() == def5.getY()) {
                    endPlay();
                }
            }
            void endPlay()
            {
                down = down + 1;

                if (sound) {
                    blowWhistle();
                }

                checkDown();

                drawScoreBoard();

                resetPlay();
            }

            void checkDown()
            {
                if (YTG <= 0) {
                    YTG = 10;
                    down = 1;
                }

                if (down < 4) {
                    return;
                }
                else if (down == 4) {
                    BrainPad.Display.ClearScreen();
                    //Scoreboard
                    BrainPad.Display.DrawLine(30, 2, 98, 2);

                    BrainPad.Display.DrawLine(98, 2, 98, 21);

                    BrainPad.Display.DrawLine(30, 2, 30, 21);

                    BrainPad.Display.DrawLine(30, 21, 98, 21);

                    BrainPad.Display.DrawLine(48, 2, 48, 21);

                    BrainPad.Display.DrawLine(80, 2, 80, 21);

                    drawScoreBoard();

                    drawGameClock();

                    BrainPad.Display.DrawSmallText(17, 30, "4th Down: " + YTG + " YTG");

                    BrainPad.Display.DrawSmallText(5, 50, "Punt/L Kick/U Run/R");

                    BrainPad.Display.ShowOnScreen();

                    while (true) {
                        //Going for it on 4th down -- RUN
                        if (BrainPad.Buttons.IsRightPressed()) {
                            BrainPad.Display.ClearScreen();

                            BrainPad.Display.ShowOnScreen();

                            drawScoreBoard();

                            drawField();

                            return;
                        }

                        if (BrainPad.Buttons.IsLeftPressed()) {
                            BrainPad.Display.ClearScreen();
                            BrainPad.Display.ShowOnScreen();

                            kickOff();

                            drawScoreBoard();

                            drawField();

                            return;
                        }

                        if (BrainPad.Buttons.IsUpPressed()) {
                            BrainPad.Display.ClearScreen();

                            BrainPad.Display.ShowOnScreen();

                            tryFieldGoal();

                            return;
                        }
                    }
                }
                else if (down > 4) {

                    while (true) {
                        BrainPad.Display.ClearScreen();

                        BrainPad.Display.DrawText(25, 15, "Change");

                        BrainPad.Display.DrawText(20, 40, "Possesion");

                        BrainPad.Display.ShowOnScreen();

                        BrainPad.Wait.Seconds(3);

                        BrainPad.Display.ClearScreen();

                        BrainPad.Display.ShowOnScreen();

                        if (possession == 1)
                            possession = 2;
                        else
                            possession = 1;

                        down = 1;
                        YTG = 10;

                        drawField();

                        return;
                    }
                }

                if (YTG <= 0) {
                    YTG = 10;
                    down = 1;
                }
            }

            void touchDownSong()
            {
                //G 196 - C 261.63 - E  329.63 - G  392 - E  329.63 - G - 392
                BrainPad.Buzzer.StartBuzzing(196);//G

                BrainPad.Wait.Milliseconds(200);

                BrainPad.Buzzer.StartBuzzing(261.63);//C

                BrainPad.Wait.Milliseconds(200);

                BrainPad.Buzzer.StartBuzzing(329.63);//E

                BrainPad.Wait.Milliseconds(200);

                BrainPad.Buzzer.StartBuzzing(392);//G

                BrainPad.Wait.Milliseconds(100);

                BrainPad.Buzzer.StartBuzzing(329.63);//E

                BrainPad.Wait.Milliseconds(200);

                BrainPad.Buzzer.StartBuzzing(392);//G

                BrainPad.Wait.Milliseconds(800);

                BrainPad.Buzzer.StopBuzzing();
            }

            void blowWhistle()
            {
                for (int i = 0; i < 3; i++) {
                    BrainPad.Buzzer.StartBuzzing(2489.02);

                    BrainPad.Wait.Milliseconds(15);

                    BrainPad.Buzzer.StartBuzzing(2217.46);

                    BrainPad.Wait.Milliseconds(15);
                }

                BrainPad.Buzzer.StopBuzzing();
            }

            void drawGameClock()
            {
                if (minutes == 0 && seconds == 0) {

                }
                else {
                    if (milliseconds >= 10) {
                        seconds = seconds - 1;
                        milliseconds = 0;

                    }
                    if (seconds <= 0) {
                        seconds = 59;
                        minutes = minutes - 1;

                    }
                    //GameClock
                    BrainPad.Display.DrawSmallNumber(53, 4, minutes);

                    BrainPad.Display.DrawSmallText(60, 4, ":");

                    if (seconds < 10) {
                        BrainPad.Display.DrawSmallNumber(67, 4, 0);

                        BrainPad.Display.DrawSmallNumber(73, 4, seconds);
                    }
                    else {
                        BrainPad.Display.DrawSmallNumber(67, 4, seconds);
                    }
                }

                BrainPad.Display.ShowOnScreen();
            }

            void resetPlay()
            {
                BrainPad.Display.ClearPartOfScreen(player.getX() - offset, player.getY() - offset, 6, 5);

                BrainPad.Display.ClearPartOfScreen(def1.getX(), def1.getY(), 4, 2);

                BrainPad.Display.ClearPartOfScreen(def2.getX(), def2.getY(), 4, 2);

                BrainPad.Display.ClearPartOfScreen(def3.getX(), def3.getY(), 4, 2);

                BrainPad.Display.ClearPartOfScreen(def4.getX(), def4.getY(), 4, 2);

                BrainPad.Display.ClearPartOfScreen(def5.getX(), def5.getY(), 4, 2);

                player.setX(13);

                player.setY(42);

                def1.setX(46);

                def2.setX(46);

                def3.setX(46);

                def4.setX(68);

                def5.setX(101);

                def1.setY(32);

                def2.setY(42);

                def3.setY(52);

                def4.setY(42);

                def5.setY(42);

                BrainPad.Display.DrawCircle(player.getX(), player.getY(), 2);

                BrainPad.Display.DrawFilledRectangle(def1.getX(), def1.getY(), 4, 2);

                BrainPad.Display.DrawFilledRectangle(def2.getX(), def2.getY(), 4, 2);

                BrainPad.Display.DrawFilledRectangle(def3.getX(), def3.getY(), 4, 2);

                BrainPad.Display.DrawFilledRectangle(def4.getX(), def4.getY(), 4, 2);

                BrainPad.Display.DrawFilledRectangle(def5.getX(), def5.getY(), 4, 2);

                BrainPad.Display.ShowOnScreen();

                BrainPad.Wait.Seconds(2);
            }

            bool isSpaceOpen()
            {
                if (def1.getX() == def2.getX() && def1.getY() == def2.getY()) {
                    return false;
                }
                else if (def1.getX() == def3.getX() && def1.getY() == def3.getY()) {
                    return false;

                }
                else if (def1.getX() == def4.getX() && def1.getY() == def4.getY()) {
                    return false;

                }
                else if (def1.getX() == def5.getX() && def1.getY() == def5.getY()) {
                    return false;

                }
                else if (def2.getX() == def3.getX() && def2.getY() == def3.getY()) {
                    return false;

                }
                else if (def2.getX() == def4.getX() && def2.getY() == def4.getY()) {
                    return false;

                }
                else if (def2.getX() == def5.getX() && def2.getY() == def5.getY()) {
                    return false;

                }

                else if (def3.getX() == def4.getX() && def3.getY() == def4.getY()) {
                    return false;

                }
                else if (def3.getX() == def5.getX() && def3.getY() == def5.getY()) {
                    return false;

                }
                else if (def4.getX() == def5.getX() && def4.getY() == def5.getY()) {
                    return false;
                }

                return true;
            }

            void drawField()
            {
                //OutlineField
                BrainPad.Display.DrawLine(5, 25, 124, 25);

                BrainPad.Display.DrawLine(124, 25, 124, 60);

                BrainPad.Display.DrawLine(124, 60, 5, 60);

                BrainPad.Display.DrawLine(5, 60, 5, 25);

                //Left Goal Post
                BrainPad.Display.DrawLine(5, 42, 3, 42);

                BrainPad.Display.DrawLine(3, 39, 3, 44);

                BrainPad.Display.DrawLine(3, 39, 1, 36);

                BrainPad.Display.DrawLine(3, 44, 1, 46);

                //Right Goal Post
                BrainPad.Display.DrawLine(124, 42, 126, 42);

                BrainPad.Display.DrawLine(126, 40, 126, 44);

                BrainPad.Display.DrawLine(126, 40, 128, 38);

                BrainPad.Display.DrawLine(126, 44, 128, 46);

                //LeftGoalLine
                BrainPad.Display.DrawLine(9, 25, 9, 60);

                //10 Yard 
                BrainPad.Display.DrawLine(20, 25, 20, 60);

                //20 Yard 
                BrainPad.Display.DrawLine(31, 25, 31, 60);

                //30 Yard 
                BrainPad.Display.DrawLine(42, 25, 42, 60);

                //40 Yard 
                BrainPad.Display.DrawLine(53, 25, 53, 60);

                //50 Yard 
                BrainPad.Display.DrawLine(64, 25, 64, 60);

                //40 Yard 
                BrainPad.Display.DrawLine(75, 25, 75, 60);

                //30 Yard 
                BrainPad.Display.DrawLine(85, 25, 85, 60);

                //20 Yard 
                BrainPad.Display.DrawLine(97, 25, 97, 60);

                //10 Yard 
                BrainPad.Display.DrawLine(108, 25, 108, 60);

                //RightGoalLine
                BrainPad.Display.DrawLine(119, 25, 119, 60);

                //Hashmarks
                BrainPad.Display.DrawLine(9, 37, 11, 37);

                BrainPad.Display.DrawLine(9, 49, 11, 49);

                BrainPad.Display.DrawLine(18, 37, 22, 37);

                BrainPad.Display.DrawLine(18, 49, 22, 49);

                BrainPad.Display.DrawLine(29, 37, 33, 37);

                BrainPad.Display.DrawLine(29, 49, 33, 49);

                BrainPad.Display.DrawLine(40, 37, 44, 37);

                BrainPad.Display.DrawLine(40, 49, 44, 49);

                BrainPad.Display.DrawLine(51, 37, 55, 37);

                BrainPad.Display.DrawLine(51, 49, 55, 49);

                BrainPad.Display.DrawLine(62, 37, 66, 37);

                BrainPad.Display.DrawLine(62, 49, 66, 49);

                BrainPad.Display.DrawLine(73, 37, 77, 37);

                BrainPad.Display.DrawLine(73, 49, 77, 49);

                BrainPad.Display.DrawLine(83, 37, 87, 37);

                BrainPad.Display.DrawLine(83, 49, 87, 49);

                BrainPad.Display.DrawLine(95, 37, 99, 37);

                BrainPad.Display.DrawLine(95, 49, 99, 49);

                BrainPad.Display.DrawLine(106, 37, 110, 37);

                BrainPad.Display.DrawLine(106, 49, 110, 49);

                BrainPad.Display.DrawLine(117, 37, 119, 37);

                BrainPad.Display.DrawLine(117, 49, 119, 49);

                //Scoreboard
                BrainPad.Display.DrawLine(30, 2, 98, 2);

                BrainPad.Display.DrawLine(98, 2, 98, 21);

                BrainPad.Display.DrawLine(30, 2, 30, 21);

                BrainPad.Display.DrawLine(30, 21, 98, 21);

                BrainPad.Display.DrawLine(48, 2, 48, 21);

                BrainPad.Display.DrawLine(80, 2, 80, 21);

                BrainPad.Display.ShowOnScreen();
            }
        }

        class Player {

            int posX = 0;
            int posY = 0;
            int previousX = 0;
            int previousY = 0;

            public Player(int x, int y) {
                previousX = posX;
                previousY = posY;
                posX = x;
                posY = y;

            }
            public int getX() {
                return posX;
            }
            public int getY() {
                return posY;
            }
            public int getPreviousX() {
                return previousX;
            }
            public int getPreviousY() {
                return previousY;
            }
            public void setX(int x) {
                previousX = posX;
                posX = x;
            }
            public void setY(int y) {
                previousY = posY;
                posY = y;
            }
        }

        class DefensePlayer {

            int posX = 0;
            int posY = 0;
            int previousX = 0;
            int previousY = 0;

            public DefensePlayer(int x, int y) {
                previousX = posX;
                previousY = posY;
                posX = x;
                posY = y;
            }
            public int getX() {
                return posX;
            }
            public int getY() {
                return posY;
            }
            public int getPreviousX() {
                return previousX;
            }
            public int getPreviousY() {
                return previousY;
            }
            public void setX(int x) {
                previousX = posX;
                posX = x;
            }
            public void setY(int y) {
                previousY = posY;
                posY = y;
            }
        }
    }
}

