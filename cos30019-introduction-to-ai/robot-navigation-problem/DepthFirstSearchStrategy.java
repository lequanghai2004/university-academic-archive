import java.util.*;

public class DepthFirstSearchStrategy extends SearchStrategy
{
    public DepthFirstSearchStrategy(Map map)
    {
        super(map);
    }

    @Override public void execute()
    {
        // create frontier queue, since the use of a stack is theoretically
        // correct but will make it impossible to memorize the path
        List<State> frontierStates = new ArrayList<>();
        // create storing structure with constant key checking time
        Set<Position> visitedStates = new HashSet<>();
        // create the stack for storing current path branch
        Stack<State> travelStack = new Stack<>();
        // int count = 0;

        // add initial state to be the first state to explore
        frontierStates.add(map.initState);
        visitedStates.add(map.initState);

        while (!frontierStates.isEmpty())
        {
            // check the first state in the queue
            State exploringState = frontierStates.remove(0);
            travelStack.push(exploringState);

            while (!travelStack.isEmpty())
            {
                // count++;
                State currentState = travelStack.peek();
                map.print(currentState, visitedStates);

                // return if the state is the goal
                if (isGoal(currentState))
                {
                    // System.out.println(count);
                    return;
                }

                // else add successors to queue, waiting to be explored
                List<State> successors = successorGenerator
                    .generate(currentState);
                boolean foundNewPath = false;
                for (State state : successors)
                {
                    if (!visitedStates.contains(state))
                    {
                        travelStack.push(state);
                        visitedStates.add(state);
                        foundNewPath = true;
                        break;
                    }
                }

                // get back if no further path is found
                if (!foundNewPath)
                {
                    travelStack.pop();
                }
            }
        }

        System.out.println("No solution found");
    }
}