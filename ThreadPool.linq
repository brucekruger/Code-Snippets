<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

static void Main()    // The Task class is in System.Threading.Tasks
{
	Task.Factory.StartNew(Go);
}

static void Go()
{
	Console.WriteLine("Hello from the thread pool!");
}