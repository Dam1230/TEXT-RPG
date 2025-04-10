using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    public class TitleScene : BaseScene
    {
        public override void Render()
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|                                      |");
            Console.WriteLine("|            TEXT RPG GAME             |");
            Console.WriteLine("|                                      |");
            Console.WriteLine("|                                      |");
            Console.WriteLine("+--------------------------------------+");
            Console.ResetColor();

            Console.WriteLine("게임을 시작하려면 아무 키나 누르세요...");
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
            Game.ChangeScene("CreateCharacter");
        }
    }

}

