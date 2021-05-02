public class EscapePath implements RouteFinder
{
    @Override
    public char[][] findRoute(char[][] _map)
    {
        Map map = new Map(_map);
        Point robotPosition = map.findPosition('@');
        Point escapePostion = map.findPosition('X');
        MapGraph mapGraph = new MapGraph();
        map = mapGraph.processTree(map, robotPosition, escapePostion);
        if(map != null)
        {
            return map.toCharArray(); 
        }
        return null;
    }
}
