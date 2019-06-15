using RPG;

namespace PotionPrefabs
{
    class HealPotion : Potion
    {
        private Player player;
        public HealPotion(Player player, int healAmount)
            :base(new ConsumableStats("HealPotion",1,player.AddHealth))
        {
            PotionPower = healAmount;
            this.player = player;
            player.Inventory.Add(this);

        }
        public override void Use()
        {
            this.consumableStats.effects(PotionPower);
            player.Inventory.Remove(this);
        }
    }

    class XpPotion : Potion
    {
        private Player player;
        public XpPotion(Player player, int xpAmount, int weight = 1)
                :base(new ConsumableStats("XpPotion",weight,player.AddingXp))
        {
            PotionPower = xpAmount;
            this.player = player;
            player.Inventory.Add(this);
        }
        public override void Use()
        {
            this.consumableStats.effects(PotionPower);
            player.Inventory.Remove(this);
        }
    }
}
