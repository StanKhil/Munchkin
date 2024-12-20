using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Munchkin.Cards
{
    public delegate void Active();
    internal class Card
    {
        protected bool? active = false;
        protected Active? action;
        protected string? name;
        protected Image? image;

        public bool? Activated
        {
            get { return active; }
            set { active = value; }
        }

    }
}
