﻿using System;
namespace ChristmasPastryShop.Models.Delicacies
{
    public class Stolen : Delicacy
    {
        private const double StolenPrice = 3.50;

        public Stolen(string name) : base(name, StolenPrice)
        {
        }
    }
}

