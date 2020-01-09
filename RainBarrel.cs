using System;

namespace Emmers
{
    public class RainBarrel : Container
    {
        /// <summary>
        /// Enum for the <see cref="RainBarrel"/> size
        /// </summary>
        public enum Size
        {
            Small = 80,
            Medium = 120,
            Large = 160,
        }
        /// <summary>
        /// Constructor for <see cref="RainBarrel"/>
        /// </summary>
        /// <param name="size"></param>
        public RainBarrel(Size size) : base((int)size)
        { }

        /// <summary>
        /// Writes a debug message if the <see cref="EventTracking"/> flag is true
        /// </summary>
        /// <param name="msg"></param>
        protected override void Debugging(string msg)
        {
            if (EventTracking)
            {
                if (EventTracking)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(msg);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        /// <summary>
        /// Returns the <see cref="RainBarrel"/> values as a <see cref="string"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => $"Type: {GetType().Name}\n" +
            $"Size: {(Size)Capacity}\n" +
            $"Capacity: {Capacity}L\n" +
            $"Content: {Content}L";
    }
}
