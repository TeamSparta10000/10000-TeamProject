namespace Dungeon_Adventure
{
    internal class Program
    {
        private static Character player;
        static Item[] items;

        static void Main(string[] args)
        {
            GameDataSetting();
            DisplayStart();
            DisplayGameIntro();
        }

        private static void DisplayStart()
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

        static void GameDataSetting()
        {
            
            player = new Character("Frost", "마법사", 1, 20, 5, 50,200, 5000);
            items = new Item[10];
            AddItem(new Item("초급 마법사의 로브", "마법학교에서 지급하는 로브다.", 0, 0, 5, 0, 50));
            AddItem(new Item("초급 마법사의 스태프", "마법학교에서 지급하는 스태프다.", 1, 10, 0, 0, 50));


        }
        static void AddItem(Item item) 
        {
            if (Item.ItemCnt == 10) return;
            items[Item.ItemCnt] = item;
            Item.ItemCnt++;
        }

        static void DisplayGameIntro()
        {
            Console.Clear();

            Console.WriteLine("초보던전 입구마을에 오신"+(player.Name)+"님 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전에 점검을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int input = CheckValidInput(1, 2);
            switch (input)
            {
                case 1:
                    DisplayMyInfo();
                    break;

                case 2:
                    Inventory();
                    break;
            }
        }

        static void DisplayMyInfo()
        {
            Console.Clear();

            ShowHighlightText("상태보기");
            Console.WriteLine("캐릭터의 정보를 표시합니다.");
            Console.WriteLine();
            PrintTextWithHighlights($"Lv.",player.Level.ToString("00"));
            Console.WriteLine($"{player.Name}({player.Job})");

            int bonusAtk = getSumBonusAtk();
            int bonusDef = getSumBonusDef();
            int bonusHp = getSumBonusHp();
            int bonusMp = getSumBonusMp();

            PrintTextWithHighlights($"Atk :", (player.Atk + bonusAtk).ToString(), bonusAtk > 0 ? string.Format("(+{0})", bonusAtk) : "");
            PrintTextWithHighlights($"Def :", (player.Def + bonusDef).ToString(), bonusDef > 0 ? string.Format("(+{0})", bonusDef) : "");
            PrintTextWithHighlights($"Hp :", (player.Hp + bonusHp).ToString(), bonusHp > 0 ? string.Format("(+{0})", bonusHp) : "");
            PrintTextWithHighlights($"Mp :", (player.Mp + bonusMp).ToString(), bonusMp > 0 ? string.Format("(+{0})", bonusMp) : "");
            Console.WriteLine($"Gold : {player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
            }
        }
        private static int getSumBonusAtk()
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++) 
            {
                if (items[i].IsEquipped) sum += items[i].Atk;
            }
            return sum;
        }
        private static int getSumBonusDef()
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                if (items[i].IsEquipped) sum += items[i].Def;
            }
            return sum;
        }
        private static int getSumBonusHp()
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                if (items[i].IsEquipped) sum += items[i].Hp;
            }
            return sum;
        }
        private static int getSumBonusMp()
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                if (items[i].IsEquipped) sum += items[i].Mp;
            }
            return sum;
        }

        static void Inventory()
        {   
            Console.Clear();

            ShowHighlightText("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();
            for(int i = 0; i < Item.ItemCnt; i++) 
            {
                items[i].PrintItemDescription();
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine("1. 장착관리");

            int input = CheckValidInput(0, 1);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
                case 1:
                    EquipMenu();
                    break;
            }
        }

        private static void EquipMenu()
        {
            Console.Clear();

            ShowHighlightText("인벤토리 - 장착관리");
            Console.WriteLine("보유중인 아이템을 장착하거나 해제할수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                items[i].PrintItemDescription(true,i + 1);
            }
            Console.WriteLine();
            Console.WriteLine("0.나가기");
            int keyinput = CheckValidInput(0, Item.ItemCnt);
            switch (keyinput)
            {
                case 0:
                    Inventory();
                    break;
                default:
                    ToggleEqupStatus(keyinput - 1);
                    EquipMenu();
                    break;
            }
        }

        private static void ToggleEqupStatus(int idx)
        {
            items[idx].IsEquipped = !items[idx].IsEquipped;
        }

        private static void ShowHighlightText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        private static void PrintTextWithHighlights(string s1,string s2,string s3 ="")
        {
            Console.Write(s1);
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.Write(s2);
            Console.ResetColor();
            Console.WriteLine(s3);
        }


        static void DisplayInventory()
        {

        }

        static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.WriteLine("잘못된 입력입니다.");
            }
        }
    }


    public class Character
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public int Mp { get; }
        public int Gold { get; }

        public Character(string name, string job, int level, int atk, int def, int hp,int mp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Mp = mp;
            Gold = gold;
        }
       

    }
    public class Item
    {
        public string ItemName { get; }
        public string Description { get; }
        public int Type { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public int Mp { get; }
        public bool IsEquipped { get; set; }
        public static int ItemCnt = 0;

        public Item(string itemName, string description, int type, int atk, int def, int hp, int mp, bool isEquipped=false)
        {
            ItemName = itemName;
            Description = description;
            Type = type;
            Atk = atk;
            Def = def;
            Hp = hp;
            Mp = mp;
            IsEquipped = isEquipped;
        }
        public void PrintItemDescription(bool withNumber = false,int idx=0)
        {
            Console.Write("-");
            if (withNumber)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("{0}",idx);
                Console.ResetColor();
            }
            if(IsEquipped)
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("E");
                Console.ResetColor();
                Console.Write("]");
            }
            Console.Write(ItemName);
            Console.Write("|");

            if (Atk != 0) Console.Write($" Atk {(Atk >= 0 ? "+" : "")}{Atk}");
            if (Def != 0) Console.Write($" Def {(Def >= 0 ? "+" : "")}{Def}");
            if (Hp != 0) Console.Write($" Hp {(Hp >= 0 ? "+" : "")}{Hp}");
            if (Mp != 0) Console.Write($" Mp {(Mp >= 0 ? "+" : "")}{Mp}");

            Console.Write('|');

            Console.WriteLine(Description);

        }
    }
}