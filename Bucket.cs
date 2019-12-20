using System;
using System.Collections.Generic;
using System.Text;

namespace Emmers
{
    public class Bucket : Container, IContainerTransferable
    {
        /// <summary>
        /// Constructor for <see cref="Bucket"/>
        /// </summary>
        /// <param name="capacity"></param>
        public Bucket(int capacity) : base(capacity, 10) { }

        /// <summary>
        /// Transfers content from a <see cref="Bucket"/> to another <see cref="Bucket"/>
        /// </summary>
        /// <param name="bucket"></param>
        /// <param name="amount"></param>
        public void TransferContents(Container bucket, int amount)
        {
            if (bucket as Bucket != null)
            {
                if (Content >= amount)
                {
                    var overflow = bucket.Fill(amount);

                    if (overflow > 0)
                        Empty(amount - overflow);
                    else
                        Empty(amount);
                }
                else
                {

                    throw new ArgumentOutOfRangeException($"Can't transfer {amount}L to {bucket.GetType().Name}, {GetType().Name} only has {Content}L");
                }
            }
        }

        /// <summary>
        /// Writes a debug message if the <see cref="EventTracking"/> flag is true
        /// </summary>
        /// <param name="msg"></param>
        protected override void Debugging(string msg)
        {
            if (EventTracking)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(msg);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
