import java.util.ArrayList;
import java.util.List;

public class StateSuccessorGenerator
{
    private Map map;

    public StateSuccessorGenerator(Map map)
    {
        this.map = map;
    }

    /*
     * Generate successors for four directions
     */
    public List<State> generate(State current)
    {
        List<State> successors = new ArrayList<>();
        int[][] directions = { { 0, -1 }, { -1, 0 }, { 0, 1 }, { 1, 0 } };
        String[] directionStr = { "up", "left", "down", "right" };

        for (int i = 0; i < 4; i++)
        {
            int x = current.column + directions[i][0];
            int y = current.row + directions[i][1];

            State newState = new State(x, y, current);
            newState.direction = directionStr[i];

            if (isValidState(newState))
                successors.add(newState);
        }

        return successors;
    }

    /*
     * Generate successors for four directions
     * @param step: the number of cell each move goes through
     */
    public List<State> generate(State current, int step)
    {
        List<State> successors = new ArrayList<>();
        int[][] directions = { { 0, -1 }, { -1, 0 }, { 0, 1 }, { 1, 0 } };
        String[] directionStr = { "up", "right", "left", "down" };

        for (int i = 0; i < 4; i++)
        {
            int x = current.column + directions[i][0] * step;
            int y = current.row + directions[i][1] * step;

            State newState = new State(x, y, current);
            newState.direction = directionStr[i];
            if (isValidState(newState))
                successors.add(newState);
        }

        return successors;
    }

    /*
     * Check if the state within valid bounds and not hitting wall
     */
    private boolean isValidState(State state)
    {
        return state.row >= 0 && state.row < map.noOfRows && state.column >= 0
            && state.column < map.noOfColumns && !map.isWall(state);
    }
}
