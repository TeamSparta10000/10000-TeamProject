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
                    break;
                case 2:
                    player = new Character(name, "Mage", 1, 20, 5, 50, 200, 5000);
                    break;
                case 3:
                    player = new Character(name, "Archer", 1, 15, 15, 150, 100, 3000);
                    break;
            }


            

                    
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

