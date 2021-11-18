using System;
using System.Collections.Generic;

namespace TicTakToe
{
  class Program
  {
    static readonly int[] diagonalDifferences = new[] { -2, -1, 0, 1, 2 };
    static readonly int n = 3;
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      var player1Markers = new List<(int x, int y)>()
      {
        (x: 2, y: 2),
        (x: 1, y: 1),
        (x: 0, y: 2),
        (x: 2, y: 0)
      };
      var player2Markers = new List<(int x, int y)>()
      {
        (x: 0, y: 1),
        (x: 0, y: 0),
        (x: 1, y: 2),
      };

      Program p = new Program();

      p.GetWinningCombo(player1Markers, player2Markers);
    }

    // List<(int x, int y)>
    public string GetWinningCombo(List<(int x, int y)> player1Markers, List<(int x, int y)> player2Markers)
    {
      List<(int x, int y)> moves = new List<(int x, int y)>();
      int length = player1Markers.Count > player2Markers.Count ? player1Markers.Count : player2Markers.Count;
      for (int i = 0; i < length; i++)
      {
        if (i < player1Markers.Count)
          moves.Add(player1Markers[i]);

        if (i < player2Markers.Count)
          moves.Add(player2Markers[i]);
      }

      //int[] aRow = new int[3], aCol = new int[3], bRow = new int[3], bCol = new int[3];
      //int aD1 = 0, aD2 = 0, bD1 = 0, bD2 = 0;
      //for (int i = 0; i < moves.Count; ++i)
      //{
      //  int r = moves[i].x, c = moves[i].y;
      //  if (i % 2 == 1)
      //  {
      //    if (++bRow[r] == 3 || ++bCol[c] == 3 || r == c && ++bD1 == 3 || r + c == 2 && ++bD2 == 3) return "B";
      //  }
      //  else
      //  {
      //    if (++aRow[r] == 3 || ++aCol[c] == 3 || r == c && ++aD1 == 3 || r + c == 2 && ++aD2 == 3) return "A";
      //  }
      //}
      //return moves.Count == 9 ? "Draw" : "Pending";
      int[] rows = new int[n], cols = new int[n];
      int diag = 0, diag2 = 0;
      for (int i = moves.Count - 1; 0 <= i; i -= 2)
      {
        int row = moves[i].x, col = moves[i].y;

        ++rows[row];
        ++cols[col];
        if (row == col)
        {
          ++diag;
        }
        if (row + col == n - 1)
        {
          ++diag2;
        }

        if (rows[row] == n || cols[col] == n || diag == n || diag2 == n)
        {
          return moves.Count % 2 == 0 ? "B" : "A";
        }
      }

      return moves.Count == n * n ? "Draw" : "Pending";
    }
  }
}
