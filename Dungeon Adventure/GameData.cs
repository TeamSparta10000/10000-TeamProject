using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Dungeon_Adventure;

namespace Dungeon_Adventure
{
    public class GameData
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
    }
}
