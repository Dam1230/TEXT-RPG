using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
   public static class EnemyFactory
    {
        private static Random random = new Random();

        public static Enemy CreateRandomEnemy()
        {
            int enemyType = random.Next(0, 3); // 1부터 3까지의 랜덤 숫자 생성
            switch (enemyType)
            {
                case 0:
                    return new Goblin();
                case 1:
                    return new Skeleton();
                case 2:
                    return new Zombie();
                default:
                    return new Goblin();
            }
        }
    }
}
