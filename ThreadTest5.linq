<Query Kind="Program" />

void Main()
{
	Thread operation = new Thread(() => Print("Test message!"));
	operation.Start();
}

public void Print(string message)
{
	Console.WriteLine(message);
}