using System;
using System.Threading;
using System.Collections.Generic;
using SnakeLib;
using Colors;
using static System.Console;

namespace SnakeConsole
{
    class Program
    {
        static Color Wall = new Color(ConsoleColor.Black, ConsoleColor.DarkBlue);
        static Color Apple = new Color(ConsoleColor.Black, ConsoleColor.Red);
        static Area area = new Area(20, 20);
        static void Main()
        {
            #region snake
            area.snake.SnakePos = new List<Point>();
            area.snake.SnakePos.Add(new Point(2, 2));
            area.snake.SnakePos.Add(new Point(3, 2));
            area.snake.SnakePos.Add(new Point(4, 2));
            area.snake.SnakePos.Add(new Point(5, 2));
            area.snake.SnakePos.Add(new Point(6, 2));
            area.snake.SnakePos.Add(new Point(6, 3));
            #endregion
            area.Apple = new Point(19, 19);
            while (true)
            {

                Move();
                Clear();
                WriteLine(area.SnakeIsContain(new Point(3, 8)));
                Print(area.H, area.W);
                Thread.Sleep(700);
            }
        }
        static void Print(int h, int w)
        {
            //area.snake.SnakePos.Contains(new Point(s, i));
            for (int i = 0; i < h + 2; i++)
            {
                if (i == 0 || i == h + 1)
                {
                    for (int j = 0; j < w + 2; j++)
                    {
                        Wall.Print("  ");
                    }
                    WriteLine();
                    continue;
                }
                for (int s = 0; s < w + 2; s++)
                {
                    if (s == 0) { Wall.Print("  "); }
                    else if (s == w + 1) { Wall.PrintLine("  "); break; }
                    else if (s == area.Apple.x + 1 && i == area.Apple.y + 1) Apple.Print("  ");
                    else Write("  ");
                }
            }

        }
        static void Move()
        {

        }

    }
}
