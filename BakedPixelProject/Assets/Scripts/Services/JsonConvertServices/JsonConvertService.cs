using UnityEngine;

namespace Services.JsonConvertServices
{
	public class JsonConvertService : IJsonConvertService
	{
		public string ToJson(object obj) => 
			JsonUtility.ToJson(obj);

		public T FromJson<T>(string json) => 
			JsonUtility.FromJson<T>(json);
	}
}