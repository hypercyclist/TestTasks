import java.util.ArrayList;
import org.w3c.dom.*;
import javax.xml.parsers.*;
import java.io.*;



public class MapsParser
{
    private MapsParser(){}

    public static void parseMapsFile(ArrayList<Map> _maps, String _file)
    {
        try
        {
            File inputFile = new File(_file);
            DocumentBuilderFactory dbFactory = DocumentBuilderFactory.newInstance();
            DocumentBuilder dBuilder = dbFactory.newDocumentBuilder();
            Document document = dBuilder.parse(_file);
            document.getDocumentElement().normalize();

            NodeList list = document.getElementsByTagName("map");
            for (int i = 0; i < list.getLength(); i++)
            {
                Node node = list.item(i);
                Element element = (Element)node;
                System.out.println("Parsing: " + element.getAttribute("name"));
                
                String mapString = element.getTextContent();
                mapString = mapString.replaceAll(" ", "");
                int arrayWidth = mapString.indexOf('\n', 2) - 1;
                mapString = mapString.replaceAll("\n", "");
                int arrayHeight = mapString.length() / arrayWidth;
                char[][] mapArray = new char[arrayHeight][arrayWidth];
                for(int j = 0; j < arrayHeight; j++)
                {
                    for (int k = 0; k < arrayWidth; k++)
                    {
                        mapArray[j][k] = mapString.charAt(arrayWidth * j + k);
                    }
                }
                _maps.add( new Map(mapArray) );
            }
        }
        catch (Exception exception)
        {
            exception.printStackTrace();
        }
    }
}
