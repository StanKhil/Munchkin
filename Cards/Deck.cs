using Munchkin.Cards;
using Munchkin.Cards.Treasures;
using Munchkin.Cards.Doors;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Munchkin.Player;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Media;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System;

// Желательно не смотреть

namespace Munchkin.Cards
{
    public class Deck : INotifyPropertyChanged
    {
        private ObservableCollection<Treasure> treasures;
        private ObservableCollection<Door> doors;
        private List<Door> doorsList;
        private List<Treasure> treasuresList;
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
                new Treasure("1000GoldPieces.png", "1000 Gold pieces", null, null, null, 1000),
                new Footgear("BootsOfButtKicking.png", "Boots Of Butt Kicking", null, null, null, 400, Size.Small, 2),
                new Weapon("BowWithRibbons.png", "Bow With Ribbons", null, null, null, 800, Size.Small, 2, 4),
                new Weapon("DaggerOfTreachery.png", "Dagger Of Treachery", null, null, null, 400, Size.Small, 1, 3),
                new Weapon("ElevenFootPole.png", "Eleven-Foot Pole", null, null, null, 200, Size.Small, 2, 1),
                new Armor("FlamingArmor.png", "Flaming Armor", null, null, null, 400, Size.Small, 2),
                new Spell("FriendshipPotion.png", "Friendship Potion", null, null, null, 200), // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                new Armor("LeatherArmor.png", "Leather Armor", null, null, null, 200, Size.Small, 1),
                new Spell("LoadedDie.png", "Loaded Die", null ,null,null, 300), // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                new Weapon("MaceOfSharpness.png", "Mace Of Sharpness", null,  null, null, 600, Size.Small, 1, 4),
                new Spell("MagicLamp.png", "Magic Lamp", null, null, null, 500),  // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                new Weapon("RapierOfUnfairness.png", "Rapier Of Unfairness", null, null, null, 600, Size.Small, 1, 3),
                new Weapon("RatOnStick.png", "Rat On a Stick", null, null, null, 0, Size.Small, 1, 1),
                new Gear("ReallyImpressiveTitle.png", "Really Impressive Title", null, null, null, 0),
                new Weapon("ShieldOfUbiquity.png", "Shield Of Ubiquity", null, null, null, 600, Size.Big, 1, 4),
                new Armor("ShortWideArmor.png", "Short Wide Armor", null, null, null, 400, Size.Small, 3),
                new Gear("SingingAndDancingSword.png", "Singing And Dancing Sword", null, null, null, 400),
                new Armor("SmilyArmor.png", "Smily Armor", null, null, null, 200, Size.Small, 1),
                new Gear("SpikyKnees.png", "Spiky Knees", null, null, null, 200),
                new Weapon("StaffOfNapalm.png", "Staff Of Napalm", null, null, null, 800, Size.Small, 1, 5),
                new Weapon("SwissArmyPolearm.png", "Swiss Army Polearm", null, null, null, 600, Size.Big, 2, 4)
            };

            //----------------------------------------------------------------------------------

            var treasure0 = Treasures[0];
            treasure0.Action = delegate (User? user)
            {
                if (user != null)
                    user.Level++;
            };
            treasure0.Condition = delegate (User? user)
            {
                if (user != null)
                    if (user.Level < 9) return true;
                return false;
            };

