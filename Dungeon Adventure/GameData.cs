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
            Console.Write("캐릭터 이름을 입력하세요: ");
            string name = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("1.Knight(기사) 초기 스탯-Atk:10,Def:20,Hp:200,Mp:50,Gold:3000 ");
            Console.WriteLine("2.Mage(마법사) 초기 스탯-Atk:20,Def:5,Hp:50,Mp:200,Gold:5000 ");
            Console.WriteLine("3.Archer(궁수) 초기 스탯-Atk:15,Def:15,Hp:150,Mp:100,Gold:2000 ");
            Console.Write("직업을 선택하세요: ");
            int input = Program.CheckValidInput(1, 3);
            switch (input)
            {
                case 1:
                    player = new Character(name, "Knight", 1, 10, 20, 200, 50, 3000);
                    items = new Item[10];
                    AddItem(new Item("초급 기사의 갑옷", "기사에게 지급하는 갑옷이다.", 0, 0, 20, 100, 0));
                    AddItem(new Item("초급 기사의 검", "기사에게 지급하는 검이다.", 1, 20, 0, 0, 0));
                    AddItem(new Item("초급 기사의 방패", "기사에게 지급하는 방패다.", 1, 0, 20, 0, 0));
                    break;
                case 2:
                    player = new Character(name, "Mage", 1, 20, 5, 50, 200, 5000);
                    items = new Item[10];
                    AddItem(new Item("초급 마법사의 로브", "마법학교에서 지급하는 로브다.", 0, 0, 5, 0, 100));
                    AddItem(new Item("초급 마법사의 스태프", "마법학교에서 지급하는 스태프다.", 1, 20, 0, 0, 100));
                    AddItem(new Item("초급 마법사의 오브", "마법학교에서 지급하는 오브다.", 1, 20, 0, 0, 100));
                    break;
                case 3:
                    player = new Character(name, "Archer", 1, 15, 15, 150, 100, 3000);
                    items = new Item[10];
                    AddItem(new Item("초급 궁수의 슈트", "궁수에게 지급되는 슈트다.", 0, 0, 10, 50, 0));
                    AddItem(new Item("초급 궁수의 활", "궁수에게 지급되는 활이다.", 1, 5, 5, 0, 0));
                    AddItem(new Item("초급 궁수의 마법화살", "궁수에게 지급되는 마법화살이다.", 1, 10, 0, 0, 50));
                    break;
            }

            monsters = new Monster[] 
            {
            new Monster("가고일", "마계에서 온 흔히 볼 수 있는 마물입니다.", 12, 10, 40, 10),
            new Monster("골렘", "마기가 가득한 돌덩이들이 모여 만들어졌습니다.", 5, 10, 60, 10),
            new Monster("고블린", "마계에서 군락을 이루고 사는 하급 마물입니다.", 8, 10, 30, 10)
            };
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
    }
}
