using EZInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;




namespace Pac_Man_6
{
    internal class Ghost
    {
        private int x;
        private int y;
        private int stopCheck = 0;
        private char ghostCharacter;
        private string ghostDirection;
        private float ghostSpeed;
        private char previousItem;
        private Grid mazeGrid;
        private float deltaChange;
        private bool stoppingCondition = false;

        public Ghost(int x, int y, char ghostCharacter, string ghostDirection, float ghostSpeed, char previousItem, Grid mazeGrid)
        {
            this.x = x;
            this.y = y;
            this.ghostCharacter = ghostCharacter;
            this.ghostDirection = ghostDirection;
            this.ghostSpeed = ghostSpeed;
            this.previousItem = previousItem;
            this.mazeGrid = mazeGrid;
        }

          public bool isStoppingCondition()
          {
              if (stoppingCondition == false)
             {
           return false;
          }
         return true;
         }


        public Ghost() 
        { }

        public string getDirection()
        {
            return ghostDirection;
        }

        public void setDirection(string ghostDirection)
        {
            this.ghostDirection = ghostDirection;
        }
       
        
        public char getCharacter()
        {
            return ghostCharacter;
        }

        public void removeGhost()
        {
            Console.SetCursorPosition(y, x);
            Console.Write(previousItem);
            if (mazeGrid.maze[x, y].getValue() == 'P')
            {
                mazeGrid.maze[x, y].setValue(' ');
            }
            else
            {
                mazeGrid.maze[x, y].setValue(previousItem);
            }


        }

        public void drawGhost()
        {
            previousItem = mazeGrid.maze[x, y].getValue();
            Console.SetCursorPosition(y, x);
            Console.Write(ghostCharacter);

          if ( mazeGrid.maze[x, y].getValue() == 'P')
                {
                Console.SetCursorPosition(80, 7);
                Console.WriteLine("Game Over! You Touched a Ghost.");
                Console.SetCursorPosition(80, 8);
                Console.WriteLine("Press Space to Close.");

                while(1 != stopCheck)
                {
                    if (Keyboard.IsKeyPressed(Key.Space))
                    {
                        stoppingCondition = true;
                        stopCheck = 1;

                    }
                }


                }


        }






        void setDeltaChangeSpeed()
        {
            deltaChange += ghostSpeed;
        }

        public float getDelta()
        {
            return deltaChange;
        }

        

        public void setDeltaZero()
        {
            deltaChange = 0;
        }

        public void ghostMoveLeft()
        {
            removeGhost();
            y -= 1;
            drawGhost();
        }

        public void ghostMoveRight()
        {
            removeGhost();
            y += 1;
            drawGhost();
        }

        public void ghostMoveUp()
        {
            removeGhost();
            x -= 1;
            drawGhost();
        }

        public void ghostMoveDown()
        {
            removeGhost();
            x += 1;
            drawGhost();
        }

        public void moveHorizontal()
        {
            if (ghostDirection == "Left")
            {
                if (mazeGrid.maze[x, y - 1].getValue() == ' ' || mazeGrid.maze[x, y - 1].getValue() == '.' || mazeGrid.maze[x, y - 1].getValue() == 'P'  || mazeGrid.maze[x, y - 1].getValue() == '*' )
                {
                    ghostMoveLeft();
                }

                else
                {
                    ghostDirection = "Right";
                }



            }

            else if (ghostDirection == "Right")
            {
                if (mazeGrid.maze[x, y + 1].getValue() == ' ' || mazeGrid.maze[x, y + 1].getValue() == '.' || mazeGrid.maze[x, y + 1].getValue() == 'P' || mazeGrid.maze[x, y + 1].getValue() == '*')
                {
                    ghostMoveRight();
                }

                else
                {
                    ghostDirection = "Left";
                }




            }


        }


        public void moveVertical()
        {
            if (ghostDirection == "Up")
            {
                if (mazeGrid.maze[x - 1, y].getValue() == ' ' || mazeGrid.maze[x - 1, y].getValue() == '.' || mazeGrid.maze[x - 1, y].getValue() == 'P' || mazeGrid.maze[x - 1, y].getValue() == '*')
                {
                    ghostMoveUp();
                }

                else
                {
                    ghostDirection = "Down";
                }
            }

           else if (ghostDirection == "Down")
            {
                if (mazeGrid.maze[x + 1, y].getValue() == ' ' || mazeGrid.maze[x + 1, y].getValue() == '.' || mazeGrid.maze[x + 1, y].getValue() == 'P' || mazeGrid.maze[x + 1, y].getValue() == '*')
                {
                    ghostMoveDown();
                }

                else
                {
                    ghostDirection = "Up";
                }
            }


        }

        public int generateRandom()
        {
            Random rand = new Random();
            return rand.Next(0, 4);

        }


