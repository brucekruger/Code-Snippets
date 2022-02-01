<Query Kind="Program">
  <Namespace>ExtensionMethods</Namespace>
</Query>

void Main()
{
	int[] ints = { 10, 45, 15, 39, 21, 26 };
	var result = ints.OrderBy(g => g);
	foreach(var i in result)
	{
		Console.Write(i + " ");
	}
	
	string s = "Hello Extension Methods";
	int count = s.WordCount();
	Console.WriteLine();
	Console.WriteLine(count);
}

namespace ExtensionMethods
{
	public static class MyExtensions
	{
		public static int WordCount(this string str)
		{
			return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
		}
	}
}
