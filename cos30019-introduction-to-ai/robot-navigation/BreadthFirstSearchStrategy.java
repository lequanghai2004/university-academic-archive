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
}
