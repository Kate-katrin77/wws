using System;

namespace MathUtils
{
    class Program
    {
        //1. Change a and b arameters to double
        //2. Modify logic to return average (a+b)/2

        //This is how I would fix this logic
        //public static double Average(double a, double b)
        //{
        //    return (a + b) / 2;
        //}

        static void Main(string[] args)
        {
            Console.WriteLine(Average(2.4, 5.3, 2));
            Console.ReadLine();
        }

        //This is how I would implement Average function to be able to pass array of params
        public static double Average(params double[] values)
        {
            if (values == null) { throw new NullReferenceException("Params must be supplied"); }

            if (values.Length == 0) { return 0; }

            var result = 0.0;
            foreach (var value in values)
            {
                result = result + value;
            }

            return result / values.Length;
        }
    }
}

