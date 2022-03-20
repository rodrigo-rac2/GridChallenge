using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'gridChallenge' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING_ARRAY grid as parameter.
     */

    public static string gridChallenge(List<string> grid)
    {
        for (int x = 0; x < grid.Count; x++)
            grid[x] = SortString(grid[x]);
        for (int i = 0; i < grid[0].Length; i++)
        {
            string col = "";
            for (int j = 0; j < grid.Count; j++)
                col += grid[j][i];
            if (!IsInOrder('\u0000', col.ToCharArray()))
                return "NO";
        }
        return "YES";
    }

    public static string SortString(string input)
    {
        char[] characters = input.ToCharArray();
        Array.Sort(characters);
        return new string(characters);
    }

    public static bool IsInOrder(char previous, char[] arr)
    {
        foreach (char current in arr)
        {
            if (current < previous)
                return false;
            previous = current;
        }
        return true;
    }

}

class Program
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<string> grid = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string gridItem = Console.ReadLine();
                grid.Add(gridItem);
            }

            string result = Result.gridChallenge(grid);

            Console.WriteLine(result);
        }
    }
}