        public void moveRandom()
        {
            int random = generateRandom();
            if (random == 0) // left
            {
                if (mazeGrid.maze[x, y - 1].getValue() == '.' || mazeGrid.maze[x, y - 1].getValue() == ' ' || mazeGrid.maze[x, y - 1].getValue() == 'P' || mazeGrid.maze[x, y - 1].getValue() == '*')
                {
                    ghostMoveLeft();
                }

            }

            if (random == 1) // right
            {
                if (mazeGrid.maze[x, y + 1].getValue() == '.' || mazeGrid.maze[x, y + 1].getValue() == ' ' || mazeGrid.maze[x, y + 1].getValue() == 'P' || mazeGrid.maze[x, y + 1].getValue() == '*')
                {
                    ghostMoveRight();
                }

            }


            if (random == 2) // up
            {
                if (mazeGrid.maze[x - 1, y].getValue() == '.' || mazeGrid.maze[x - 1, y].getValue() == ' ' || mazeGrid.maze[x - 1, y].getValue() == 'P' || mazeGrid.maze[x - 1, y].getValue() == '*')
                {
                    ghostMoveUp();
                }

            }




            if (random == 3) // down
            {
                if (mazeGrid.maze[x + 1, y].getValue() == '.' || mazeGrid.maze[x + 1, y].getValue() == ' ' || mazeGrid.maze[x + 1, y].getValue() == 'P' || mazeGrid.maze[x + 1, y].getValue() == '*')
                {
                    ghostMoveDown();
                }



                

            }





           


        }

        public double calculateDistance(Spaces current, Spaces pacmanLocation)
        {
           
           

            double distance = Math.Sqrt((Math.Pow(pacmanLocation.getX() - current.getX(), 2) + (Math.Pow(pacmanLocation.getY() - current.getY(), 2))));


            return distance;
        }


        public void moveSmart()
        {
            Spaces g = new Spaces(ghostCharacter, x, y);
            double[] distance = new double[4] { 1000000, 1000000, 1000000, 1000000 };
            if (mazeGrid.getLeftSpace(g).getValue() == '.' || mazeGrid.getLeftSpace(g).getValue() == ' ' || mazeGrid.getLeftSpace(g).getValue() == 'P' || mazeGrid.getLeftSpace(g).getValue() == '*')
            {
                distance[0] = calculateDistance(mazeGrid.getLeftSpace(g), mazeGrid.playerLocation());
            }

            if (mazeGrid.getRightSpace(g).getValue() == '.' || mazeGrid.getRightSpace(g).getValue() == ' ' || mazeGrid.getRightSpace(g).getValue() == 'P' || mazeGrid.getRightSpace(g).getValue() == '*')
            {
                distance[1] = calculateDistance(mazeGrid.getRightSpace(g), mazeGrid.playerLocation());
            }

            if (mazeGrid.getTopSpace(g).getValue() == '.' || mazeGrid.getTopSpace(g).getValue() == ' ' || mazeGrid.getTopSpace(g).getValue() == 'P' || mazeGrid.getTopSpace(g).getValue() == '*')
            {
                distance[2] = calculateDistance(mazeGrid.getTopSpace(g), mazeGrid.playerLocation());
            }

            if (mazeGrid.getDownSpace(g).getValue() == '.' || mazeGrid.getDownSpace(g).getValue() == ' ' || mazeGrid.getDownSpace(g).getValue() == 'P' || mazeGrid.getDownSpace(g).getValue() == '*')
            {
                distance[3] = calculateDistance(mazeGrid.getDownSpace(g), mazeGrid.playerLocation());
            }

            if (distance[1] > distance[0] && distance[3] > distance[0] && distance[2] > distance[0])
            {
                setDirection("Left");
                moveHorizontal();
            }


           else if (distance[0] > distance[1] && distance[3] > distance[1] && distance[2] > distance[1])
            {
                setDirection("Right");
                moveHorizontal();
            }



          else  if (distance[0] > distance[2] && distance[3] > distance[2] && distance[1] > distance[2])
            {
                setDirection("Up");
                moveVertical();
            }


          else  if (distance[0] > distance[3] && distance[1] > distance[3] && distance[2] > distance[3])
            {
                setDirection("Down");
                moveVertical();
            }

           


        }
        public void moveGhost()
        {
            setDeltaChangeSpeed();
            if (Math.Floor(deltaChange) == 1)
            {
                if (ghostCharacter == 'G')
                {
                    moveHorizontal();
                }
                else if (ghostCharacter == 'O')
                {
                    moveRandom();
                }
                else if (ghostCharacter == 'S')
                {
                    moveVertical();
                }
                else if (ghostCharacter == 'T')
                {
                    moveSmart();
                }
                setDeltaZero();
            }
        }






    }

}