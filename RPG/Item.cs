using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{

    /// <summary>
    /// Базовый класс "предмет"
    /// </summary>
    class Item
    {
        /// <summary>
        /// Название предмета
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Вес предмета
        /// </summary>
        public int Weight { get; set; }


        /// <summary>
        /// Использование предмета
        /// </summary>
        public virtual void Use()
        {

        }
    }



}
