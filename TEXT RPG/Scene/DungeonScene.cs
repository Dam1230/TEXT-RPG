using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG.Scene
{
    public class dungeonScene : BaseScene
    {
        private enum DungeonStep
        {
            Intro,
            Choice,
            Battle,
            Treasure,
            Exit
        }

        private DungeonStep step = DungeonStep.Intro;
        private ConsoleKey input;

        public override void Render()
        {
            Console.Clear();
            Game.PrintInfo();
            switch (step)
            {
                case DungeonStep.Intro:
                    Console.WriteLine("던전의 입구에 도착했습니다.");
                    Console.WriteLine("1. 던전 탐험하기");
                    Console.WriteLine("2. 던전 나가기");
                    break;
                case DungeonStep.Choice:
                    Console.WriteLine("던전에서 어떤 행동을 할까요?");
                    Console.WriteLine("1. 적과 전투하기");
                    Console.WriteLine("2. 보물 찾기");
                    break;
                case DungeonStep.Battle:
                    Console.WriteLine("몬스터가 등장했다 !!");
                    Console.WriteLine("1. 싸운다.");
                    Console.WriteLine("2. 도망간다.");
                    break;
                case DungeonStep.Treasure:
                    Console.WriteLine("보물상자를 발견했습니다 !");
                    Console.WriteLine("회복 포션을 얻었습니다.");
                    break;
                case DungeonStep.Exit:
                    Console.WriteLine("던전을 나갑니다...");
                    Console.WriteLine("아무 키나 눌러주세요...");
                    break;
            }
        }
        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }
        public override void Update()
        {
            switch (step)
            {
                case DungeonStep.Intro:
                    if (input == ConsoleKey.D1)
                    {
                        step = DungeonStep.Choice;
                    }
                    else if (input == ConsoleKey.D2)
                    {
                        step = DungeonStep.Exit;
                    }
                    break;
                case DungeonStep.Choice:
                    if (input == ConsoleKey.D1) step = DungeonStep.Battle;
                    else if (input == ConsoleKey.D2) step = DungeonStep.Treasure;
                    break;
                case DungeonStep.Battle:
                    if (input == ConsoleKey.D1)
                    {
                        Console.WriteLine("전투를 시작합니다...");
                        Game.ChangeScene("Battle");
                    }
                    else if (input == ConsoleKey.D2)
                    {
                        Console.WriteLine("도망쳤습니다.");
                        step = DungeonStep.Exit;
                    }
                    break;
                case DungeonStep.Treasure:
                    Console.WriteLine("보물을 얻었습니다.");
                    Console.WriteLine("회복 포션을 얻었습니다.");

                    PlayerManager.Player.AddItem(new HealPotion());
                    step = DungeonStep.Exit;
                    break;
                case DungeonStep.Exit:
                    Console.WriteLine("던전을 나갑니다...");
                    Game.ChangeScene("Village");
                    break;
            }
        }
        public override void Result()
        {
 
        }
 
    }
}
