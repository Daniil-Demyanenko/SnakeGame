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
    } 


    public void add_apple()//TODO: Используй нормальное определение ячеек змеи 
    {        
       do Apple = new Point(rand.Next(W), rand.Next(H));
       while(!snake.IsContainPoint(Apple));
    }
    
}

