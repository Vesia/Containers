using System;
using System.Collections.Generic;
using System.Text;

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
        public RainBarrel(Size size) : base((int)size, (int)size)
        { }
    }
}
