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
}
