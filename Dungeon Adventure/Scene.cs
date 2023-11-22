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
                monsterList.Add(monsterData);
            }
        }
        private static void RandomMonsterCount(bool withNumber = false)
        {
            for (int i = 0; i < monsterList.Count; i++)
            {
                Console.Write("- ");
                if (withNumber)
                {
                    Console.Write($"{i + 1}. ");
                }
                Console.Write($"{monsterList[i].MonsterName} ");
                Console.Write(" | ");
                Console.WriteLine(monsterList[i].IsDead ? "Dead" : $"Hp {monsterList[i].Hp}");
            }
        }


        public static int PlayerAtkDamage() // Character class에 생성하고 싶었으나, script가 나누어져 호출 문제로 GameDate.cs에 생성함 Enemy 데이터가 만들어지면 EnemyAtkDamage() 메서드 생성 예정
        {
            // 아이템을 장착하면 캐릭터의 스탯에 반영한다.
            double MinDamage = (GameData.GetSumBonusAtk() > 0 ? GameData.player.Atk + GameData.GetSumBonusAtk() : GameData.player.Atk) - Math.Ceiling((double)GameData.player.Atk / 10);
            //double MinDamage = player.Atk - Math.Ceiling((double)player.Atk / 10);

            double MaxDamage = (GameData.GetSumBonusAtk() > 0 ? GameData.player.Atk + GameData.GetSumBonusAtk() : GameData.player.Atk) + Math.Ceiling((double)GameData.player.Atk / 10);
            //double MaxDamage = player.Atk + Math.Ceiling((double)player.Atk / 10);
            int atkDamage = new Random().Next((int)MinDamage, (int)MaxDamage + 1);
            return atkDamage;
        }
        public static void PlayerTakeDamage(int damage, int i) // 이하동문
        {
            GameData.player.Hp -= damage;
            if (GameData.player.Hp <= 0)
            {
                GameData.player.Hp = 0;
                Console.WriteLine($"{GameData.player.Name}이(가) {monsterList[i].MonsterName}에게 {damage}의 데미지를 받았습니다. 남은 체력: {GameData.player.Hp}\n");
                Console.WriteLine($"{GameData.player.Name}이(가) 죽었습니다.");
            }
            else
            {
                Console.WriteLine($"{GameData.player.Name}이(가) {monsterList[i].MonsterName}에게 {damage}의 데미지를 받았습니다. 남은 체력: {GameData.player.Hp}\n");
            }
        }
        public static int MonsterAtkDamage(int i) // 마찬가지의 이유로 GameDate.cs에 생성항. 
        {
            double MinDamage = monsterList[i].Atk - Math.Ceiling((double)monsterList[i].Atk / 10);
            double MaxDamage = monsterList[i].Atk + Math.Ceiling((double)GameData.monsters[i].Atk / 10);
            int atkDamage = new Random().Next((int)MinDamage, (int)MaxDamage + 1);
            return atkDamage;
        }
        public static void MonsterTakeDamage(int damage, int i) // 이하동문
        {
            monsterList[i].Hp -= damage;
            if (monsterList[i].Hp <= 0)
            {
                Program.MonsterDead(i);
                monsterList[i].Hp = 0;
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

            // 랜덤으로 생성하여 보자
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
                    // 번호를 붙이는 토글?
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
                inputIdx = Program.CheckValidInput(1, monsterCnt) - 1;
            }
            while (monsterList[inputIdx].IsDead == true);            

            MonsterTakeDamage(PlayerAtkDamage(), inputIdx);

            //int keyinput = Program.CheckValidInput(0, Monster.MonsterCnt); // 죽어서 선택을 못하게 하려면 배열에서 삭제..? 그럼 아예 콘솔창에서 사라질텐데 어쩌지
            //switch (keyinput)
            //{
            //    case 0:
            //        DisplayTown();
            //        break;
            //    default:
            //        GameOver();
            //        if (GameData.monsters[keyinput - 1].Hp <= 0)
            //        {
            //            Console.WriteLine("잘못된 선택입니다. 아무 키를 입력하여 플레이어 공격 화면으로 돌아갑니다. ");
            //            Console.ReadKey();
            //            PlayerAtkScene();
            //        }
            //        GameData.MonsterTakeDamage(GameData.PlayerAtkDamage(), keyinput - 1);
            //        break;
            //}
            Console.WriteLine("\n아무 키 입력 시 다음 턴으로 넘어갑니다. ");
            Console.ReadKey();
            GameOver();

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
                    PlayerTakeDamage(MonsterAtkDamage(i), i);
                    if (GameData.player.Hp <= 0)
                    {
                        Console.WriteLine("\n아무 키 입력 시 전투 결과창으로 넘어갑니다. ");
                        Console.ReadKey();

                        GameOver();
                    }
                }
            }

            Console.WriteLine("\n아무 키 입력 시 다음 턴으로 넘어갑니다. ");
            Console.ReadKey();
            PlayerAtkScene();
        }
        public static void GameOver() // 플레이어와 몬스터의 hp를 계속 판단하여 if 플레이어가 죽었을 시 출력, else if 몬스터가 전부 죽었을 시 출력
        {
            if (GameData.player.Hp <= 0)
            {
                Console.Clear();
                Console.WriteLine("패배하였습니다. . .\n");
                Console.WriteLine(GameData.player.Name + "은(는) 눈 앞이 캄캄해졌다. ");
                Console.WriteLine();
                Console.WriteLine("\n아무 키 입력 시 마을로 돌아갑니다. ");
                Console.ReadLine();
                Reset();
                DisplayTown();
            }
            else if (GameData.monsters[0].Hp <= 0 && GameData.monsters[1].Hp <= 0 && GameData.monsters[2].Hp <= 0) // 배열로 조건을 하나로 만들고 싶지만 호출 등에 문제가 있어서 코드가 길어짐, 랜덤 생성 몬스터 메서드와 겹칠 시 문제 발생 우려됨
            {
                Console.Clear();
                Console.WriteLine("전투에서 승리하였습니다 ! \n");
                Console.WriteLine("처치한 몬스터 수 " + "랜덤으로 생성한 값");
                Console.WriteLine("\n아무 키 입력 시 마을로 돌아갑니다. ");
                Console.WriteLine();
                Console.ReadLine();
                DisplayTown();
            }
        }// 게임오버시 몬스터의 리셋, 전투창 나갔다 오면 몬스터 체력 리셋
        public static void Reset()
        {
            GameData.player.Hp = 15;
        }
    }    
}
