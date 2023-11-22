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
            player = new Character("Frost", "마법사", 1, 20, 5, 15, 200, 5000);
            items = new Item[10];            
            AddItem(new Item("초급 마법사의 로브", "마법학교에서 지급하는 로브다.", 0, 0, 5, 0, 50));
            AddItem(new Item("초급 마법사의 스태프", "마법학교에서 지급하는 스태프다.", 1, 10, 0, 0, 50));

            monsters = new Monster[] 
            {
            new Monster("가고일", "마계에서 온 흔히 볼 수 있는 마물입니다.", 12, 10, 40, 10),
            new Monster("골렘", "마기가 가득한 돌덩이들이 모여 만들어졌습니다.", 5, 10, 60, 10),
            new Monster("고블린", "마계에서 군락을 이루고 사는 하급 마물입니다.", 8, 10, 30, 10)
            };
        }
        
        
        
        //public static void MonsterList(Monster monster)
        //{
        //    if (Monster.MonsterCnt == 10) return;
        //    monsters[Monster.MonsterCnt] = monster;
        //    Monster.MonsterCnt++;
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
    }
}
