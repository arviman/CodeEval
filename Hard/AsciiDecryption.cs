using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
  static int getIndexCommon(List<int> lst, int length, int spaceChar)
  {
    int n = lst.Count;
    for (int i = 0; i < n; ++i)
    {
      bool ok = true;
      for (int j = i + length; j < n; ++j)
      {
        int k = 0;
        for (; k < length; ++k)
        {
          if (lst[i + k] != lst[j + k] || lst[i+k] == spaceChar)
          {
            break;
          }
        }
        ok = k == length;
        if(ok)
          return i;

      }
    }
    return -1;//should never come here
  }
  static string decrypt(int length, char last, string msg)
  {
    var l = msg.Split(' ');
    var lst = new List<int>();
    foreach (var c in l)
      lst.Add(Convert.ToInt32(c));

    int spaceChar = lst.Min();
    int indx = getIndexCommon(lst, length, spaceChar);
    int msgLastChar = lst[indx + length - 1];
    
    int diff = msgLastChar - (int)last;
    int n = lst.Count;
    char[] retChar = new char[n];
    for (int i = 0; i < n; i++)
    {
      retChar[i] = (char)(lst[i] - diff);
    }
    return new string(retChar);

  }

  static void go(string line)
  {
    //todo remove this
    //line = "5 | s | 92 112 109 40 118 109 109 108 123 40 119 110 40 124 112 109 40 117 105 118 129 40 119 125 124 127 109 113 111 112 40 124 112 109 40 118 109 109 108 123 40 119 110 40 124 112 109 40 110 109 127 54 40 53 40 91 120 119 107 115";
    var parts = line.Split('|');
    for (int i = 0; i < parts.Length; ++i)
    {
      parts[i] = parts[i].Trim();
    }

    Console.WriteLine(decrypt(Convert.ToInt32(parts[0]), parts[1][0], parts[2]));
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
     

    //go(null);
  }
}