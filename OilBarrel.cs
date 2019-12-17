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
        /// <param name="capacity"></param>
        public OilBarrel(int capacity) : base(capacity, 159) { }
    }
}
