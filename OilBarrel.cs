using System;
using System.Collections.Generic;
using System.Text;

namespace Emmers
{
    public class OilBarrel : Container
    {
        /// <summary>
        /// Constructor for <see cref="OilBarrel"/>
        /// </summary>
        public OilBarrel() : base(159, 159) { }

        /// <summary>
        /// Writes a debug message if the <see cref="EventTracking"/> flag is true
        /// </summary>
        /// <param name="msg"></param>
        protected override void Debugging(string msg)
        {
            if (EventTracking)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(msg);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
