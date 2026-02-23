namespace Services.JsonConvertServices
{
	public interface IJsonConvertService
	{
		string ToJson(object obj);
		T FromJson<T>(string json);
	}
}