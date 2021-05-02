import java.util.ArrayList;



public class Main
{
    public static void main(String[] args)
    {
        ArrayList<Map> maps = new ArrayList<Map>();
        MapsParser.parseMapsFile(maps, "maps.txt");

        EscapePath escapePath = new EscapePath();

        for (int i = 0; i < maps.size(); i++)
        {
            Map map = new Map( escapePath.findRoute(maps.get(i).toCharArray()) );
            map.printMap();
            System.out.println("");
        }
    }
}
