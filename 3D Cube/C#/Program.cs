// Copyright (c) GHI Electronics, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;

namespace _3DCube {
    class Program {
        class Vector3 {
            public double X;
            public double Y;
            public double Z;
            public Vector3(double X, double Y, double Z) {
                this.X = X;
                this.Y = Y;
                this.Z = Z;
            }
        }

        class Vector2 {
            public double X;
            public double Y;
            public Vector2(double X, double Y) {
                this.X = X;
                this.Y = Y;
            }
        }

        static void Translate3Dto2D(Vector3[] Points3D, Vector2[] Points2D, Vector3 Rotate, Vector3 Position) {
            int OFFSETX = 64;
            int OFFSETY = 32;
            int OFFSETZ = 50;

            double sinax = Math.Sin(Rotate.X * Math.PI / 180);
            double cosax = Math.Cos(Rotate.X * Math.PI / 180);
            double sinay = Math.Sin(Rotate.Y * Math.PI / 180);
            double cosay = Math.Cos(Rotate.Y * Math.PI / 180);
            double sinaz = Math.Sin(Rotate.Z * Math.PI / 180);
            double cosaz = Math.Cos(Rotate.Z * Math.PI / 180);

            for (int i = 0; i < 8; i++) {
                double x = Points3D[i].X;
                double y = Points3D[i].Y;
                double z = Points3D[i].Z;

                double yt = y * cosax - z * sinax;  // rotate around the x axis
                double zt = y * sinax + z * cosax;  // using the Y and Z for the rotation
                y = yt;
                z = zt;

                double xt = x * cosay - z * sinay;  // rotate around the Y axis
                zt = x * sinay + z * cosay;         // using X and Z
                x = xt;
                z = zt;

                xt = x * cosaz - y * sinaz;         // finally rotate around the Z axis
                yt = x * sinaz + y * cosaz;         // using X and Y
                x = xt;
                y = yt;

                x = x + Position.X;                 // add the object position offset
                y = y + Position.Y;                 // for both x and y
                z = z + OFFSETZ - Position.Z;       // as well as Z

                Points2D[i].X = (x * 64 / z) + OFFSETX;
                Points2D[i].Y = (y * 64 / z) + OFFSETY;
                //BrainPad.ImageBuffer.DrawPoint((int)Points2D[i].X, (int)Points2D[i].Y);
            }
        }

        static void Main() {
            // our object in 3D space
            Vector3[] cube_points = new Vector3[8]
            {
            new Vector3(10,10,-10),
            new Vector3(-10,10,-10),
            new Vector3(-10,-10,-10),
            new Vector3(10,-10,-10),
            new Vector3(10,10,10),
            new Vector3(-10,10,10),
            new Vector3(-10,-10,10),
            new Vector3(10,-10,10),
            };

            // what we get back in 2D space!
            Vector2[] cube2 = new Vector2[8]
            {
            new Vector2(0,0),
            new Vector2(0,0),
            new Vector2(0,0),
            new Vector2(0,0),
            new Vector2(0,0),
            new Vector2(0,0),
            new Vector2(0,0),
            new Vector2(0,0),
            };

            // the connections between the "dots"
            int[] start = new int[12] { 0, 1, 2, 3, 4, 5, 6, 7, 0, 1, 2, 3 };
            int[] end = new int[12] { 1, 2, 3, 0, 5, 6, 7, 4, 4, 5, 6, 7 };

            Vector3 rot = new Vector3(0, 0, 0);
            Vector3 pos = new Vector3(0, 0, 0);

            while (true) {
                double accelX = BrainPad.Accelerometer.ReadX();
                double accelY = BrainPad.Accelerometer.ReadY();
                BrainPad.Display.Clear();
                //rot.Z += 5;
                //rot.X += 5;
                rot.X = 360 - accelY;
                rot.Y = accelX;
                //pos.X += 1;
                Translate3Dto2D(cube_points, cube2, rot, pos);

                for (int i = 0; i < start.Length; i++) {    // draw the lines that make up the object
                    int vertex = start[i];                  // temp = start vertex for this line
                    int sx = (int)cube2[vertex].X;          // set line start x to vertex[i] x position
                    int sy = (int)cube2[vertex].Y;          // set line start y to vertex[i] y position
                    vertex = end[i];                        // temp = end vertex for this line
                    int ex = (int)cube2[vertex].X;          // set line end x to vertex[i+1] x position
                    int ey = (int)cube2[vertex].Y;          // set line end y to vertex[i+1] y position
                    BrainPad.Display.DrawLine(sx, sy, ex, ey);
                }
                BrainPad.Display.DrawSmallText(0, 55, "X: " + (accelX * 100).ToString("F0"));
                BrainPad.Display.DrawSmallText(80, 55, "Y: " + (accelY * 100).ToString("F0"));
                BrainPad.Display.RefreshScreen();
                BrainPad.Wait.Minimum();
            }
        }
    }
}
