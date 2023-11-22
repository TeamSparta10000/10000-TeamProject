using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeon_Adventure;

namespace Dungeon_Adventure
{
    public class Character
    {
    public string Name { get; set; }
    public string Job { get; set; }
    public int Level { get; set; }
    public int Atk { get; set; }
    public int Def { get; set; }
    public int Hp { get; set; }
    public int Mp { get; set; }
    public int Gold { get; set; }
        bool IsDead => Hp <= 0;

        public Character(string name, string job, int level, int atk, int def, int hp, int mp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Mp = mp;
            Gold = gold;
        }
        public void AttackMonster(Monster monster)
        {
            monster.Hp -= this.Atk;
        }
        public void TakeDamage(int damage)
        { 
                Hp -= damage;
                if (IsDead) Console.WriteLine($"{Name}이(가) 죽었습니다.");
                else Console.WriteLine($"{Name}이(가) {damage}의 데미지를 받았습니다. 남은 체력: {Hp}");
        }
      
    }
}
