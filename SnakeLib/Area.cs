﻿namespace SnakeLib;
/// <summary>
/// Класс для всего происходящего на поле.
/// </summary>

public class Area
{
    public int W, H;
    public Point Apple;
    public List<Point> Snake = new List<Point>();
    private Direction ActDirection;
    private Random rand = new Random();
    readonly Point AreaCenter;

    /// <summary>
    /// Создаёт поле. Является экземпляром класса Area.
    /// </summary>
    /// <param name="W">Ширина поля.</param>
    /// <param name="H">Высота поля</param>
    public Area(int W, int H)
    {
        ActDirection = Direction.Up;

        this.W = W; this.H = H;
        AreaCenter = new Point(W / 2, H / 2);
        Add_apple();
    }

    /// <summary>
    /// Добавляет яблоко на поле.
    /// </summary>
    public void Add_apple()
    {        
       do Apple = new Point(rand.Next(W), rand.Next(H));
       while(!Snake.Contains(Apple));
    }


}
/// <summary>
/// Перечисление направлений движения. 
/// </summary>
public enum Direction
{
    Up,
    Down,
    Left,
    Right
}