<Query Kind="Program" />

class Abort
{
  static void Main()
	{
		Thread t = new Thread(delegate() { while (true) ; });

		Console.WriteLine(t.ThreadState);     // Unstarted

		t.Start();
		Thread.Sleep(1000);
		Console.WriteLine(t.ThreadState);     // Running

		t.Abort();
		Console.WriteLine(t.ThreadState);     // AbortRequested

		t.Join();
		Console.WriteLine(t.ThreadState);     // Stopped
	}
}