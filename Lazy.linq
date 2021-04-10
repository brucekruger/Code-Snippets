<Query Kind="Program" />

Lazy<SampleClass> lazy;
SampleClass _sampleObject;

void Main()
{
	lazy = new Lazy<SampleClass>(() => new SampleClass(), true);
	var _sampleObject = GetSampleClass;
	var sampleObject2 = GetSampleClassLazy;
}

public class SampleClass
{
	private int number;
	private string characters;
	private decimal value;

	public SampleClass() {
		number = 1000;
		characters = "string";
		value = 1.5m;
	}
}

public SampleClass GetSampleClass
{
	get {
		return lazy.Value;
	}
}

public SampleClass GetSampleClassLazy
{
	get
	{
		// Implement double-checked locking
		LazyInitializer.EnsureInitialized(ref _sampleObject, () => new SampleClass());
		return _sampleObject;
	}
}
