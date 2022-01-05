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
        static Area area = new Area(20, 20);
        static void Main()
        {
            //area.snake.SnakePos = new List<Point>({ Point(1,1)});
            while(true)
            {

                Move();
                Print(area.H, area.W);
                Thread.Sleep(700);
            }
        }
        static void Print(int h, int w)
        {
            for (int i = 0; i < h+2; i++)
            {
                if (i == 0 || i == h+1)
                {
                    for (int j = 0; j < w; j++)
                    {
                        Wall.Print("##");
                    }
                    WriteLine();
                    continue;
                }
                for (int s = 0; s < w; s++)
                {
                    if (s == 0) { Wall.Print("##"); }
                    else if (s == w-1) { Wall.PrintLine("##"); break; }
                    else Write("  ");
                }
            }
            
        }
        static void Move()
        {

        }

    }
}
