using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dungeon_Adventure;

namespace Dungeon_Adventure
{
    public class Monster
    {
        public string MonsterName { get; }
        public string Description { get; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Hp { get; set; }
        public int Mp { get; set; }
        public static int MonsterCnt = 0;
        public bool IsDead { get; set; }

        public Monster(string monstername, string description, int atk, int def, int hp, int mp, bool isDead = false)
        {
            MonsterName = monstername;
            Description = description;
            Atk = atk;
            Def = def;
            Hp = hp;
            Mp = mp;
            IsDead = isDead;
        }
        public void AttackPlayer(Character player)
        {
            player.Hp -= this.Atk;
        }
        public void PrintMonsterDescription(bool withNumber = false, int idx = 0)
        {
            Console.Write("- ");
            if (withNumber)
            {
                Console.Write("{0}. ", idx);
            }
            if (IsDead)
            {
                Console.Write("사망한 몬스터 입니다. " + MonsterName);
            }
            else
            {
                Console.Write(MonsterName);
            }
            
            
            Console.Write(" | ");
            Console.Write(Description );
            Console.Write(" | ");
            Console.Write("공격력: " + Atk + " ");
            Console.WriteLine("체력: " + Hp);
        }
    }
}


