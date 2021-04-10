<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	foreach (char c in "Hello, world")
		if (c == ',')
			break;
		else
			Console.Write(c);

	Console.WriteLine();

	Parallel.ForEach("Hello, world", (c, loopState) =>
	{
	   if (c == ',')
		   loopState.Break();
	   else
		   Console.Write(c);
	});
}
