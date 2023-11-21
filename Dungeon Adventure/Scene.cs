using System;
using System.Collections.Generic;
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
        public static void DisplayTown()
        {
            Console.Clear();

            Console.WriteLine("초보던전 입구마을에 오신" + (GameData.player.Name) + "님 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전에 점검을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 전투시작");
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
            
            Console.WriteLine(GameData.PlayerAtkDamage());            

            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            int input = Program.CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayTown();
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
                    DisplayTown();
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
            Console.Clear();

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
                    DisplayTown();
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
                GameData.monsters[i].PrintMonsterDescription(true, i + 1);
            }
            Console.WriteLine() ;
            Console.WriteLine("공격할 몬스터의 번호를 선택하세요. ");
            Console.WriteLine();
            Console.WriteLine("0. 마을로 도망가기 ");
            Console.WriteLine();
            int keyinput = Program.CheckValidInput(0, Monster.MonsterCnt); // 죽어서 선택을 못하게 하려면 배열에서 삭제..? 그럼 아예 콘솔창에서 사라질텐데 어쩌지
            switch (keyinput)
            {
                case 0:
                    DisplayTown();
                    break;
                default:                    
                    if (GameData.monsters[keyinput - 1].Hp <= 0)
                    {
                        Console.WriteLine("잘못된 선택입니다. ");
                    }
                    GameData.MonsterTakeDamage(GameData.PlayerAtkDamage(), keyinput - 1);
                    break;                
            }
            Console.ReadKey();
            MonsterAtkScene();
        }
        public static void MonsterAtkScene()
        {
            Console.Clear();

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
                    GameData.PlayerTakeDamage(GameData.MonsterAtkDamage(i));
                }                
            }            
            Console.ReadKey();
            PlayerAtkScene();
        }
    }
}
