import java.util.*;

public class BreadthFirstSearchStrategy extends SearchStrategy
{
    public BreadthFirstSearchStrategy(Map map)
    {
        super(map);
    }

    @Override public void execute()
    {
        // create frontier queue
        List<State> exploringStates = new ArrayList<>();
        // create storing structure with constant key checking time
        Set<Position> visitedStates = new HashSet<>();
        // add initial state to be the first state to explore
        exploringStates.add(map.initState);
        // int count = 0;

        while (!exploringStates.isEmpty())
        {
            // check the first state in the queue
            State currentState = exploringStates.remove(0);
            // mark the checking queue as visited
            visitedStates.add(currentState);

            map.print(currentState, visitedStates);
            // count++;

            // return if the state is the goal
            if (isGoal(currentState))
            {
                // System.out.println(count);
                return;
            }

            // else add successors to queue, waiting to be explored
            for (State state : successorGenerator.generate(currentState))
            {
                if (!visitedStates.contains(state))
                {
                    exploringStates.add(state);
                }
            }
        }
    }

    // @Override public void execute()
    // {
    // List<State> exploringStates = new ArrayList<>();
    // HashMap<State, State> parentMap = new HashMap<>();

    // exploringStates.add(map.initState);
    // parentMap.put(map.initState, null);

    // while (!exploringStates.isEmpty())
    // {
    // State currentState = exploringStates.remove(0);
    // if (map.isGoal(currentState))
    // {
    // System.out.println("Found");
    // List<State> path = new ArrayList<>();
    // State tempState = currentState;
    // while (tempState != null)
    // {
    // path.add(tempState);
    // tempState = parentMap.get(tempState);
    // }
    // Collections.reverse(path);
    // System.out.println("Path: " + path);
    // return;
    // }

    // for (State state : successorGenerator
    // .generateSuccessors(currentState))
    // {
    // if (!parentMap.containsKey(state))
    // {
    // exploringStates.add(state);
    // parentMap.put(state, currentState);
    // }
    // }
    // }
    // }
}
