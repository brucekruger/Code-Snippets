<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Task t1 = new Task(() => {
		Thread.Sleep(TimeSpan.FromSeconds(2));
		Console.WriteLine("First task completed!");
	});

	Task t2 = new Task(() =>
	{
		Thread.Sleep(TimeSpan.FromSeconds(4));
		Console.WriteLine("Second task completed!");
	});

	Task t3 = new Task(() =>
	{
		Thread.Sleep(TimeSpan.FromSeconds(8));
		Console.WriteLine("Third task completed!");
	});

	// Assume t1, t2 and t3 are tasks:
	var exceptions = new List<Exception>();
	try { 
		t1.Start();
		t1.Wait();
	} catch (AggregateException ex) { exceptions.Add(ex); }
	try {
		t2.Start();
		t2.Wait();
	} catch (AggregateException ex) { exceptions.Add(ex); }
	try {
		t3.Start();
		t3.Wait();
	} catch (AggregateException ex) { exceptions.Add(ex); }
	
	if (exceptions.Count > 0) throw new AggregateException(exceptions);
}
