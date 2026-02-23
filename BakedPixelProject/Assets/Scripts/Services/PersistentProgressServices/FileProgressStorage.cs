using System.IO;
using UnityEngine;

namespace Services.PersistentProgressServices
{
	public class FileProgressStorage : IFileProgressStorage
	{
		private const string FileName = "progress.json";
		
		private readonly string _path;

		public FileProgressStorage()
		{
			_path = Path.Combine(Application.persistentDataPath, FileName);
			Directory.CreateDirectory(Application.persistentDataPath);
		}

		public bool HasData => File.Exists(_path);

		public void Save(string json)
		{
			Debug.LogError($"Saving to: {_path}");
			string tmp = _path + ".tmp";
			File.WriteAllText(tmp, json);

			if (File.Exists(_path))
				File.Replace(tmp, _path, _path + ".bak");
			else
				File.Move(tmp, _path);
		}

		public bool TryLoad(out string json)
		{
			if (File.Exists(_path) == false)
			{
				json = null;
				return false;
			}
			
			json = File.ReadAllText(_path);
			return true;
		}

		public void Delete()
		{
			if (File.Exists(_path))
				File.Delete(_path);

			string bak = _path + ".bak";
			
			if (File.Exists(bak))
				File.Delete(bak);

			string tmp = _path + ".tmp";
			
			if (File.Exists(tmp))
				File.Delete(tmp);
		}
	}
}