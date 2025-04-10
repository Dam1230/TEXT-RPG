using TEXT_RPG.Scene;

namespace TEXT_RPG
{
    public static class Game
    {
        private static Dictionary<string, BaseScene> sceneDic;
        private static BaseScene curScene;

        private static bool gameOver;

        public static void Run()
        {
            Start();
            while (gameOver == false)
            {
                Console.Clear();
                curScene.Render();
                curScene.Input();
                curScene.Update();
                curScene.Result();
            }
            End();
        }

        //게임의 시작 작업 진행
        private static void Start()
        {
            gameOver = false;

            sceneDic = new Dictionary<string, BaseScene>();
            sceneDic.Add("Title", new TitleScene());
            sceneDic.Add("CreateCharacter", new Scene.CreateCharacter());
            sceneDic.Add("Battle", new Scene.BattleScene());
            sceneDic.Add("Dungeon", new Scene.dungeonScene());
            sceneDic.Add("Village", new VillageScene());
            sceneDic.Add("Shop", new ShopScene());
            sceneDic.Add("Inventory", new InventoryScene());


            curScene = sceneDic["Title"];
        }

        //게임의 마무리 작업 진행
        public static void End()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("게임이 종료되었습니다. 플레이어가 사망했습니다");
            Console.ResetColor();
            Console.WriteLine("아무 키나 누르면 게임이 종료됩니다.");
            gameOver = true;
            Console.ReadKey();
        }
        public static void ChangeScene(string sceneName)
        {
            curScene = sceneDic[sceneName];
        }

        public static void PrintInfo()
        {
            if (PlayerManager.Player == null)
                return;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"이름 : {PlayerManager.Player.Name}  HP: {PlayerManager.Player.MaxHP}/{PlayerManager.Player.currentHP}  MP: {PlayerManager.Player.MaxMP}/{PlayerManager.Player.currentMP} ATK: {PlayerManager.Player.Attack}");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }
    }
}
