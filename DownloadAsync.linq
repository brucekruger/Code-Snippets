<Query Kind="Program">
  <Namespace>System.Net</Namespace>
</Query>

void Main()
{
	var wc = new WebClient();
	wc.DownloadStringCompleted += (sender, args) =>
	{
		if (args.Cancelled)
			Console.WriteLine("Canceled");
		else if (args.Error != null)
			Console.WriteLine("Exception: " + args.Error.Message);
		else
		{
			Console.WriteLine(args.Result.Length + " chars were downloaded");
		// We could update the UI from here...
	}
	};
	wc.DownloadStringAsync(new Uri("http://www.linqpad.net"));  // Start it
}

// You can define other methods, fields, classes and namespaces here
