namespace SnakeLib;

public class Area
{
    public int W, H;
    public Point Apple;
    //public Snake snake = new Snake();
    public Stack<Point> Snake = new Stack<Point>();
    private Random rand = new Random();
    readonly Point AreaCenter;

    public Area(int W, int H)
    {
        this.W = W; this.H = H;
        AreaCenter = new Point(W / 2, H / 2);
        add_apple();
    } 

    //adding apple on the area 
    public void add_apple()
    {        
       do Apple = new Point(rand.Next(W), rand.Next(H));
       while(!Snake.Contains(Apple));
    }
    
}

