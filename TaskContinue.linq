<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Task task1 = Task.Factory.StartNew(() => Console.Write("antecedant.."));
	Task task2 = task1.ContinueWith(ant => Console.Write("..continuation"));

	task2.Wait();
	Console.WriteLine();
	
	Task.Factory.StartNew<int>(() => 8)
	  .ContinueWith(ant => ant.Result * 2)
	  .ContinueWith(ant => Math.Sqrt(ant.Result))
	  .ContinueWith(ant => Console.WriteLine(ant.Result));   // 4
}
