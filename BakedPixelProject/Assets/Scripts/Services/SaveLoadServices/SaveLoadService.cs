using UnityEngine;

namespace Services.SaveLoadServices
{
	public class SaveLoadService : ISaveLoadService
	{
		public void LoadProgress()
		{
			Debug.Log("Create progress");
		}

		public void SaveProgress()
		{
			Debug.Log("Save progress");
		}
	}
}