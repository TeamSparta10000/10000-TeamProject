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
        private static int monsterCnt;
        private static List<Monster> monsterList;
        private static bool isAllMonsterDead => monsterList.All((o) => o.IsDead == true);

        public static void DisplayGameStart()
        {
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
                    DisplayMyInfo();
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
            Console.WriteLine();
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

        public static void InitializeMonsterList()
        {
            Random random = new Random();
            monsterCnt = random.Next(1, 5);
            monsterList = new List<Monster>(monsterCnt);

            for (int i = 0; i < monsterCnt; i++)
            {
                int monsterIdx = random.Next(0, GameData.monsters.Length);
                Monster monsterData = GameData.monsters[monsterIdx];
                monsterList.Add(monsterData.Clone() as Monster);
            }
        }
        private static void RandomMonsterCount(bool withNumber = false)
        {
            for (int i = 0; i < monsterList.Count; i++)
            {
                if (monsterList[i].IsDead)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("- ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("- ");
                }

                if (withNumber)
                {
                    if (monsterList[i].IsDead)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write($"{i + 1}. ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write($"{i + 1}. ");
                    }
                }

                if (monsterList[i].IsDead)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"{monsterList[i].MonsterName} ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"{monsterList[i].MonsterName} ");
                }

                Console.Write(" | ");
                Console.WriteLine(monsterList[i].IsDead ? "Dead" : $"Hp {monsterList[i].Hp}");
            }
        }


        public static int PlayerAtkDamage()
        {
            // 아이템을 장착하면 캐릭터의 스탯에 반영한다.
            double MinDamage = (GameData.GetSumBonusAtk() > 0 ? GameData.player.Atk + GameData.GetSumBonusAtk() : GameData.player.Atk) - Math.Ceiling((double)GameData.player.Atk / 10);
            double MaxDamage = (GameData.GetSumBonusAtk() > 0 ? GameData.player.Atk + GameData.GetSumBonusAtk() : GameData.player.Atk) + Math.Ceiling((double)GameData.player.Atk / 10);
            int atkDamage = new Random().Next((int)MinDamage, (int)MaxDamage + 1);
            return atkDamage;
        }
        public static void PlayerTakeDamage(int damage, int i)
        {
            GameData.player.Hp -= damage;
            if (GameData.player.Hp <= 0)
            {
                GameData.player.IsDead = true;
                GameData.player.Hp = 0;
                Console.WriteLine($"{GameData.player.Name}이(가) {monsterList[i].MonsterName}에게 {damage}의 데미지를 받았습니다. 남은 체력: {GameData.player.Hp}\n");
                Console.WriteLine($"{GameData.player.Name}이(가) 죽었습니다.");
            }
            else
            {
                Console.WriteLine($"{GameData.player.Name}이(가) {monsterList[i].MonsterName}에게 {damage}의 데미지를 받았습니다. 남은 체력: {GameData.player.Hp}\n");
            }
        }
        public static int MonsterAtkDamage(int i)
        {
            double MinDamage = monsterList[i].Atk - Math.Ceiling((double)monsterList[i].Atk / 10);
            double MaxDamage = monsterList[i].Atk + Math.Ceiling((double)monsterList[i].Atk / 10);
            int atkDamage = new Random().Next((int)MinDamage, (int)MaxDamage + 1);
            return atkDamage;
        }
        public static void MonsterTakeDamage(int damage, int i)
        {
            monsterList[i].Hp -= damage;

            if (monsterList[i].Hp <= 0)
            {
                monsterList[i].Hp = 0;
                monsterList[i].IsDead = true;
                Console.WriteLine($"{monsterList[i].MonsterName}이(가) {damage}의 데미지를 받았습니다. 남은 체력: {monsterList[i].Hp}");
                Console.WriteLine($"{monsterList[i].MonsterName}이(가) 죽었습니다.");
            }
            else
            {
                Console.WriteLine($"{monsterList[i].MonsterName}이(가) {damage}의 데미지를 받았습니다. 남은 체력: {monsterList[i].Hp}");
            }
        }
        public static void BattleScene()
        {
            Console.Clear();

            int bonusAtk = GameData.GetSumBonusAtk();
            int bonusDef = GameData.GetSumBonusDef();
            int bonusHp = GameData.GetSumBonusHp();
            int bonusMp = GameData.GetSumBonusMp();

            InitializeMonsterList();
            RandomMonsterCount();

            Console.WriteLine();
            Console.WriteLine($"{GameData.player.Name}({GameData.player.Job})");
            Program.PrintTextWithHighlights($"Atk :", (GameData.player.Atk + bonusAtk).ToString(), bonusAtk > 0 ? string.Format("(+{0})", bonusAtk) : "");
            Program.PrintTextWithHighlights($"Def :", (GameData.player.Def + bonusDef).ToString(), bonusDef > 0 ? string.Format("(+{0})", bonusDef) : "");
            Program.PrintTextWithHighlights($"Hp :", (GameData.player.Hp + bonusHp).ToString(), bonusHp > 0 ? string.Format("(+{0})", bonusHp) : "");
            Program.PrintTextWithHighlights($"Mp :", (GameData.player.Mp + bonusMp).ToString(), bonusMp > 0 ? string.Format("(+{0})", bonusMp) : "");

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
        }
        public static void PlayerAtkScene()
        {
            Console.Clear();
            RandomMonsterCount(true);

            int bonusAtk = GameData.GetSumBonusAtk();
            int bonusDef = GameData.GetSumBonusDef();
            int bonusHp = GameData.GetSumBonusHp();
            int bonusMp = GameData.GetSumBonusMp();

            Console.WriteLine();

            Console.WriteLine($"{GameData.player.Name}({GameData.player.Job})");
            Program.PrintTextWithHighlights($"Atk :", (GameData.player.Atk + bonusAtk).ToString(), bonusAtk > 0 ? string.Format("(+{0})", bonusAtk) : "");
            Program.PrintTextWithHighlights($"Def :", (GameData.player.Def + bonusDef).ToString(), bonusDef > 0 ? string.Format("(+{0})", bonusDef) : "");
            Program.PrintTextWithHighlights($"Hp :", (GameData.player.Hp + bonusHp).ToString(), bonusHp > 0 ? string.Format("(+{0})", bonusHp) : "");
            Program.PrintTextWithHighlights($"Mp :", (GameData.player.Mp + bonusMp).ToString(), bonusMp > 0 ? string.Format("(+{0})", bonusMp) : "");

            Console.WriteLine();
            Console.WriteLine("공격할 몬스터의 번호를 선택하세요. ");
            Console.WriteLine();
            Console.WriteLine("0. 마을로 돌아가기 ");
            Console.WriteLine();

            int inputIdx;
            do
            {
                inputIdx = Program.CheckValidInput(0, monsterCnt) - 1;
                if (inputIdx < 0)
                {
                    DisplayTown();
                    break;
                }
            }
            while (monsterList[inputIdx].IsDead == true);

            MonsterTakeDamage(PlayerAtkDamage(), inputIdx);

            Console.WriteLine("\n아무 키 입력 시 다음 턴으로 넘어갑니다. ");
            Console.ReadKey();

            if (isAllMonsterDead)
            {
                PlayerWin();
            }
            else
            {
                MonsterAtkScene();
            }
        }

        private static void PlayerWin()
        {
            Console.Clear();
            Console.WriteLine("승리\n");
            Console.WriteLine("\n아무 키 입력 시 마을로 돌아갑니다. \n");
            Console.ReadKey();
            DisplayTown();
        }

        public static void MonsterAtkScene()
        {
            Console.Clear();

            RandomMonsterCount(true);

            Console.WriteLine();
            Console.WriteLine("몬스터가 공격합니다. ");
            Console.WriteLine();

            int idx = 0;

            for (int i = 0; i < monsterCnt; i++)
            {
                if (monsterList[i].IsDead)
                {
                    continue;
                }
                else
                {
                    PlayerTakeDamage(MonsterAtkDamage(i), i);
                    Thread.Sleep(1000);
                }

                if (GameData.player.IsDead)
                {
                    Console.WriteLine("\n아무 키 입력 시 다음 턴으로 넘어갑니다. ");
                    Console.ReadKey();
                    PlayerLose();                                        
                }                
            }
            Console.WriteLine("\n아무 키 입력 시 다음 턴으로 넘어갑니다. ");
            Console.ReadKey();
            PlayerAtkScene();
        }

        private static void PlayerLose()
        {
            Console.Clear();
            Console.WriteLine("패배\n");
            Console.WriteLine("\n아무 키 입력 시 마을로 돌아갑니다. \n");
            Console.ReadKey();
            DisplayTown();
        }
    }
}
