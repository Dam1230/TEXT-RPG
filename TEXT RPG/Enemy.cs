using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    public class Enemy
    {
        public string Name { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public int Attack { get; set; }

        public Enemy(string name, int HP, int atk)
        {
            Name = name;
            MaxHP = HP;
            CurrentHP = HP;
            Attack = atk;
        }


        public void TakeDamage(int amount)
        {
            CurrentHP -= amount;
            if (CurrentHP < 0)
            {
                CurrentHP = 0;
            }
            Console.WriteLine($"{Name}이(가) {amount}의 피해를 입었습니다. 현재 HP: {MaxHP}/{CurrentHP}");
        }
        public bool isdead()
        {
            if (CurrentHP <= 0)
            {
                Console.WriteLine($"{Name}이(가) 쓰러졌습니다!");
                return true;
            }
            return false;
        }

        public virtual void AttackPlayer(Player player)
        {
            Console.WriteLine($"{Name}이(가) {player.Name}을(를) 공격합니다!");
            player.currentHP -= Attack;

            if (player.currentHP < 0)
            {
                player.currentHP = 0;
            }
            Console.WriteLine($"{player.Name}의 현재 HP: {player.MaxHP}/{player.currentHP}");
        }
    }

    public class Goblin : Enemy
    {
        public Goblin() : base("고블린", 50, 10) { }

        public override void AttackPlayer(Player player)
        {
            Console.WriteLine($"고블린이 돌맹이를 던집니다 !");
            player.currentHP -= Attack;
            if (player.currentHP < 0)
            {
                player.currentHP = 0;
            }
            Console.WriteLine($"{player.Name}의 현재 HP: {player.MaxHP}/{player.currentHP}");
        }
    }

    public class Skeleton : Enemy
    {
        public Skeleton() : base("스켈레톤", 70, 15) { }
        public override void AttackPlayer(Player player)
        {
            Console.WriteLine($"스켈레톤이 칼로 베어냅니다 !");
            player.currentHP -= Attack;
            if (player.currentHP < 0)
            {
                player.currentHP = 0;
            }
            Console.WriteLine($"{player.Name}의 현재 HP: {player.MaxHP}/{player.currentHP}");
        }
    }
    public class Zombie : Enemy
    {
        public Zombie() : base("좀비", 100, 20) { }
        public override void AttackPlayer(Player player)
        {
            Console.WriteLine($"좀비가 물어뜯습니다 !");
            player.currentHP -= Attack;
            if (player.currentHP < 0)
            {
                player.currentHP = 0;
            }
            Console.WriteLine($"{player.Name}의 현재 HP: {player.MaxHP}/{player.currentHP}");
        }



    }
}
