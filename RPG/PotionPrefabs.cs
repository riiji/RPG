using RPG;

namespace PotionPrefabs
{
    class HealPotion : Potion
    {
        private Player player;


        /// <summary>
        /// Создание Зелье лечения
        /// </summary>
        /// <param name="player">Персонаж</param>
        /// <param name="healAmount">Количество лечения</param>
        public HealPotion(Player player, int healAmount)
            : base(new ConsumableStats("HealPotion", 1, player.AddHealth))
        {
            PotionPower = healAmount;
            this.player = player;
            player.Inventory.Add(this);

        }

        /// <summary>
        /// Использование зелья
        /// </summary>
        public override void Use()
        {
            this.consumableStats.effects(PotionPower);
            player.Inventory.Remove(this);
        }
    }


    /// <summary>
    /// Зелье опыта
    /// </summary>
    class XpPotion : Potion
    {
        private Player player;

        /// <summary>
        /// Создание зелья опыта
        /// </summary>
        /// <param name="player">Персонаж</param>
        /// <param name="xpAmount">Количество опыта за использование</param>
        /// <param name="weight">Вес зелья</param>
        public XpPotion(Player player, int xpAmount, int weight = 1)
                : base(new ConsumableStats("XpPotion", weight, player.AddingXp))
        {
            PotionPower = xpAmount;
            this.player = player;
            player.Inventory.Add(this);
        }

        /// <summary>
        /// Использование зелья
        /// </summary>
        public override void Use()
        {
            this.consumableStats.effects(PotionPower);
            player.Inventory.Remove(this);
        }
    }
}
