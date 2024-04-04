import java.io.FileReader;
import java.lang.reflect.Constructor;
import java.io.BufferedReader;

public class MapGenerator
{
    private static String fileName;
    private static String strategyName;

    public MapGenerator()
    {}

    public static void print()
    {
        System.out.println("Map input file name: " + fileName);
        System.out.println("Method: " + strategyName);
    }

    public static Map createMapFromFileInput(String file, String strategy)
    {
        fileName = file;
        strategyName = strategy;

        try (BufferedReader reader = new BufferedReader(
            new FileReader(fileName)))
        {
            String line;
            int[] coordinate;

            // read map size
            if ((line = reader.readLine()) == null)
                return null;
            coordinate = readCoordinate(line);
            int noOfRows = coordinate[0];
            int noOfColumns = coordinate[1];

            // read initial state
            if ((line = reader.readLine()) == null)
                return null;
            coordinate = readCoordinate(line);
            State initState = new State(coordinate[0], coordinate[1]);

            // read goal state
            if ((line = reader.readLine()) == null)
                return null;
            String[] data = line.split(" \\| ");
            State[] goalStates = new State[data.length];

            for (int i = 0; i < data.length; i++)
            {
                coordinate = readCoordinate(data[i]);
                goalStates[i] = new State(coordinate[0], coordinate[1]);
            }

            // obtain the strategy class correspondingly to arg[1]
            Class<?> typeName = Class.forName(strategyName + "Strategy");
            if (!SearchStrategy.class.isAssignableFrom(typeName))
                return null;
            @SuppressWarnings("unchecked")
            Constructor<SearchStrategy> constructor = ((Class<SearchStrategy>)typeName)
                .getConstructor(Map.class);

            // create Map instance with a valid strategy
            Map map = new Map(noOfRows, noOfColumns, initState, goalStates,
                constructor);

            // read walls cordination and size
            while ((line = reader.readLine()) != null)
            {
                coordinate = readCoordinate(line);
                map.addWall(new Wall(coordinate[0], coordinate[1],
                    coordinate[2], coordinate[3]));
            }

            return map;
        }
        catch (Exception e)
        {
            e.printStackTrace();
            return null;
        }
    }

    private static int[] readCoordinate(String line)
    {
        String[] data = line.substring(1, line.length() - 1).split(",");
        int[] result = new int[data.length];

        for (int i = 0; i < result.length; i++)
            result[i] = Integer.parseInt(data[i]);

        return result;
    }
}
