using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI
{
    public static class BotBuilding
    {
        /* https://www.hackerrank.com/challenges/saveprincess */
        /// <summary>
        /// Play saves princess game, by processing board from the console and outputing the moves required to the Console
        /// </summary>
        /// <remarks>Princess Peach is trapped in one of the four corners of a square grid. You are in the center of the grid and can move one step at a time in any of the four directions. Can you rescue the princess?  </remarks>
        public static void savesPrincessMain()
        {
            int m;

            m = int.Parse(Console.ReadLine());

            String[] grid = new String[m];
            for (int i = 0; i < m; i++)
            {
                grid[i] = Console.ReadLine();
            }

            List<string> moves = displayPathtoPrincess(m, grid);

            foreach (string s in moves)
                Console.WriteLine(s);
        }

        /// <summary>
        /// Determine moves to play the game
        /// </summary>
        /// <returns>List string - lists the moves</returns>
        /// <remarks>Princess Peach is trapped in one of the four corners of a square grid. You are in the center of the grid and can move one step at a time in any of the four directions. Can you rescue the princess?  </remarks>
        public static List<string> displayPathtoPrincess(int n, String[] grid)
        {
            int bX, bY, pX, pY;
            bX = bY = pX = pY = 0;

            for (int i = 0; i < n; i++)
            {
                if (grid[i].Contains("m"))
                {
                    bY = i;
                    bX = grid[i].IndexOf("m");
                }

                //only check first and last row bc only in corners of grid
                if ((i == 0 || i == n - 1) && grid[i].Contains("p"))
                {
                    pY = i;
                    pX = grid[i].IndexOf("p");
                }
            }

            List<string> moves = new List<string>();
            while (bX > pX)
            {
                bX--;
                moves.Add("LEFT");
            }

            while (bX < pX)
            {
                bX++;
                moves.Add("RIGHT");
            }

            while (bY < pY)
            {
                bY++;
                moves.Add("DOWN");
            }

            while (bY > pY)
            {
                bY--;
                moves.Add("UP");
            }

            return moves;
        }
    }
}