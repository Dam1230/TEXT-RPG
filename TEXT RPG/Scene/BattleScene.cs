using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG.Scene
{
    public class BattleScene : BaseScene
    {
        private List<string> battleLog = new List<string>();
        private ConsoleKey input;
        private Enemy enemy;
        private bool isPlayerTurn = true;

        private void Log(string message)
        {
            battleLog.Add(message);
            if (battleLog.Count > 10)
                battleLog.RemoveAt(0);
        }


        public BattleScene()
        {
            enemy = EnemyFactory.CreateRandomEnemy();
        }

        public override void Render()
        {
            Console.Clear();
            Console.WriteLine($"전투 시작! {enemy.Name}가 등장했다.");
            Console.WriteLine($"{PlayerManager.Player.Name} HP: {PlayerManager.Player.MaxHP}/{PlayerManager.Player.currentHP}");
            Console.WriteLine($"{enemy.Name} HP: {enemy.MaxHP}/{enemy.CurrentHP}");
            Console.WriteLine("\n[전투 로그]");

            foreach (var log in battleLog)
            {
                Console.WriteLine(log);
            }

            Console.WriteLine("1. 공격");
            Console.WriteLine("2. 스킬 사용");
            Console.WriteLine("3. 아이템 사용");
            Console.WriteLine("4. 도망치기");



        }
        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }
        public override void Update()
        {
            if (isPlayerTurn)
            {
                switch (input)
                {
                    case ConsoleKey.D1:
                        enemy.TakeDamage(PlayerManager.Player.Attack);
                        Log($"{PlayerManager.Player.Name}이(가) {enemy.Name}에게 {PlayerManager.Player.Attack}의 피해를 입혔습니다.");
                        break;
                    case ConsoleKey.D2:
                        PlayerManager.Player.Job.UseSkill(PlayerManager.Player, enemy);
                        Log($"{PlayerManager.Player.Name}이(가) 스킬을 사용했습니다!");
                        break;
                    case ConsoleKey.D3:
                        Game.ChangeScene("Inventory");
                        return;
                    case ConsoleKey.D4:
                        Log($"{PlayerManager.Player.Name}이(가) 전투에서 도망쳤습니다!");
                        Console.WriteLine("도망쳤습니다.");
                        Game.ChangeScene("Village");
                        return;
                    default:
                        Console.WriteLine("잘못된 선택입니다.");
                        return;
                }

                if (enemy.isdead())
                {
                    Log($"{enemy.Name}이(가) 쓰러졌습니다!");
                    Console.WriteLine($"{enemy.Name}이(가) 쓰러졌습니다!");
                    Game.ChangeScene("Dungeon");
                    return;
                }
                isPlayerTurn = false;
                return;
            }
        
            enemy.AttackPlayer(PlayerManager.Player);
            if (PlayerManager.Player.currentHP <= 0)
            {
                Console.WriteLine($"{PlayerManager.Player.Name}이(가) 쓰러졌습니다!");
                Console.WriteLine("게임 오버!");
                Game.End();
                return;
            }
            isPlayerTurn = true;
        }       
           
        public override void Result()
        {
           
        }
    }
    public static class PlayerManager
    {
        public static Player Player { get; set; }
    }
}
