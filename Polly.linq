<Query Kind="Program">
  <NuGetReference Version="7.2.1">Polly</NuGetReference>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Polly</Namespace>
</Query>

async Task Main()
{
	try
	{
		await DoTheJob();
	}
	catch(Exception ex)
	{
		Console.WriteLine($"Something happened inside {nameof(DoTheJob)}: {ex.Message}");
	}
}

private async Task DoTheJob()
{
	var retryProvider = new RetryProvider();

	try
	{
		await retryProvider.RetryAsync(async () =>
			{
				await Task.Delay(1000);
				throw new Exception("Something happened!");
			});
	}
	catch (Exception ex)
	{
		Console.WriteLine($"Something happened! :{ex.Message}");
	}


	var policyResult = await retryProvider.RetryWithResultAsync(async () =>
		{
			await Task.Delay(1000);
			throw new Exception("Something happened!");
		});

	var message = policyResult.FinalException?.GetBaseException().Message;

	if (policyResult.Outcome == OutcomeType.Successful)
	{
		Console.WriteLine("Program completed!");
	}
	else
	{
		Console.WriteLine($"Program completed with errors! {policyResult?.FinalException.Message}");
	}
}

// You can define other methods, fields, classes and namespaces here
public class RetryProvider
{
	private const int _retryCount = 3;
	private const int _retryTimeoutSeconds = 1;

	public async Task RetryAsync(Func<Task> action)
	{
		await Policy
			   .Handle<Exception>()
			   .WaitAndRetryAsync(_retryCount, retryAttempt => TimeSpan.FromSeconds(_retryTimeoutSeconds))
			   .ExecuteAsync(async () => await action());
	}

	public async Task<PolicyResult> RetryWithResultAsync(Func<Task> action)
	{
		return await Policy
			   .Handle<Exception>()
			   .WaitAndRetryAsync(_retryCount, (retryAttempt) => TimeSpan.FromSeconds(_retryTimeoutSeconds))
			   .ExecuteAndCaptureAsync(action);
	}
}