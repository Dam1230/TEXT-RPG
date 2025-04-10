using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    public abstract class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public abstract void Use(Player player);
    }

    public class HealPotion : Item
    {
        public int HealAmount { get; set; }
        public HealPotion()
        {
            Name = "회복포션";
            HealAmount = 20;
            Price = 30;
        }
        
        public override void Use(Player player)
        {
            player.currentHP += HealAmount;
            if (player.currentHP > player.MaxHP)
            {
                player.currentHP = player.MaxHP;
            }
            Console.WriteLine($"{player.Name}이(가) {HealAmount}만큼 회복했습니다. 현재 HP: {player.MaxHP}/{player.currentHP}");
        }
    }
    public class ManaPotion : Item
    {
        public int ManaAmount { get; set; }
        public ManaPotion()
        {
            Name = "마나포션";
            ManaAmount = 10;
            Price = 30;
        }

        public override void Use(Player player)
        {
            player.currentMP += ManaAmount;
            if (player.currentMP > player.MaxMP)
            {
                player.currentMP = player.MaxMP;
            }
            Console.WriteLine($"{player.Name}이(가) {ManaAmount}만큼 마나를 회복했습니다. 현재 MP: {player.MaxMP}/{player.currentMP}");
        }
    }
}
