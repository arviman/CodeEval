

using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void go(string line)
  {
    var numStr = line.Split(';');
	  int n = Convert.ToInt32(numStr[0]);
		var choicesStr = numStr[1].Split(new[] {"],"}, StringSplitOptions.RemoveEmptyEntries);
		List<List<int>> choices = new List<List<int>>();
		foreach (string t in choicesStr)
		{
			string[] roomchoices = t.Split(new[] {":["}, StringSplitOptions.RemoveEmptyEntries);
			string[] rooms = roomchoices[1].Split(',');
			for (int i = 0; i < rooms.Length; i++)
			{
				string room = rooms[i];
				rooms[i] = new string((from c in room
					where char.IsDigit(c)
					select c).ToArray());
			}

			choices.Sort((a,b) => a.Count - b.Count);
			choices.Add(rooms.Select(r => Convert.ToInt32(r)).ToList());
		}
		

		Console.WriteLine(Process(choices, new List<int>()) ? "Yes" : "No");
  }

	private static bool Process(List<List<int>> choices, List<int> taken )
	{

		if (choices.Count == 1)
		{
			foreach (var c in choices[0])
			{
				if (!taken.Contains(c))
					return true;
			}
			return false;
		}
		
		List<List<int>> nxt = new List<List<int>>();
		for (int i = 1; i < choices.Count; ++i)
		{
			nxt.Add(choices[i]);
		}
		for (int i = 0; i < choices[0].Count; ++i)
		{
			if(!taken.Contains(choices[0][i]))
			{
				taken.Add(choices[0][i]);
				bool res = Process(nxt, taken);
				taken.Remove(choices[0][i]);
				if (res) return true;
			}
		}
		return false;
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
