using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    enum Classes
    {
        Warrior,
        Paladin,
        Hunter,
        Rogue,
        Priest,
        DeathKnight,
        Shaman,
        Mage,
        Warlock,
        Monk,
        Druid,
        DemonHunter
    }

    class Class
    {
        public static bool EquipForClass(Player player, Item item)
        {
            if (item is Armor armor)
            {
                if (player.Stats.Role == Classes.DeathKnight)
                    return true;

                ArmorType armorType = armor.armorStats.armorType;
                Classes role = player.Stats.Role;


                if (role == Classes.DemonHunter)
                {
                    if (armorType == ArmorType.Plate)
                        return false;
                    else
                        return true;
                }

                if(role==Classes.Druid)
                {
                    if (armorType == ArmorType.Chain || armorType == ArmorType.Plate)
                        return false;
                    else
                        return true;
                }

                if(role==Classes.Hunter)
                {
                    if (armorType == ArmorType.Chain || armorType == ArmorType.Plate)
                        return false;
                    else
                        return true;
                }

                if(role==Classes.Mage)
                {
                    if (armorType == ArmorType.Cloth)
                        return true;
                    else
                        return false;
                }

                if(role==Classes.Monk)
                {
                    if (armorType == ArmorType.Plate || armorType == ArmorType.Chain)
                        return false;
                    else
                        return true;
                }

                if(role==Classes.Paladin)
                {
                    return true;
                }

                if(role==Classes.Priest)
                {
                    if (armorType == ArmorType.Cloth)
                        return true;
                    else
                        return false;
                }

                if(role==Classes.Rogue)
                {
                    if (armorType == ArmorType.Leather || armorType == ArmorType.Cloth)
                        return true;
                    else
                        return false;
                }

                if(role==Classes.Shaman)
                {
                    if (armorType == ArmorType.Plate)
                        return false;
                    else
                        return true;
                }

                if(role==Classes.Warlock)
                {
                    if (armorType == ArmorType.Cloth)
                        return true;
                    else
                        return false;
                }

                if(role==Classes.Warrior)
                {
                    return true;
                }
                return false;
            }
            else if (item.GetType() == typeof(Weapon))
            {
                Weapon weapon = (Weapon)item;
                Classes role = player.Stats.Role;
                WeaponType weaponType = weapon.weaponStats.weaponType;


                if(role==Classes.DeathKnight)
                {
                    if (weaponType == WeaponType.Axe || weaponType == WeaponType.Sword)
                    {
                        return true;
                    }
                    else
                        return false;
                }

                if(role==Classes.DemonHunter)
                {
                    if (weaponType == WeaponType.Axe || weaponType == WeaponType.Sword || weaponType == WeaponType.Dagger)
                        return true;
                    else
                        return false;
                }

                if(role==Classes.Druid)
                {
                    if (weaponType == WeaponType.Staff || weaponType == WeaponType.Wand)
                        return true;
                    else
                        return false;
                }

                if (role == Classes.Hunter)
                {
                    if (weaponType == WeaponType.Bow)
                        return true;
                    else
                        return false;
                }

                if (role == Classes.Mage)
                {
                    if (weaponType == WeaponType.Staff || weaponType == WeaponType.Wand || weaponType == WeaponType.Dagger)
                        return true;
                    else
                        return false;
                }

                if (role == Classes.Monk)
                {
                    if (weaponType == WeaponType.Dagger || weaponType == WeaponType.Staff)
                        return true;
                    else
                        return false;
                }

                if (role == Classes.Paladin)
                {
                    if (weaponType == WeaponType.Axe || weaponType == WeaponType.Sword)
                        return true;
                    else
                        return false;
                }

                if (role == Classes.Priest)
                {
                    if (weaponType == WeaponType.Staff || weaponType == WeaponType.Wand || weaponType==WeaponType.Dagger)
                        return true;
                    else
                        return false;
                }

                if (role == Classes.Rogue)
                {
                    if (weaponType == WeaponType.Dagger)
                        return true;
                    else
                        return false;
                }

                if (role == Classes.Shaman)
                {
                    if (weaponType == WeaponType.Staff || weaponType == WeaponType.Wand)
                        return true;
                    else
                        return false;
                }

                if (role == Classes.Warlock)
                {
                    if (weaponType == WeaponType.Staff || weaponType == WeaponType.Wand || weaponType==WeaponType.Dagger)
                        return true;
                    else
                        return false;
                }

                if (role == Classes.Warrior)
                {
                    if (weaponType == WeaponType.Axe || weaponType == WeaponType.Sword)
                        return true;
                    else
                        return false;
                }

                return false;
            }
            else
            {
                return false;
            }
        }
    }

}
