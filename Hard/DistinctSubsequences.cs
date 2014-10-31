//Sample code to read in test cases:
using System;
using System.IO;
using System.Collections.Generic;

class Program
{  
  static int n, m;
  static string _a, _b;
  static int ans;
  static int process(string a, string b)
  {
    _a = a;
    _b = b;
    n = a.Length;
    m = b.Length;
    ans = 0;
    mem = new int[n, m];
    
    for (int i = 0; i < n; i++)
    {
      for (int j = 0; j < m; j++)
      {
        mem[i,j] = -1;
      }
    }
    return go(0,0);
  }
  static int[,] mem;
  static int go(int x, int y)
  {
    int res = 0;

    if (y == m)
      return 1;
    
    if (x >= n) return 0;    

    if (mem[x, y] >= 0)
      return mem[x, y];

    if (_a[x] == _b[y])
      res = go(x + 1, y + 1) + go(x+1, y);
    else
      res = go(x + 1, y);

    mem[x, y] = res;
    return res;
  }
    static void Main(string[] args)
    {
      //Console.WriteLine(process("babgbag","bag"));
      //Console.WriteLine(process("rabbbit","rabbit"));
      
        using (StreamReader reader = File.OpenText(args[0]))
        while (!reader.EndOfStream)
        {
          string line = reader.ReadLine();
          if (null == line)
              continue;
          string[] words = line.Split(',');
          Console.WriteLine(process(words[0], words[1]));         
          
        }
    }
}