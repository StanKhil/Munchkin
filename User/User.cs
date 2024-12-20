using Munchkin.Cards;
using Munchkin.Cards.Treasures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin.User
{
    enum State
    {
        Men,
        Women
    }
    internal class User
    {
        int level;
        int money;
        int power;
        State state;
        List<Treasure> treasures = new List<Treasure>();
        List<Door> doors = new List<Door>();
        Armor? body;
        Armor? head;
        Armor? legs;

        public void Fight() { }
    }
}
