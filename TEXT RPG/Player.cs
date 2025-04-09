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
        public Job Job { get; set; } // Added Job property to hold the player's job  

        public int MaxHP => Job.BaseHP + (Level * 10);
        public int MaxMP => Job.BaseMP + (Level * 5);
        public int Attack => Job.BaseAttack + (Level * 2);

        public int currentHP { get; set; }
        public List<string> Inventory = new List<string>();

        public Player(string name, Job job) // Changed job parameter type to Job  
        {
            Name = name;
            Job = job;
            Level = 1;
            currentHP = MaxHP;
        }

        public void ChangeJob(Job newJob) // Changed newJob parameter type to Job  
        {
            Job = newJob;
            Console.WriteLine($"축하합니다! {Name}이 {newJob.Name}으로 전직하였습니다!");
        }
    }
}
