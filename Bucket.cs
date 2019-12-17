using System;
using System.Collections.Generic;
using System.Text;

namespace Emmers
{
    public class Bucket : Container
    {
        public Bucket(int capacity) : base(capacity, 10) {  }

        public void TransferContents(Bucket bucket, int amount)
        {
            if(Content >= amount)
            {
                var overflow = bucket.Fill(amount);

                if (overflow > 0)
                    Empty(amount - overflow);
                else
                    Empty(amount);
            }
        }

        public override void OnOverFlow(int amount)
            => Debugging($"Bucket overflowing by: {amount}L");

        public override void OnUnderFlow(int amount)
            => Debugging($"Bucket underflowing by: {amount}L");

        public override void OnContainerFilled(int amount)
        {
            if(amount == Capacity)
                Debugging($"Bucket is full!");
            // If almost full
        }

        public override void OnContainerEmpty(int amount)
        {
            if(amount == 0)
                Debugging("Bucket is empty!");
        }
    }
}
