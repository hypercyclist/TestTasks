class MapNode
{
    public Point position;
    public MapNode parentNode;

    public MapNode(Point _position, MapNode _parentNode)
    {
        position = _position;
        parentNode = _parentNode;
    }
}