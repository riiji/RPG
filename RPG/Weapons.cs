using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    enum WeaponType
    {
        Sword,
        Axe,
        Dagger,
        Wand,
        Staff,
        Bow
    }

    class WeaponStats
    {
        public WeaponStats(string Name, int Power, int Weight, WeaponType weaponType, Effect.Effects effects = null)
        {
            this.Name = Name;
            this.Weight = Weight;
            this.effects = effects;
            this.weaponType = weaponType;

            if(weaponType==WeaponType.Axe || weaponType==WeaponType.Sword || weaponType == WeaponType.Bow)
            {
                AD = Power;
                AP = 0;
            }
            if(weaponType==WeaponType.Wand || weaponType==WeaponType.Staff)
            {
                AD = 0;
                AP = Power;
            }
            if(weaponType==WeaponType.Dagger)
            {
                AD = Power / 2;
                AP = Power / 2;
            }


            
        }

        /// <summary>
        /// Weapon Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Attack Damage
        /// </summary>
        public int AD { get; set; }

        /// <summary>
        /// Ability Power
        /// </summary>
        public int AP { get; set; }

        /// <summary>
        /// Weapon Weight
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Is Two Handed Weapon?
        /// </summary>
        public bool IsTwoHanded { get; set; }

        /// <summary>
        /// List of weapon effects
        /// </summary>
        public Effect.Effects effects { get; set; }

        public WeaponType weaponType { get; set; }
    }

    class Weapon : Item
    {
        public Weapon(WeaponStats weaponStats)
        {
            this.weaponStats = weaponStats;
            Name = weaponStats.Name;
            Weight = weaponStats.Weight;
        }

        public WeaponStats weaponStats { get; set; }
    }
}
