import java.util.Comparator;
import java.util.List;
import java.util.PriorityQueue;

public class AStarSearchStrategy extends SearchStrategy
{
    public AStarSearchStrategy(Map map)
    {
        super(map);
    }

    @Override public void execute()
    {
        // create a min heap, the order is determined by depth + heuristic
        // evaluation of the state in the search tree
        PriorityQueue<State> priorityQueue = new PriorityQueue<>(
            Comparator.comparingInt(this::calculateHeuristic));
        // add initial state to be the first state to explore
        priorityQueue.add(map.initState);

        while (!priorityQueue.isEmpty())
        {
            // check the first state in the queue
            State currentState = priorityQueue.poll();
            map.print(currentState);
            // return if the state is the goal
            if (isGoal(currentState))
                return;

            // else add successors to queue, waiting to be explored
            List<State> successors = successorGenerator.generate(currentState);
            for (State successor : successors)
            {
                priorityQueue.add(successor);
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
                + Math.abs(state.row - goalState.row) + state.depth / 2);
        }
        // System.out.println(result);
        return result;
    }
}