            Footgear treasure1 = Treasures[1] as Footgear; //Boots of butt-kicking
            treasure1.Action = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power += 2;
                    user.Legs = treasure1;
                }
            };  
            treasure1.Condition = delegate (User? user)
            {
                if (user != null)
                    if (user.Legs == null) return true;
                return false;
            };
            treasure1.Discard = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power -= 2;
                    user.Legs = null;
                }
            };

            Weapon treasure2 = Treasures[2] as Weapon; //Bow with ribbons
            treasure2.Action = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power += 4;
                    user.Weapon1 = treasure2;
                    user.Weapon2 = new Weapon("UsedSlot.png");
                }
            };
            treasure2.Condition = delegate (User? user)
            {
                if (user != null)
                    if ((user.FirstRace == Race.Elf || user.SecondRace == Race.Elf) && user.Weapon1 == null && user.Weapon2 == null) return true;
                return false;
            };
            treasure2.Discard = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power -= 4;
                    user.Weapon1 = null;
                    user.Weapon2 = new Weapon(null);
                    user.Weapon2 = null;
                }
            };

            Weapon treasure3 = Treasures[3] as Weapon; //Dagger Of Treachery
            treasure3.Action = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power += 3;
                    if(user.Weapon1 != null && user.Weapon2 == null) user.Weapon2 = treasure3;
                    else user.Weapon1 = treasure3;
                }
            }; 
            treasure3.Condition = delegate (User? user)
            {
                if (user != null)
                    if ((user.FirstClass == Class.Thief || user.SecondClass == Class.Thief) && (user.Weapon1 != null || user.Weapon2 != null)) return true;
                return false;
            }; ;
            treasure3.Discard = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power -= 3;
                    if (user.Weapon1 == treasure3) user.Weapon1 = null;
                    else user.Weapon2 = null;
                }
            };

            Weapon treasure4 = Treasures[4] as Weapon; //Eleven-Foot Pole
            treasure4.Action = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power += 1;
                    user.Weapon1 = treasure4;
                    user.Weapon2 = new Weapon("UsedSlot.png");
                }
            };
            treasure4.Condition = delegate (User? user)
            {
                if (user != null)
                    if (user.Weapon1 == null && user.Weapon2 == null) return true;
                return false;
            };
            treasure4.Discard = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power -= 1;
                    user.Weapon1 = null;
                    user.Weapon2 = new Weapon(null);
                    user.Weapon2 = null;
                }
            };

            Armor treasure5 = Treasures[5] as Armor; //Flaming Armor
            treasure5.Action = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power += 2;
                    user.Body = treasure5;
                }
            };
            treasure5.Condition = delegate (User? user)
            {
                if (user != null)
                    if (user.Body == null) return true;
                return false;
            };
            treasure5.Discard = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power -= 2;
                    user.Body = null;
                }
            };
            Spell treasure6 = Treasures[6] as Spell; // Friendship Potion
            treasure6.Action = delegate (User? user)
            {
                if (user != null)
                {
                    gameManager.Stadia = Stadia.DiscardCards;
                    gameManager.discardDoors.Add(gameManager.CurrentMonster);
                    gameManager.CurrentMonster = null;
                    gameManager.Table.monster.Source = null;
                    gameManager.positions["monster"] = null;
                    gameManager.Table.fightPanel.Visibility = Visibility.Hidden;
                    gameManager.LastCalledMethod = "end";

                }
            };
            treasure6.Condition = delegate (User? user)
            {
                if (user != null)
                    if (gameManager.CurrentMonster != null) return true;
                return false;
            };
            treasure6.Discard = null;

            Armor treasure7 = Treasures[7] as Armor; //Leather Armor
            treasure7.Action = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power += 1;
                    user.Body = treasure7;
                }
            };
            treasure7.Condition = delegate (User? user)
            {
                if (user != null)
                    if (user.Body == null) return true;
                return false;
            };
            treasure7.Discard = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power -= 1;
                    user.Body = null;
                }
            };
            Spell treasure8 = Treasures[8] as Spell; // Loaded Die
            treasure8.Action = delegate (User? user)
            {
                if (user != null)
                {
                    user.RollNumber = 6;
                }
            };
            treasure8.Condition = delegate (User? user)
            {
                if (user != null)
                    if (user.RollNumber < user.RollMin && gameManager.CurrentMonster != null) return true;
                return false;
            };
            treasure8.Discard = null;

            Weapon treasure9 = Treasures[9] as Weapon; // Mace of sharpness
            treasure9.Action = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power += 4;
                    if (user.Weapon1 != null && user.Weapon2 == null) user.Weapon2 = treasure9;
                    else user.Weapon1 = treasure9;
                }
            };
            treasure9.Condition = delegate (User? user)
            {
                if (user != null)
                    if ((user.FirstClass == Class.Cleric || user.SecondClass == Class.Cleric) && (user.Weapon1 == null || user.Weapon2 == null)) return true;
                return false;
            };
            treasure9.Discard = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power -= 4;
                    if (user.Weapon1 == treasure9) user.Weapon1 = null;
                    else user.Weapon2 = null;
                } 
            };
            Spell treasure10 = Treasures[10] as Spell; // Magic Lamp
            treasure10.Action = delegate (User? user)
            {
                if (user != null)
                {
                    gameManager.treasuresToTake = gameManager.CurrentMonster.Treasusers;
                    gameManager.Stadia = Stadia.TakeTreasures;
                    gameManager.discardDoors.Add(gameManager.CurrentMonster);
                    gameManager.CurrentMonster = null;
                    gameManager.Table.monster.Source = null;
                    gameManager.positions["monster"] = null;
                    gameManager.Table.fightPanel.Visibility = Visibility.Hidden;
                    gameManager.LastCalledMethod = "end";

                }
            };
            treasure10.Condition = delegate (User? user)
            {
                if (user != null)
                    if (gameManager.CurrentMonster != null) return true;
                return false;
            };
            treasure10.Discard = null;

            Weapon treasure11 = Treasures[11] as Weapon; //Rapier of sharpness
            treasure11.Action = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power += 3;
                    if (user.Weapon1 != null && user.Weapon2 == null) user.Weapon2 = treasure11;
                    else user.Weapon1 = treasure11;
                }
            };
            treasure11.Condition = delegate (User? user)
            {
                if (user != null)
                    if ((user.FirstRace == Race.Elf || user.SecondRace == Race.Elf) && (user.Weapon1 == null || user.Weapon2 == null)) return true;
                return false;
            };
            treasure11.Discard = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power -= 3;
                    if (user.Weapon1 == treasure11) user.Weapon1 = null;
                    else user.Weapon2 = null;
                }
            };

            Weapon treasure12 = Treasures[12] as Weapon; //Rat On a Stick
            treasure12.Action = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power += 1;
                    if (user.Weapon1 != null && user.Weapon2 == null) user.Weapon2 = treasure12;
                    else user.Weapon1 = treasure12;
                }
            };
            treasure12.Condition = delegate (User? user)
            {
                if (user != null)
                    if (user.Weapon1 == null || user.Weapon2 == null) return true;
                return false;
            };
            treasure12.Discard = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power -= 1;
                    if (user.Weapon1 == treasure12) user.Weapon1 = null;
                    else user.Weapon2 = null;
                }
            };

            Gear treasure13 = Treasures[13] as Gear; //Really Impressive Title
            treasure13.Action = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power += 3;
                    user.Accessory = treasure13;
                }
            };
            treasure13.Condition = delegate (User? user)
            {
                if (user != null)
                    if (user.Accessory == null) return true;
                return false;
            };
            treasure13.Discard = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power -= 3;
                    user.Accessory = null;
                }
            };

            Weapon treasure14 = Treasures[14] as Weapon; //Shield Of Ubiquity
            treasure14.Action = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power += 4;
                    user.HasBig = true;
                    if(user.Weapon1 != null && user.Weapon2 == null) user.Weapon2 = treasure14;
                    else user.Weapon1 = treasure14;
                }
            };
            treasure14.Condition = delegate (User? user)
            {
                if (user != null)
                    if ((user.FirstClass == Class.Warrior || user.SecondClass == Class.Warrior) && (user.Weapon1 == null || user.Weapon2 == null) && user.HasBig == false)
                        return true;
                return false;
            };
            treasure14.Discard = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power += 4;
                    user.HasBig = false;
                    if (user.Weapon1 == treasure14) user.Weapon1 = null;
                    else user.Weapon2 = null;
                }
            };

            Armor treasure15 = Treasures[15] as Armor; //Short Wide Armor
            treasure15.Action = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power += 3;
                    user.Body = treasure15;
                }
                   
            };
            treasure15.Condition = delegate(User? user)
            {
                if (user != null)
                    if ((user.FirstRace == Race.Dwarf || user.SecondRace == Race.Dwarf) && user.Body == null) return true;
                return false;
            };
            treasure15.Discard = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power -= 3;
                    user.Body = null;
                }
            };

            Gear treasure16 = Treasures[16] as Gear; //Singing And Dancing Sword
            treasure16.Action = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power += 2;
                    user.Accessory = treasure16;
                }
            };
            treasure16.Condition = delegate(User? user)
            {
                if (user != null)
                    if (user.FirstClass != Class.Thief && user.SecondClass != Class.Thief && user.Accessory == null) return true;
                return false;
            };
            treasure16.Discard = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power -= 2;
                    user.Accessory = null;
                }
            };

            Armor treasure17 = Treasures[17] as Armor; //Smily Armor
            treasure17.Action = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power += 1;
                    user.Body = treasure17;
                }
            };
            treasure17.Condition = delegate(User? user)
            {
                if (user != null)
                    if(user.Body == null) return true;
                return false;
            };
            treasure17.Discard = delegate(User? user) 
            {
                if (user != null)
                {
                    user.Power -= 1;
                    user.Body = null;
                }
            };

            Gear treasure18 = Treasures[18] as Gear; //Spiky Knees
            treasure18.Action = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power += 1;
                    user.Accessory = treasure18;
                }
            };
            treasure18.Condition = delegate(User? user)
            {
                if (user != null) 
                    if(user.Accessory == null) return true;
                return false;
            };
            treasure18.Discard = delegate(User? user)
            {
                if (user != null)
                {
                    user.Power -= 1;
                    user.Accessory = null;
                }
            };

            Weapon treasure19 = Treasures[19] as Weapon; //Staff Of Napalm
            treasure19.Action = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power += 5;
                    if(user.Weapon1 != null) user.Weapon2 = treasure19;
                    else user.Weapon1 = treasure19;
                }
            };
            treasure19.Condition = delegate(User? user)
            {
                if (user != null)
                    if ((user.Weapon1 == null || user.Weapon2 == null) && (user.FirstClass == Class.Wizard || user.SecondClass == Class.Wizard)) return true;
                return false;
            };
            treasure19.Discard = delegate(User? user)
            {
                if (user != null)
                {
                    user.Power -= 5;
                    if (user.Weapon1 == treasure19) user.Weapon1 = null;
                    else user.Weapon2 = null;
                }
            };

            Weapon treasure20 = Treasures[20] as Weapon; //Swiss Army Polearm
            treasure20.Action = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power += 4;
                    user.Weapon1 = treasure20;
                    user.Weapon2 = new Weapon("UsedSlot.png");
                    //user.Weapon2.Image.Source = new ImageSourceConverter().ConvertFromString(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Resources\\Cards\\Treasures\\UsedSlot.png") as ImageSource;
                }
                
            };
            treasure20.Condition = delegate(User? user)
            {
                if (user != null)
                    if ((user.FirstRace == Race.Human || user.SecondRace == Race.Human) && user.HasBig == false && (user.Weapon1 == null && user.Weapon2 == null)) return true;
                return false;
            };
            treasure20.Discard = delegate (User? user)
            {
                if (user != null)
                {
                    user.Power -= 4;
                    user.Weapon1 = null;
                    user.Weapon2 = new Weapon(null);
                    user.Weapon2 = null;
                }
            };

            //----------------------------------------------------------------------------------

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
                new PlayerClass("Cleric.png", "Cleric",Class.Cleric, null, null, null),
                new PlayerClass("Thief.png", "Thief", Class.Thief, null, null, null),
                new PlayerClass("Warrior.png", "Warrior", Class.Warrior, null, null, null),
                new PlayerClass("Wizard.png", "Wizard", Class.Wizard, null, null, null),
                new PlayerRace("Dwarf.png", "Dwarf", Race.Dwarf, null, null, null),
                new PlayerRace("Elf.png", "Elf", Race.Elf, null, null, null),
                new PlayerRace("Hafling.png", "Hafling", Race.Hafling, null, null, null),
                new PlayerClass("Supermunchkin.png", "Supermunchkin", Class.None, null, null, null),
                new PlayerRace("HalfBreed.png", "Half Breed", Race.None, null, null, null)
            };


            Monster door0 = Doors[0] as Monster; //3872 Orcs
            door0.Action = delegate (User? user)
            {
                if (user != null)
                    if (user.FirstRace == Race.Dwarf || user.SecondRace == Race.Dwarf) door0.Power += 6;
            };
            door0.BadStuff = delegate (User? user)
            {
                int roll = new Random().Next();
                if (roll <= 2) user.Death();
                else
                {
                    user.Level -= roll;
                    if (user.Level <= 0) user.Level = 1;
                };
            };
            door0.Condition = null;
            door0.Discard = null;

            Monster door1 = Doors[1] as Monster; //Amazon
            door1.Action = delegate (User? user)
            {
                if (user != null)
                    if (user.State == State.Woman)
                    { 
                        gameManager.Table.ProvideTreasure();
                        door1.Discard(user);
                    }
            };
            door1.BadStuff = delegate (User? user)
            {
                if (user != null)
                {
                    if(user.FirstClass == Class.None && user.SecondClass == Class.None)
                    {
                        user.Level -= 3;
                        if (user.Level <= 0) user.Level = 1;
                    }
                    else
                    {
                        if(user.FirstClass != Class.None) user.FirstClass = Class.None;
                        if(user.SecondClass != Class.None) user.SecondClass = Class.None;
                    }
                }
            }; ;
            door1.Condition = null;
            door1.Discard = null;

            Monster door2 = Doors[2] as Monster; //Crabs
            door2.Action = delegate (User? user) { };
            door2.BadStuff = delegate (User? user)
            {
                if (user != null)
                {
                    user.Body = null;
                    user.Legs = null;
                }
            };
            door2.Condition = null;
            door2.Discard = null;

            Monster door3 = Doors[3] as Monster; //Droodling slime
            door3.Action = delegate (User? user)
            {
                if (user != null)
                    if (user.FirstRace == Race.Elf || user.SecondRace == Race.Elf) door3.Power += 4;
            };
            door3.BadStuff = delegate (User? user)
            {
                if (user != null)
                {
                    if (user.Legs != null) user.Legs = null;
                    else
                    {
                        user.Level -= 1;
                        if (user.Level <= 0) user.Level = 1;
                    }
                }
            };
            door3.Condition = null;
            door3.Discard = null;


            Monster door4 = Doors[4] as Monster; //Bigfoor
            door4.Action = delegate (User? user)
            {
                if (user != null)
                    if (user.FirstRace == Race.Dwarf || user.SecondRace == Race.Dwarf || user.FirstRace == Race.Hafling || user.SecondRace == Race.Hafling) door4.Power += 3;
            };
            door4.BadStuff = delegate (User? user)
            {
                if (user != null)
                    user.Head = null;
            };
            door4.Condition = null;
            door4.Discard = null;

            Monster door5 = Doors[5] as Monster; //Lawers
            door5.Action = delegate (User? user) 
            {
                if (user != null)
                    if (user.FirstClass == Class.Thief || user.SecondClass == Class.Thief) user.CanFlee = true;
            };
            door5.BadStuff = delegate (User? user)
            {
                if (user != null)
                    for (int i = 0; i < user.Hand.Count; i++)
                    {
                        user.Hand.Clear();
                    }
            };
            door5.Condition = null;
            door5.Discard = null;

            Monster door6 = Doors[6] as Monster; //Leperchaun
            door6.Action = delegate (User? user)
            {
                if (user != null)
                    if (user.FirstRace == Race.Elf || user.SecondRace == Race.Elf) door6.Power += 5;
            };
            door6.BadStuff = delegate (User? user)
            {
                if (user != null)
                {
                    int rand = new Random().Next(0, user.Hand.Count);
                    user.Hand.RemoveAt(rand);
                    rand = new Random().Next(0, user.Hand.Count);
                    user.Hand.RemoveAt(rand);
                }
            };
            door6.Condition = null;
            door6.Discard = null;

            Monster door7 = Doors[7] as Monster; //Pit bull
            door7.Action = delegate (User? user) { }; ;
            door7.BadStuff = delegate (User? user)
            {
                if (user != null)
                {
                    user.Level -= 2;
                    if (user.Level <= 0) user.Level = 1;
                }
            };
            door7.Condition = null;
            door7.Discard = null;
            
            Monster door8 = Doors[8] as Monster; //Plutonium Dragon
            door8.Action = delegate (User? user)
            {
                if (user != null)
                    if (user.Level <= 5) user.CanFlee = true;
            };
            door8.BadStuff = delegate (User? user)
            {
                if (user != null && user.Level <= 5) user.Death();
            };
            door8.Condition = null;
            door8.Discard = null;

            Monster door9 = Doors[9] as Monster; //Shrieking Geek
            door9.Action = delegate (User? user)
            {
                if (user != null)
                    if (user.FirstClass == Class.Warrior || user.SecondClass == Class.Warrior) door9.Power += 6;
            };
            door9.BadStuff = delegate (User? user)
            {
                if (user != null)
                {
                    user.ClearClasses();
                    user.ClearRaces();
                }
            };
            door9.Condition = null;
            door9.Discard = null;

            Monster door10 = Doors[10] as Monster; //Wannabe Vampire
            door10.Action = delegate(User? user)
            {
                if (user != null)
                    if (user.FirstClass == Class.Cleric || user.SecondClass == Class.Cleric) user.CanFlee = true;
            };
            door10.BadStuff = delegate(User? user)
            {
                if(user != null)
                {
                    user.Level -= 3;
                    if (user.Level <= 0) user.Level = 1;
                }
            };
            door10.Condition = null;
            door10.Discard = null;

            Monster door11 = Doors[11] as Monster; //Wight Brothers
            door11.Action = delegate (User? user)
            {
                if (user != null)
                    if (user.Level <= 3) user.CanFlee = true;
            };
            door11.BadStuff = delegate (User? user)
            {
                if (user != null) user.Level = 1;
            }; ;
            door11.Condition = null;
            door11.Discard = null;

            PlayerClass door12 = Doors[12] as PlayerClass; // Cleric
            door12.Action = delegate (User? user)
            {
                if (user != null)
                {
                    if (user.FirstClass == Class.None)
                    {
                        user.FirstClass = Class.Cleric;
                        user.Class1 = door12;
                    }
                    else if (user.SecondClass == Class.None && user.IsSuperMunchkin)
                    {
                        user.SecondClass = Class.Cleric;
                        user.Class2 = door12;
                    }
                }
            };
            door12.Condition = delegate (User? user) 
            {
                if (user.FirstClass == Class.None || (user.SecondClass == Class.None && user.IsSuperMunchkin)) return true;
                return false;
            };
            door12.Discard = delegate (User? user)
            {
                if (user != null)
                {
                    if (user.FirstClass == Class.Cleric)
                    {
                        user.FirstClass = Class.None;
                        user.Class1 = null;
                    }
                    else if (user.SecondClass == Class.Cleric)
                    { 
                        user.SecondClass = Class.None;
                        user.Class2 = null;
                    }
                }
            };

            PlayerClass door13 = Doors[13] as PlayerClass; // Thief
            door13.Action = delegate (User? user)
            {
                if (user != null)
                {
                    if (user.FirstClass == Class.None)
                    {
                        user.FirstClass = Class.Thief;
                        user.Class1 = door13;
                    }
                    else if (user.SecondClass == Class.None && user.IsSuperMunchkin)
                    { 
                        user.SecondClass = Class.Thief;
                        user.Class2 = door13;
                    }
                }
            };
            door13.Condition = delegate (User? user)
            {
                if (user.FirstClass == Class.None || (user.SecondClass == Class.None && user.IsSuperMunchkin)) return true;
                return false;
            };
            door13.Discard = delegate (User? user)
            {
                if (user != null)
                {
                    if (user.FirstClass == Class.Thief)
                    {
                        user.FirstClass = Class.None;
                        user.Class1 = null;
                    }
                    else if (user.SecondClass == Class.Thief)
                    {
                        user.SecondClass = Class.None;
                        user.Class2 = null;
                    }
                }
            };

            PlayerClass door14 = Doors[14] as PlayerClass; //Warrior
            door14.Action = delegate (User? user)
            {
                if (user != null)
                {
                    if (user.FirstClass == Class.None)
                    {
                        user.FirstClass = Class.Warrior;
                        user.Class1 = door14;
                    }
                    else if (user.SecondClass == Class.None && user.IsSuperMunchkin)
                    { 
                        user.SecondClass = Class.Warrior;
                        user.Class2 = door14;
                    }
                }
            };
            door14.Condition = delegate (User? user)
            {
                if (user.FirstClass == Class.None || (user.SecondClass == Class.None && user.IsSuperMunchkin)) return true;
                return false;
            };
            door14.Discard = delegate (User? user)
            {
                if (user != null)
                {
                    if (user.FirstClass == Class.Warrior)
                    {
                        user.FirstClass = Class.None;
                        user.Class1 = null;
                    }
                    else if (user.SecondClass == Class.Warrior) 
                    { 
                        user.SecondClass = Class.None;
                        user.Class2 = null;
                    }
                }
            };

            PlayerClass door15 = Doors[15] as PlayerClass; //Wizard
            door15.Action = delegate (User? user)
            {
                if (user != null)
                {
                    if (user.FirstClass == Class.None)
                    {
                        user.FirstClass = Class.Wizard;
                        user.Class1 = door15;
                    }
                    else if (user.SecondClass == Class.None && user.IsSuperMunchkin) 
                    {
                        user.SecondClass = Class.Wizard;
                        user.Class2 = door15;
                    };
                }
            };
            door15.Condition = delegate (User? user)
            {
                if (user.FirstClass == Class.None || (user.SecondClass == Class.None && user.IsSuperMunchkin)) return true;
                return false;
            };
            door15.Discard = delegate (User? user)
            {
                if (user != null)
                {
                    if (user.FirstClass == Class.Wizard)
                    {
                        user.FirstClass = Class.None;
                        user.Class1 = null;
                    }
                    else if (user.SecondClass == Class.Wizard)
                    {
                        user.SecondClass = Class.None;
                        user.Class2 = null;
                    }
                }
            };

            PlayerRace door16 = Doors[16] as PlayerRace; //Dwarf
            door16.Action = delegate (User? user)
            {
                if (user != null)
                {
                    user.Limit = 6;
                    if (user.FirstRace == Race.Human)
                    {
                        user.FirstRace = Race.Dwarf;
                        user.Race1 = door16;
                    }
                    else if (user.SecondRace == Race.None && user.IsHalfBlood)
                    { 
                        user.SecondRace = Race.Dwarf; 
                        user.Race2 = door16;
                    }
                }
            };
            door16.Condition = delegate (User? user)
            {
                if (user.FirstRace == Race.Human || (user.SecondRace == Race.None && user.IsHalfBlood)) return true;
                return false;
            };
            door16.Discard = delegate (User? user)
            {
                if (user != null)
                {
                    user.Limit = 5;
                    if (user.FirstRace == Race.Dwarf)
                    {
                        user.FirstRace = Race.Human;
                        user.Race1 = null;
                    }
                    else if (user.SecondRace == Race.Dwarf)
                    {
                        user.SecondRace = Race.None;
                        user.Race2 = null;
                    }
                }
            };

            PlayerRace door17 = Doors[17] as PlayerRace; //Elf
            door17.Action = delegate (User? user)
            {
                if (user != null)
                {
                    if (user.FirstRace == Race.Human)
                    {
                        user.FirstRace = Race.Elf;
                        user.Race1 = door17;
                    }
                    else if (user.SecondRace == Race.None && user.IsHalfBlood)
                    {
                        user.SecondRace = Race.Elf;
                        user.Race2 = door17;
                    }
                    user.RollMin = 3;
                }
            };
            door17.Condition = delegate (User? user)
            {
                if (user != null)
                    if (user.FirstRace == Race.Human || (user.SecondRace == Race.None && user.IsHalfBlood)) return true;
                return false;
            };
            door17.Discard = delegate (User? user)
            {
                if (user != null)
                {
                    if (user.FirstRace == Race.Elf)
                    {
                        user.FirstRace = Race.Human;
                        user.Race1 = null;
                    }
                    else if (user.SecondRace == Race.Elf)
                    {
                        user.SecondRace = Race.None;
                        user.Race2 = null;
                    }
                }
            };

            PlayerRace door18 = Doors[18] as PlayerRace; //Hafling
            door18.Action = delegate (User? user)
            {
                if (user != null)
                {
                    if (user.FirstRace == Race.Human)
                    {
                        user.FirstRace = Race.Hafling;
                        user.Race1 = door18;
                    }
                    else if (user.SecondRace == Race.None && user.IsHalfBlood)
                    {
                        user.SecondRace = Race.Hafling;
                        user.Race2 = door18;
                    }
                }
            };
            door18.Condition = delegate (User? user)
            {
                if (user.FirstRace == Race.Human || (user.SecondRace == Race.None && user.IsHalfBlood)) return true;
                return false;
            };
            door18.Discard = delegate (User? user)
            {
                if (user != null)
                {
                    if (user.FirstRace == Race.Hafling)
                    {
                        user.FirstRace = Race.Human;
                        user.Race1 = null;
                    }
                    else if (user.SecondRace == Race.Hafling)
                    {
                        user.SecondRace = Race.None;
                        user.Race2 = null;
                    }
                }
            };

            PlayerClass door19 = Doors[19] as PlayerClass; //Supermunchkin
            door19.Action = delegate (User? user)
            {
                if (user != null)
                {
                    user.IsSuperMunchkin = true;
                    user.Supermunchkin = door19;
                }
                   
            };
            door19.Condition = delegate (User? user)
            {
                if (user != null)
                    if (user.IsSuperMunchkin == false) return true;
                return false;
            };
            door19.Discard = delegate (User? user)
            {
                if (user != null)
                {
                    user.IsSuperMunchkin = false;
                    user.Supermunchkin = null;
                }
            };

            PlayerRace door20 = Doors[20] as PlayerRace; //Half-Breed
            door20.Action = delegate (User? user)
            {
                if (user != null)
                {
                    user.IsHalfBlood = true;
                    user.HalfBlood = door20;
                }
            };
            door20.Condition = delegate (User? user)
            {
                if (user != null)
                    if (user.IsHalfBlood == false) return true;
                return false;
            };
            door20.Discard = delegate (User? user)
            {
                if (user != null)
                {
                    user.IsHalfBlood = false;
                    user.HalfBlood = null;
                }
            };

            doorsList = new List<Door>(Doors);
            treasuresList = new List<Treasure>(Treasures);
            foreach(Door door in Doors)
            {
                doorsList.Add(door);
            }
            foreach (Treasure treasure in Treasures)
            {
                treasuresList.Add(treasure);
            }
        }

        public void UpdateDoors()
        {
            MessageBox.Show("Update Doors");
            Random random = new Random();
            Doors = new ObservableCollection<Door>(gameManager.discardDoors.OrderBy(x => random.Next()));
            gameManager.discardDoors.Clear();
        }

        public void UpdateTreasures()
        {
            MessageBox.Show("Update Treasures");
            Random random = new Random();
            Treasures = new ObservableCollection<Treasure>(gameManager.discardTreasures.OrderBy(x => random.Next()));
            gameManager.discardTreasures.Clear();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
