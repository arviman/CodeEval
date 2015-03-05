using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text;

class Program
{
  static void go(string line)
    {
//US001
// split the line
      
      var nums = line.Split(' ');
      int x = Convert.ToInt32(nums[0]);
      int y = Convert.ToInt32(nums[1]);
      int n = Convert.ToInt32(nums[2]);
      StringBuilder ret = new StringBuilder();
      for (int i = 1; i <= n; i++)
      {
        string ans = "";
        if (i % x == 0 && i % y == 0)
        {
          ans = "FB";
        }
        else if (i % x == 0)
          ans = "F";
        else if (i % y == 0)
          ans = "B";
        else
          ans = i.ToString();

        if (i < n)
          ret.Append(ans + " ");
        else ret.Append(ans);
      }
      Console.WriteLine(ret);
    }
  static void Main(string[] args)
  {
    
    using (StreamReader reader = File.OpenText(args[0]))
      while (!reader.EndOfStream)
      {
        string line = reader.ReadLine();
        if (null == line)
          continue;
        go(line);
        // do something with line
      }
    
  }
}