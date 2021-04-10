<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	int x = 0;
	Task<int> calc = Task.Factory.StartNew(() => 7 / x);
	try
	{
		Console.WriteLine(calc.Result);
	}
	catch (AggregateException aex)
	{
		Console.Write(aex.InnerException.Message);  // Attempted to divide by 0
	}
}
