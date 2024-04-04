public class Program
{
    public static void main(String[] args)
    {
        execute(args);
        // test();
    }

    public static void execute(String[] args)
    {
        // args contains:
        // [0] - filename containing world map data
        // [1] - searching method name
        if (args.length < 2)
        {
            System.out.println("Usage: <filename> <search-method>");
            System.exit(1);
        }

        Map map;
        if ((map = MapGenerator.createMapFromFileInput(args[0],
            args[1])) == null)
        {
            System.out.println("Failed reading data from " + args[0]
                + " or invalid search strategy input");
            System.exit(1);
        }

        map.search();
    }

    public static void test()
    {
        // Create two Position objects
        Position pos1 = new Position(1, 2);
        Position pos2 = new Position(1, 2);

        // Create a State object with the same coordinates
        State state = new State(1, 2);

        // Test equals method with Position objects
        System.out.println("pos1 equals pos2: " + pos1.equals(pos2)); // Should
                                                                      // print
                                                                      // true

        // Test equals method with State and Position objects
        System.out.println("pos1 equals state: " + pos1.equals(state)); // Should
                                                                        // print
                                                                        // true

        // Test equals method with State objects
        System.out.println("state equals pos2: " + state.equals(pos2)); // Should
                                                                        // print
                                                                        // true
    }
}
