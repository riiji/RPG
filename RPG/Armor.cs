using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    /// <summary>
    /// Список типов брони
    /// </summary>
    enum ArmorType
    {
        Cloth,
        Leather,
        Chain,
        Plate
    }

    /// <summary>
    /// Характеристики брони
    /// </summary>
    class ArmorStats
    {

        /// <summary>
        /// Создание характеристик брони
        /// </summary>
        /// <param name="Name">Название брони</param>
        /// <param name="Health">Добавляемое здоровье предмета</param>
        /// <param name="Weight">Вес предмета</param>
        /// <param name="Armor">Добавлямая броня предмета</param>
        /// <param name="armorType">Тип брони</param>
        /// <param name="effects">Способности брони</param>
        public ArmorStats(string Name, int Health, int Weight, int Armor, ArmorType armorType, Effect.Effects effects = null)
        {
            this.Name = Name;
            this.Health = Health;
            this.Weight = Weight;
            this.Armor = Armor;
            this.effects = effects;
            this.armorType = armorType;
        }

        /// <summary>
        /// Название брони
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Добавляемое здоровье
        /// </summary>
        public int Health { get; set; }


        /// <summary>
        /// Вес брони
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Добавляемая броня
        /// </summary>
        public int Armor { get; set; }

        /// <summary>
        /// Способности брони
        /// </summary>
        public Effect.Effects effects { get; set; }

        /// <summary>
        /// Тип брони
        /// </summary>
        public ArmorType armorType;
    }

    /// <summary>
    /// Броня
    /// </summary>
    class Armor : Item
    {
        /// <summary>
        /// Создание брони
        /// </summary>
        /// <param name="armorStats">Характеристики брони</param>
        public Armor(ArmorStats armorStats)
        {
            this.armorStats = armorStats;


            Name = armorStats.Name;
            Weight = armorStats.Weight;
        }

        /// <summary>
        /// Характеристики брони
        /// </summary>
        public ArmorStats armorStats { get; set; }
    }

    /// <summary>
    /// Шлем
    /// </summary>
    class Helmet : Armor
    {
        /// <summary>
        /// Создание шлема
        /// </summary>
        /// <param name="armorStats">Характеристики шлема</param>
        public Helmet(ArmorStats armorStats) : base(armorStats)
        {

        }

    }

    /// <summary>
    /// Нагрудник
    /// </summary>
    class Chest : Armor
    {
        /// <summary>
        /// Создание нагрудника
        /// </summary>
        /// <param name="armorStats">Характеристики нагрудника</param>
        public Chest(ArmorStats armorStats) : base(armorStats)
        {

        }
    }

    /// <summary>
    /// Штаны
    /// </summary>
    class Pants : Armor
    {
        /// <summary>
        /// Создание штанов
        /// </summary>
        /// <param name="armorStats">Характеристики штанов</param>
        public Pants(ArmorStats armorStats) : base(armorStats)
        {

        }
    }

    /// <summary>
    /// Ботинки
    /// </summary>
    class Boots : Armor
    {
        /// <summary>
        /// Создание ботинок
        /// </summary>
        /// <param name="armorStats">Характеристики ботинок</param>
        public Boots(ArmorStats armorStats) : base(armorStats)
        {

        }
    }
    /// <summary>
    /// Запястья
    /// </summary>
    class Wrist : Armor
    {
        /// <summary>
        /// Создание запястей
        /// </summary>
        /// <param name="armorStats">Характеристики запястей</param>
        public Wrist(ArmorStats armorStats) : base(armorStats)
        {

        }
    }


}
