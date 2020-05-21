using System;
using System.IO.Compression;

namespace lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            RationalNumber number1 = new RationalNumber(2, 5);
            RationalNumber number2 = new RationalNumber(5, 2);

            Console.WriteLine("Number1 : {0}", number1.ToString(RationalNumber.RepresentationVariant.Fraction));
            Console.WriteLine("Number2 : {0} \n", number2.ToString(RationalNumber.RepresentationVariant.Fraction));


            //Arithmetical operations
            Console.WriteLine("Number1 + Number2 = {0}", (number1 + number2).ToString(RationalNumber.RepresentationVariant.Fraction));
            Console.WriteLine("Number1 - Number2 = {0}", (number1 - number2).ToString(RationalNumber.RepresentationVariant.Fraction));
            Console.WriteLine("Number1 * Number2 = {0}", (number1 * number2).ToString(RationalNumber.RepresentationVariant.Fraction));
            Console.WriteLine("Number1 / Number2 = {0}\n", (number1 / number2).ToString(RationalNumber.RepresentationVariant.Fraction));


            //Comparison operations
            Console.WriteLine("Number1 >  Number2 = {0}", number1 > number2);
            Console.WriteLine("Number1 <= Number2 = {0}", number1 <= number2);
            Console.WriteLine("Number1 == Number2 = {0}", number1 == number2);
            Console.WriteLine("Number1 != Number2 = {0} \n", number1 != number2);


            //Getting numbers from strings
            string case1 = "15/3";
            string case2 = "-7/2";
            string case3 = "1.3615";
            string case4 = "-5.";

            RationalNumber number3 = RationalNumber.StringToNumber(case1);
            RationalNumber number4 = RationalNumber.StringToNumber(case2);
            RationalNumber number5 = RationalNumber.StringToNumber(case3);
            RationalNumber number6 = RationalNumber.StringToNumber(case4);
            Console.WriteLine(@"Number 3 string variant : ""{0}"" and Number 3 deciaml fraction variant : {1}", 
                case1, number3.ToString(RationalNumber.RepresentationVariant.DecimalFraction));
            Console.WriteLine(@"Number 4 string variant : ""{0}"" and Number 4 deciaml fraction variant : {1}",
                case2, number4.ToString(RationalNumber.RepresentationVariant.DecimalFraction));
            Console.WriteLine(@"Number 5 string variant : ""{0}"" and Number 5 deciaml fraction variant : {1}",
                case3, number5.ToString(RationalNumber.RepresentationVariant.DecimalFraction));
            Console.WriteLine(@"Number 6 string variant : ""{0}"" and Number 6 deciaml fraction variant : {1}",
                case4, number6.ToString(RationalNumber.RepresentationVariant.DecimalFraction));


            //Explicit/implicit operators
            RationalNumber number7 = 3.1;
            RationalNumber number8 = 7.99;
            int a = (int)number8;
            double b = (double)number7;
            Console.WriteLine($"Number7 : {number7.ToString(RationalNumber.RepresentationVariant.Fraction)} \n" +
                              $"Number8 : {number8.ToString(RationalNumber.RepresentationVariant.Fraction)} \n" +
                              $"a = {a}, b = {b} \n");
            Console.WriteLine("double b = {1} from Number7 : {0} ", number7.ToString(RationalNumber.RepresentationVariant.Fraction), b);
            Console.WriteLine("int a = {1} from Number8 : {0}\n", number8.ToString(RationalNumber.RepresentationVariant.Fraction), a);


            // Demonstration of overrided CompareTo method of IComparable inteface
            double c = 6.185;
            double d = c * 0.1 / 0.1;
            RationalNumber number9 = c;
            RationalNumber number10 = d;
            Console.WriteLine("c = {0}\nd = {1}", c, d);
            Console.WriteLine("Default comparison method of c & d = {0}", c.CompareTo(d) == 0);
            Console.WriteLine("My comparison method of c & d = {0}", number9.CompareTo(number10) == 0);
        }
    }
}