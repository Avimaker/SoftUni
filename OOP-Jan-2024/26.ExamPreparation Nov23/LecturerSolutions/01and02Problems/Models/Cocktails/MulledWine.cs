﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class MulledWine : Cocktail
    {
        public MulledWine(string name, string size) 
            : base(name, size, 13.50)
        {
        }
    }
}
