using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pac_Man_6;
using System.Threading.Tasks;




namespace Pac_Man_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pathMaze = "maze.txt";
            Grid mazeGrid = new Grid(24, 71, pathMaze);
            PacMan player = new PacMan(9, 32, mazeGrid);
            Ghost g1 = new Ghost(16, 39, 'G', "Left", 0.1F, ' ', mazeGrid);
            List<Ghost> enemies = new List<Ghost>();
            enemies.Add(g1);


            mazeGrid.draw();
            player.drawPacMan();

            bool gameRunning = true;

            while (gameRunning)
            {
                Thread.Sleep(90); //tick rate
                player.printScore();
                player.removePacMan();
                player.movePacMan();
                player.drawPacMan();

                foreach (Ghost g in enemies)
                {
                    g.removeGhost();
                    g.moveGhost();
                    g.drawGhost();

                }

                if (player.isStoppingCondition() == false)
                {
                    gameRunning = false;
                }
            }

            Console.ReadKey();
        }
    }
}