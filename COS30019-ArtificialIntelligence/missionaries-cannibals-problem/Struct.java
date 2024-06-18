public class Struct
{
    public int leftBank[];
    public int rightBank[];
    public boolean isOnLeft;

    float stateCost;
    float pathCost;
    Struct prev;

    public Struct(int[] left, int[] right)
    {
        leftBank = left;
        rightBank = right;
        isOnLeft = true;
        stateCost = stateEval();
        pathCost = 0;
        prev = null;
    }

    public Struct(Struct that)
    {
        leftBank = that.leftBank.clone();
        rightBank = that.rightBank.clone();
        isOnLeft = that.isOnLeft;
        stateCost = stateEval();
        pathCost = that.pathCost + 2;
        prev = that;
    }

    public float stateEval()
    {
        // return (6 - leftBank[0] - leftBank[1]
        // + (leftBank[0] - leftBank[1] <= 1 ? 1 : 0)
        // + (leftBank[0] - leftBank[1] > 0 ? 1 : 0) + (1 / 2 * leftBank[0])
        // + (1 / 3 * leftBank[1]));

        return (leftBank[0] + leftBank[1]);
    }

    public float pathEval()
    {
        return pathCost;
    }

    public boolean update(int[] arg)
    {
        int srcBank[] = isOnLeft ? leftBank : rightBank;
        int dstBank[] = isOnLeft ? rightBank : leftBank;

        srcBank[0] -= arg[0];
        srcBank[1] -= arg[1];
        dstBank[0] += arg[0];
        dstBank[1] += arg[1];

        // Check if the move results in missionaries being outnumbered
        if (srcBank[0] < 0 || srcBank[1] < 0
            || (srcBank[0] > 0 && srcBank[0] < srcBank[1])
            || (dstBank[0] > 0 && dstBank[0] < dstBank[1]))
        {
            return false;
        }

        isOnLeft = !isOnLeft;
        return true;
    }

    public void print()
    {
        System.out.print("cost: " + (pathCost + stateCost) + " - leftM: "
            + leftBank[0] + " - leftC: " + leftBank[1] + "\n");
    }
}
