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
    class ExpertPlayer {
        int posX = 23;
        int posY = 21;
        int previousX = 0;
        int previousY = 0;

        public ExpertPlayer(int x, int y) {
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

        public void setX(int x) {
            previousX = posX;
            posX = x;
        }

        public void setY(int y) {
            previousY = posY;
            posY = y;
        }

        public int getPreviousX() {
            return previousX;
        }

        public int getPreviousY() {
            return previousY;
        }

        public void checkWall() {
            

            if (posX >= 19 && posX <= 25 && posY == 16) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 17 && posY <= 25 && posX == 19) {
                makeSound();

                resetPlayer();
            }

            if (posY == 24 && posX >= 19 && posX <= 36) {
                makeSound();

                resetPlayer();
            }

            if (posY <= 23 && posY >= 2 && posX == 36) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 17 && posX <= 25 && posY == 12) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 15 && posY <= 28 && posX == 15) {
                makeSound();

                resetPlayer();
            }
            if (posX >= 2 && posX <= 18 && posY == 35) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 18 && posX <= 20 && posY == 29) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 29 && posY <= 37 && posX == 27) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 26 && posX <= 27 && posY == 14) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 16 && posX <= 26 && posY == 29) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 16 && posX <= 35 && posY == 48) {
                makeSound();

                resetPlayer();
            }
            if (posY >= 36 && posY <= 47 && posX == 36) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 38 && posX <= 48 && posY == 34) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 27 && posY <= 33 && posX == 48) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 30 && posY <= 35 && posX == 31) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 32 && posX <= 47 && posY == 29) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 2 && posX <= 20 && posY == 35) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 2 && posX <= 20 && posY == 38) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 18 && posX <= 39 && posY == 52) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 49 && posY <= 59 && posX == 48) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 40 && posY <= 50 && posX == 40) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 41 && posX <= 50 && posY == 39) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 40 && posY <= 50 && posX == 60) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 49 && posY <= 59 && posX == 52) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 52 && posY <= 59 && posX == 72) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 62 && posX <= 71 && posY == 52) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 25 && posY <= 38 && posX == 52) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 40 && posX <= 50 && posY == 23) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 3 && posY <= 22 && posX == 40) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 51 && posX <= 60 && posY == 16) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 51 && posX <= 64 && posY == 13) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 16 && posY <= 26 && posX == 61) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 63 && posX <= 71 && posY == 29) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 28 && posY <= 37 && posX == 72) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 2 && posY <= 11 && posX == 71) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 65 && posX <= 87 && posY == 48) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 39 && posY <= 47 && posX == 85) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 14 && posY <= 24 && posX == 65) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 74 && posX <= 84 && posY == 39) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 66 && posX <= 74 && posY == 24) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 2 && posY <= 12 && posX == 77) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 15 && posY <= 26 && posX == 86) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 25 && posY <= 35 && posX == 76) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 16 && posY <= 26 && posX == 90) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 76 && posX <= 98 && posY == 34) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 16 && posY <= 34 && posX == 99) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 91 && posX <= 99 && posY == 16) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 88 && posX <= 115 && posY == 12) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 16 && posY <= 38 && posX == 104) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 25 && posY <= 37 && posX == 112) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 103 && posX <= 113 && posY == 16) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 26 && posY <= 37 && posX == 111) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 114 && posX <= 123 && posY == 24) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 102 && posX <= 123 && posY == 47) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 29 && posY <= 38 && posX == 117) {
                makeSound(); 

                resetPlayer();
            }

            if (posX >= 117 && posX <= 123 && posY == 29) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 90 && posX <= 102 && posY == 40) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 40 && posY <= 50 && posX == 91) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 76 && posX <= 89 && posY == 53) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 52 && posY <= 59 && posX == 76) {
                makeSound();

                resetPlayer();
            }

            if (posY >= 52 && posY <= 59 && posX == 77) {
                makeSound();

                resetPlayer();
            }

            if (posX >= 101 && posX <= 123 && posY == 52) {
                makeSound();

                resetPlayer();
            }

            if (posY <= 2) {
                posY = 3;
            }

            if (posY >= 60) {
                posY = 59;
            }

            if (posX <= 2) {
                posX = 2;
            }
            if (posX >= 124) {
                posX = 123;
            }
        }
        void makeSound() {
            BrainPad.Buzzer.StartBuzzing(15);

            BrainPad.Wait.Milliseconds(1000);

            BrainPad.Buzzer.StopBuzzing();
        }

        void resetPlayer() {
            BrainPad.Display.ClearPart(getX(), getY(), 3, 3);

            posX = 23;
            posY = 21;

            BrainPad.Display.DrawRectangle(getX(), getY(), 3, 3);
        }
    }
}