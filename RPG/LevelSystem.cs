using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    /// <summary>
    /// Система уровней
    /// </summary>
    class LevelSystem
    {

        /// <summary>
        /// Получение максимального опыта для текущего уровня
        /// </summary>
        /// <param name="level">Уровень</param>
        /// <returns></returns>
        public static int XPbyLevel(int level)
        {
            return (int)(100 * (Math.Pow(1.15, level - 1)));
        }

        /// <summary>
        /// Получение максимального здоровья для текущего уровня
        /// </summary>
        /// <param name="level">Уровень</param>
        /// <returns></returns>
        public static int HealthbyLevel(int level)
        {
            return 100 * level;
        }

        /// <summary>
        /// Повышение уровня персонажа и обновление характеристик
        /// </summary>
        /// <param name="stats">Характеристики персонажа</param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static PlayerStats LevelUp(PlayerStats stats, int count)
        {
            stats.Level++;
            stats.Xp = count;
            stats.MaxXp = XPbyLevel(stats.Level);
            stats.MaxHealth = HealthbyLevel(stats.Level);
            stats.Health = stats.MaxHealth;

            return stats;
        }
        /// <summary>
        /// Понижение уровня персонажа и обновление характеристик
        /// </summary>
        /// <param name="stats"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static PlayerStats LevelDown(PlayerStats stats, int count)
        {
            stats.Level--;
            stats.MaxXp = XPbyLevel(stats.Level);
            stats.Xp = stats.MaxXp - count;
            stats.MaxHealth = HealthbyLevel(stats.Level);
            if (stats.Health > stats.MaxHealth)
                stats.Health = stats.MaxHealth;
            return stats;
        }

    }

}
