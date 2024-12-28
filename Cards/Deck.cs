using Munchkin.Cards;
using Munchkin.Cards.Treasures;
using Munchkin.Cards.Doors;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Munchkin.Player;
using System.Windows.Media.Animation;
using System.Windows;

namespace Munchkin.Cards
{
    public class Deck : INotifyPropertyChanged
    {
        private ObservableCollection<Treasure> treasures;
        private ObservableCollection<Door> doors;
        GameManager gameManager;

        public ObservableCollection<Treasure> Treasures
        {
            get => treasures;
            set
            {
                if (treasures != value)
                {
                    treasures = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Door> Doors
        {
            get => doors;
            set
            {
                if (doors != value)
                {
                    doors = value;
                    OnPropertyChanged();
                }
            }
        }

        public Deck(GameManager gameManager)
        {
            this.gameManager = gameManager;
            Treasures = new ObservableCollection<Treasure>
            {
                new Treasure("1000GoldPieces.png", "1000 Gold pieces", delegate(User? user) 
                {
                    if(user != null)
                        user.Level++;
                }, delegate(User? user)
                {
                    if(user != null)
                        if(user.Level < 9) return true;
                    return false;
                }, null, 1000),
                new Armor("BootsOfButtKicking.png", "Boots Of Butt Kicking", delegate(User? user)
                {
                    if(user != null)
                        user.Power += 1;
                }, delegate(User? user)
                {
                    if(user != null)
                        if(user.Legs == null) return true;
                    return false;
                }, delegate(User? user)
                {
                    if(user != null)
                        user.Power -= 1;
                }, 400, Size.Small, 2),
                new Weapon("BowWithRibbons.png", "Bow With Ribbons", delegate(User? user)
                {
                    if(user != null)
                        user.Power += 4;
                }, delegate(User? user)
                {
                    if(user != null)
                        if(user.Race == Race.Elf && user.Weapon1 == null && user.Weapon2 == null) return true;
                    return false;
                }, delegate(User? user)
                {
                    if(user != null)
                        user.Power -= 4;
                }, 800, Size.Small, 2, 4),
                new Weapon("DaggerOfTreachery.png", "Dagger Of Treachery", delegate(User? user)
                {
                    if(user != null)
                        if(user.GameClass == Class.Thief) user.Power += 3;
                }, delegate(User? user)
                {
                    if(user != null)
                        if(user.GameClass == Class.Thief && (user.Weapon1 != null || user.Weapon2 != null)) return true;
                    return false;
                }, delegate(User? user)
                {
                    if(user != null)
                        user.Power -= 3;
                }, 400, Size.Small, 1, 3),
                new Weapon("ElevenFootPole.png", "Eleven-Foot Pole", delegate(User? user)
                {
                    if(user != null)
                    {
                        user.Power += 1;
                    }
                        
                }, delegate(User? user)
                {
                    if(user != null)
                        if(user.Weapon1 == null && user.Weapon2 == null) return true;
                    return false;
                }, delegate(User? user)
                {
                    if(user != null)
                        user.Power -= 1;
                }, 200, Size.Small, 2, 1),
                new Armor("FlamingArmor.png", "Flaming Armor", delegate(User? user)
                {
                    if(user != null)
                        user.Power += 2;
                }, delegate(User? user)
                {
                    if(user != null)
                        if(user.Body == null) return true;
                    return false;
                }, delegate(User? user)
                {
                    if(user != null)
                    {
                        user.Power -= 2;
                        user.Body = null;
                    }
                },400, Size.Small, 2),
                new Spell("FriendshipPotion.png", "Friendship Potion", delegate(User? user)
                {
                    // ------
                }, null, null, 200),
                new Armor("LeatherArmor.png", "Leather Armor", delegate(User? user)
                {
                    if(user != null)
                        user.Power += 1;
                }, delegate(User? user)
                {
                    if(user != null)
                        if(user.Body == null) return true;
                    return false;
                }, delegate(User? user)
                {
                    if(user != null)
                    {
                        user.Power -= 1;
                        user.Body = null;
                    }
                }, 200, Size.Small, 1),
                new Spell("LoadedDie.png", "Loaded Die", delegate(User? user)
                {
                    // ------
                },null,null, 300),
                new Weapon("MaceOfSharpness.png", "Mace Of Sharpness", delegate(User? user)
                {
                    if(user != null)
                        if(user.GameClass == Class.Cleric) user.Power += 4;
                }, delegate(User? user)
                {
                    if(user != null)
                        if(user.GameClass == Class.Cleric && (user.Weapon1 == null || user.Weapon2 == null)) return true;
                    return false;
                }, delegate(User? user)
                {
                    if(user != null)
                        user.Power -= 4;
                }, 600, Size.Small, 1, 4),
                new Spell("MagicLamp.png", "Magic Lamp", delegate(User? user)
                {
                    // ------
                }, null, null, 500),
                new Weapon("RapierOfUnfairness.png", "Rapier Of Unfairness", delegate(User? user)
                {
                    if(user != null)
                        if(user.Race == Race.Elf) user.Power += 3;
                }, delegate(User? user)
                { 
                    if(user != null)
                        if(user.Race == Race.Elf && (user.Weapon1 == null || user.Weapon2 == null)) return true;
                    return false;
                }, delegate(User? user)
                {
                    if(user != null)
                        user.Power -= 3;
                }, 600, Size.Small, 1, 3),
                new Weapon("RatOnStick.png", "Rat On Stick", delegate(User? user)
                {
                    if(user != null)
                        user.Power += 1;
                },delegate(User? user)
                {
                    if(user != null)
                        if(user.Weapon1 == null || user.Weapon2 == null) return true;
                    return false;
                },delegate(User? user)
                {
                    if(user != null)
                        user.Power -= 1;
                }, 0, Size.Small, 1, 1),
                new Gear("ReallyImpressiveTitle.png", "Really Impressive Title", delegate(User? user)
                {
                    if(user != null)
                        user.Power += 3;
                },delegate(User? user)
                {
                    return true;
                },delegate(User? user)
                {
                    if(user != null)
                        user.Power -= 3;
                }, 0),
                new Weapon("ShieldOfUbiquity.png", "Shield Of Ubiquity", delegate(User? user)
                {
                    if(user != null)
                    {
                        user.Power += 4;
                        user.HasBig = true;
                    }
                        
                },delegate(User? user)
                {
                    if(user != null)
                        if(user.GameClass == Class.Warrior && (user.Weapon1 == null || user.Weapon2 == null) && user.HasBig == false)
                            return true;
                    return false;
                },delegate(User? user)
                {
                    if(user != null)
                    {
                        user.Power += 4;
                        user.HasBig = false;
                    }
                }, 600, Size.Big, 1, 4),
                //new Armor("ShortWideArmor.png", "Short Wide Armor", delegate(User? user)
                //{
                //    if(user != null)
                //        if(user.Race == Race.Dwarf) user.Power += 3;
                //}, 400, Size.Small, 3),
                //new Gear("SingingAndDancingSword.png", "Singing And Dancing Sword", delegate(User? user)
                //{
                //    if(user != null)
                //        if(user.GameClass != Class.Thief) user.Power += 2;
                //}, 400),
                //new Armor("SmilyArmor.png", "Smily Armor", delegate(User? user)
                //{
                //    if(user != null)
                //        user.Power += 1;
                //}, 200, Size.Small, 1),
                //new Gear("SpikyKnees.png", "Spiky Knees", delegate(User? user)
                //{
                //    if(user != null)
                //        user.Power += 1;
                //}, 200),
                //new Weapon("StaffOfNapalm.png", "Staff Of Napalm", delegate(User? user)
                //{
                //    if(user != null)
                //        if(user.GameClass == Class.Wizard) user.Power += 5;
                //}, 800, Size.Small, 1, 5),
                //new Weapon("SwissArmyPolearm.png", "Swiss Army Polearm", delegate(User? user)
                //{
                //    if(user != null)
                //        if(user.Race == Race.Human) user.Power += 4;
                //}, 600, Size.Big, 2, 4)
            };

            Doors = new ObservableCollection<Door>
            {
                new Monster("3872Orcs.png", "3872 Orcs", null, null, null, null, 10, 1, 3, 10),
                new Monster("Amazon.png", "Amazon", null, null, null, null, 8, 1, 2, 8),
                new Monster("Crabs.png", "Crabs", null, null, null, null, 1, 1, 1, 1),
                new Monster("DroolingSmile.png", "Drooling Smile", null, null, null, null, 1, 1, 1, 1),
                new Monster("Bigfoot.png", "Bigfoot", null, null, null, null, 12, 1, 3, 12),
                new Monster("Lawers.png", "Lawers", null, null, null, null, 6, 1, 2, 6),
                new Monster("Leperchaun.png", "Leperchaun", null, null, null, null, 4, 1, 2, 4),
                new Monster("PitBull.png", "Pitbull", null, null, null, null, 2, 1, 1, 2),
                new Monster("PlutoniumDragon.png", "Plutonium Dragon", null, null, null, null, 20, 2, 5, 20),
                new Monster("ShriekingGeek.png", "Shrieking Geek", null, null, null, null, 6, 1, 2, 6),
                new Monster("WannabeVampire.png", "Wannabe Vampire", null, null, null, null, 12, 1, 3, 12),
                new Monster("WightBrothers.png", "Wight Brothers", null, null, null, null, 16, 2, 4, 16),
                new PlayerClass("Cleric.png", "Cleric", delegate(User? user)
                {
                    if(user != null)
                        user.GameClass = Class.Cleric;
                },delegate(User? user)
                {
                    return true;
                },delegate(User? user)
                {
                    if(user != null)
                        user.GameClass = Class.None;
                }),
                new PlayerClass("Thief.png", "Thief", delegate(User? user)
                {
                    if(user != null)
                        user.GameClass = Class.Thief;
                },delegate(User? user)
                {
                    return true;
                },delegate(User? user)
                {
                    if(user != null)
                        user.GameClass = Class.None;
                }),
                new PlayerClass("Warrior.png", "Warrior", delegate(User? user)
                {
                    if(user != null)
                        user.GameClass = Class.Warrior;
                },delegate(User? user)
                {
                    return true;
                },delegate(User? user)
                {
                    if(user != null)
                        user.GameClass = Class.None;
                }),
                new PlayerClass("Wizard.png", "Wizard", delegate(User? user)
                {
                    if(user != null)
                        user.GameClass = Class.Wizard;
                },delegate(User? user)
                {
                    return true;
                },delegate(User? user)
                {
                    if(user != null)
                        user.GameClass = Class.None;
                }),
                new PlayerRace("Dwarf.png", "Dwarf", delegate(User? user)
                {
                    if(user != null)
                        user.Race = Race.Dwarf;
                },delegate(User? user)
                {
                    return true;
                },delegate(User? user)
                {
                    if(user != null)
                        user.Race = Race.Human;
                }),
                new PlayerRace("Elf.png", "Elf", delegate(User? user)
                {
                    if(user != null)
                        user.Race = Race.Elf;
                },delegate(User? user)
                {
                    return true;
                },delegate(User? user)
                {
                    if(user != null)
                        user.Race = Race.Human;
                }),
                new PlayerRace("Hafling.png", "Hafling", delegate(User? user)
                {
                    if(user != null)
                        user.Race = Race.Hafling;
                },delegate(User? user)
                {
                    return true;
                },delegate(User? user)
                {
                    if(user != null)
                        user.Race = Race.Human;
                }),
                new Door("Supermunchkin.png", "Supermunchkin", delegate(User? user)
                {
                    if(user != null)
                        user.IsSuperMunchkin = true;
                }, delegate(User? user)
                {
                    if(user != null)
                        if(user.IsSuperMunchkin == false) return true;
                    return false;
                }, delegate(User? user)
                {
                    if(user != null)
                    {
                        user.IsSuperMunchkin = false;
                        //user.Race2 = false;
                    }

                        
                })
            };
            Monster? monster = Doors[0] as Monster;
            monster.Action = delegate (User? user)
            {
                if (user != null)
                    if (user.Race == Race.Dwarf) monster.Power += 6;
            };
            monster.BadStuff = delegate (User? user)
            {
                int roll = user.Roll();
                if (roll <= 2) user.Death();
                else
                {
                    user.Level -= roll;
                    if(user.Level <= 0) user.Level = 1;
                };
            };
            monster = Doors[1] as Monster;
            monster.Action = delegate (User? user)
            {
                if (user != null)
                    if (user.State == State.Woman) gameManager.Table.ProvideTreasure();
            };
            monster.BadStuff = delegate (User? user)
            {
                if(user != null)
                {
                    if(user.GameClass != Class.None) user.GameClass = Class.None;
                    else
                    {
                        user.Level -= 3;
                        if (user.Level <= 0) user.Level = 1;
                    }
                }
            };
            monster = Doors[2] as Monster;
            monster.Action = delegate (User? user)
            {
                // -------
            };
            monster.BadStuff = delegate (User? user)
            {
                if (user != null)
                {
                    user.Body = null;
                    user.Legs = null;
                }
            };
            monster = Doors[3] as Monster;
            monster.Action = delegate (User? user)
            {
                if (user != null)
                    if (user.Race == Race.Elf) monster.Power += 4;
            };
            monster.BadStuff = delegate (User? user)
            {
                if (user != null)
                    if (user.Legs != null) user.Legs = null;
                    else
                    {
                        user.Level -= 1;
                        if (user.Level <= 0) user.Level = 1;
                    }
            };
            monster = Doors[4] as Monster;
            monster.Action = delegate (User? user)
            {
                if (user != null)
                    if (user.Race == Race.Dwarf || user.Race == Race.Hafling) monster.Power += 3;
            };
            monster.BadStuff = delegate (User? user)
            {
                if (user != null)
                    user.Head = null; // !!!
            };
            monster = Doors[5] as Monster;
            monster.Action = delegate (User? user) { };
            monster.BadStuff = delegate (User? user)
            {
                if(user != null)
                    for(int i = 0; i < user.Hand.Count; i++)
                    {
                        user.Hand.Clear();
                    }
            };
            monster = Doors[6] as Monster;
            monster.Action = delegate (User? user) 
            {
                if (user != null)
                    if (user.Race == Race.Elf) monster.Power += 5;
            };
            monster.BadStuff = delegate (User? user)
            {
                if (user != null)
                {
                    int rand = new Random().Next(0, user.Hand.Count);
                    user.Hand.RemoveAt(rand);
                    rand = new Random().Next(0, user.Hand.Count);
                    user.Hand.RemoveAt(rand);
                }
            };
            monster = Doors[7] as Monster;
            monster.Action = delegate (User? user) { };
            monster.BadStuff = delegate (User? user)
            {
                if (user != null)
                {
                    user.Level -= 2;
                    if (user.Level <= 0) user.Level = 1;
                }
            };
            monster = Doors[8] as Monster;
            monster.Action = delegate (User? user) 
            {
                if (user != null)
                    if (user.Level <= 5) MessageBox.Show("It won't pursue you");
            };
            monster.BadStuff = delegate (User? user)
            {
                if (user != null) user.Death();
            };
            monster = Doors[9] as Monster;
            monster.Action = delegate (User? user)
            {
                if (user != null)
                    if (user.GameClass == Class.Warrior) monster.Power += 6;
                    
            };
            monster.BadStuff = delegate (User? user)
            {
                if (user != null)
                {
                    user.GameClass = Class.None;
                    user.Race = Race.Human;
                }  
            };
            monster = Doors[10] as Monster;
            monster.Action = delegate (User? user)
            {
                if (user != null)
                    if (user.Level <= 3) MessageBox.Show("They won't pursue you");
            };
            monster.BadStuff = delegate (User? user)
            {
                if (user != null) user.Level = 1;
            };


        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
