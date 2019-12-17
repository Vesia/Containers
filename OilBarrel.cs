using System;
using System.Collections.Generic;
using System.Text;

namespace Emmers
{
    public class OilBarrel : Container
    {
        public OilBarrel(int capacity) : base(capacity, 159) { }

        public override void OnOverFlow(int amount)
            => Debugging($"Oil barrel overflowing by: {amount}L");

        public override void OnUnderFlow(int amount)
            => Debugging($"Oil barrel underflowing by: {amount}L");

        public override void OnContainerFilled(int amount)
        {
            if (amount == Capacity)
                Debugging($"Oil barrel is full!");
            // If almost full
        }

        public override void OnContainerEmpty(int amount)
        {
            if (amount == 0)
                Debugging("Oil barrel is empty!");
        }
    }
}
