namespace SnakeLib;

public class Area
{
    public int W, H;
    public Point Apple;
    public Snake snake = new Snake();
    private Random rand = new Random();
    readonly Point AreaCenter;

    public Area(int W, int H)
    {
        this.W = W; this.H = H;
        AreaCenter = new Point(W / 2, H / 2);

        //TODO: Нормальный спавн яблока
        Apple = new Point(rand.Next(W/2),rand.Next(H/2));
    } 

    public void add_apple()//TODO: Используй нормальное определение ячеек змеи 
    {
        Apple = new Point(rand.Next(W), rand.Next(H));
        if (Apple.x == AreaCenter.x || Apple.y == AreaCenter.y) Apple.x++;


    }
    
}

