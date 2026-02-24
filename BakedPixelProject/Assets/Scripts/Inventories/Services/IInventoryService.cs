using System;
using System.Collections.Generic;
using Bullets;
using Inventories.Domain;
using Weapons;

namespace Inventories.Services
{
	public interface IInventoryService
	{
		Inventory Inventory { get; }
		bool TryUnlockSlot(int slotIndex);
		bool TrySetItem(InventorySlot.ItemKey itemKey, int count);
		bool TryClearItem(int slotIndex);
		bool HaveWeaponTypes(IEnumerable<WeaponType> weaponTypes);
		bool TryGetWeaponByBullet(BulletType randomBulletType, out WeaponType weaponType);
		void RemoveBullet(BulletType randomBulletType);
	}
}