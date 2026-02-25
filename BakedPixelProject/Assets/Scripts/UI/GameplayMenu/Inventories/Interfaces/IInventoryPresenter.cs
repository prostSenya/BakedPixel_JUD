using Services.PersistentProgressServices;
using UI.BaseUI.Interfaces;

namespace UI.GameplayMenu.Inventories.Interfaces
{
	public interface IInventoryPresenter : IPresenter
	{
		void WriteProgress(ProjectProgress projectProgress);
	}
}
