using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;




namespace Pac_Man_6
{
    internal class PacMan
    {
        private int x;
        private int y;
        private int score;
        private Grid mazeGrid;
        private bool stoppingCondition = false;
        private int stopcheck = 0;

        public PacMan(int x, int y, Grid mazeGrid)
        {
            this.x = x;
            this.y = y;
            this.mazeGrid = mazeGrid;
        }

        public void drawPacMan()
        {
            Console.SetCursorPosition(y, x);
            Console.Write("P");
            mazeGrid.maze[x, y].setValue('P');
        }

        public void removePacMan()
        {
            Console.SetCursorPosition(y, x);
            Console.Write(" ");
            mazeGrid.maze[x, y].setValue(' ');


        }


        public void leftSide()
        {
            removePacMan();
            y -= 1;
        }

        public void rightSide() 
        
        {
            removePacMan();
            y += 1;
        }

        public void upSide()
        {
            removePacMan();
            x -= 1;
        }

        public void downSide()
        {
            removePacMan();
            x += 1;
        }


        public void moveLeftDirection(Ghost g)
        {
            if (mazeGrid.maze[x, y - 1].getValue() == ' ' || mazeGrid.maze[x, y - 1].getValue() == '.' || mazeGrid.maze[x, y - 1].getValue() == '*')
            {

                leftSide();
              if (mazeGrid.maze[x, y].getValue() == '.')
                {
                    score += 1;
                }
              else if(mazeGrid.maze[x, y].getValue() == '*')
                {
                    score += 50;
                }


            }

        }


        public void moveRightDirection(Ghost g)
        {
            if (mazeGrid.maze[x, y + 1].getValue() == ' ' || mazeGrid.maze[x, y + 1].getValue() == '.' || mazeGrid.maze[x, y + 1].getValue() == '*')
            {

                rightSide();
                 if (mazeGrid.maze[x, y].getValue() == '.')
                {
                    score += 1;
                }
                else if (mazeGrid.maze[x, y].getValue() == '*')
                {
                    score += 50;
                }


            }

        }



        public void moveUpDirection(Ghost g)
        {
            if (mazeGrid.maze[x - 1, y].getValue() == ' ' || mazeGrid.maze[x - 1, y].getValue() == '.' || mazeGrid.maze[x - 1, y].getValue() == '*')
            {

                upSide();
                if (mazeGrid.maze[x, y].getValue() == '.')
                {
                    score += 1;
                }

                else if (mazeGrid.maze[x, y].getValue() == '*')
                {
                    score += 50;
                }


            }

        }


        public void moveDownDirection(Ghost g)
        {
            if (mazeGrid.maze[x + 1, y].getValue() == ' ' || mazeGrid.maze[x + 1, y].getValue() == '.' || mazeGrid.maze[x + 1, y].getValue() == '*')
            {

                downSide();
               
                
                if (mazeGrid.maze[x, y].getValue() == '.')
                {
                    score += 1;
                }

                else if (mazeGrid.maze[x, y].getValue() == '*')
                {
                    score += 50;
                }

            }



        }




        public void printScore()
        {
            Console.SetCursorPosition(80, 5);
            Console.WriteLine("Score : {0}", score);
            Console.SetCursorPosition(80, 6);
            Console.WriteLine("Goal  : 400");
            Console.SetCursorPosition(80, 7);
            Console.WriteLine("Player: P");
            Console.SetCursorPosition(80, 8);
            Console.WriteLine("Enemies: G, O, S, T");

            Console.SetCursorPosition(80, 15);
            Console.WriteLine("Move with Arrow Keys, Esc to Quit");
            Console.SetCursorPosition(80, 16);
            Console.WriteLine(". = 1 Point, * = 50 Points");


            if (score > 399)

            {
                Console.SetCursorPosition(80, 10);
                Console.WriteLine("You win! press Space To Exit.");
                while (1 != stopcheck)
                {
                    if (Keyboard.IsKeyPressed(Key.Space))
                    {
                        stoppingCondition = true;
                        stopcheck = 1;
                    }
                }

              
            }

        }

        public bool pacmanStop()
        {
            
            {
                if (stoppingCondition == false)
                {
                    return false;
                }
                return true;
            }
        }

        public void movePacMan()
        {
            Ghost g = new Ghost();
            {
              if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    moveUpDirection(g);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    moveDownDirection(g);
                }

                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    moveLeftDirection(g);
                }

                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    moveRightDirection(g);
                }

                if (Keyboard.IsKeyPressed(Key.Escape))
                {
                    stoppingCondition = true;
                }



            }
        }


    }


}