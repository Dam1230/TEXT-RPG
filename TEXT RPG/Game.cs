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
            sceneDic.Add("Scene02", new Scene.Battle());
            sceneDic.Add("Scene03", new Scene.dungeon());

            curScene = sceneDic["Title"];
        }

        //게임의 마무리 작업 진행
        public static void End()
        {   
        }
        public static void ChangeScene(string sceneName)
        {
            curScene = sceneDic[sceneName];
        }
    }
}
