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
        /// <summary>
        /// Создание характеристик оружия
        /// </summary>
        /// <param name="Name">Название оружия</param>
        /// <param name="Power">Сила оружия</param>
        /// <param name="Weight">Вес оружия</param>
        /// <param name="weaponType">Тип оружия</param>
        /// <param name="effects">Способности оружия</param>
        public WeaponStats(string Name, int Power, int Weight, WeaponType weaponType, Effect.Effects effects = null)
        {
            this.Name = Name;
            this.Weight = Weight;
            this.effects = effects;
            this.weaponType = weaponType;

            if (weaponType == WeaponType.Axe || weaponType == WeaponType.Sword || weaponType == WeaponType.Bow)
            {
                AD = Power;
                AP = 0;
            }
            if (weaponType == WeaponType.Wand || weaponType == WeaponType.Staff)
            {
                AD = 0;
                AP = Power;
            }
            if (weaponType == WeaponType.Dagger)
            {
                AD = Power / 2;
                AP = Power / 2;
            }



        }

        /// <summary>
        /// Название оружия
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Сила атаки оружия
        /// </summary>
        public int AD { get; set; }

        /// <summary>
        /// Сила заклинаний оружия
        /// </summary>
        public int AP { get; set; }

        /// <summary>
        /// Вес оружия
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Является ли двуручным?
        /// </summary>
        public bool IsTwoHanded { get; set; }

        /// <summary>
        /// Список способностей оружия
        /// </summary>
        public Effect.Effects effects { get; set; }

        /// <summary>
        /// Тип оружия
        /// </summary>
        public WeaponType weaponType { get; set; }
    }

    class Weapon : Item
    {
        /// <summary>
        /// Создание оружия
        /// </summary>
        /// <param name="weaponStats">Характеристики оружия</param>
        public Weapon(WeaponStats weaponStats)
        {
            this.weaponStats = weaponStats;
            Name = weaponStats.Name;
            Weight = weaponStats.Weight;
        }


        public WeaponStats weaponStats { get; set; }
    }
}
