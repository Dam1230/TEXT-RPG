using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG.Scene
{
    public class dungeon : BaseScene
    {
        private ConsoleKey input;

        public override void Render()
        {
            Console.WriteLine("테스트 01 씬입니다.");
            Console.WriteLine("1. 테스트 01 씬으로 이동");
            Console.WriteLine("2. 테스트 02 씬으로 이동");
            Console.WriteLine("선택지를 입력하세요.");
        }
        public override void Input()
        {
            Console.ReadKey(true);
        }
        public override void Update()
        {

        }
        public override void Result()
        {
            switch (input)
            {
                case ConsoleKey.D1:
                    Game.ChangeScene("Scene01");
                    break;
                case ConsoleKey.D2:
                    Game.ChangeScene("Scene02");
                    break;
                default:
                    Console.WriteLine("잘못된 선택입니다.");
                    break;
            }
        }
    }
}
