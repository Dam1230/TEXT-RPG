using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    public class Player
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public Job Job { get; set; } 

        public int MaxHP => Job.BaseHP + (Level * 10);
        public int MaxMP => Job.BaseMP + (Level * 5);
        public int Attack => Job.BaseAttack + (Level * 2);

        public int currentHP { get; set; }
        public int currentMP { get; set; }
        
        public void UseMP(int amount)
        {
            if (currentMP >= amount)
            {
                currentMP -= amount;
                Console.WriteLine($"{Name}이(가) {amount}의 마나를 사용했습니다. 현재 마나: {currentMP}");
            }
            else
            {
                Console.WriteLine("마나가 부족합니다!");
            }
        }

        public int Gold { get; set; } = 100; // 플레이어의 골드


        public List<Item> Inventory { get; private set; } = new List<Item>();
        public void AddItem(Item item)
        {
            Inventory.Add(item);
            Console.WriteLine($"{item.Name}을(를) 인벤토리에 추가했습니다.");
        }

        public void UseItem(int index)
        {
            if (index < 0 || index >= Inventory.Count)
            {
                Console.WriteLine("인벤토리에 해당 아이템이 없습니다.");
                return;
            }

            var item = Inventory[index];
            item.Use(this);
            Inventory.RemoveAt(index);

        }




        public Player(string name, Job job) 
        {
            Name = name;
            Job = job;
            Level = 1;
            currentHP = MaxHP;
            currentHP = MaxMP;
        }

        public void ChangeJob(Job newJob)  
        {
            Job = newJob;
            Console.WriteLine($"축하합니다! {Name}이 {newJob.Name}으로 전직하였습니다!");
        }
    }
}
