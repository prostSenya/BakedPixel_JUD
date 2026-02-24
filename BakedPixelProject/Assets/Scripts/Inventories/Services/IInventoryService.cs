using System.Collections.Generic;
using Bullets;
using Inventories.Domain;
using Weapons;

namespace Inventories.Services
{
	public interface IInventoryService
	{
		bool IsEmptyInventory { get; }
		int SlotCount { get; }
		IReadOnlyList<IReadOnlyInventorySlot> Slots { get; }
		public bool IsFullInventory();
		bool TrySetStackableItem(ItemKey itemKey, int count);
		bool TryGetWeaponByBullet(BulletType randomBulletType, out WeaponType weaponType);
		void RemoveBullet(BulletType randomBulletType);
		InventorySlot GetRandomSlot();
		bool TrySetItem(ItemKey itemKey, int count = 1);
	}
}