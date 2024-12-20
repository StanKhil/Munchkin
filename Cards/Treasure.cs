﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Munchkin.Cards
{
    
    enum Size
    {
        Small,
        Big
    }
    public  class Treasure : Card
    {
        
        public int Price { get; set; }
        
        //Effect effect
        //Specific specific
        public Treasure(string source, string name, Active? action, int price)
        {
            this.action = action;
            image.Source = new ImageSourceConverter().ConvertFromString(source) as ImageSource;
            Price = price;
            Name = name;
        }
    }
}
