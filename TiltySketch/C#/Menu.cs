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
    static class Menu {

        static public int Show(string[] menu) {
            int selection = -1;

            if (menu.Length > 7)
                throw new System.Exception("Max menu size is 6!");

            BrainPad.Display.ClearScreen();

            for (int i = 0; i < menu.Length; i++)
                BrainPad.Display.DrawScaledText(12, 9 * i, menu[i], 1, 1);

            BrainPad.Display.DrawScaledText(0, 64 - 8, "R = Select L = Exit", 1, 1);

            BrainPad.Display.ShowOnScreen();

            while (true) {
                if (BrainPad.Buttons.IsDownPressed() || selection == -1) {
                    BrainPad.Buzzer.StartBuzzing(400);

                    BrainPad.Wait.Milliseconds(10);

                    BrainPad.Buzzer.StopBuzzing();

                    BrainPad.Display.DrawScaledText(0, selection * 9, " ", 2, 1);

                    selection++;

                    if (selection >= menu.Length)
                        selection = 0;

                    BrainPad.Display.DrawScaledText(0, selection * 9, ">", 2, 1);

                    BrainPad.Display.ShowOnScreen();

                    while (BrainPad.Buttons.IsDownPressed())
                        BrainPad.Wait.Minimum();
                }
                else if (BrainPad.Buttons.IsUpPressed() || selection == -1) {
                    BrainPad.Buzzer.StartBuzzing(400);

                    BrainPad.Wait.Milliseconds(10);

                    BrainPad.Buzzer.StopBuzzing();

                    BrainPad.Display.DrawScaledText(0, selection * 9, " ", 2, 1);

                    selection--;

                    if (selection < 0)
                        selection = menu.Length - 1;

                    BrainPad.Display.DrawScaledText(0, selection * 9, ">", 2, 1);

                    BrainPad.Display.ShowOnScreen();

                    while (BrainPad.Buttons.IsUpPressed())
                        BrainPad.Wait.Minimum();
                }

                if (BrainPad.Buttons.IsRightPressed())
                    return selection + 1;

                BrainPad.Wait.Minimum();

                int width = BrainPad.Display.Width;
            }
        }
    }
}