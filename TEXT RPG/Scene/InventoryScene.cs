using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG.Scene
{
    public class InventoryScene : BaseScene
    {
        private ConsoleKey input;
        public override void Render()
        {
            Console.Clear();
            Game.PrintInfo();

            var inventory = PlayerManager.Player.Inventory; 

            if(inventory.Count == 0)
            {
                Console.WriteLine("인벤토리에 아이템이 없습니다.");              
            }
            else 
            {
                for(int i = 0; i < inventory.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {inventory[i].Name}");
                }
            }
            Console.WriteLine("사용할 아이템의 번호를 입력하세요 (0: 나가기):");

        }
        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }
        public override void Update()
        {
            int choice = input - ConsoleKey.D0;

            if (choice == 0)
            {
                Game.ChangeScene("Battle"); // 예: 전투에서 불렀다면 복귀
                return;
            }

            var inventory = PlayerManager.Player.Inventory;

            if (choice >= 1 && choice <= inventory.Count)
            {
                PlayerManager.Player.UseItem(choice - 1);
            }
            else
            {
                Console.WriteLine("잘못된 선택입니다.");
            }

            Console.WriteLine("아무 키나 눌러 계속...");
            Console.ReadKey();
        }
        public override void Result()
        {
        }
    }

}
