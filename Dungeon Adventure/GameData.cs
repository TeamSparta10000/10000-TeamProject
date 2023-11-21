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
                    player = new Character(name, "Archer", 1, 15, 15, 150, 100, 2000);
                    items = new Item[10];
                    AddItem(new Item("초급 궁수의 슈트", "궁수에게 지급되는 슈트다.", 0, 0, 10, 50, 0));
                    AddItem(new Item("초급 궁수의 활", "궁수에게 지급되는 활이다.", 1, 5, 5, 0, 0));
                    AddItem(new Item("초급 궁수의 마법화살", "궁수에게 지급되는 마법화살이다.", 1, 10, 0, 0, 50));
                    break;
            }
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
                    if (items[i].IsEquipped) sum += items[i].Atk;
                }
                return sum;
            }
            public static int GetSumBonusDef()
            {
                int sum = 0;
                for (int i = 0; i < Item.ItemCnt; i++)
                {
                    if (items[i].IsEquipped) sum += items[i].Def;
                }
                return sum;
            }
            public static int GetSumBonusHp()
            {
                int sum = 0;
                for (int i = 0; i < Item.ItemCnt; i++)
                {
                    if (items[i].IsEquipped) sum += items[i].Hp;
                }
                return sum;
            }
            public static int GetSumBonusMp()
            {
                int sum = 0;
                for (int i = 0; i < Item.ItemCnt; i++)
                {
                    if (items[i].IsEquipped) sum += items[i].Mp;
                }
                return sum;
            }
        }
    } 

