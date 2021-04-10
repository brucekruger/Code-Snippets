<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Task t1 = Task.Factory.StartNew(() =>
	{
		Thread.Sleep(TimeSpan.FromSeconds(10));
		Console.WriteLine("First task completed!");
	});

	Task t2 = Task.Factory.StartNew(() =>
	{
		Thread.Sleep(TimeSpan.FromSeconds(4));
		Console.WriteLine("Second task completed!");
	});

	Task t3 = Task.Factory.StartNew(() =>
	{
		Thread.Sleep(TimeSpan.FromSeconds(8));
		Console.WriteLine("Third task completed!");
	});
	
	Stopwatch timer = new Stopwatch();
	timer.Start();
	Task.WaitAll(t1, t2, t3);
	//Task.WaitAny(t1, t2, t3);
	timer.Stop();
	Console.WriteLine("Elapsed seconds: " + timer.ElapsedMilliseconds / 1000);
}
