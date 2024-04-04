import java.util.ArrayList;
import java.util.List;

public class Location {
    public String name;
    public boolean visited;
    public List<Path> adjacentLocs;
    public float costEstimation;

    public Location(String n, float c) {
        name = n;
        costEstimation = c;

        visited = false;
        adjacentLocs = new ArrayList<Path>();
    }

    public void AddAdjacentLoc(Location loc, float distance) {
        adjacentLocs.add(new Path(loc, distance));
    }

    public void pisit() {
        visited = true;
    }

    public void print() {
        String result = name + ": ";

        for (Path path : adjacentLocs) {
            result += path.dstLoc.name + "-" + path.distance + " ; ";
        }

        System.out.println(result);
    }
}
