﻿using System;
namespace ChristmasPastryShop.Models.Cocktails
{
    public class Hibernation : Cocktail
    {
        private const double LargeHibernation = 10.50; 

        public Hibernation(string name, string size) : base(name, size, LargeHibernation)
        {
        }
    }
}

