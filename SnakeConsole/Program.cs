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
        static Color Snake = new Color(ConsoleColor.Black, ConsoleColor.Green);
        static Area area = new Area(20, 20);
        static bool WasPressed = false;
        static void Main()
        {
            // #region snake
            // area.Snake = new List<Point>();
            // area.Snake.Add(new Point(2, 2));
            // area.Snake.Add(new Point(3, 2));
            // area.Snake.Add(new Point(4, 2));
            // area.Snake.Add(new Point(5, 2));
            // area.Snake.Add(new Point(6, 2));
            // area.Snake.Add(new Point(6, 3));
            // #endregion

            Random rand = new Random();
            while (true)
            {
                Clear();
                //Move();
                WriteLine("Длинна змейки: " + area.Snake.Count);
                Print(area.H, area.W);
                Thread.Sleep(30);
                Wall.BackText = (ConsoleColor)rand.Next(1, 16);
            }
        }

        //todo: Режим эпилептика, пасхалка
        static void Print(int h, int w)
        {
            //area.Snake.Contains(new Point(s, i));
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
                    else if (s == w + 1) { Wall.PrintLine("  "); break; } //Нафиг брейк?
                    else if (s == area.Apple.X + 1 && i == area.Apple.Y + 1) Apple.Print("  ");
                    else if (area.Snake.Contains(new Point(s - 1, i - 1))) Snake.Print("  ");
                    else Write("  ");
                }
            }

        }
        static void Move()
        {
            if (!Console.KeyAvailable) WasPressed = false;
            if (Console.KeyAvailable && !WasPressed)
            {
                var a = ReadKey(false).Key;
                if (a == ConsoleKey.UpArrow) Write("Up");
                else if (a == ConsoleKey.DownArrow) Write("Down");
                else if (a == ConsoleKey.LeftArrow) Write("Left");
                else if (a == ConsoleKey.RightArrow) Write("Right");
                WasPressed = true;
            }

        }

    }
}
