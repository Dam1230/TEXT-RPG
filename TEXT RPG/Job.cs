namespace TEXT_RPG
{
    public abstract class Job
    {
        public abstract string Name { get; }
        public abstract int BaseHP { get; }
        public abstract int BaseMP { get; }
        public abstract int BaseAttack { get; }

        public abstract void UseSkill(Player player);
    }

       

    public class Warrior : Job
    {
        public override string Name => "전사";
        public override int BaseHP => 100;
        public override int BaseMP => 20;
        public override int BaseAttack => 15;
        public override void UseSkill(Player player)
        {
            Console.WriteLine($"{player.Name}이(가) '강타' 스킬을 사용했습니다!");
            // 스킬 효과 구현
        }
    }

    public class Mage : Job
    {
        public override string Name => "마법사";
        public override int BaseHP => 80;
        public override int BaseMP => 50;
        public override int BaseAttack => 7;
        public override void UseSkill(Player player)
        {
            Console.WriteLine($"{player.Name}이(가) '파이어볼' 스킬을 사용했습니다!");
            // 스킬 효과 구현
        }
    }

}

