using System;
using System.Linq;
using Armors;
using Bullets;
using Weapons;

namespace Helpers
{
	public static class EnumHelper
	{
		public static bool TryParse<TEnum>(int value, out TEnum result)
			where TEnum : struct, Enum
		{
			if (Enum.IsDefined(typeof(TEnum), value))
			{
				result = (TEnum)(object)value;
				return true;
			}

			result = default;
			return false;
		}

		public static ArmorType[] GetArmorTypes() =>
			Enum.GetValues(typeof(ArmorType))
				.Cast<ArmorType>()
				.Where(type => type != ArmorType.Unknown)
				.ToArray();
		
		public static BulletType[] GetBulletTypes() =>
			Enum.GetValues(typeof(BulletType))
				.Cast<BulletType>()
				.Where(type => type != BulletType.Unknown)
				.ToArray();
		
		public static WeaponType[] GetWeaponTypes() =>
			Enum.GetValues(typeof(WeaponType))
				.Cast<WeaponType>()
				.Where(type => type != WeaponType.Unknown)
				.ToArray();
	}
}