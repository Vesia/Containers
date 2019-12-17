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
            
            Bucket bucket1 = new Bucket(12);

            //Console.WriteLine("Creating bucket 2");
            Bucket bucket2 = new Bucket(12);

            bucket1.Fill(11);
            bucket2.Fill(4);
            bucket1.TransferContents(bucket2, 10);

            Console.WriteLine(bucket1);
            Console.WriteLine(bucket2);


            OilBarrel oil1 = new OilBarrel();
            oil1.Fill(5000);
            oil1.Empty();
            oil1.Fill(50);
            Console.WriteLine(oil1);
            oil1.Empty(500);
            Console.WriteLine(oil1);
        }

        private static void RandomScenario()
        {
            //Random rnd = new Random();
            //int buckets = 10;
            //for (int i = 0; i < buckets; i++)
            //{
            //    Bucket bucket = new Bucket(rnd.Next(10, 15));
            //    bucket.Fill(12);
            //    bucket.Empty(13);
            //    Console.WriteLine($"Capacity: {bucket.Capacity} | Contents: {bucket.Content}");
            //    Console.WriteLine("---------------------");
            //}
        }
    }
}
