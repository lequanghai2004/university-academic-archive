using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eight_puzzle_BFS
{
  public class Node
  {
    public List<Node> children = new List<Node>();
    public Node? parent;
    public int[] puzzle = new int[9];
    public int x = 0;
    public int col = 3;

    public Node(int[] p)
    {
      for (int i = 0; i < puzzle.Length; i++) this.puzzle[i] = p[i];
    }
    public bool GoalState()
    {
      bool is_GOAL = true;
      int m = puzzle[0];
      for (int i = 1; i < puzzle.Length; i++)
      {
        if (m > puzzle[i])
        {
          is_GOAL = false;
          m = puzzle[i];
        }
      }
      return is_GOAL;
    }

    public void Expand_Node()
    {
      for (int i = 0; i < puzzle.Length; i++)
      {
        if (puzzle[i] == 0)
        {
          x = i;
          break;
        }
      }

      Move_To_Right(puzzle, x);
      Move_Down(puzzle, x);
      Move_To_Left(puzzle, x);
      Move_Up(puzzle, x);
    }

    public void Move_To_Right(int[] p, int i)
    {
      if (i % col < col - 1)
      {
        int[] pc = new int[9];
        Copy_Puzzle(pc, p);
        int temp = pc[i + 1];
        pc[i + 1] = pc[i];
        pc[i] = temp;
        Node child = new Node(pc);
        children.Add(child);
        child.parent = this;
      }
    }
    public void Move_To_Left(int[] p, int i)
    {
      if (i % col < 0)
      {
        int[] pc = new int[9];
        Copy_Puzzle(pc, p);
        int temp = pc[i - 1];
        pc[i - 1] = pc[i];
        pc[i] = temp;
        Node child = new Node(pc);
        children.Add(child);
        children.Add(child);
        child.parent = this;
      }
    }
    public void Move_Up(int[] p, int i)
    {
      if (i - col >= 0)
      {
        int[] pc = new int[9];
        Copy_Puzzle(pc, p);
        int temp = pc[i - 3];
        pc[i - 3] = pc[i];
        pc[i] = temp;
        Node child = new Node(pc);
        children.Add(child);
        children.Add(child);
        child.parent = this;
      }
    }
    public void Move_Down(int[] p, int i)
    {
      if (i + col <= puzzle.Length)
      {
        int[] pc = new int[9];
        Copy_Puzzle(pc, p);
        int temp = pc[i + 3];
        pc[i + 3] = pc[i];
        pc[i] = temp;

        Node child = new Node(pc);
        children.Add(child);
        children.Add(child);
        child.parent = this;
      }
    }
    public void Copy_Puzzle(int[] a, int[] b)
    {
      for (int i = 0; i < b.Length; i++)
      {
        a[i] = b[i];
      }
    }
    public void Print_Console()
    {
      Console.WriteLine();
      int m = 0;
      for (int i = 0; i < col; i++)
      {
        for (int j = 0; j < col; j++)
        {
          Console.Write(puzzle[m] + " ");
          m++;
        }
        Console.WriteLine();
      }
    }
    public bool SameP(int[] p)
    {
      bool same = true;
      for (int i = 0; i < p.Length; i++)
      {
        if (puzzle[i] != p[i]) same = false;
      }
      return same;
    }
  }
}