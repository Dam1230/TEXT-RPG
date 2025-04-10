namespace TEXT_RPG.Scene
{
    public class VillageScene : BaseScene
    {
        private ConsoleKey input;
        public override void Render()
        {
            Console.Clear();
            Game.PrintInfo();
            Console.WriteLine("마을에 도착했습니다.");
            Console.WriteLine("무엇을 하시겠습니까?");
            Console.WriteLine("1. 휴식하기.(HP,MP 모두 회복)");
            Console.WriteLine("2. 상점가기");
            Console.WriteLine("3. 던전 탐험하기");
            Console.WriteLine("4. 게임 종료");

        }
        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }
        public override void Update()
        {
            switch (input)
            {
                case ConsoleKey.D1:
                    PlayerManager.Player.currentHP = PlayerManager.Player.MaxHP;
                    PlayerManager.Player.currentMP = PlayerManager.Player.MaxMP;
                    Console.WriteLine("HP/MP가 모두 회복되었습니다.");
                    Console.WriteLine("아무 키나 눌러주세요...");
                    Console.ReadKey();
                    break;

                case ConsoleKey.D2:
                    Game.ChangeScene("Shop");
                    break;
                case ConsoleKey.D3:
                    Game.ChangeScene("Dungeon");
                    break;
                case ConsoleKey.D4:
                    Console.WriteLine("게임을 종료합니다.");
                    Game.End();
                    break;
                default:
                    Console.WriteLine("잘못된 선택입니다.");
                    Console.WriteLine("아무 키나 눌러주세요...");
                    Console.ReadKey();
                    break;

            }

        }
        public override void Result()
        {

        }


    }
}
