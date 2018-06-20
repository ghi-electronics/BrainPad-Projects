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
  
    class Pen {
        int posX = 23;
        int posY = 21;
        int previousX = 0;
        int previousY = 0;

        public Pen(int x, int y) {
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
    }
}
