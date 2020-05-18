using System;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            object obj = 3.5f; // Для значения 3.5 выводится тип double 
            int х = (int) (float) obj;
        }
    }
}
