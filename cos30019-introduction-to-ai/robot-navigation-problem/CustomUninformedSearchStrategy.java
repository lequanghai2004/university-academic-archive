import java.util.*;

public class CustomUninformedSearchStrategy extends SearchStrategy
{
    public CustomUninformedSearchStrategy(Map map)
    {
        super(map);
    }

    @Override public void execute()
    {
        // create frontier queue, since the use of a stack is theoretically
        // correct but will make it impossible to memorize the path
        List<State> frontierStates = new ArrayList<>();
        // create storing structure with constant key checking time
        // advancement from DFS: the structure allow access to state to compare
        // for best cost path
        HashMap<Position, State> visitedStates = new HashMap<>();
        // create the stack for storing current path branch
        Stack<State> travelStack = new Stack<>();

        int depth = 0;
        int maxDepth = 10;
        // add initial state to be the first state to explore
        frontierStates.add(map.initState);
        visitedStates.put(map.initState, map.initState);

        while (!frontierStates.isEmpty())
        {
            // check the first state in the queue
            State exploringState = frontierStates.remove(0);
            travelStack.push(exploringState);

            while (!travelStack.isEmpty())
            {
                State currentState = travelStack.peek();
                map.print(currentState, visitedStates);

                // return if the state is the goal
                if (isGoal(currentState))
                    return;

                // try other path is goal not found after some exploration
                if (depth == maxDepth)
                {
                    frontierStates.add(currentState);
                    travelStack.pop();
                    depth--;
                    currentState = travelStack.peek();
                }

                // else add successors to queue, waiting to be explored
                List<State> successors = successorGenerator
                    .generate(currentState);
                boolean foundNewPath = false;
                for (State state : successors)
                {
                    // add to wait list is not visited
                    if (!visitedStates.containsKey(state))
                    {
                        travelStack.push(state);
                        depth++;

                        visitedStates.put(new Position(state), state);
                        foundNewPath = true;
                        break;
                    }

                    // if the same state has been met, compare for shortest path
                    if (visitedStates.get(state).depth > state.depth)
                    {
                        travelStack.push(state);
                        depth++;

                        visitedStates.put(state, state);
                        foundNewPath = true;
                        break;
                    }
                }

                // get back if no further path is found
                if (!foundNewPath)
                {
                    travelStack.pop();
                    depth--;
                }
            }

            System.out.println("Goal State Not Found!");
        }
    }
}
