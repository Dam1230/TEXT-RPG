using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    public class Skill
    {
        public string Name { get; }
        public int MPCost { get; }
        public int Damage { get; }
        public string Description { get; }
        public Action<Player, Enemy> Execute { get; }

        public Skill(string name, int mpCost, int damage, string description, Action<Player, Enemy> execute)
        {
            Name = name;
            MPCost = mpCost;
            Damage = damage;
            Description = description;
            Execute = execute;
        }
    }
}
