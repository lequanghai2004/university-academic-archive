using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eight_puzzle_BFS
{
  public class Uninformed_Search
  {
    public Uninformed_Search()
    {
    }
    public List<Node> BFS(Node root)
    {
      List<Node> path_to_solution = new List<Node>();
      List<Node> frontier = new List<Node>();
      List<Node> visited = new List<Node>();
      frontier.Add(root);
      bool goal_found = false;

      while ((frontier.Count > 0) && (!goal_found))
      {
        Node current_node = frontier[0];
        visited.Add(current_node);
        frontier.RemoveAt(0);

        current_node.Expand_Node();
        current_node.Print_Console();

        for (int i = 0; i < current_node.children.Count; i++)
        {
          Node current_child = current_node.children[i];
          if (current_child.GoalState())
          {
            Console.WriteLine("Goal Found");
            goal_found = true;
            Path_Tracer(path_to_solution, current_child);
          }
          if (!Contains(frontier, current_child) && !Contains(visited, current_child))
          {
            frontier.Add(current_child);
          }
        }
      }
      return path_to_solution;
    }
    public void Path_Tracer(List<Node> path, Node n)
    {
      Console.WriteLine("Retracing Path...");
      Node current = n;
      path.Add(current);
      while (current.parent != null)
      {
        current = current.parent;
        path.Add(current);
      }
      path.Reverse();
    }
    public static bool Contains(List<Node> list, Node c)
    {
      bool contains = false;
      for (int i = 0; i < list.Count; i++)
      {
        if (list[i].SameP(c.puzzle))
        {
          contains = true;
        }
      }
      return contains;
    }
  }
}
