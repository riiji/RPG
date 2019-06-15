using System;

namespace RPG
{
    class ConsumableStats
    {
        public ConsumableStats(string Name, int Weight, Effect.Effects effects)
        {
            this.Name = Name;
            this.Weight = Weight;
            this.effects = effects;
        }

        /// <summary>
        /// Consumable Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Consumable Weight
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// List of effects
        /// </summary>
        public Effect.Effects effects { get; set; }


    }

    class Consumables : Item
    {
        public Consumables(ConsumableStats consumableStats)
        {
            this.consumableStats = consumableStats;
            Name = consumableStats.Name;
            Weight = consumableStats.Weight;
        }

        public ConsumableStats consumableStats { get; set; }
    }

    class Potion : Consumables
    {
        public Potion(ConsumableStats consumableStats) : base(consumableStats)
        {

        }

        public int PotionPower { get; set; }
    }


}
