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

        static Monster[] MonsterGroup()
        {
            Random random = new Random();
            int monsterNo = random.Next(1, 5);
            Monster[] monsters = new Monster[monsterNo];              // 1~4, 랜덤 숫자만큼의 몬스터 그룹(배열) 생성
            for (int i = 0; i < monsterNo; i++)
            {
                int monsterID = random.Next(1, 5);
                switch (monsterID)
                {
                    case 1:
                        monsters[i] = new Monster("A", "A", 5, 2, 100, 20);
                        break;

                    case 2:
                        monsters[i] = new Monster("B", "B", 7, 0, 80, 30);
                        break;

                    case 3:
                        monsters[i] = new Monster("C", "C", 3, 6, 150, 0);
                        break;

                    case 4:
                        monsters[i] = new Monster("D", "D", 10, 0, 50, 0);
                        break;
                }
            }
            return monsters;
        }
    }
}


