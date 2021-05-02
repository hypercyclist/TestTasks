class Point
{
    public int x;
    public int y;

    public Point(){}
    public Point(int _x, int _y) 
    {
        x = _x;
        y = _y;
    }

    public boolean equals(Point _position)
    {
        return (x == _position.x) && (y == _position.y) ? true : false;
    }
}
