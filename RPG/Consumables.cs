using System;

namespace RPG
{
    /// <summary>
    /// Характеристики расходных предметов
    /// </summary>
    class ConsumableStats
    {
        /// <summary>
        /// Создание характеристик расходного предмета
        /// </summary>
        /// <param name="Name">Название расходника</param>
        /// <param name="Weight">Вес расходника</param>
        /// <param name="effects">Эффекты расходника</param>
        public ConsumableStats(string Name, int Weight, Effect.Effects effects)
        {
            this.Name = Name;
            this.Weight = Weight;
            this.effects = effects;
        }

        /// <summary>
        /// Имя расходника
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Вес расходника
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Список эффектов расходника
        /// </summary>
        public Effect.Effects effects { get; set; }


    }

    /// <summary>
    /// Расходный предмет
    /// </summary>
    class Consumables : Item
    {
        /// <summary>
        /// Создание расходного предмета
        /// </summary>
        /// <param name="consumableStats"></param>
        public Consumables(ConsumableStats consumableStats)
        {
            this.consumableStats = consumableStats;
            Name = consumableStats.Name;
            Weight = consumableStats.Weight;
        }

        /// <summary>
        /// Характеристики расходного предмета
        /// </summary>
        public ConsumableStats consumableStats { get; set; }
    }

    /// <summary>
    /// Зелье
    /// </summary>
    class Potion : Consumables
    {
        /// <summary>
        /// Создание зелья
        /// </summary>
        /// <param name="consumableStats">Характеристики расходного предмета</param>
        public Potion(ConsumableStats consumableStats) : base(consumableStats)
        {

        }

        /// <summary>
        /// Эффективность зелья
        /// </summary>
        public int PotionPower { get; set; }
    }


}
