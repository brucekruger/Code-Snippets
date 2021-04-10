<Query Kind="Program" />

class ThreadTest
{
	private bool done;
	private static readonly object locker = new object(); 

	static void Main()
	{
		ThreadTest tt = new ThreadTest();   // Create a common instance
		new Thread(tt.Go).Start();
		tt.Go();
	}

	// Note that Go is now an instance method
	void Go()
	{
		lock(locker){
			if (!done) {
				Console.WriteLine("Done"); done = true;
			}
		}
	}
}