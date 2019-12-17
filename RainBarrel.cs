using System;
using System.Collections.Generic;
using System.Text;

namespace Emmers
{
    public class RainBarrel : Container
    {
        public enum Size
        {
            Small,
            Medium,
            Large,
        }
        public RainBarrel(Size size) : base()
        {
            switch (size)
            {
                case Size.Small:
                    min_size = 80;
                    Capacity = 80;
                    break;
                case Size.Medium:
                    min_size = 120;
                    Capacity = 120;
                    break;
                case Size.Large:
                    min_size = 160;
                    Capacity = 160;
                    break;
            }
        }
        public override void OnOverFlow(int amount)
            => Debugging($"Rainbarrel overflowing by: {amount}L");

        public override void OnUnderFlow(int amount)
            => Debugging($"Rainbarrel underflowing by: {amount}L");

        public override void OnContainerFilled(int amount)
        {
            if (amount == Capacity)
                Debugging($"Rainbarrel is full!");
            // If almost full
        }

        public override void OnContainerEmpty(int amount)
        {
            if (amount == 0)
                Debugging("Rainbarrel is empty!");
        }
    }
}
