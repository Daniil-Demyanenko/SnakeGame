namespace SnakeLib;

/// <summary>
/// Класс для всего происходящего на поле.
/// </summary>
public class Area
{
    public int W, H;

    /// <summary>
    /// Координаты яблока на поле
    /// </summary>
    public Point Apple { get; private set; }

    /// <summary>
    /// Координаты Змейки на поле
    /// </summary>
    public List<Point> Snake = new List<Point>();

    /// <summary>
    /// Пока змейка жива = true
    /// </summary>
    public bool SnakeIsLive { get; private set; }

    /// <summary>
    /// Игра окончена
    /// </summary>
    public bool EndOfGame { get; private set; }

    private Random _rand = new Random();
    private Direction ActDirection;

    /// <summary>
    /// Создаёт поле размером W х H
    /// </summary>
    /// <param name="W">Ширина поля.</param>
    /// <param name="H">Высота поля</param>
    public Area(int W, int H)
    {
        this.W = W;
        this.H = H; // Инициализируем размеры поля
        SnakeIsLive = true; // Змейка жива...
        EndOfGame = false;
        Apple = NewApplePosition(); // добавляем яблоко

        ActDirection = Direction.Up; // Начальное направление движения змейки

        var AreaCenter = new Point(W / 2, H / 2);
        Snake.Add(AreaCenter); // Добавляем змейку
        // Snake.Add(new Point(AreaCenter.X, AreaCenter.Y + 1));
    }

    /// <summary>
    /// Добавляет яблоко на поле.
    /// </summary>
    private Point NewApplePosition()
    {
        Point apple;
        do apple = new Point(_rand.Next(W), _rand.Next(H));
        while (Snake.Contains(apple));

        return apple;
    }

    /// <summary>
    /// Перемещение в заданном направлении. 
    /// </summary>
    /// <param name="d"></param>
    public void NextStep(Direction d)
    {
        Point next = d switch
        {
            Direction.Up => new Point(Snake.Last().X, Snake.Last().Y - 1),
            Direction.Down => new Point(Snake.Last().X, Snake.Last().Y + 1),
            Direction.Left => new Point(Snake.Last().X - 1, Snake.Last().Y),
            Direction.Right => new Point(Snake.Last().X + 1, Snake.Last().Y),
        };

        next.X = next.X > W - 1 ? next.X = 0 : next.X;
        next.X = next.X < 0 ? next.X = W - 1 : next.X;
        next.Y = next.Y > H - 1 ? next.Y = 0 : next.Y;
        next.Y = next.Y < 0 ? next.Y = H - 1 : next.Y;

        if (Snake.Contains(next))
        {
            (SnakeIsLive, EndOfGame) = (false, true);
            return;
        }

        if (Apple == next)
        {
            Snake.Add(next);
            Apple = NewApplePosition();
        }
        else
        {
            Snake.Add(next);
            Snake.Remove(Snake.First());
        }

        if (Snake.Count >= W * H - 1)
        {
            EndOfGame = true;
            return;
        }
        
        //Заглушка для отладки:
        Console.WriteLine("# Направление движения: {0} - {1}", d.ToString(), next.ToString());
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