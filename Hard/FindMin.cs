using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void go(string line)
    {
      var words = line.Split(',');
      long n = Convert.ToInt64(words[0]);
      long k = Convert.ToInt64(words[1]);
      long a = Convert.ToInt64(words[2]);
      long b = Convert.ToInt64(words[3]);
      long c = Convert.ToInt64(words[4]);
      long r = Convert.ToInt64(words[5]);

      long[] arr = new long[n];
      arr[0] = a;
      var lst = new List<long>();
      lst.Add(a);
      for (long i = 1; i < k; i++)
			{
        arr[i] = (arr[i-1] * b + c) % r;
        lst.Add(arr[i]);
			}
      
      for(long i = k; i < n; ++i)
      {
        long first = arr[i-k];
        long res = -1;
        lst.Sort();

        if(lst.First() != 0)
        {
          res = 0;
        }
        else
        {
          for (int j = 1; j < lst.Count; j++)
			    {
			      if(lst[j] != (lst[j-1]+1))
            {
              res = lst[j-1]+1;break;
            }
			    }
          if(res == -1)
            res = lst.Last() + 1;
        }

        lst.Remove(first);
        arr[i] = res;
        lst.Add(res);

      }
        
      Console.WriteLine(arr[n-1]);
    }
    static void Main(string[] args)
    {
      
        using (StreamReader reader = File.OpenText(args[0]))
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            if (null == line)
                continue;
            // do something with line  
            go(line);
            
        }
        
    }
}