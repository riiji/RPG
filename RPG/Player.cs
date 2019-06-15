using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class PlayerStats
    {
        /// <summary>
        /// Создание характеристики персонажа
        /// </summary>
        /// <param name="Id">ID персонажа</param>
        /// <param name="Role">Класс персонажа</param>
        /// <param name="Health">Здоровья персонажа</param>
        /// <param name="MaxHealth">Максимальное здоровье персонажа</param>
        /// <param name="Xp">Опыт персонажа</param>
        /// <param name="MaxXp">Максимальный опыт персонажа</param>
        /// <param name="Level">Уровень персонажа</param>
        /// <param name="gold">Золото персонажа</param>
        public PlayerStats(int Id, Classes Role, int Health = 100, int MaxHealth = 100, int Xp = 0, int MaxXp = 100, int Level = 1, int Gold = 0)
        {
            this.Id = Id;
            this.Health = Health;
            this.MaxHealth = Health;
            this.Xp = Xp;
            this.MaxXp = MaxXp;
            this.Level = Level;
            this.Gold = Gold;
            this.Role = Role;

        }

        /// <summary>
        /// ID персонажа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Текущее здоровье персонажа
        /// </summary>
        public int GetHealth
        {
            get
            {
                return Health + AdditionalHealth;
            }
        }

        /// <summary>
        /// Текущее максимальное здоровья персонажа
        /// </summary>
        public int GetMaxHealth
        {
            get
            {
                return MaxHealth + AdditionalHealth;
            }
        }


        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int AdditionalHealth { get; set; } = 0;


        /// <summary>
        /// Player XP
        /// </summary>
        public int Xp { get; set; }

        /// <summary>
        /// Player MAX XP
        /// </summary>
        public int MaxXp { get; set; }

        /// <summary>
        /// Player Level
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Player Class
        /// </summary>
        public Classes Role { get; set; }

        /// <summary>
        /// Player gold
        /// </summary>
        public int Gold { get; set; } = 0;

        public int Armor { get; set; } = 0;
    }

    class Player
    {

        public PlayerStats Stats { get; set; }
        public List<Item> Inventory { get; set; }
        public Location Location { get; set; } = Location.Newborn;
        public delegate void funcs();

        public Helmet helmet = null;
        public Chest chest = null;
        public Pants pants = null;
        public Boots boots = null;
        public Wrist wrist = null;
        public Weapon weapon = null;

        public Player(PlayerStats stats)
        {
            Stats = stats;
            Inventory = new List<Item>();
            Stats.Armor = 0;

        }

        /// <summary>
        /// Добавить здоровье персонажу
        /// </summary>
        /// <param name="count">Количество здоровья</param>
        public void AddHealth(int count)
        {
            if (count < 0)
            {
                SubHealth(-count);
                return;
            }
            Stats.Health += count;
            if (Stats.Health > Stats.MaxHealth)
                Stats.Health = Stats.MaxHealth;
        }

        /// <summary>
        /// Вычесть здоровье персонажа
        /// </summary>
        /// <param name="count">Количество здоровья</param>
        public void SubHealth(int count)
        {
            if (count < 0)
            {
                AddHealth(-count);
                return;
            }
            Stats.Health -= count;
            if (Stats.Health < 0)
                Stats.Health = 0;
        }

        /// <summary>
        /// Добавить опыт персонажа 
        /// </summary>
        /// <param name="count">Количество опыта</param>
        public void AddingXp(int count)
        {
            Stats.Xp += count;
            while (Stats.Xp >= Stats.MaxXp)
            {
                Stats = LevelSystem.LevelUp(Stats, Stats.Xp - Stats.MaxXp);
            }
        }

        /// <summary>
        /// Вычесть опыт персонажа
        /// </summary>
        /// <param name="count">Количество опыта</param>
        public void SubstractXp(int count)
        {
            Stats.Xp -= count;
            while (Stats.Xp < 0)
            {
                Stats = LevelSystem.LevelDown(Stats, -Stats.Xp);
            }
        }

        /// <summary>
        /// Перемещение персонажа в другую локацию
        /// </summary>
        /// <param name="id">ID локации</param>
        public void Travel(int id)
        {
            int dst = Map.distance[(int)Location, id];
            if (dst == -1)
                return;

            int reqgold = dst / 10;
            if (this.Stats.Gold < reqgold)
                return;
            else
                this.Stats.Gold -= reqgold;
            Location = (Location)id;
        }

        /// <summary>
        /// Получить награду
        /// </summary>
        /// <param name="reward">Награда</param>
        public void GetReward(Reward reward)
        {
            this.Stats.Gold += reward.GoldAmount;
            this.AddingXp(reward.XpAmount);

            foreach (var item in reward.RewardItems)
            {
                this.Inventory.Add(item);
            }
        }

        /// <summary>
        /// Надеть предмет
        /// </summary>
        /// <param name="item">Предмет</param>
        public void Equip(Item item)
        {
            if (Class.EquipForClass(this, item))
            {
                if (item is Weapon)
                {
                    if (weapon != null)
                        UnEquip(typeof(Weapon));
                    weapon = (Weapon)item;
                }
                if (item is Armor)
                {
                    if (item is Helmet)
                    {
                        if (helmet != null)
                            UnEquip(typeof(Helmet));
                        helmet = item as Helmet;
                    }

                    if (item is Chest)
                    {
                        if (chest != null)
                            UnEquip(typeof(Chest));
                        chest = item as Chest;
                    }

                    if (item is Pants)
                    {
                        if (pants != null)
                            UnEquip(typeof(Pants));
                        pants = item as Pants;
                    }

                    if (item is Boots)
                    {
                        if (boots != null)
                            UnEquip(typeof(Boots));
                        boots = item as Boots;
                    }

                    if (item is Wrist)
                    {
                        if (wrist != null)
                            UnEquip(typeof(Wrist));
                        wrist = item as Wrist;
                    }
                }
                this.Inventory.Remove(item);
                StatsUpdate();
            }
            else
                return;
        }

        /// <summary>
        /// Снять вещь 
        /// </summary>
        /// <param name="type">Тип предмета</param>
        public void UnEquip(Type type)
        {
            if (type == typeof(Helmet))
            {
                if (helmet != null)
                    this.Inventory.Add(helmet);
                helmet = null;
            }

            if (type == typeof(Chest))
            {
                if (chest != null)
                    this.Inventory.Add(chest);
                chest = null;
            }

            if (type == typeof(Pants))
            {
                if (pants != null)
                    this.Inventory.Add(pants);
                pants = null;
            }

            if (type == typeof(Boots))
            {
                if (boots != null)
                    this.Inventory.Add(boots);
                boots = null;
            }

            if (type == typeof(Wrist))
            {
                if (wrist != null)
                    this.Inventory.Add(wrist);

                wrist = null;
            }

            if (type == typeof(Weapon))
            {
                if (weapon != null)
                    this.Inventory.Add(weapon);
                weapon = null;
            }
            StatsUpdate();

        }

        /// <summary>
        /// Обновление характеристик персонажа
        /// </summary>
        public void StatsUpdate()
        {
            this.Stats.MaxHealth = LevelSystem.HealthbyLevel(this.Stats.Level);
            this.Stats.Armor = 0;

            if (helmet != null)
            {
                this.Stats.AdditionalHealth += helmet.armorStats.Health;
                this.Stats.Armor += helmet.armorStats.Armor;
            }
            if (chest != null)
            {
                this.Stats.AdditionalHealth += chest.armorStats.Health;
                this.Stats.Armor += chest.armorStats.Armor;
            }
            if (pants != null)
            {
                this.Stats.AdditionalHealth += pants.armorStats.Health;
                this.Stats.Armor += pants.armorStats.Armor;
            }
            if (boots != null)
            {
                this.Stats.AdditionalHealth += boots.armorStats.Health;
                this.Stats.Armor += boots.armorStats.Armor;

            }
            if (wrist != null)
            {
                this.Stats.AdditionalHealth += wrist.armorStats.Health;
                this.Stats.Armor += wrist.armorStats.Armor;
            }





        }
    }
}
