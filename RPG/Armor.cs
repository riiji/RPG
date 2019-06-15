using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    enum ArmorType
    {
        Cloth,
        Leather,
        Chain,
        Plate
    }

    class ArmorStats
    {
        public ArmorStats(string Name, int Health, int Weight,int Armor, ArmorType armorType, Effect.Effects effects = null)
        {
            this.Name = Name;
            this.Health = Health;
            this.Weight = Weight;
            this.Armor = Armor;
            this.effects = effects;
            this.armorType = armorType;
        }

        /// <summary>
        /// Armor Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Additional Health
        /// </summary>
        public int Health { get; set; }


        /// <summary>
        /// Weight of armor
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Additional Armor
        /// </summary>
        public int Armor { get; set; }

        /// <summary>
        /// Effects
        /// </summary>
        public Effect.Effects effects { get; set; }

        /// <summary>
        /// Type of armor
        /// </summary>
        public ArmorType armorType;
    }

    class Armor : Item
    {
        public Armor(ArmorStats armorStats)
        {
            this.armorStats = armorStats;


            Name = armorStats.Name;
            Weight = armorStats.Weight;
        }
        public ArmorStats armorStats { get; set; }
    }

    class Helmet : Armor
    {
        public Helmet(ArmorStats armorStats) : base(armorStats)
        {

        }

    }

    class Chest: Armor
    {
        public Chest(ArmorStats armorStats) : base(armorStats)
        {

        }
    }

    class Pants : Armor
    {
        public Pants(ArmorStats armorStats) : base(armorStats)
        {

        }
    }

    class Boots : Armor
    {
        public Boots(ArmorStats armorStats) : base(armorStats)
        {

        }
    }

    class Wrist : Armor
    {
        public Wrist(ArmorStats armorStats) : base(armorStats)
        {

        }
    }


}
