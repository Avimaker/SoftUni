﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Delicacies
{
    public class Stolen : Delicacy
    {
        public Stolen(string name) 
            : base(name, 3.50)
        {
        }
    }
}
