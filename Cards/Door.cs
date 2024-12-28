using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;

namespace Munchkin.Cards
{
    public class Door : Card
    {
        public Door(string source, string name, Active action, Condition condition, Discard discard)
        {
            Name = name;
            image.Source = new ImageSourceConverter().ConvertFromString(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Resources\\Cards\\Doors\\" + source) as ImageSource;
            this.action = action;
            this.condition = condition;
            this.discard = discard;
        }


    }
}
