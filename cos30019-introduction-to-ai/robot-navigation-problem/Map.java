import java.lang.reflect.Constructor;
import java.util.TreeSet;
import java.util.Stack;
import java.util.Set;
import java.util.ArrayList;
import java.util.HashMap;

public class Map
{
    int noOfRows;
    int noOfColumns;

    public State initState;
    public State[] goalStates;
    public SearchStrategy searchStrategy;
    public TreeSet<Wall> walls;

    public Map(int rows, int cols, State init, State[] goal,
        Constructor<SearchStrategy> strategyConstructor) throws Exception
    {
        noOfRows = rows;
        noOfColumns = cols;

        initState = init;
        goalStates = goal;

        walls = new TreeSet<>(new WallComparator());
        searchStrategy = strategyConstructor.newInstance(this);
    }

    public void addWall(Wall wall)
    {
        walls.add(wall);
    }

    public void search()
    {
        searchStrategy.execute();
    }

    public boolean isWall(State state)
    {
        for (Wall wall : walls)
            if (wall.isIn(state))
                return true;
        return false;
    }

    public boolean isWall(int x, int y)
    {
        for (Wall wall : walls)
            if (wall.isIn(x, y))
                return true;
        return false;
    }

    public boolean isGoal(State state)
    {
        for (State goal : goalStates)
            if (state.equals(goal))
                return true;
        return false;
    }

    private boolean isPath(Stack<State> path, int x, int y)
    {
        for (State state : path)
            if (state.column == x && state.row == y)
                return true;
        return false;
    }

    public void print(State currentState)
    {
        printHeader();

        for (int i = 0; i < noOfRows; i++)
        {
            for (int j = 0; j < noOfColumns; j++)
                if (isWall(j, i))
                    System.out.print(" ##### |");
                else if (isGoal(new State(j, i))
                    && currentState.equals(new State(j, i)))
                    System.out.print("ARRIVED|");
                else if (currentState.column == j && currentState.row == i)
                    System.out.print(" AGENT |");
                else if (isGoal(new State(j, i)))
                    System.out.print(" GOAL! |");
                else if (initState.equals(new State(j, i)))
                    System.out.print(" HOME  |");
                else
                    System.out.print("       |");

            System.out.println();
            for (int j = 0; j < noOfColumns; j++)
                System.out.print("--------");
            System.out.println();
        }

        printDelay();
    }

    public void print(State currentState,
        HashMap<Position, State> visitedStates)
    {
        printHeader();

        for (int i = 0; i < noOfRows; i++)
        {
            for (int j = 0; j < noOfColumns; j++)
                if (isWall(j, i))
                    System.out.print(" ##### |");
                else if (isGoal(new State(j, i))
                    && currentState.equals(new State(j, i)))
                    System.out.print("ARRIVED|");
                else if (currentState.column == j && currentState.row == i)
                    System.out.print(" AGENT |");
                else if (isGoal(new State(j, i)))
                    System.out.print(" GOAL! |");
                else if (initState.equals(new State(j, i)))
                    System.out.print(" HOME  |");
                else if (visitedStates.containsKey(new State(j, i)))
                    System.out.print(" ----- |");
                else
                    System.out.print("       |");

            System.out.println();
            for (int j = 0; j < noOfColumns; j++)
                System.out.print("--------");
            System.out.println();
        }

        printDelay();
    }

    public void print(State currentState, Set<Position> visitedStates)
    {
        printHeader();

        for (int i = 0; i < noOfRows; i++)
        {
            for (int j = 0; j < noOfColumns; j++)
                if (isWall(j, i))
                    System.out.print(" ##### |");
                else if (isGoal(new State(j, i))
                    && currentState.equals(new State(j, i)))
                    System.out.print("ARRIVED|");
                else if (currentState.column == j && currentState.row == i)
                    System.out.print(" AGENT |");
                else if (isGoal(new State(j, i)))
                    System.out.print(" GOAL! |");
                else if (initState.equals(new State(j, i)))
                    System.out.print(" HOME  |");
                else if (visitedStates.contains(new State(j, i)))
                    System.out.print(" ----- |");
                else
                    System.out.print("       |");

            System.out.println();
            for (int j = 0; j < noOfColumns; j++)
                System.out.print("--------");
            System.out.println();
        }

        printDelay();
    }

    public void print(ArrayList<State> states)
    {
        printHeader();

        for (int i = 0; i < noOfRows; i++)
        {
            for (int j = 0; j < noOfColumns; j++)
                if (isWall(j, i))
                    System.out.print(" ##### |");
                else if (states
                    .get(j + i * noOfColumns).eval == Integer.MAX_VALUE - 1)
                    System.out.print(" INF!  |");
                else
                    System.out.print(" " + String.format("%05d",
                        states.get(j + i * noOfColumns).eval) + " |");

            System.out.println();
            for (int j = 0; j < noOfColumns; j++)
                System.out.print("--------");
            System.out.println();
        }

        printDelay();
    }

    public void print(Stack<State> path)
    {
        printHeader();

        for (int i = 0; i < noOfRows; i++)
        {
            for (int j = 0; j < noOfColumns; j++)
                if (isWall(j, i))
                    System.out.print(" ##### |");
                else if (initState.equals(new State(j, i)))
                    System.out.print(" HOME  |");
                else if (isPath(path, j, i))
                    System.out.print(" PATH  |");
                else
                    System.out.print("       |");

            System.out.println();
            for (int j = 0; j < noOfColumns; j++)
                System.out.print("--------");
            System.out.println();
        }

        MapGenerator.print();
        System.out.print("Instructions: ");
        String mss = "";
        for (State state : path)
            // mss = state.column + ";" + state.row + ":" + mss;
            mss = state.direction + "; " + mss;
        if (mss.length() > 5)
            mss = mss.substring(5, mss.length() - 2);
        System.out.println(mss + "\n");
    }

    private void clearConsole()
    {
        try
        {
            final String os = System.getProperty("os.name");
            if (os.contains("Windows"))
            {
                new ProcessBuilder("cmd", "/c", "cls").inheritIO().start()
                    .waitFor();
            }
            else
            {
                Runtime.getRuntime().exec("clear");
            }
        }
        catch (final Exception e)
        {
            // Handle exceptions
            e.printStackTrace();
        }
    }

    private void printHeader()
    {
        clearConsole();
        System.out.println();
        for (int i = 0; i < noOfColumns; i++)
            System.out.print("--------");
        System.out.println();
    }

    private void printDelay()
    {
        try
        {
            Thread.sleep(10);
        }
        catch (InterruptedException e)
        {
            e.printStackTrace();
        }
    }
}
