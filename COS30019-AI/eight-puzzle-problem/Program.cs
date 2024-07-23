using System.Security.Cryptography.X509Certificates;

namespace Eight_puzzle_BFS
{
  public class Program
  {
    static void Main(string[] args)
    {
      int[] puzzle =
      {
        1, 4, 2,
        3, 8, 5,
        7, 6, 0,
      };

      Node root = new Node(puzzle);
      Uninformed_Search ui = new Uninformed_Search();
      List<Node> sol = ui.BFS(root);

      if (sol.Count > 0)
      {
        for (int i = 0; i < sol.Count; i++)
        {
          sol[i].Print_Console();
        }
      }
      else
      {
        Console.WriteLine("No path found");
      }
      Console.ReadLine();
    }
  }
}