using System;
using System.IO;

class Program
{
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

		private static void go(string line)
		{
			var spl = line.Split(',');
			string a = spl[0];
			string b = spl[1];
			bool res = isSubstring(a, b);
			Console.WriteLine(res ?"true":"false");
		}

		private static bool isSubstring(string astr, string bstr)
		{
			char[] str = astr.ToCharArray();
			char[] needle = bstr.ToCharArray();

			int sn = str.Length;
			int n = needle.Length;
			if (n == sn)
				return astr.Equals(bstr);
			if (n > sn)
				return false;

			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < sn; j++)
				{
					int k = 0;
					for (; i+k < n && j+k < sn; ++k)
					{
						if (needle[i + k] == '*' && (i+k > 0 && needle[i+k-1] != '\\'))
						{
							return isSubstring(new string(str, j+k+1, sn-(j+k+1)), new string(needle, i+k+1, n-(i+k+1)));
						}
						else if (needle[i + k] != str[j+k])
						{
							break;
						}
					}
					if (k == n)
						return true;
				}

			}
			return false;
		}
}