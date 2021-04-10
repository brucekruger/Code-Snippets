<Query Kind="Program" />

void Main()
{
	Thread operation = new Thread(new ThreadStart(Go));
	operation.Start();
	Go();
}

public void Go(){
	Console.WriteLine("hello!");
}