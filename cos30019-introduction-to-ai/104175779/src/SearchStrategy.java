import java.util.Stack;

/**
 * ISearchStrategy
 */
public abstract class SearchStrategy
{
    protected Map map;
    protected StateSuccessorGenerator successorGenerator;

    public SearchStrategy(Map m)
    {
        map = m;
        successorGenerator = new StateSuccessorGenerator(m);
    }

    public abstract void execute();

    protected boolean isGoal(State state)
    {
        if (!map.isGoal(state))
            return false;
        getResult(state);
        return true;
    }

    protected void getResult(State state)
    {
        Stack<State> pathTrace = new Stack<>();
        while (state != null)
        {
            pathTrace.push(state);
            state = state.parent;
        }
        map.print(pathTrace);
    }
}