import java.util.Objects;

public class Position
{
    public int column;
    public int row;

    public Position(int x, int y)
    {
        column = x;
        row = y;
    }

    public Position(Position that)
    {
        column = that.column;
        row = that.row;
    }

    @Override public boolean equals(Object o)
    {
        if (o == null)
            return false;

        if (o instanceof Position)
        {
            Position state = (Position)o;
            return column == state.column && row == state.row;
        }

        return false;
    }

    @Override public int hashCode()
    {
        return Objects.hash(column, row);
    }
}
