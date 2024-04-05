public class State extends Position
{
    public State parent;
    public String direction;

    public int eval = Integer.MAX_VALUE - 1;
    public int depth = 1;

    public State(int x, int y)
    {
        super(x, y);
    }

    public State(int x, int y, int d)
    {
        this(x, y);
        depth = d;
    }

    public State(int x, int y, State prevState)
    {
        this(x, y);
        parent = prevState;
        depth = prevState.depth + 1;
    }

    public int getPathCost()
    {
        return depth;
    }

    @Override public String toString()
    {
        return "State" + (column + row * 11) + "{" + column + "-" + row
            + "-cost=" + eval + "}";
    }
}
