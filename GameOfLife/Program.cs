using System;
using System.Threading;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Random chaos = new Random();
            int gridSize = chaos.Next(20, 40);
            int AliveCell = 1;
            int DeadCell = 0;

            int[,] gridRead = new int[gridSize, gridSize];
            int[,] gridWrite = new int[gridSize, gridSize];


            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    gridRead[y, x] = chaos.Next(0, 2);
                }

            }

            DrawGrid(gridSize, AliveCell, gridRead);

            while (true)
            {
                LifeCalculations(gridSize, AliveCell, DeadCell, gridRead, gridWrite);
                gridRead = gridWrite;
                gridWrite = new int[gridSize, gridSize];

                Console.WriteLine();

                DrawGrid(gridSize, AliveCell, gridRead);
                Thread.Sleep(250);
            }
        }

        private static void LifeCalculations(int gridSize, int AliveCell, int DeadCell, int[,] gridRead, int[,] gridWrite)
        {
            for (int y = 1; y < gridSize - 1; y++)
            {
                for (int x = 1; x < gridSize - 1; x++)
                {
                    int neighborSum = gridRead[y + 1, x] +
                        gridRead[y + 1, x + 1] +
                        gridRead[y, x + 1] +
                        gridRead[y - 1, x + 1] +
                        gridRead[y - 1, x] +
                        gridRead[y - 1, x - 1] +
                        gridRead[y, x - 1] +
                        gridRead[y + 1, x - 1];

                    if (neighborSum == 3)
                    {
                        gridWrite[y, x] = AliveCell;
                    }
                    else if (neighborSum == 2)
                    {
                        gridWrite[y, x] = gridRead[y, x];
                    }
                    else
                    {
                        gridWrite[y, x] = DeadCell;
                    }
                }
            }
        }

        private static void DrawGrid(int gridSize, int AliveCell, int[,] grid)
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 1; y < gridSize - 1; y++)
            {
                for (int x = 1; x < gridSize - 1; x++)
                {
                    if (grid[y, x] == AliveCell)
                    {
                        Console.Write("■ ");
                    }
                    else
                    {
                        Console.Write("· ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
