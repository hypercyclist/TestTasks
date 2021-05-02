import java.util.ArrayList;



class MapGraph
{
    private Map map;
    private ArrayList<MapNode> openNodes;
    private ArrayList<MapNode> closedNodes;
    boolean solutionFounded;



    public MapGraph()
    {
        map = null;
        openNodes = new ArrayList<MapNode>();
        closedNodes = new ArrayList<MapNode>();
        solutionFounded = false;
    }
    
    public Map processTree(Map _map, Point _start, Point _end)
    {
        map = _map;
        openNodes.add(new MapNode(_start, null));
        while (!openNodes.isEmpty() && !solutionFounded)
        {
            MapNode node = openNodes.get(0);
            Point position = node.position;
            closedNodes.add(node);
            openNodes.remove(0);
            checkDirectionAndAddNode(new Point(position.x + 1, position.y), node);
            checkDirectionAndAddNode(new Point(position.x - 1, position.y), node);
            checkDirectionAndAddNode(new Point(position.x, position.y + 1), node);
            checkDirectionAndAddNode(new Point(position.x, position.y - 1), node);
        }
        if (solutionFounded)
        {
            map.setNodePathToMap( closedNodes.get(closedNodes.size() - 1) );
        }
        else
        {
            map = null;
        }
        openNodes.clear();
        closedNodes.clear();
        solutionFounded = false;
        return map;
    }

    public void checkDirectionAndAddNode(Point _position, MapNode _node)
    {
        switch (map.isPointClear(_position))
        {
            case 0: return;
            case 2: solutionFounded = true; return;
        }
        boolean nodeExist = false;
        for (int i = 0; i < closedNodes.size(); i++)
        {
            if (_position.equals(closedNodes.get(i).position))
            {   
                nodeExist = true;
            }
        }
        for (int i = 0; i < openNodes.size(); i++)
        {
            if (_position.equals(openNodes.get(i).position))
            {   
                nodeExist = true;
            }
        }
        if (!nodeExist)
        {
            openNodes.add(new MapNode(_position, _node));
            // map.map[_position.y][_position.x] = 'o';
        }
    }
}