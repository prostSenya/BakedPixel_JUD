namespace Services.RandomServices
{
	public interface IRandomService
	{
		T GetRandomElement<T>(T[] array);
	}
}