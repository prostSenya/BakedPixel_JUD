using Bullets;
using Inventories.Domain;
using Weapons;

namespace Inventories.Services
{
	public interface IInventoryService
	{
		bool IsEmptyInventory { get; }
		bool TrySetItem(InventorySlot.ItemKey itemKey, int count);
		bool TryGetWeaponByBullet(BulletType randomBulletType, out WeaponType weaponType);
		void RemoveBullet(BulletType randomBulletType);
		InventorySlot GetRandomSlot();
	}
}