using System.Collections.Generic;
using Services.JsonConvertServices;
using Services.PersistentProgressServices;

namespace Services.SaveLoadServices
{
	public sealed class SaveLoadService : ISaveLoadService
	{
		private readonly IPersistentProgressService _persistentProgressService;
		private readonly IFileProgressStorage _fileProgressStorage;
		private readonly IJsonConvertService _jsonConvertService;

		private readonly List<IProgressReader> _progressReaders = new();

		public SaveLoadService(
			IPersistentProgressService persistentProgressService, 
			IFileProgressStorage fileProgressStorage,
			IJsonConvertService jsonConvertService)
		{
			_persistentProgressService = persistentProgressService;
			_fileProgressStorage = fileProgressStorage;
			_jsonConvertService = jsonConvertService;
		}

		public IReadOnlyList<IProgressReader> ProgressReaders => _progressReaders;

		public bool HasSavedProgress => _fileProgressStorage.HasData;

		public void RegisterProgressReader(IProgressReader reader)
		{
			if (reader == null)
				return;
			
			_progressReaders.Add(reader);
		}

		public void UnregisterProgressReader(IProgressReader reader)
		{
			if (reader == null)
				return;

			_progressReaders.Remove(reader);
		}

		public void SaveProgress()
		{
			UpdateProgressWriters();

			string json = _jsonConvertService.ToJson(_persistentProgressService.ProjectProgress);
			_fileProgressStorage.Save(json);
		}

		public void LoadProgress()
		{
			if (_fileProgressStorage.TryLoad(out string json))
				_persistentProgressService.LoadProgress(json);
			else
				_persistentProgressService.SetDefaultProgress();

			UpdateProgressReaders();
		}

		public void DeleteSaves() =>
			_fileProgressStorage.Delete();

		private void UpdateProgressReaders()
		{
			ProjectProgress progress = _persistentProgressService.ProjectProgress;

			for (int i = 0; i < _progressReaders.Count; i++)
				_progressReaders[i].ReadProgress(progress);
		}

		private void UpdateProgressWriters()
		{
			ProjectProgress progress = _persistentProgressService.ProjectProgress;

			for (int i = 0; i < _progressReaders.Count; i++)
			{
				if (_progressReaders[i] is IProgressWriter writer)
					writer.WriteProgress(progress);
			}
		}
	}
}