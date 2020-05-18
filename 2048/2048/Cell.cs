using System;
using System.Collections.Generic;
using System.Text;

namespace _2048
{
    class Cell
    {
            public int number = 0;
            public int Generate()
            {
            if (number == 0)
            {
                {
                    Random rnd = new Random();
                    int chance = rnd.Next(0, 9);
                    if (chance == 0) number = 4;
                    else number = 2;
                    return number;
                }
            }
            else return number;
            }
    }
}
