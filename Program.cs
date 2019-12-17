using System;

namespace Emmers
{
    class Program
    {
        static void Main(string[] args)
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

            Bucket bucket1 = new Bucket(12)
            {
                EventTracking = true,
            };
            Bucket bucket2 = new Bucket(9)
            {
                EventTracking = true,
            };
            bucket1.Fill(13);
            bucket2.Fill(4);

            bucket1.TransferContents(bucket2, 7);

            Console.WriteLine($"Bucket 1 contents: {bucket1.Content}");
            Console.WriteLine($"Bucket 2 contents: {bucket2.Content}");


            Console.ReadLine();
        }
    }
}
