using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    public class TitleScene : BaseScene
    {
        //⌝⌜⌟⌞◜◝◝◜◞◟‾_–‾—=–−-
        public override void Render()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("--------------------");
            Console.WriteLine("      TEXT RPG      ");
            Console.WriteLine("--------------------");
            Console.WriteLine("--------------------");
        }
        public override void Input()
        {
            Console.ReadKey();
        }
        public override void Update()
        {

        }
        public override void Result()
        {

        }
    }

}

