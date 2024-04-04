import java.util.Comparator;

public class Wall
{
    public int left;
    public int top;
    public int right;
    public int bottom;

    public Wall(int l, int t, int width, int height)
    {
        left = l;
        top = t;
        right = left + width - 1;
        bottom = top + height - 1;
    }

    public boolean isIn(State state)
    {
        return state.column >= left && state.column <= right && state.row >= top
            && state.row <= bottom;
    }

    public boolean isIn(int x, int y)
    {
        return x >= left && x <= right && y >= top && y <= bottom;
    }

    public String toString()
    {
        return "Wall [left=" + left + ", top=" + top + ", right=" + right
            + ", bottom=" + bottom + "]";
    }
}

class WallComparator implements Comparator<Wall>
{

    @Override public int compare(Wall wall1, Wall wall2)
    {
        return Integer.compare(wall1.left, wall2.left) == 0
            ? Integer.compare(wall1.top, wall2.top)
            : Integer.compare(wall1.left, wall2.left);
    }
}