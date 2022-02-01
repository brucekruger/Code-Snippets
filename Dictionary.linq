<Query Kind="Statements" />

var dictionary = new Dictionary<string, string>();
dictionary.Add("1", "error1");
dictionary.Add("2", "error2");
dictionary.Add("3", "error2");

foreach (var id in dictionary.Keys)
{
	if (id.Equals("1"))
	{
		dictionary.Remove("1");
		dictionary["2"] = "error22";
	}
	if(id.Equals("2"))
	{
		dictionary.Remove("2");
	}
}

Console.WriteLine(dictionary.Count);