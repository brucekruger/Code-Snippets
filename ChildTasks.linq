<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Task parent = Task.Factory.StartNew(() =>
	{
	   Console.WriteLine("I am a parent");

	   Task.Factory.StartNew(() =>        // Detached task
		{
		 Console.WriteLine("I am detached");
	 });

   Task.Factory.StartNew(() =>        // Child task
		{
		 	Console.WriteLine("I am a child");
	 	}, TaskCreationOptions.AttachedToParent);
	});
}
