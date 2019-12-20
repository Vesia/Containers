using System;

namespace Emmers
{
    class Program
    {
        static void Main(string[] args)
        {
            Scenario1();
            Console.ReadLine();
        }


        /// <summary>
        /// A scenario to play
        /// </summary>
        private static void Scenario1()
        {
            Console.Clear();

            Bucket bucket1 = new Bucket(15);
            Bucket bucket2 = new Bucket(12);

            bucket1.Fill(11);
            bucket2.Fill(4);
            bucket1.TransferContents(bucket2, 10);

            Console.WriteLine(bucket1);
            Console.WriteLine(bucket2);

            OilBarrel oil1 = new OilBarrel();
            oil1.Fill(5000);
            bucket1.TransferContents(oil1, 50);
            oil1.Empty();
            oil1.Fill(50);
            Console.WriteLine(oil1);
            oil1.Empty(500);
            Console.WriteLine(oil1);

            RainBarrel small = new RainBarrel(RainBarrel.Size.Small);
            RainBarrel medium = new RainBarrel(RainBarrel.Size.Medium);
            RainBarrel large = new RainBarrel(RainBarrel.Size.Large);

            small.Fill(small.Capacity);
            small.EventTracking = false;
            small.Empty(small.Capacity + 1);
            Console.WriteLine(small);

            medium.Empty(1);
            medium.Fill(50);
            Console.WriteLine(medium);

            large.Fill(145);
            large.Empty(113);
            large.Empty(2);
            Console.WriteLine(large);
        }

        private static void RandomScenario()
        {

        }
    }
}
