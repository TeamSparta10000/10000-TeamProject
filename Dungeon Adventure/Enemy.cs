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

            public bool IsDead => Hp <= 0;

            public Monster(string monstername, string description, int atk, int def, int hp, int mp)
            {
                MonsterName = monstername;
                Description = description;
                Atk = atk;
                Def = def;
                Hp = hp;
                Mp = mp;
            }
            public void TakeDamage(int damage)
            {
                Hp -= damage;
                if (IsDead) Console.WriteLine($"{MonsterName}이(가) 죽었습니다.");
                else Console.WriteLine($"{MonsterName}이(가) {damage}의 데미지를 받았습니다. 남은 체력: {Hp}");
            }
        }
    }


