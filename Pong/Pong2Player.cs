using System;
using System.Collections;
using System.Text;
using System.Threading;

namespace Pong {
    static class Pong2Player {
        static public void Run() {

            int playerOneScore = 0;
            int playerTwoScore = 0;
            int paddleSize = 10;

            Ball ball = new Ball(60, 30);

            Paddle player1 = new Paddle(3, 3);

            Paddle player2 = new Paddle(40, 40);
            //starts the ball moving toward player one
            ball.changeDirection(1);

            while (true) {
                //Player One Controls
                if (BrainPad.Buttons.IsUpPressed()) {
                    player1.moveUp();
                }
                if (BrainPad.Buttons.IsLeftPressed()) {
                    player1.moveDown();
                }
                //Player Two Controls
                if (BrainPad.Buttons.IsRightPressed()) {
                    player2.moveUp();
                }
                if (BrainPad.Buttons.IsDownPressed()) {
                    player2.moveDown();
                }

                ballCollision();

                ball.Move();

                drawGame();

                if (BrainPad.Buttons.IsLeftPressed() && BrainPad.Buttons.IsDownPressed() && BrainPad.Buttons.IsUpPressed() && BrainPad.Buttons.IsRightPressed())
                    return;
            }

            void ballCollision() {
                //Check for Player 1 paddle collision
                for (int i = 0; i < paddleSize + 1; i++) {

                    int test = (player1.getX() + i);
                    
                    if (ball.getY() == test)
                        if (ball.getX() < 8) {
                            ball.player1RandomDirection();

                            BrainPad.Buzzer.StartBuzzing(600);

                            BrainPad.Wait.Milliseconds(20);

                            BrainPad.Buzzer.StopBuzzing();
                        }
                }

                //Check for Player 2 paddle collision
                for (int i = 0; i < paddleSize + 1; i++) {

                    int test = (player2.getX() + i);
                    
                    if (ball.getY() == test)
                        if (ball.getX() > 118) {
                            ball.player2RandomDirection();

                            BrainPad.Buzzer.StartBuzzing(600);

                            BrainPad.Wait.Milliseconds(20);

                            BrainPad.Buzzer.StopBuzzing();
                        }
                }
                //Ball passes player 2
                if (ball.getX() > 120) {
                    playerOneScore = playerOneScore + 1;

                    BrainPad.Buzzer.StartBuzzing(45);

                    BrainPad.Wait.Milliseconds(100);

                    BrainPad.Buzzer.StopBuzzing();

                    ball.Reset();

                    ball.changeDirection(4);
                }
                //Ball passes player 1
                if (ball.getX() < 0) {
                    playerTwoScore = playerTwoScore + 1;

                    BrainPad.Buzzer.StartBuzzing(45);

                    BrainPad.Wait.Milliseconds(100);

                    BrainPad.Buzzer.StopBuzzing();

                    ball.Reset();
                }
                // STOP = 0, LEFT = 1, UPLEFT = 2, DOWNLEFT = 3, RIGHT = 4, UPRIGHT = 5, DOWNRIGHT = 6 
                //Ball Hits Top Wall travelling from Left to Right
                if (ball.getY() <= 3 && ball.getDirection() == 5) {
                    ball.changeDirection(6);

                    BrainPad.Buzzer.StartBuzzing(800);

                    BrainPad.Wait.Milliseconds(20);

                    BrainPad.Buzzer.StopBuzzing();
                }
                //Ball Hits Top Wall travelling from Right to Left
                if (ball.getY() <= 3 && ball.getDirection() == 2) {
                    ball.changeDirection(3);

                    BrainPad.Buzzer.StartBuzzing(800);

                    BrainPad.Wait.Milliseconds(20);

                    BrainPad.Buzzer.StopBuzzing();
                }
                //Ball Hits Bottom Wall travelling from Right to Left
                if (ball.getY() >= 60 && ball.getDirection() == 6) {
                    ball.changeDirection(5);

                    BrainPad.Buzzer.StartBuzzing(800);

                    BrainPad.Wait.Milliseconds(20);

                    BrainPad.Buzzer.StopBuzzing();
                }
                //Ball Hits Bottom Wall travelling from Left to Right
                if (ball.getY() >= 60 && ball.getDirection() == 3) {
                    ball.changeDirection(2);

                    BrainPad.Buzzer.StartBuzzing(800);

                    BrainPad.Wait.Milliseconds(20);

                    BrainPad.Buzzer.StopBuzzing();
                }
            }

            void drawGame() {
                //Top Wall
                BrainPad.Display.DrawLine(0, 0, 128, 0);
                //Bottom Wall
                BrainPad.Display.DrawLine(0, 63, 128, 63);
                // net
                BrainPad.Display.DrawLine(64, 0, 64, 5);
                // net
                BrainPad.Display.DrawLine(64, 10, 64, 15);
                // net
                BrainPad.Display.DrawLine(64, 20, 64, 25);
                // net
                BrainPad.Display.DrawLine(64, 30, 64, 35);
                // net
                BrainPad.Display.DrawLine(64, 40, 64, 45);
                // net
                BrainPad.Display.DrawLine(64, 50, 64, 55);
                // net
                BrainPad.Display.DrawLine(64, 60, 64, 65);
                // Player Two Score
                BrainPad.Display.DrawSmallNumber(70, 5, playerTwoScore);
                //Ball
                BrainPad.Display.DrawCircle(ball.getX(), ball.getY(), 2);
                //Players One Paddle
                BrainPad.Display.DrawLine(2, player1.getX(), 2, player1.getX() + paddleSize);
                //Player Two Paddle
                BrainPad.Display.DrawLine(124, player2.getX(), 124, player2.getX() + paddleSize);
                //Back Wall
                BrainPad.Display.DrawLine(127, 0, 127, 64);

                BrainPad.Display.ShowOnScreen();

                BrainPad.Display.ClearScreen();
            }
        }

