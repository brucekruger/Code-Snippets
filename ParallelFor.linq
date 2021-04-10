<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	object locker = new object();
	double total = 0;
	Parallel.For(1, 100,
				  i => { 
				  	var value = Math.Sqrt(i);
					Console.WriteLine(value);
				  	lock (locker) total += value;
				  });
	Console.WriteLine(Environment.NewLine + "=== TOTAL: ===");
	Console.WriteLine(total);
}
