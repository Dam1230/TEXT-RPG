using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            sceneDic = new Dictionary<string, BaseScene>();
            sceneDic.Add("Title", new TitleScene());
            gameOver = false;

            curScene = sceneDic["Title"];
        }

        //게임의 마무리 작업 진행
        public static void End()
        {
            sceneDic.Clear();
            curScene = null;
            gameOver = true;
        }
    }
}
