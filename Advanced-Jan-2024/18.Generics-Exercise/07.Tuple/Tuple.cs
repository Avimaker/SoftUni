﻿using System;
namespace Tuple
{
	public class Tuple<T1, T2>
	{

        public Tuple()
        {

        }

        public Tuple(T1 item1, T2 item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public T1 item1 { get; set; }
		public T2 item2 { get; set; }


    }
}

