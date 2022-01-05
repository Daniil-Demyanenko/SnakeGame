namespace SnakeLib;

public class Area
{
    public int W, H;
    public Point Apple;
    public Snake snake = new Snake();
    private Random RndPoint = new Random();
    readonly Point AreaCenter;

    public Area(int W, int H)
    {
        this.W = W; this.H = H;
        AreaCenter = new Point(W / 2, H / 2);
    }

    public void add_apple()
    {
        Apple = new Point(RndPoint.Next(W), RndPoint.Next(H));
        if (Apple.x == AreaCenter.x || Apple.y == AreaCenter.y) Apple.x++;


    }
     

    /// <summary>
    /// Содержит ли змейка точку
    /// </summary>
    /// <param name="point">точка</param>
    /// <returns></returns>
    public bool SnakeIsContain(Point point)
    {
        foreach (Point p in snake.SnakePos)
            if (p.x == point.x && p.y == point.y) return true;
        
        return false;
    }
}

