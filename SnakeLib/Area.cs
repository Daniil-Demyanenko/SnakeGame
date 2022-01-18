namespace SnakeLib;
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
    public bool SnaleIsLive {get; private set;}
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
        SnaleIsLive = true;
        AreaCenter = new Point(W / 2, H / 2);
        Add_apple();
        
        Snake.Add(AreaCenter);
        Snake.Add(new Point(AreaCenter.x, AreaCenter.y));
    }

    /// <summary>
    /// Добавляет яблоко на поле.
    /// </summary>
    public void Add_apple()
    {        
       do Apple = new Point(rand.Next(W), rand.Next(H));
       while(Snake.Contains(Apple));
    }

    public void NextStep(Direction d) 
    {
        //TODO: Движение в направлении d
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