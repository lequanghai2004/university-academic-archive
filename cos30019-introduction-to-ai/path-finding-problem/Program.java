import java.io.FileReader;
import java.io.BufferedReader;
import java.util.function.Consumer;
import java.util.Comparator;
import java.util.HashMap;
import java.util.Map;
import java.util.PriorityQueue;
import java.util.Queue;

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
            for (Path path : currentState.locations
                .get(currentState.locations.size() - 1).adjacentLocs)
            {

                nextState = new Solution(currentState);
                nextState.Travel(path);
                queue.add(nextState);
            }

            currentState = queue.poll();

        } while (currentState.locations
            .get(currentState.locations.size() - 1) != dstLoc);

        currentState.print();
    }

    private static Map<String, Location> readData(String[] args)
    {
        Map<String, Location> locations = new HashMap<>();

        readFile("./src/assets/locations.csv", (data) ->
        {
            String[] values = data.split(",");
            locations.put(values[0],
                new Location(values[0], Float.parseFloat(values[1])));
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
        try (BufferedReader csvReader = new BufferedReader(
            new FileReader(fileName)))
        {
            csvReader.lines().forEach(processFunc);
        } catch (Exception e)
        {
            e.printStackTrace();
        }
    }
}

class SolutionComparator implements Comparator<Solution>
{

    @Override
    public int compare(Solution s1, Solution s2)
    {
        return s1.costEstimation < s2.costEstimation ? -1 : 1;
        // s1 is then priority
    }
}