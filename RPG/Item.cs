﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{


    class Item
    {
        public string Name { get; set; }
        public int Weight { get; set; }

        public virtual void Use()
        {

        }
    }



}
