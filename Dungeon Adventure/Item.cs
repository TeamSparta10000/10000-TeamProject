using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeon_Adventure;

namespace Dungeon_Adventure
{
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
            Console.Write("- ");
            if (withNumber)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("{0}. ", idx);
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
            Console.Write(" | ");

            if (Atk != 0) Console.Write($" Atk {(Atk >= 0 ? "+" : "")}{Atk}");
            if (Def != 0) Console.Write($" Def {(Def >= 0 ? "+" : "")}{Def}");
            if (Hp != 0) Console.Write($" Hp {(Hp >= 0 ? "+" : "")}{Hp}");
            if (Mp != 0) Console.Write($" Mp {(Mp >= 0 ? "+" : "")}{Mp}");

            Console.Write(" | ");

            Console.WriteLine(Description);

        }
    }
}

