using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Dungeon_Adventure;
using static System.Net.Mime.MediaTypeNames;

namespace Dungeon_Adventure
{
    public class GameData
    {
        public static Character player;
        public static Monster[] monsters;
        public static Item[] items;
        public static void GameDataSetting()
        {
            player = new Character("Frost", "마법사", 1, 100, 5, 50, 200, 5000);
            items = new Item[10];            
            AddItem(new Item("초급 마법사의 로브", "마법학교에서 지급하는 로브다.", 0, 0, 5, 0, 50));
            AddItem(new Item("초급 마법사의 스태프", "마법학교에서 지급하는 스태프다.", 1, 10, 0, 0, 50));

            monsters = new Monster[10];
            MonsterList(new Monster("가고일", "마계에서 온 흔히 볼 수 있는 가고일입니다.", 12, 10, 40, 10));
            MonsterList(new Monster("골렘", "마기가 가득한 돌덩이들이 모여 만들어졌습니다.", 5, 10, 60, 10));
        }
        
        public static int PlayerAtkDamage() // Character class에 생성하고 싶었으나, script가 나누어져 호출 문제로 GameDate.cs에 생성함 Enemy 데이터가 만들어지면 EnemyAtkDamage() 메서드 생성 예정
        {
            // 아이템을 장착하면 캐릭터의 스탯에 반영한다.
            double MinDamage = (GetSumBonusAtk() > 0 ? player.Atk + GetSumBonusAtk() : player.Atk) - Math.Ceiling((double)player.Atk / 10);
            //double MinDamage = player.Atk - Math.Ceiling((double)player.Atk / 10);

            double MaxDamage = (GetSumBonusAtk() > 0 ? player.Atk + GetSumBonusAtk() : player.Atk) + Math.Ceiling((double)player.Atk / 10);
            //double MaxDamage = player.Atk + Math.Ceiling((double)player.Atk / 10);
            int atkDamage = new Random().Next((int)MinDamage, (int)MaxDamage + 1);
            return atkDamage;
        }
        public static void PlayerTakeDamage(int damage) // 이하동문
        {            
            player.Hp -= damage;
            if (player.Hp <= 0)
            {
                Console.WriteLine($"{player.Name}이(가) 죽었습니다.");
            }
            else
            {
                Console.WriteLine($"{player.Name}이(가) {damage}의 데미지를 받았습니다. 남은 체력: {player.Hp}");
            }
        }
        public static int MonsterAtkDamage(int i) // 마찬가지의 이유로 GameDate.cs에 생성항. 
        {            
            double MinDamage = monsters[i].Atk - Math.Ceiling((double)monsters[i].Atk / 10);
            double MaxDamage = monsters[i].Atk + Math.Ceiling((double)monsters[i].Atk / 10);
            int atkDamage = new Random().Next((int)MinDamage, (int)MaxDamage + 1);
            return atkDamage;
        }
        
        public static void MonsterTakeDamage(int damage, int i) // 이하동문
        {            
            monsters[i].Hp -= damage;
            if (monsters[i].Hp <= 0)
            {
                Program.MonsterDead(i);
                monsters[i].Hp = 0;
                Console.WriteLine($"{monsters[i].MonsterName}이(가) 죽었습니다.");
            }
            else
            {
                Console.WriteLine($"{monsters[i].MonsterName}이(가) {damage}의 데미지를 받았습니다. 남은 체력: {monsters[i].Hp}");
            }
        }
        
        public static void MonsterList(Monster monster)
        {
            if (Monster.MonsterCnt == 10) return;
            monsters[Monster.MonsterCnt] = monster;
            Monster.MonsterCnt++;
        }
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
                if (items[i].IsEquipped)
                {
                    sum += items[i].Atk;
                }
            }
            return sum;
        }
        public static int GetSumBonusDef()
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                if (items[i].IsEquipped)
                {
                    sum += items[i].Def;
                }
            }
            return sum;
        }
        public static int GetSumBonusHp()
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                if (items[i].IsEquipped)
                {
                    sum += items[i].Hp;
                }
            }
            return sum;
        }
        public static int GetSumBonusMp()
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                if (items[i].IsEquipped)
                {
                    sum += items[i].Mp;
                }
            }
            return sum;
        }

        public static void SetMonseters(Monster[] newMonsters)
        {
            monsters = newMonsters;
            Monster.MonsterCnt = newMonsters.Length;
        }
    }
}