        class Paddle {
            private int x, y;
            private int originalX, originalY;
            private int gameSpeed = 6;

            public Paddle() {
                x = 0;
                y = 0;
            }

            public Paddle(int posX, int posY) {
                originalX = posX;
                originalY = posY;
                x = posX;
                y = posY;
            }

            public void Reset() {
                x = originalX;
                y = originalY;
            }

            public int getX() {
                return x;
            }

            public int getY() {
                return y;
            }

            public void moveUp() {
                x = x - gameSpeed;
            }

            public void moveDown() {
                x = x + gameSpeed;
            }
        }

        class Ball {
            private int x, y;
            private int originalX, originalY;
            private int direction;
            private int gameSpeed = 6;

            public Ball(int posX, int posY) {
                originalX = posX;
                originalY = posY;
                x = posX;
                y = posY;
                direction = 0;
            }
            public void Reset() {
                x = originalX;
                y = originalY;
                direction = 1;
            }

            public void changeDirection(int d) {
                direction = d;
            }

            public void setX(int xBall) {
                x = xBall;
            }

            public void setY(int yBall) {
                y = yBall;
            }

            public int getX() {
                return x;
            }

            public int getY() {
                return y;
            }
            // STOP = 0, LEFT = 1, UPLEFT = 2, DOWNLEFT = 3, RIGHT = 4, UPRIGHT = 5, DOWNRIGHT = 6 
            public void player1RandomDirection() {
                Random rnd = new Random();

                do {
                    direction = rnd.Next(3) + 4;
                } while (direction == 4); //insures no straight shots from player 1

            }

            public void player2RandomDirection() {
                Random rnd = new Random();

                do {
                    direction = rnd.Next(2) + 1;
                } while (direction == 1);//insures no straight shots player 2
            }

            public int getDirection() {
                return direction;
            }
            // STOP = 0, LEFT = 1, UPLEFT = 2, DOWNLEFT = 3, RIGHT = 4, UPRIGHT = 5, DOWNRIGHT = 6 
            public void Move() {

                switch (direction) {
                    case 0:
                        break;
                    case 1:
                        x = x - gameSpeed;
                        break;
                    case 2:
                        x = x - gameSpeed;
                        y = y - gameSpeed;
                        break;
                    case 3:
                        x = x - gameSpeed;
                        y = y + gameSpeed;
                        break;
                    case 4:
                        x = x + gameSpeed;
                        break;
                    case 5:
                        x = x + gameSpeed;
                        y = y - gameSpeed;
                        break;
                    case 6:
                        x = x + gameSpeed;
                        y = y + gameSpeed;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}




