<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

static void Main()
{
	// Start the task executing:
	Task<string> task = Task.Factory.StartNew<string>
	  (() => DownloadString("http://www.linqpad.net"));

	// We can do other work here and it will execute in parallel:
	RunSomeOtherMethod();

	// When we need the task's return value, we query its Result property:
	// If it's still executing, the current thread will now block (wait)
	// until the task finishes:
	string result = task.Result;
	
	RunSomeOtherWork();
}

static void RunSomeOtherMethod()
{
	Task.Delay(TimeSpan.FromSeconds(5));
}

static void RunSomeOtherWork()
{
	Console.WriteLine("Processing finished!");
}


static string DownloadString(string uri)
{
	Task.Delay(TimeSpan.FromSeconds(5));
	using (var wc = new System.Net.WebClient())
		return wc.DownloadString(uri);
}