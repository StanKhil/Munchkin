using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Munchkin.Cards
{
    public class Door : Card
    {
        public Door(string source, string name, Active action)
        {
            Name = name;
            image.Source = new ImageSourceConverter().ConvertFromString(source) as ImageSource;
            this.action = action;
        }


    }
}
