using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Munchkin;

namespace Munchkin.Cards
{
    
    public enum Size
    {
        Small,
        Big
    }
    public  class Treasure : Card
    {
        
        public int Price { get; set; }
        
        //Effect effect
        //Specific specific
        public Treasure(string source, string name, Active? action, Condition condition, int price)
        {
            this.action = action;
            image.Source = new ImageSourceConverter().ConvertFromString(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Resources\\Cards\\Treasures\\" + source) as ImageSource;
            Price = price;
            Name = name;
        }
    }
}
