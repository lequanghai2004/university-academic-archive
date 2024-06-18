import java.io.BufferedReader;
import java.io.FileReader;
import java.util.*;
import java.util.function.Consumer;

public class Program
{
    public static void main(String[] args)
    {
        Map<String, Location> map = readData(args);
        // for (Map.Entry<String, Location> entry : map.entrySet()) {
        // entry.getValue().Print(); }

        Location srcLoc = map.get("Zer");
        Location dstLoc = map.get("Buc");

        Solution currentState = new Solution(srcLoc);
        Queue<Solution> queue = new PriorityQueue<>(new SolutionComparator());

        Solution nextState;

        do
        {
            for (Path path : currentState.locations.get(currentState.locations.size() - 1).adjacentLocs)
            {

                nextState = new Solution(currentState);
                nextState.Travel(path);
                queue.add(nextState);
            }

            currentState = queue.poll();

        } while (Objects.requireNonNull(currentState).locations.get(currentState.locations.size() - 1) != dstLoc);

        currentState.print();
    }

    private static Map<String, Location> readData(String[] args)
    {
        Map<String, Location> locations = new HashMap<>();

        readFile("./src/assets/locations.csv", (data) ->
        {
            String[] values = data.split(",");
            locations.put(values[0], new Location(values[0], Float.parseFloat(values[1])));
        });

        readFile("./src/assets/paths.csv", (data) ->
        {
            String[] values = data.split(",");
            float distance = Float.parseFloat(values[2]);

            Location loc0 = locations.get(values[0]);
            Location loc1 = locations.get(values[1]);

            loc0.AddAdjacentLoc(loc1, distance);
            loc1.AddAdjacentLoc(loc0, distance);
        });

        return locations;
    }

    private static void readFile(String fileName, Consumer<String> processFunc)
    {
        try (BufferedReader csvReader = new BufferedReader(new FileReader(fileName)))
        {
            csvReader.lines().forEach(processFunc);
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }
}