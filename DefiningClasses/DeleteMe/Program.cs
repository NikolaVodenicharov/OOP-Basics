using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

public class Program
{

    public static void Main()
    {
        int num = 5;
        double dub = 5.2;
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Hi man");
        sb.AppendLine("whats up");
        sb.Append($"{num} hoho-hihi {dub}");
        sb.Append("bla, bla");

        string str = sb.ToString();
        Console.WriteLine(sb.ToString());
    }
}
