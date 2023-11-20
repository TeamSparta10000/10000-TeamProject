using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeon_Adventure;

namespace Dungeon_Adventure
{
    internal class Enemy
    {
        public class Monster
        {
            public string MonsterName { get; }
            public string Description { get; }
            public int Type { get; }
            public int Atk { get; }
            public int Def { get; }
            public int Hp { get; }
            public int Mp { get; }
            public bool IsEquipped { get; set; }
            public static int ItemCnt = 0;

            public Monster(string monstername, string description, int atk, int def, int hp, int mp)
            {
                MonsterName = monstername;
                Description = description;
                Atk = atk;
                Def = def;
                Hp = hp;
                Mp = mp;
            }
        }
    }
}

