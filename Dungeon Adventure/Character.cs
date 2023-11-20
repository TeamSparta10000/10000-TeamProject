namespace Dungeon_Adventure
{
    public interface Character
    {
    string Name { get; set; }
    string Job { get; set; }
    int Level { get; set; }
    int Atk { get; set; }
    int Def { get; set; }
    int Hp { get; set; }
    int Mp { get; set; }
    int Gold { get; set; }

        public class ClassType:Character
        {
           public string Name { get; set; }
            public string Job {  get; set; }
            public int Level {  get; set; }
            public int Atk { get; set; }
            public int Def { get; set; }
            public int Hp { get; set; }
            public int Mp { get; set; }
            public int Gold { get; set; }
            public bool IsDead => Hp <= 0;
            public Knight(string name)
            {
                Name = name;
                Job = "Knight";
                Level = 1;
                Atk = 10;
                Def = 20;
                Hp = 200;
                Mp = 50;
                Gold = 3000;
            }
            public Mage(string name)
            {
                Name = name;
                Job = "Mage";
                Level = 1;
                Atk = 20;
                Def = 5;
                Hp = 50;
                Mp = 200;
                Gold = 5000;
            }
            public Archer(string name)
            {
                Name = name;
                Job = "Archer";
                Level = 1;
                Atk = 15;
                Def = 15;
                Hp = 150;
                Mp = 100;
                Gold = 2000;
            }
            public void TakeDamage(int damage)
            {
                Hp -= damage;
                if (IsDead) Console.WriteLine($"{Name}이(가) 죽었습니다.");
                else Console.WriteLine($"{Name}이(가) {damage}의 데미지를 받았습니다. 남은 체력: {Hp}");
            }
        }
      
    }
}
