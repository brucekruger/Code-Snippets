<Query Kind="Program" />

void Main()
{
	IEnumerable<int> numbers = Enumerable.Range(3, 100000 - 3);

	var parallelQuery =
	  from n in numbers.AsParallel()
	  where Enumerable.Range(2, (int)Math.Sqrt(n)).All(i => n % i > 0)
	  select n;

	int[] primes = parallelQuery.ToArray();
	foreach(var item in primes){
		Console.WriteLine(item);
	}
}
