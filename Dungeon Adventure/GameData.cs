using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Dungeon_Adventure;

namespace Dungeon_Adventure
{
    internal class GameData
    {
        public static Character player;
        public static Item[] items;
        public static void GameDataSetting()
        {

            player = new Character("Frost", "마법사", 1, 20, 5, 50, 200, 5000);
            items = new Item[10];
            AddItem(new Item("초급 마법사의 로브", "마법학교에서 지급하는 로브다.", 0, 0, 5, 0, 50));
            AddItem(new Item("초급 마법사의 스태프", "마법학교에서 지급하는 스태프다.", 1, 10, 0, 0, 50));


        }
        //public class Character
        //{
        //    public string Name { get; }
        //    public string Job { get; }
        //    public int Level { get; }
        //    public int Atk { get; }
        //    public int Def { get; }
        //    public int Hp { get; }
        //    public int Mp { get; }
        //    public int Gold { get; }

        //    public Character(string name, string job, int level, int atk, int def, int hp, int mp, int gold)
        //    {
        //        Name = name;
        //        Job = job;
        //        Level = level;
        //        Atk = atk;
        //        Def = def;
        //        Hp = hp;
        //        Mp = mp;
        //        Gold = gold;
        //    }


        //}
        public static void AddItem(Item item)
        {
            if (Item.ItemCnt == 10) return;
            items[Item.ItemCnt] = item;
            Item.ItemCnt++;
        }
        public static int GetSumBonusAtk()
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                if (GameData.items[i].IsEquipped) sum += GameData.items[i].Atk;
            }
            return sum;
        }
        public static int GetSumBonusDef()
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                if (GameData.items[i].IsEquipped) sum += GameData.items[i].Def;
            }
            return sum;
        }
        public static int GetSumBonusHp()
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                if (GameData.items[i].IsEquipped) sum += GameData.items[i].Hp;
            }
            return sum;
        }
        public static int GetSumBonusMp()
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                if (GameData.items[i].IsEquipped) sum += GameData.items[i].Mp;
            }
            return sum;
        }
        public class Item
        {
            public string ItemName { get; }
            public string Description { get; }
            public int Type { get; }
            public int Atk { get; }
            public int Def { get; }
            public int Hp { get; }
            public int Mp { get; }
            public bool IsEquipped { get; set; }
            public static int ItemCnt = 0;

            public Item(string itemName, string description, int type, int atk, int def, int hp, int mp, bool isEquipped = false)
            {
                ItemName = itemName;
                Description = description;
                Type = type;
                Atk = atk;
                Def = def;
                Hp = hp;
                Mp = mp;
                IsEquipped = isEquipped;
            }
            public void PrintItemDescription(bool withNumber = false, int idx = 0)
            {
                Console.Write("-");
                if (withNumber)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("{0}", idx);
                    Console.ResetColor();
                }
                if (IsEquipped)
                {
                    Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("E");
                    Console.ResetColor();
                    Console.Write("]");
                }
                Console.Write(ItemName);
                Console.Write("|");

                if (Atk != 0) Console.Write($" Atk {(Atk >= 0 ? "+" : "")}{Atk}");
                if (Def != 0) Console.Write($" Def {(Def >= 0 ? "+" : "")}{Def}");
                if (Hp != 0) Console.Write($" Hp {(Hp >= 0 ? "+" : "")}{Hp}");
                if (Mp != 0) Console.Write($" Mp {(Mp >= 0 ? "+" : "")}{Mp}");

                Console.Write('|');

                Console.WriteLine(Description);

            }
        }
    }
}
