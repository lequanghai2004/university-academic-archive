import java.util.*;

public class CustomInformedSearchStrategy extends SearchStrategy
{
    public CustomInformedSearchStrategy(Map map)
    {
        super(map);
    }

    // advantage: alway find shortest path
    // disadvantage: cannot find all goal (can with modification)
    public void execute()
    {
        int row = map.noOfRows;
        int col = map.noOfColumns;

        // create an array storing all states available
        ArrayList<State> states = new ArrayList<>(row * col);
        // set all state cost to infinity, goal state cost is 0
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                State state = new State(j, i);
                if (!map.isWall(state))
                    states.add(state);
                else
                    states.add(null);
            }
        }

        // if map.goalStates has size 0 return immediately
        if (map.goalStates.length == 0)
        {
            System.out.println("No goal state found");
            return;
        }

        for (State goal : map.goalStates)
            states.get(goal.column + goal.row * col).eval = 0;

        boolean doneRelaxation = false;
        // keep relaxation while any still has default heuristic cost (infinity)
        while (!doneRelaxation)
        {
            doneRelaxation = true;
            map.print(states);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (states.get(j + i * col) == null)
                        continue;
                    int cost = states.get(j + i * col).eval;

                    if (i > 0 && states.get(j + (i - 1) * col) != null)
                        cost = Math.min(cost,
                            states.get(j + (i - 1) * col).eval + 1);
                    if (i < row - 1 && states.get(j + (i + 1) * col) != null)
                        cost = Math.min(cost,
                            states.get(j + (i + 1) * col).eval + 1);
                    if (j > 0 && states.get((j - 1) + i * col) != null)
                        cost = Math.min(cost,
                            states.get((j - 1) + i * col).eval + 1);
                    if (j < col - 1 && states.get((j + 1) + i * col) != null)
                        cost = Math.min(cost,
                            states.get((j + 1) + i * col).eval + 1);

                    if (cost < states.get(j + i * col).eval)
                    {
                        states.get(j + i * col).eval = cost;
                        doneRelaxation = false;
                    }
                }
            }
        }

        // done relaxation, now all state has a definite cost, use greedy method
        // to travel to least cost state
        State currentState = states
            .get(map.initState.column + map.initState.row * col);
        while (!map.isGoal(currentState))
        {
            int curCol = currentState.column;
            int curRow = currentState.row;

            State nextState = null;
            int minCost = Integer.MAX_VALUE;

            // Check all neighboring states and find the one with lowest cost
            if (curRow > 0 && states.get(curCol + (curRow - 1) * col) != null
                && states.get(curCol + (curRow - 1) * col).eval < minCost)
            {
                minCost = states.get(curCol + (curRow - 1) * col).eval;
                nextState = states.get(curCol + (curRow - 1) * col);
            }
            if (curRow < row - 1
                && states.get(curCol + (curRow + 1) * col) != null
                && states.get(curCol + (curRow + 1) * col).eval < minCost)
            {
                minCost = states.get(curCol + (curRow + 1) * col).eval;
                nextState = states.get(curCol + (curRow + 1) * col);
            }
            if (curCol > 0 && states.get((curCol - 1) + curRow * col) != null
                && states.get((curCol - 1) + curRow * col).eval < minCost)
            {
                minCost = states.get((curCol - 1) + curRow * col).eval;
                nextState = states.get((curCol - 1) + curRow * col);
            }
            if (curCol < col - 1
                && states.get((curCol + 1) + curRow * col) != null
                && states.get((curCol + 1) + curRow * col).eval < minCost)
            {
                minCost = states.get((curCol + 1) + curRow * col).eval;
                nextState = states.get((curCol + 1) + curRow * col);
            }

            // update the path to current state, this is to keep track of the
            // instructions order
            nextState.parent = currentState;
            if (nextState.column == currentState.column - 1)
                nextState.direction = "left";
            else if (nextState.column == currentState.column + 1)
                nextState.direction = "right";
            else if (nextState.row == currentState.row - 1)
                nextState.direction = "up";
            else if (nextState.row == currentState.row + 1)
                nextState.direction = "down";
            currentState = nextState;
        }

        // Print the path
        getResult(currentState);
    }
}
