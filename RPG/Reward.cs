using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Reward
    {
        /// <summary>
        /// Создание награды 
        /// </summary>
        /// <param name="GoldAmount">Золото за выполнение</param>
        /// <param name="XpAmount">Опыт за выполнение</param>
        /// <param name="RewardItems">Предметы за выполнение</param>
        public Reward(int GoldAmount = 0, int XpAmount = 0, List<Item> RewardItems = null)
        {
            this.GoldAmount = GoldAmount;
            this.XpAmount = XpAmount;
            this.RewardItems = RewardItems;
        }

        public int GoldAmount { get; set; }
        public int XpAmount { get; set; }
        public List<Item> RewardItems { get; set; }


    }







}
