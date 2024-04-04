public class State
{
    Jug[] jugs;

    public State(int j1Level, int j2Level)
    {
        jugs = new Jug[]
        { new Jug(3, j1Level), new Jug(5, j2Level) };
    }

    public State(State that)
    {
        int len = that.jugs.length;
        jugs = new Jug[len];
        for (int i = 0; i < len; i++)
        {
            jugs[i] = new Jug(that.jugs[i]);
        }
    }

    public boolean Compare(State otherState)
    {
        if (jugs.length != otherState.jugs.length)
        {
            return false;
        }

        for (int i = 0; i < jugs.length; i++)
        {
            if (jugs[i].getActualLevel() != otherState.jugs[i].getActualLevel())
            {
                return false;
            }
        }

        return true;
    }

    public void Update(Action action, int index)
    {
        // System.out.println(action.name());

        Jug chosenJug = jugs[index];
        switch (action)
        {
        case Empty:
            chosenJug.Empty();
            break;
        case Fill:
            chosenJug.Fill();
            break;
        case Pour:
            Jug otherJug = jugs[1 - index];
            int buffer = Math.min(otherJug.getActualLevel(), chosenJug.getMaxLevel() - chosenJug.getActualLevel());

            chosenJug.Fill(buffer);
            otherJug.Fill(-buffer);
            break;
        default:
            throw new Error();
        }
    }
}
