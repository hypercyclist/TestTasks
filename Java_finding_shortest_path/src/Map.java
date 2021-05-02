public class Map
{
    public char[][] map;
    private Size mapSize;
    
    public Map(char[][] _map)
    {
        if(_map == null)
        {
            return;
        }
        map = _map;
        mapSize = new Size(map[0].length, map.length);
    }

    public char[][] toCharArray()
    {
        return map;
    }

    public void printMap()
    {
        if(map == null)
        {
            System.out.println("null");
            return;
        }
        for(int j = 0; j < mapSize.height; j++)
        {
            for (int k = 0; k < mapSize.width; k++)
            {
                System.out.print(map[j][k]);
            }
            System.out.println("");
        }
    }

    public Point findPosition(char _object)
    {
        Point objectPosition = new Point();
        for(int i = 0; i < mapSize.height; i++)
        {
            int x = new String(map[i]).indexOf(_object);
            if(x != -1)
            {
                objectPosition.y = i;
                objectPosition.x = x;
                break;
            }
        }
        return objectPosition;
    }

    public int isPointClear(Point _point)
    {
        if (_point.y < 0 || _point.y >= mapSize.height
         || _point.x < 0 || _point.x >= mapSize.width)
        {
            return 0;
        }
        int status;
        switch (map[_point.y][_point.x])
        {
            // case 'o':
            case '.': status = 1; break;
            case 'X': status = 2; break;
            default: status = 0; break;
        }
        return status;
    }

    public void setNodePathToMap(MapNode _node)
    {
        MapNode parentNode = _node;
        map[_node.position.y][_node.position.x] = '+';
        while (true)
        {
            if(parentNode.parentNode == null)
            {
                return;
            }
            map[parentNode.position.y][parentNode.position.x] = '+';
            parentNode = parentNode.parentNode;
        }
    }
}
