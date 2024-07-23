import java.util.ArrayList;
import java.util.List;

// negative weight
// BFS, DFS, UCS

public class Program
{
    private static State goalState1 = new State(1, 0);
    private static State goalState2 = new State(0, 1);

    public static void main(String[] args)
    {
        // TestArrayList(args);
        // BfsExecute(args);
        DfsExecute(args);
    }

    public static void TestArrayList(String[] args)
    {
        ArrayList<String> colors = new ArrayList<String>()
        {
            {
                add("red");
                add("yellow");
                add("pink");
                add("green");
                remove(0);
            }
        };

        System.out.println(colors.get(0));
        System.out.println(colors.get(1));
        System.out.println(colors.get(2));
    }

    private static void TestState(String[] args)
    {
        State initState = new State(0, 5);
        initState.Update(Action.Pour, 0);
        System.out.println("J1: " + initState.jugs[0].getActualLevel() + ", J2: " + initState.jugs[1].getActualLevel());

        State s1 = new State(0, 1);
        State s2 = new State(0, 1);
        System.out.println(s1.Compare(s2));
    }

    private static void BfsExecute(String[] args)
    {
        State initState = new State(3, 0);
        List<State> states = new ArrayList<State>();
        states.add(initState);

        State currentState = states.get(0);
        while (!(goalState1.Compare(currentState) || goalState2.Compare(currentState)))
        {

            for (Action action : Action.values())
            {
                State newState0 = new State(currentState);
                newState0.Update(action, 0);
                states.add(newState0);
                State newState1 = new State(currentState);
                newState1.Update(action, 1);
                states.add(newState1);
            }

            states.remove(0);
            currentState = states.get(0);

            System.out.println(
                    "J1: " + currentState.jugs[0].getActualLevel() + ", J2: " + currentState.jugs[1].getActualLevel());

            try
            {
                Thread.sleep(0);
            }
            catch (InterruptedException ex)
            {
                Thread.currentThread().interrupt();
            }
        }

    }

    private static void DfsExecute(String[] args)
    {
        State initState = new State(3, 0);

        List<State> traceMap = new ArrayList<State>();
        List<State> visitedStates = new ArrayList<State>();
        visitedStates.add(initState);

        DfsRecurseFunc(initState, visitedStates, traceMap);
    }

    private static void DfsRecurseFunc(State state, List<State> visitedStates, List<State> traceMap)
    {
        System.out.println("J1: " + state.jugs[0].getActualLevel() + ", J2: " + state.jugs[1].getActualLevel());

        if (goalState1.Compare(state) || goalState2.Compare(state))
        {
            return;
        }

        for (Action action : Action.values()) // O(1) since const n = 3
        {
            for (int i = 0; i <= 1; i++) // O(1) since const n = 2;
            {
                State newState = new State(state);
                newState.Update(action, i);

                boolean repeated = false;
                for (State s : visitedStates) // O(n) but can improve with hashmap
                {
                    if (newState.Compare(s))
                    {
                        repeated = true;
                    }
                }

                if (!repeated)
                {
                    visitedStates.add(newState);
                    DfsRecurseFunc(newState, visitedStates, traceMap);
                }

                if (traceMap.size() >= 1)
                {
                    traceMap.remove(traceMap.size() - 1);
                }
            }
        }

        return;
    }
}