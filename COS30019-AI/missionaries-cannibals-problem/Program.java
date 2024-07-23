import java.util.Arrays;
import java.util.Comparator;
import java.util.PriorityQueue;
import java.util.Queue;
import java.util.List;

public class Program
{
    public static void main(String[] args)
    {
        Struct initState = new Struct(new int[] { 3, 3 }, new int[] { 0, 0 });
        Struct currentState = initState;
        Queue<Struct> queue = new PriorityQueue<>(new StructComparator());
        queue.add(currentState);

        Struct temp;
        int count = 0;
        List<int[]> options = Arrays.asList(new int[] { 1, 0 },
            new int[] { 0, 1 }, new int[] { 2, 0 }, new int[] { 0, 2 },
            new int[] { 1, 1 });

        while (!Arrays.equals(currentState.leftBank, new int[] { 0, 0 }))
        {
            for (int[] option : options)
            {
                temp = new Struct(currentState);
                if (temp.update(option))
                {
                    queue.add(temp);
                }
            }

            currentState = queue.poll();

            System.out.print(count + ": ");
            currentState.print();
            count++;
        }

        while (currentState.prev != null)
        {
            currentState.prev.print();
            currentState = currentState.prev;
        }
    }
}

class IntComparator implements Comparator<Integer>
{
    @Override
    public int compare(Integer s1, Integer s2)
    {
        return s1 < s2 ? -1 : 0; // s1 is then priority
    }
}

class StructComparator implements Comparator<Struct>
{
    @Override // method of Comparator
    public int compare(Struct s1, Struct s2)
    {
        // return s1.pathCost + s1.stateCost < s2.pathCost + s2.stateCost ?-1:1;
        return Float.compare(s1.pathCost + s1.stateCost,
            s2.pathCost + s2.stateCost);
    }
}
