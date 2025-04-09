namespace TEXT_RPG
{
    public abstract class Job
    {
        public abstract string Name { get; }
        public abstract int BaseHP { get; }
        public abstract int BaseMP { get; }
        public abstract int BaseAttack { get; }

        public abstract void UseSkill(Player player, Enemy enemy);
    }



    public class Warrior : Job
    {
        public override string Name => "전사";
        public override int BaseHP => 100;
        public override int BaseMP => 20;
        public override int BaseAttack => 15;
        public override void UseSkill(Player player, Enemy enemy)
        {
            int mpCost = 10; // 스킬 사용에 필요한 마나
            int damage = 20; // 스킬의 피해량

            Console.WriteLine($"{player.Name}이(가) '강타' 스킬을 사용했습니다!");
            player.UseMP(mpCost); // 마나 사용
            enemy.TakeDamage(damage); // 적에게 피해를 줌
            // 스킬 효과 구현
        }
    }

    public class Mage : Job
    {
        public override string Name => "마법사";
        public override int BaseHP => 80;
        public override int BaseMP => 50;
        public override int BaseAttack => 7;
        public override void UseSkill(Player player, Enemy enemy)
        {
            int mpCost = 15; // 스킬 사용에 필요한 마나
            int damage = 30; // 스킬의 피해량

            Console.WriteLine($"{player.Name}이(가) '파이어볼' 스킬을 사용했습니다!");
            player.UseMP(mpCost); // 마나 사용
            enemy.TakeDamage(damage); // 적에게 피해를 줌
            // 스킬 효과 구현
        }
    }



}


