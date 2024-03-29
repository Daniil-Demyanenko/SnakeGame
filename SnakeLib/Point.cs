﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLib;
public record Point
{
    public int X { get; set; }
    public int Y { get; set; }

    /// <summary>
    /// Существует ради одной цели - быть жалким и ничтожным типом данных, всёго лишь точкой на поле. Его никто не ценит, но парень он полезный.
    /// </summary>
    /// <param name="x">Координата Хы</param>
    /// <param name="y">Координата Ыгрек</param>
    public Point(int x, int y) => (X, Y) = (x, y);
}