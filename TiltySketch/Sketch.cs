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

namespace TiltySketch {

    class Sketch {

        static public void Run(bool tilt) {
            Pen ball = new Pen(23, 21);

            while (true) {

                if (tilt) {
                    //This code uses the accelerometer to draw
                    if (BrainPad.Accelerometer.ReadY() > .40) {
                        ball.setY(ball.getY() - 1);
                    }
                    else if (BrainPad.Accelerometer.ReadY() < -.40) {
                        ball.setY(ball.getY() + 1);
                    }
                    else if (BrainPad.Accelerometer.ReadX() > .40) {
                        ball.setX(ball.getX() + 1);
                    }
                    else if (BrainPad.Accelerometer.ReadX() < -.40) {
                        ball.setX(ball.getX() - 1);
                    }
                }
                else {
                    //This code uses the buttons to draw
                    if (BrainPad.Buttons.IsUpPressed())
                        ball.setY(ball.getY() - 1);
                    if (BrainPad.Buttons.IsDownPressed())
                        ball.setY(ball.getY() + 1);
                    if (BrainPad.Buttons.IsRightPressed())
                        ball.setX(ball.getX() + 1);
                    if (BrainPad.Buttons.IsLeftPressed())
                        ball.setX(ball.getX() - 1);
                }

                BrainPad.Display.DrawPoint(ball.getX(), ball.getY());

                BrainPad.Display.ShowOnScreen();

                //If BrainPad is turned upsidedown erase the screen
                if (BrainPad.Accelerometer.ReadZ() > 1) {
                    BrainPad.Display.ClearScreen();

                    BrainPad.Display.ShowOnScreen();
                }
            }
        }
    }
}


           
      