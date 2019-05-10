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

//G: G, Bb, C, C#, D, F, G

namespace BrainTouchPiano {

    class keyGm {

        static public void Run() {
            Click.ClampTouch.TouchClamp touch = new Click.ClampTouch.TouchClamp();

            BrainPad.Display.Clear();

            drawKeyBoard();

            int LastKey = -1;

            while (true) {
                int key = touch.GetKey();
                //Press LEFT button to Exit
                if (BrainPad.Buttons.IsLeftPressed())
                    return;

                if (key == LastKey)
                    continue;

                LastKey = key;

                if (key == -1) {
                    drawNotes(key);

                    BrainPad.Buzzer.StopBuzzing();
                }                
                else if (key == 7) {
                    drawNotes(key);
                    //G: G, Bb, C, C#, D, F, G
                    BrainPad.Buzzer.StartBuzzing(196);//G
                }
                else if (key == 6) {
                    drawNotes(key);

                    BrainPad.Buzzer.StartBuzzing(233.08);//Bb
                }
                else if (key == 5) {
                    drawNotes(key);

                    BrainPad.Buzzer.StartBuzzing(261.63);//C
                }
                else if (key == 3) {
                    drawNotes(key);

                    BrainPad.Buzzer.StartBuzzing(277.18);//C#
                }
                else if (key == 2) {
                    drawNotes(key);

                    BrainPad.Buzzer.StartBuzzing(293.66);//D
                }
                else if (key == 1) {
                    drawNotes(key);

                    BrainPad.Buzzer.StartBuzzing(349.23);//F
                }
                else if (key == 0) {
                    drawNotes(key);

                    BrainPad.Buzzer.StartBuzzing(392);//G
                }
                //Press LEFT button to Exit
                if (BrainPad.Buttons.IsLeftPressed())
                    return;
            }

            void drawNotes(int key) {
                
                switch (key) {
                    case 7:
                        BrainPad.Display.DrawSmallText(38, 55, "G");
                        break;
                    case 6:
                        BrainPad.Display.DrawSmallText(47, 44, "B");                        BrainPad.Display.DrawSmallText(56, 44, "b");
                        break;
                    case 5:
                        BrainPad.Display.DrawSmallText(65, 55, "C");
                        
                        break;
                    case 3:
                        BrainPad.Display.DrawSmallText(65, 44, "C");                        BrainPad.Display.DrawSmallText(74, 44, "#");
                        break;
                    case 2:
                        BrainPad.Display.DrawSmallText(75, 55, "D");
                        break;
                    case 1:
                        BrainPad.Display.DrawSmallText(92, 55, "F");
                        break;
                    case 0:
                        BrainPad.Display.DrawSmallText(102, 55, "G");
                        break;

                    default:
                        //Clears the display when the notes aren't playing
                        BrainPad.Display.ClearPart(38, 55, 5, 8);

                        BrainPad.Display.ClearPart(47, 44, 5, 8);

                        BrainPad.Display.ClearPart(56, 44, 5, 8);

                        BrainPad.Display.ClearPart(65, 55, 5, 8);

                        BrainPad.Display.ClearPart(65, 44, 5, 8);

                        BrainPad.Display.ClearPart(74, 44, 5, 8);

                        BrainPad.Display.ClearPart(75, 55, 5, 8);

                        BrainPad.Display.ClearPart(92, 55, 5, 8);

                        BrainPad.Display.ClearPart(102, 55, 5, 8);

                        break;
                }

                BrainPad.Display.RefreshScreen();
            }

            void drawKeyBoard() {
                BrainPad.Display.DrawLine(0, 0, 128, 0);

                BrainPad.Display.DrawLine(0, 0, 0, 64);

                BrainPad.Display.DrawLine(9, 40, 9, 64);

                BrainPad.Display.DrawLine(7, 0, 7, 40);

                BrainPad.Display.DrawLine(8, 0, 8, 40);

                BrainPad.Display.DrawLine(9, 0, 9, 40);

                BrainPad.Display.DrawLine(10, 0, 10, 40);

                BrainPad.Display.DrawLine(11, 0, 11, 40);

                BrainPad.Display.DrawLine(7, 40, 11, 40);

                BrainPad.Display.DrawLine(18, 40, 18, 64);

                BrainPad.Display.DrawLine(16, 0, 16, 40);

                BrainPad.Display.DrawLine(17, 0, 17, 40);

                BrainPad.Display.DrawLine(18, 0, 18, 40);

                BrainPad.Display.DrawLine(19, 0, 19, 40);

                BrainPad.Display.DrawLine(20, 0, 20, 40);

                BrainPad.Display.DrawLine(16, 40, 20, 40);

                BrainPad.Display.DrawLine(27, 0, 27, 64);

                BrainPad.Display.DrawLine(36, 40, 36, 64);

                BrainPad.Display.DrawLine(34, 0, 34, 40);

                BrainPad.Display.DrawLine(35, 0, 35, 40);

                BrainPad.Display.DrawLine(36, 0, 36, 40);

                BrainPad.Display.DrawLine(37, 0, 37, 40);

                BrainPad.Display.DrawLine(38, 0, 38, 40);

                BrainPad.Display.DrawLine(34, 40, 38, 40);

                BrainPad.Display.DrawLine(45, 40, 45, 64);

                BrainPad.Display.DrawLine(43, 0, 43, 40);

                BrainPad.Display.DrawLine(44, 0, 44, 40);

                BrainPad.Display.DrawLine(45, 0, 45, 40);

                BrainPad.Display.DrawLine(46, 0, 46, 40);

                BrainPad.Display.DrawLine(47, 0, 47, 40);

                BrainPad.Display.DrawLine(43, 40, 47, 40);

                BrainPad.Display.DrawLine(54, 40, 54, 64);

                BrainPad.Display.DrawLine(52, 0, 52, 40);

                BrainPad.Display.DrawLine(53, 0, 53, 40);

                BrainPad.Display.DrawLine(54, 0, 54, 40);

                BrainPad.Display.DrawLine(55, 0, 55, 40);

                BrainPad.Display.DrawLine(56, 0, 56, 40);

                BrainPad.Display.DrawLine(52, 40, 56, 40);

                BrainPad.Display.DrawLine(63, 0, 63, 64);

                BrainPad.Display.DrawLine(72, 40, 72, 64);

                BrainPad.Display.DrawLine(70, 0, 70, 40);

                BrainPad.Display.DrawLine(71, 0, 71, 40);

                BrainPad.Display.DrawLine(72, 0, 72, 40);

                BrainPad.Display.DrawLine(73, 0, 73, 40);

                BrainPad.Display.DrawLine(74, 0, 74, 40);

                BrainPad.Display.DrawLine(70, 40, 74, 40);

                BrainPad.Display.DrawLine(81, 40, 81, 64);

                BrainPad.Display.DrawLine(79, 0, 79, 40);

                BrainPad.Display.DrawLine(80, 0, 80, 40);

                BrainPad.Display.DrawLine(81, 0, 81, 40);

                BrainPad.Display.DrawLine(82, 0, 82, 40);

                BrainPad.Display.DrawLine(83, 0, 83, 40);

                BrainPad.Display.DrawLine(79, 40, 83, 40);

                BrainPad.Display.DrawLine(90, 0, 90, 64);

                BrainPad.Display.DrawLine(99, 40, 99, 64);

                BrainPad.Display.DrawLine(97, 0, 97, 40);

                BrainPad.Display.DrawLine(98, 0, 98, 40);

                BrainPad.Display.DrawLine(99, 0, 99, 40);

                BrainPad.Display.DrawLine(100, 0, 100, 40);

                BrainPad.Display.DrawLine(101, 0, 101, 40);

                BrainPad.Display.DrawLine(97, 40, 101, 40);

                BrainPad.Display.DrawLine(108, 40, 108, 64);

                BrainPad.Display.DrawLine(106, 0, 106, 40);

                BrainPad.Display.DrawLine(107, 0, 107, 40);

                BrainPad.Display.DrawLine(108, 0, 108, 40);

                BrainPad.Display.DrawLine(109, 0, 109, 40);

                BrainPad.Display.DrawLine(110, 0, 110, 40);

                BrainPad.Display.DrawLine(106, 40, 110, 40);

                BrainPad.Display.DrawLine(117, 40, 117, 64);

                BrainPad.Display.DrawLine(115, 0, 115, 40);

                BrainPad.Display.DrawLine(116, 0, 116, 40);

                BrainPad.Display.DrawLine(117, 0, 117, 40);

                BrainPad.Display.DrawLine(118, 0, 118, 40);

                BrainPad.Display.DrawLine(119, 0, 119, 40);

                BrainPad.Display.DrawLine(115, 40, 119, 40);

                BrainPad.Display.DrawLine(127, 0, 127, 64);

                BrainPad.Display.DrawLine(0, 63, 128, 63);

                BrainPad.Display.RefreshScreen();

                //Adds Banner
                BrainPad.Display.DrawText(0, 0, " Key of Gm  ");

                BrainPad.Display.RefreshScreen();
            }        
        }       
    }
}
 
