using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestEngine
{
    class Quest
    {
        /// <summary>
        /// Описание задания
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Награда за задание
        /// </summary>
        RPG.Reward reward { get; set; }
    }




}
