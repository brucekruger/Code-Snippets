<Query Kind="Program" />

public static void Main()
{
	try
	{
		new Thread(Go).Start();
	}
	catch (Exception ex)
	{
		// We'll never get here!
		Console.WriteLine("Exception!");
	}
}

static void Go() {
	// Throws a NullReferenceException
	throw new NullReferenceException();
}
