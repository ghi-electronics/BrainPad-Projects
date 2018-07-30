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

namespace TiltMaze {
    class TiltMazeOne {

        static public void Run() {

            int milliseconds = 0;
            int seconds = 0;
            int minutes = 0;
            
            Player ball = new Player(23, 21);
            
            drawMaze();

            BrainPad.Display.DrawRectangle(ball.getX(), ball.getY(), 3, 3);

            BrainPad.Display.ShowOnScreen();
            //Put your program code here. It runs repeatedly after the BrainPad starts up.
            while (true) {
                if (BrainPad.Buttons.IsLeftPressed())
                    return;

                if (BrainPad.Accelerometer.ReadY() > .40) {
                    BrainPad.Display.ClearPartOfScreen(ball.getX(), ball.getY(), 3, 3);

                    ball.setY(ball.getY() - 1);

                    BrainPad.Display.DrawRectangle(ball.getX(), ball.getY(), 3, 3);

                    BrainPad.Display.ShowOnScreen();                    
                }                 
                else if (BrainPad.Accelerometer.ReadY() < -.40) {
                    BrainPad.Display.ClearPartOfScreen(ball.getX(), ball.getY(), 3, 3);

                    ball.setY(ball.getY() + 1);
                    
                    BrainPad.Display.DrawRectangle(ball.getX(), ball.getY(), 3, 3);

                    BrainPad.Display.ShowOnScreen();             
                }                  
                else if (BrainPad.Accelerometer.ReadX() > .40) {
                    BrainPad.Display.ClearPartOfScreen(ball.getX(), ball.getY(), 3, 3);

                    ball.setX(ball.getX() + 1);

                    BrainPad.Display.DrawRectangle(ball.getX(), ball.getY(), 3, 3);

                    BrainPad.Display.ShowOnScreen();
                }                   
                else if (BrainPad.Accelerometer.ReadX() < -.40) {
                    BrainPad.Display.ClearPartOfScreen(ball.getX(), ball.getY(), 3, 3);
                    ball.setX(ball.getX() - 1);
                    BrainPad.Display.DrawRectangle(ball.getX(), ball.getY(), 3, 3);
                    BrainPad.Display.ShowOnScreen();
                }
   
                ball.checkWall();

                if (milliseconds > 10) {
                    milliseconds = 0;
                    seconds++;
                }
                if (seconds >= 59) {
                    seconds = 0;
                    minutes++;
                }

                if (seconds < 10) {
                    BrainPad.Display.DrawSmallNumber(115, 53 ,0);

                    BrainPad.Display.DrawSmallNumber(121, 53, seconds);
                }
                else {
                    BrainPad.Display.DrawSmallNumber(115, 53, seconds);
                }
                
                BrainPad.Display.DrawSmallText(108, 53, ":");

                BrainPad.Display.DrawSmallNumber(101, 53, minutes);

                BrainPad.Display.ShowOnScreen();

                if (ball.getX() == 115 && ball.getY()<=59 && ball.getY()>=51) {
                    BrainPad.Display.DrawText(45, 25, minutes.ToString());

                    BrainPad.Display.DrawText(55, 25, ":");

                    BrainPad.Display.DrawText(65, 25, seconds.ToString());

                    BrainPad.Display.ShowOnScreen();

                    BrainPad.Wait.Seconds(5);

                    BrainPad.Display.ClearScreen();

                    BrainPad.Display.ShowOnScreen();

                    drawMaze();

                    ball.setY(21);

                    ball.setX(23);

                    BrainPad.Display.DrawRectangle(ball.getX(), ball.getY(), 3, 3);

                    BrainPad.Display.ShowOnScreen();

                    milliseconds = 0;
                    seconds = 0;
                    minutes = 0;
                }
                else
                    milliseconds++;
            }

            void drawMaze() {
                //Outer parameter
                BrainPad.Display.DrawLine(0, 0, 128, 0);

                BrainPad.Display.DrawLine(1, 1, 128, 1);

                BrainPad.Display.DrawLine(127, 0, 127, 64);

                BrainPad.Display.DrawLine(128, 0, 128, 64);

                BrainPad.Display.DrawLine(0, 63, 128, 63);

                BrainPad.Display.DrawLine(0, 64, 128, 64);

                BrainPad.Display.DrawLine(0, 0, 0, 64);

                BrainPad.Display.DrawLine(1, 1, 1, 64);

                BrainPad.Display.DrawLine(39, 0, 39, 27);

                BrainPad.Display.DrawLine(75, 0, 75, 12);

                BrainPad.Display.DrawLine(18, 15, 26, 15);

                BrainPad.Display.DrawLine(52, 15, 64, 15);

                BrainPad.Display.DrawLine(89, 15, 116, 15);
                
                BrainPad.Display.DrawLine(18, 15, 18, 27);

                BrainPad.Display.DrawLine(64, 15, 64, 27);

                BrainPad.Display.DrawLine(89, 15, 89, 27);

                BrainPad.Display.DrawLine(102, 15, 102, 38);

                BrainPad.Display.DrawLine(18, 27, 51, 27);

                BrainPad.Display.DrawLine(64, 27, 75, 27);

                BrainPad.Display.DrawLine(115, 27, 128, 27);

                BrainPad.Display.DrawLine(18, 27, 51, 27);

                BrainPad.Display.DrawLine(64, 27, 75, 27);

                BrainPad.Display.DrawLine(115, 27, 128, 27);

                BrainPad.Display.DrawLine(30, 27, 30, 38);

                BrainPad.Display.DrawLine(51, 27, 51, 38);

                BrainPad.Display.DrawLine(75, 27, 75, 38);

                BrainPad.Display.DrawLine(115, 27, 115, 38);

                BrainPad.Display.DrawLine(0, 38, 18, 38);

                BrainPad.Display.DrawLine(39, 38, 51, 38);

                BrainPad.Display.DrawLine(75, 38, 102, 38);

                BrainPad.Display.DrawLine(39, 38, 39, 51);

                BrainPad.Display.DrawLine(64, 41, 64, 51);

                BrainPad.Display.DrawLine(89, 38, 89, 51);

                BrainPad.Display.DrawLine(18, 51, 39, 51);

                BrainPad.Display.DrawLine(64, 51, 89, 51);

                BrainPad.Display.DrawLine(102, 51, 128, 51);

                BrainPad.Display.DrawLine(51, 51, 51, 64);

                BrainPad.Display.DrawLine(75, 51, 75, 64);
                
                BrainPad.Display.ShowOnScreen();
            }
        }
    }
}

