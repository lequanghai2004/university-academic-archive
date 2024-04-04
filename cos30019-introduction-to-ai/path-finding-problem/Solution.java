import java.util.ArrayList;
import java.util.List;

public class Solution
{
    public List<Location> locations;
    public float pathCost;
    public float costEstimation;

    public Solution(Location srcLoc)
    {
        locations = new ArrayList<>();
        locations.add(srcLoc);

        pathCost = 0;
        costEstimation = srcLoc.costEstimation;
    }

    public Solution(Solution that)
    {
        locations = new ArrayList<>(that.locations);
        pathCost = that.pathCost;
        costEstimation = that.costEstimation;
    }

    public void Travel(Path path)
    {
        locations.add(path.dstLoc);
        pathCost += path.distance;
        costEstimation = pathCost + path.dstLoc.costEstimation;
    }

    public void print()
    {
        for (Location location : locations)
        {
            System.out.println(location.name);
        }
    }
}
