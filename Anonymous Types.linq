<Query Kind="Program">
  <Connection>
    <ID>54bf9502-9daf-4093-88e8-7177c129999f</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Provider>System.Data.SqlServerCe.4.0</Provider>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\DemoDB.sdf</AttachFileName>
    <Persist>true</Persist>
  </Connection>
</Query>

void Main()
{
	var v = new { Amount = 108, Message = "Hello" };

	// Rest the mouse pointer over v.Amount and v.Message in the following  
	// statement to verify that their inferred types are int and string.  
	Console.WriteLine(v.Amount + v.Message);
	Console.WriteLine();

	var productQuery =
	from prod in Products
	select new { prod.ProductName, prod.UnitPrice };

	foreach (var p in productQuery)
	{
		Console.WriteLine($"Name={p.ProductName}, Price={p.UnitPrice}");
	}
	
	var anonArray = new[] { new { name = "apple", diam = 4 }, new { name = "grape", diam = 1 }};
}
