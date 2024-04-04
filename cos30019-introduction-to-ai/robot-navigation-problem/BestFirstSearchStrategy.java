import java.util.Comparator;
import java.util.HashMap;
import java.util.List;
import java.util.PriorityQueue;

public class BestFirstSearchStrategy extends SearchStrategy
{
    public BestFirstSearchStrategy(Map map)
    {
        super(map);
    }

    @Override public void execute()
    {
        // create a min heap, the order is determined by the heuristic
        // evaluation of the state in the search tree
        PriorityQueue<State> priorityQueue = new PriorityQueue<>(
            Comparator.comparingInt(this::calculateHeuristic));
        // create storing structure with constant key checking time
        HashMap<Position, State> visitedStates = new HashMap<>();

        // add initial state to be the first state to explore
        priorityQueue.add(map.initState);
        visitedStates.put(new Position(map.initState), map.initState);

        while (!priorityQueue.isEmpty())
        {
            // check the first state in the queue
            State currentState = priorityQueue.poll();
            map.print(currentState, visitedStates);

            // return if the state is the goal
            if (isGoal(currentState))
                return;

            // else add successors to queue, waiting to be explored
            List<State> successors = successorGenerator.generate(currentState);
            for (State successor : successors)
            {
                if (!visitedStates.containsKey(successor)
                    || visitedStates.get(successor).depth > successor.depth)
                {
                    visitedStates.put(successor, successor);
                    priorityQueue.add(successor);
                }
            }
        }

        System.out.println("Goal State Not Found!");
    }

    private int calculateHeuristic(State state)
    {
        int result = Integer.MAX_VALUE;

        for (State goalState : map.goalStates)
        {
            result = Math.min(result, Math.abs(state.column - goalState.column)
                + Math.abs(state.row - goalState.row));
        }

        return result;
    }
}
