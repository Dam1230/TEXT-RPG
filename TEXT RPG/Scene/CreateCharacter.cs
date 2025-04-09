namespace TEXT_RPG.Scene
{
    public class CreateCharacter : BaseScene
    {
        private string nameInput = "";
        private Job selectedJob;

        private enum CreateStep
        {
            EnterName,
            ChooseJob,
            Done
        }

        private CreateStep currentStep = CreateStep.EnterName;
        private ConsoleKey input;

        public override void Render()
        {
            Console.Clear();
            switch (currentStep)
            {
                case CreateStep.EnterName:
                    Console.WriteLine("캐릭터의 이름을 입력하세요:");
                    break;
                case CreateStep.ChooseJob:
                    Console.WriteLine($"이름: {nameInput}");
                    Console.WriteLine("직업을 선택하세요:");
                    Console.WriteLine("1. 전사");
                    Console.WriteLine("2. 마법사");
                    break;
                case CreateStep.Done:
                    Console.WriteLine($"캐릭터 생성 완료!");
                    Console.WriteLine($"이름: {nameInput}, 직업: {selectedJob.Name}");
                    Console.WriteLine("게임을 시작합니다...");
                    break;
            }

        }
        public override void Input()
        {
            switch (currentStep)
            {
                case CreateStep.EnterName:
                    nameInput = Console.ReadLine();
                    currentStep = CreateStep.ChooseJob;
                    break;

                case CreateStep.ChooseJob:
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.D1)
                        selectedJob = new Warrior();
                    else if (key == ConsoleKey.D2)
                        selectedJob = new Mage();
                    else
                        return;

                    currentStep = CreateStep.Done;
                    break;
            }
        }
        public override void Update()
        {
            if (currentStep == CreateStep.Done)
            {
                // 캐릭터 생성 완료 후 다음 씬으로 이동
                Game.ChangeScene("Scene01");
            }

        }
        public override void Result()
        {
            
        }
    }
}
