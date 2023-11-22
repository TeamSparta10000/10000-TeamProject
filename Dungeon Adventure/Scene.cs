using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Dungeon_Adventure;

namespace Dungeon_Adventure
{
    public class Scene
    {
        public static void DisplayGameStart()
        {
            Console.Clear();
            Console.WriteLine(" ________      ___  ___      ________      _______       ________      ________      ________           ________      ________      ___      ___  _______       ________       _________    ___  ___      ________      _______      ");
            Console.WriteLine("|\\   ___ \\    |\\  \\|\\  \\    |\\   ____\\    |\\  ___ \\     |\\   __  \\    |\\   __  \\    |\\   ___  \\        |\\   __  \\    |\\   ___ \\    |\\  \\    /  /||\\  ___ \\     |\\   ___  \\    |\\___   ___\\ |\\  \\|\\  \\    |\\   __  \\    |\\  ___ \\     ");
            Console.WriteLine("\\ \\  \\_|\\ \\   \\ \\  \\\\\\  \\   \\ \\  \\___|    \\ \\   __/|    \\ \\  \\|\\  \\   \\ \\  \\|\\  \\   \\ \\  \\\\ \\  \\       \\ \\  \\|\\  \\   \\ \\  \\_|\\ \\   \\ \\  \\  /  / /\\ \\   __/|    \\ \\  \\\\ \\  \\   \\|___ \\  \\_| \\ \\  \\\\\\  \\   \\ \\  \\|\\  \\   \\ \\   __/|    ");
            Console.WriteLine(" \\ \\  \\ \\\\ \\   \\ \\  \\\\\\  \\   \\ \\  \\  ___   \\ \\  \\_|/__   \\ \\   __  \\   \\ \\  \\\\\\  \\   \\ \\  \\\\ \\  \\       \\ \\   __  \\   \\ \\  \\ \\\\ \\   \\ \\  \\/  / /  \\ \\  \\_|/__   \\ \\  \\\\ \\  \\       \\ \\  \\   \\ \\  \\\\\\  \\   \\ \\   _  _\\   \\ \\  \\_|/__  ");
            Console.WriteLine("  \\ \\  \\_\\\\ \\   \\ \\  \\\\\\  \\   \\ \\  \\|\\  \\   \\ \\  \\_|\\ \\   \\ \\  \\ \\  \\   \\ \\  \\\\\\  \\   \\ \\  \\\\ \\  \\       \\ \\  \\ \\  \\   \\ \\  \\_\\\\ \\   \\ \\    / /    \\ \\  \\_|\\ \\   \\ \\  \\\\ \\  \\       \\ \\  \\   \\ \\  \\\\\\  \\   \\ \\  \\\\  \\|   \\ \\  \\_|\\ \\ ");
            Console.WriteLine("   \\ \\_______\\   \\ \\_______\\   \\ \\_______\\   \\ \\_______\\   \\ \\__\\ \\__\\   \\ \\_______\\   \\ \\__\\\\ \\__\\       \\ \\__\\ \\__\\   \\ \\_______\\   \\ \\__/ /      \\ \\_______\\   \\ \\__\\\\ \\__\\       \\ \\__\\   \\ \\_______\\   \\ \\__\\\\ _\\    \\ \\_______\\");
            Console.WriteLine("   \\|_______|    \\|_______|    \\|_______|    \\|_______|    \\|__|\\|__|    \\|_______|    \\|__| \\|__|        \\|__|\\|__|    \\|_______|    \\|__|/        \\|_______|    \\|__| \\|__|        \\|__|    \\|_______|    \\|__|\\|__|    \\|_______|");
            Console.WriteLine("=========================================================================================================================================================================================================================================================");
            Console.WriteLine("                                                                                                               PRESS ANYKEY TO START                                                                                                                     ");
            Console.WriteLine("=========================================================================================================================================================================================================================================================");
            Console.ReadKey();



        }
        public static void DisplayTown1()
        {
            Console.Clear();

            Console.WriteLine("초보던전 입구마을에 오신" + (GameData.player.Name) + "님 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전에 점검을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. Stage1시작");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int input = Program.CheckValidInput(1, 3);
            switch (input)
            {
                case 1:
                    Scene.DisplayMyInfo();
                    break;

                case 2:
                    DisplayInventory();
                    break;
                case 3:
                    BattleScene();
                    break;
            }
        }
        public static void DisplayTown2()
        {
            Console.Clear();

            Console.WriteLine("던전 첫번째마을에 오신" + (GameData.player.Name) + "님 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전에 점검을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. Stage2시작");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int input = Program.CheckValidInput(1, 3);
            switch (input)
            {
                case 1:
                    Scene.DisplayMyInfo();
                    break;

                case 2:
                    DisplayInventory();
                    break;
                case 3:
                    BattleScene();
                    break;
            }
        }
        public static void DisplayMyInfo()
        {
            Console.Clear();

            Program.ShowHighlightText("상태보기");
            Console.WriteLine("캐릭터의 정보를 표시합니다.");
            Console.WriteLine();
            Program.PrintTextWithHighlights($"Lv.", GameData.player.Level.ToString("00"));
            Console.WriteLine($"{GameData.player.Name}({GameData.player.Job})");

            int bonusAtk = GameData.GetSumBonusAtk();
            int bonusDef = GameData.GetSumBonusDef();
            int bonusHp = GameData.GetSumBonusHp();
            int bonusMp = GameData.GetSumBonusMp();

            Program.PrintTextWithHighlights($"Atk :", (GameData.player.Atk + bonusAtk).ToString(), bonusAtk > 0 ? string.Format("(+{0})", bonusAtk) : "");
            Program.PrintTextWithHighlights($"Def :", (GameData.player.Def + bonusDef).ToString(), bonusDef > 0 ? string.Format("(+{0})", bonusDef) : "");
            Program.PrintTextWithHighlights($"Hp :", (GameData.player.Hp + bonusHp).ToString(), bonusHp > 0 ? string.Format("(+{0})", bonusHp) : "");
            Program.PrintTextWithHighlights($"Mp :", (GameData.player.Mp + bonusMp).ToString(), bonusMp > 0 ? string.Format("(+{0})", bonusMp) : "");
            Console.WriteLine($"Gold : {GameData.player.Gold} G");   

            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            int input = Program.CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayTown1();
                    break;
            }
        }
        public static void DisplayInventory()
        {
            Console.Clear();

            Program.ShowHighlightText("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                GameData.items[i].PrintItemDescription();
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine("1. 장착관리");

            int input = Program.CheckValidInput(0, 1);
            switch (input)
            {
                case 0:
                    DisplayTown1();
                    break;
                case 1:
                    EquipMenu();
                    break;
            }
        }
        public static void EquipMenu()
        {
            Console.Clear();

            Program.ShowHighlightText("인벤토리 - 장착관리");
            Console.WriteLine("보유중인 아이템을 장착하거나 해제할수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                GameData.items[i].PrintItemDescription(true, i + 1);
            }
            Console.WriteLine();
            Console.WriteLine("0.나가기");
            int keyinput = Program.CheckValidInput(0, Item.ItemCnt);
            switch (keyinput)
            {
                case 0:
                    DisplayInventory();
                    break;
                default:
                    Program.ToggleEqupStatus(keyinput - 1);
                    EquipMenu();
                    break;
            }
        }
        public static void BattleScene()
        {
            GameData.monsters = new Monster[10];
            GameData.MonsterList(new Monster("가고일", "마계에서 온 흔히 볼 수 있는 가고일입니다.", 10, 10, 50, 10));
            GameData.MonsterList(new Monster("골렘", "마기가 가득한 돌덩이들이 모여 만들어졌습니다.", 20, 60, 5, 10));
            Console.Clear();
            Program.ShowHighlightText("Battle!");


            for (int i = 0; i < Monster.MonsterCnt; i++)
            {                
                GameData.monsters[i].PrintMonsterDescription();
            }

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine("1. 공격 시작");
            int keyinput = Program.CheckValidInput(0, 1);
            switch (keyinput)
            {
                case 0:
                    DisplayTown1();
                    break;
                case 1:
                    PlayerAtkScene();
                    break;
            }

            //GameData.MonsterTakeDamage(GameData.PlayerAtkDamage());
            //GameData.PlayerTakeDamage(GameData.MonsterAtkDamage());
        }
        public static void PlayerAtkScene()
        {

            Console.Clear();
            for (int i = 0; i < Monster.MonsterCnt; i++)
            {
                if (GameData.monsters[i].Hp <= 0)
                {
                    VictoryScene();
                }
                else if (GameData.player.Hp <= 0)
                {
                    GameData.player.Hp = 50;
                    LooseScene();
                }
                else
                {
                    Program.ShowHighlightText("Battle!");
                    Console.WriteLine("플레이어의 턴");
                    for (i = 0; i < Monster.MonsterCnt; i++)
                    {
                        GameData.monsters[i].PrintMonsterDescription(true, i + 1);
                    }
                    Console.WriteLine();
                    Console.WriteLine("공격할 몬스터의 번호를 선택하세요. ");
                    Console.WriteLine();
                    Console.WriteLine("0. 마을로 도망가기 ");
                    Console.WriteLine();
                    int keyinput = Program.CheckValidInput(0, Monster.MonsterCnt); // 죽어서 선택을 못하게 하려면 배열에서 삭제..? 그럼 아예 콘솔창에서 사라질텐데 어쩌지
                    switch (keyinput)
                    {
                        case 0:
                            DisplayTown1();
                            break;
                        default:
                            if (GameData.monsters[keyinput - 1].Hp <= 0)
                            {
                                Console.Clear();
                                Console.WriteLine("잘못된 선택입니다.");
                                Thread.Sleep(3000);
                                PlayerAtkScene();
                            }
                            i = keyinput - 1;
                            GameData.MonsterTakeDamage(GameData.PlayerAtkDamage(i), keyinput - 1);
                            break;
                    }
                    Console.ReadKey();
                    MonsterAtkScene(); 
                }
            }
        }
        public static void MonsterAtkScene()
        {
            Console.Clear();
            Program.ShowHighlightText("Battle!");
            Console.WriteLine("몬스터의 턴");

            for (int i = 0; i < Monster.MonsterCnt; i++)
            {
                GameData.monsters[i].PrintMonsterDescription(true, i + 1);
            }
            Console.WriteLine();
            Console.WriteLine("몬스터가 공격합니다. ");
            Console.WriteLine();
            for (int i = 0; i < Monster.MonsterCnt; i++)
            {
                if (GameData.monsters[i].Hp > 0)
                {
                    GameData.PlayerTakeDamage(GameData.MonsterAtkDamage(i),i);
                }
            }
            Console.ReadKey();
            PlayerAtkScene();
        }
        public static void VictoryScene()
        {  
            Console.Clear();
            Program.ShowHighlightText("Victory!");
            Console.WriteLine("모든 몬스터를 물리치셨습니다!");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("0.다음");


            int keyinput = Program.CheckValidInput(0, 1);
            switch (keyinput)
            {
                case 0:
                    DisplayTown2();
                    break;
            }


        }
        public static void LooseScene()
        {
            Console.Clear();
            Program.ShowHighlightText("You died!");
            Console.WriteLine("플레이어가 사망하였습니다!");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("0.다음");


            int keyinput = Program.CheckValidInput(0, 1);
            switch (keyinput)
            {
                case 0:
                    DisplayTown1();
                    break;
            }


        }
    }
}
