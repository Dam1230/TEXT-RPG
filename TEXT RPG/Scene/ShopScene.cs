using System.Reflection.PortableExecutable;

namespace TEXT_RPG.Scene
{
    public class ShopScene : BaseScene
    {
        private ConsoleKey input;
        private List<Item> itemsForSale;

        public ShopScene()
        {
            itemsForSale = new List<Item>
            {
                new HealPotion(),
                new HealPotion(),
                new HealPotion(),
                new ManaPotion(),
                new ManaPotion()
            };
        }
        public override void Render()
        {
            Console.Clear();
            Console.WriteLine("상점에 오신 것을 환영합니다!");
            Console.WriteLine("판매하는 아이템 목록입니다:");
            for (int i = 0; i < itemsForSale.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {itemsForSale[i].Name} - {itemsForSale[i].Price} Gold");
            }
            Console.WriteLine($"소지 골드 : {PlayerManager.Player.Gold}G");
            Console.WriteLine("구매할 아이템의 번호를 입력하세요 (0: 나가기):");
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
                Console.WriteLine("상점을 나갑니다.");
                Game.ChangeScene("Village");
                return;
            }
            if (choice >= 1 && choice <= itemsForSale.Count)
            {
                Item selectedItem = itemsForSale[choice - 1];
                if (PlayerManager.Player.Gold >= selectedItem.Price)
                {
                    PlayerManager.Player.Gold -= selectedItem.Price;
                    PlayerManager.Player.AddItem(selectedItem);
                    Console.WriteLine($"{selectedItem.Name}을(를) 구매했습니다!");
                }
                else
                {
                    Console.WriteLine("골드가 부족합니다.");
                }
            }
            else
            {
                Console.WriteLine("잘못된 선택입니다.");
            }
            Console.WriteLine("아무 키나 눌러주세요...");
            Console.ReadKey();
        }
        public override void Result()
        {
            
        }


    }
}
