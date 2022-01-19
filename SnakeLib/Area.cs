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
    public Point Apple {get; private set;}
    /// <summary>
    /// Координаты Змейки на поле
    /// </summary>
    public List<Point> Snake = new List<Point>();
    /// <summary>
    /// Пока змейка жива = true
    /// </summary>
    public bool SnakeIsLive {get; private set;}
    private Random rand = new Random();
    private Direction ActDirection;

    /// <summary>
    /// Создаёт поле размером W х H
    /// </summary>
    /// <param name="W">Ширина поля.</param>
    /// <param name="H">Высота поля</param>
    public Area(int W, int H)
    {
        this.W = W; this.H = H; // Инициализируем размеры поля
        SnakeIsLive = true;     // Змейка жива...
        Add_apple();            // добавляем яблоко

        ActDirection = Direction.Up; // Начальное направление движения змейки
        
        var AreaCenter = new Point(W / 2, H / 2);
        Snake.Add(AreaCenter);                              // Добавляем змейку
        Snake.Add(new Point(AreaCenter.x, AreaCenter.y+1));
    }

    /// <summary>
    /// Добавляет яблоко на поле.
    /// </summary>
    private void Add_apple()
    {        
       do Apple = new Point(rand.Next(W), rand.Next(H));
       while(Snake.Contains(Apple));
    }

/// <summary>
/// Перемещение в заданном направлении. Если не указано, используется прошлое направление.
/// </summary>
/// <param name="d"></param>
    public void NextStep(Direction d) 
    {
        //TODO: Движение в направлении d
        //Заглушка для отладки:
        Console.WriteLine("# Направление движения: {0}", d.ToString());
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