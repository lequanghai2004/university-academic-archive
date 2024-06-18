public class Jug
{
    private int maxLevel;
    private int actualLevel;

    public Jug(int maxLevel, int actualLevel)
    {
        this.maxLevel = maxLevel;
        this.actualLevel = actualLevel;
    }

    public Jug(Jug that)
    {
        maxLevel = that.maxLevel;
        actualLevel = that.actualLevel;
    }

    public int getActualLevel()
    {
        return actualLevel;
    }

    public void setActualLevel(int level)
    {
        actualLevel = level;
    }

    public int getMaxLevel()
    {
        return maxLevel;
    }

    public void Empty()
    {
        actualLevel = 0;
    }

    public void Fill()
    {
        actualLevel = maxLevel;
    }

    public void Fill(int fillLevel)
    {
        actualLevel = Math.min(maxLevel, actualLevel + fillLevel);
    }
}
