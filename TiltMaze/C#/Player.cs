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
    class Player {

        int posX = 23;
        int posY = 21;
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
                posY = 17;
            }

            if (posY >= 17 && posY <= 25 && posX == 19) {
                posX = 20;
            }

            if (posY == 24 && posX >= 19 && posX <= 36) {
                posY = 23;
            }

            if (posY <= 23 && posY >= 2 && posX == 36) {
                posX = 35;
            }

            if (posX >= 17 && posX <= 25 && posY == 12) {
                posY = 11;
            }

            if (posY >= 15 && posY <= 28 && posX == 15) {
                posX = 14;
            }

            if (posX >= 2 && posX <= 18 && posY == 35) {
                posY = 34;
            }

            if (posX >= 18 && posX <= 20 && posY == 29) {
                posY = 30;
            }

            if (posY >= 29 && posY <= 37 && posX == 27) {
                posX = 26;
            }

            if (posX >= 26 && posX <= 27 && posY == 14) {
                posX = 27;
            }

            if (posX >= 16 && posX <= 26 && posY == 29) {
                posY = 30;
            }

            if (posX >= 16 && posX <= 35 && posY == 48) {
                posY = 47;
            }
            if (posY >= 36 && posY <= 47 && posX == 36) {
                posX = 35;
            }

            if (posX >= 38 && posX <= 48 && posY == 34) {
                posY = 33;
            }

            if (posY >= 27 && posY <= 33 && posX == 48) {
                posX = 47;
            }

            if (posY >= 30 && posY <= 35 && posX == 31) {
                posX = 32;
            }

            if (posX >= 32 && posX <= 47 && posY == 29) {
                posY = 30;
            }

            if (posX >= 2 && posX <= 20 && posY == 35) {
                posY = 34;
            }

            if (posX >= 2 && posX <= 20 && posY == 38) {
                posY = 39;
            }

            if (posX >= 18 && posX <= 39 && posY == 52) {
                posY = 53;
            }

            if (posY >= 49 && posY <= 59 && posX == 48) {
                posX = 47;
            }

            if (posY >= 40 && posY <= 50 && posX == 40) {
                posX = 41;
            }

            if (posX >= 41 && posX <= 50 && posY == 39) {
                posY = 40;
            }

            if (posY >= 40 && posY <= 50 && posX == 60) {
                posX = 59;
            }

            if (posY >= 49 && posY <= 59 && posX == 52) {
                posX = 53;
            }
            if (posY >= 52 && posY <= 59 && posX == 72) {
                posX = 71;
            }

            if (posX >= 62 && posX <= 71 && posY == 52) {
                posY = 53;
            }

            if (posY >= 25 && posY <= 38 && posX == 52) {
                posX = 53;
            }

            if (posX >= 40 && posX <= 50 && posY == 23) {
                posY = 22;
            }

            if (posY >= 3 && posY <= 22 && posX == 40) {
                posX = 41;
            }

            if (posX >= 51 && posX <= 60 && posY == 16) {
                posY = 17;
            }

            if (posX >= 51 && posX <= 64 && posY == 13) {
                posY = 12;
            }

            if (posY >= 16 && posY <= 26 && posX == 61) {
                posX = 60;
            }

            if (posX >= 63 && posX <= 71 && posY == 29) {
                posY = 30;
            }

            if (posY >= 28 && posY <= 37 && posX == 72) {
                posX = 71;
            }

            if (posY >= 2 && posY <= 11 && posX == 71) {
                posX = 70;
            }

            if (posX >= 65 && posX <= 87 && posY == 48) {
                posY = 47;
            }

            if (posY >= 39 && posY <= 47 && posX == 85) {
                posX = 84;
            }

            if (posY >= 14 && posY <= 24 && posX == 65) {
                posX = 66;
            }

            if (posX >= 74 && posX <= 84 && posY == 39) {
                posY = 40;
            }

            if (posX >= 66 && posX <= 74 && posY == 24) {
                posY = 23;
            }
            if (posY >= 2 && posY <= 12 && posX == 77) {
                posX = 78;
            }
            if (posY >= 15 && posY <= 26 && posX == 86) {
                posX = 85;
            }

            if (posY >= 25 && posY <= 35 && posX == 76) {
                posX = 77;
            }

            if (posY >= 16 && posY <= 26 && posX == 90) {
                posX = 91;
            }

            if (posX >= 76 && posX <= 98 && posY == 34) {
                posY = 33;
            }

            if (posY >= 16 && posY <= 34 && posX == 99) {
                posX = 98;
            }

            if (posX >= 91 && posX <= 99 && posY == 16) {
                posY = 17;
            }

            if (posX >= 88 && posX <= 115 && posY == 12) {
                posY = 11;
            }

            if (posY >= 16 && posY <= 38 && posX == 104) {
                posX = 105;
            }

            if (posY >= 25 && posY <= 37 && posX == 112) {
                posX = 111;
            }

            if (posX >= 103 && posX <= 113 && posY == 16) {
                posY = 17;
            }

            if (posY >= 26 && posY <= 37 && posX == 111) {
                posX = 110;
            }

            if (posX >= 114 && posX <= 123 && posY == 24) {
                posY = 23;
            }
            if (posX >= 102 && posX <= 123 && posY == 47) {
                posY = 46;
            }

            if (posY >= 29 && posY <= 38 && posX == 117) {
                posX = 118;
            }

            if (posX >= 117 && posX <= 123 && posY == 29) {
                posY = 30;
            }

            if (posX >= 90 && posX <= 102 && posY == 40) {
                posY = 41;
            }

            if (posY >= 40 && posY <= 50 && posX == 91) {
                posX = 92;
            }

            if (posX >= 76 && posX <= 89 && posY == 53) {
                posY = 54;
            }

            if (posY >= 52 && posY <= 59 && posX == 76) {
                posX = 77;
            }

            if (posY >= 52 && posY <= 59 && posX == 77) {
                posX = 78;
            }

            if (posX >= 101 && posX <= 123 && posY == 52) {
                posY = 53;
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
    }
}