using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Adventure
{
    internal class Battle
    {
        public void StartBattle(Character player)
        {
            Console.WriteLine($"야생의 몬스터 {monsterNo} 기가 나타났다!");
            Console.Write($"등장한 몬스터: ");
            for (int i = 0; i < monsters.Length; i++)
            {
                Console.Write($"{monsters[i]}  ");
            }
            Monster[] monsters = MonsterGroup();
            Console.WriteLine("플레이어의 턴을 시작합니다!");
            // 플레이어 턴 종료시 적이 공격하는 로직을 구현 >> 캐릭터/몬스터에게 '대미지를 받는' 메서드가 아니라 '대미지를 주는' 메서드를 추가.
            while (player.Hp > 0 && monsters.Any(monsters => monsters.Hp > 0))
            {
                PlayerSelectTarget(player, monsters);
            }
            Console.WriteLine("적들이 공격해 옵니다!");
            foreach (var monster in monsters)
            {
                if (monster.Hp > 0)
                {
                    monster.AttackPlayer(player);
                    Console.WriteLine($"{monster.MonsterName}이(가) 공격함!");
                }
            }
        }
        void PlayerSelectTarget(Character player, Monster[] monsters)
        {
            int input = Program.CheckValidInput(1, monsters.Length);
            switch (input)
            {
                case 1:
                    player.AttackMonster(monsters[0]);
                    break;
                case 2:
                    player.AttackMonster(monsters[1]);
                    break;
                case 3:
                    player.AttackMonster(monsters[2]);
                    break;
                case 4:
                    player.AttackMonster(monsters[3]);
                    break;
            }
        }
        static Monster[] MonsterGroup()
        {
            Random random = new Random();
            int monsterNo = random.Next(1, 5);
            Monster[] monsters = new Monster[monsterNo];              // 1~4, 랜덤 숫자만큼의 몬스터 그룹(배열) 생성
            for (int i = 0; i < monsterNo; i++)
            {
                int monsterID = random.Next(1, 5);
                switch (monsterID)
                {
                    case 1:
                        monsters[i] = new Monster("A", "A", 5, 2, 100, 20);
                        break;
                    case 2:
                        monsters[i] = new Monster("B", "B", 7, 0, 80, 30);
                        break;
                    case 3:
                        monsters[i] = new Monster("C", "C", 3, 6, 150, 0);
                        break;
                    case 4:
                        monsters[i] = new Monster("D", "D", 10, 0, 50, 0);
                        break;
                }
            }
            return monsters;
        }
    }
}
