using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLib
{
    public class Snake
    {
        public List<Point> SnakePos = new List<Point>();

        /// <summary>
        /// Содержит ли змейка точку
        /// </summary>
        /// <param name="point">точка</param>
        /// <returns></returns>
        
        public bool IsContainPoint(Point point)
        {
            foreach (Point p in SnakePos)
                if (p.x == point.x && p.y == point.y) return true;

            return false;
        } 
    }
}
