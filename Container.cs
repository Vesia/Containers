using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Emmers
{
    public abstract class Container
    {
        // Default minimum size for a container
        protected int min_size { get; set; }

        private int capacity;
        public bool EventTracking { get; set; }

        // The public property for capacity
        public int Capacity 
        {
            get => capacity;
            protected set 
            {
                if (value < min_size)
                    value = min_size;
                capacity = value;
            } 
        }

        private int content = 0;

        public delegate void ContainerHandler(int amount);

        public event ContainerHandler OverflowEvent;
        public event ContainerHandler UnderflowEvent;
        public event ContainerHandler ContainerFilledEvent;
        public event ContainerHandler ContainerEmptyEvent;


        // The public property for contents
        public int Content 
        { 
            get => content; 
            private set
            {
                // If content is added
                if(value > content)
                {
                    if (value > capacity)
                    {
                        
                        // Calculate the overflow
                        int overflow = (value - capacity);
                        OverflowEvent?.Invoke(overflow);
                        value = capacity;
                    }
                    else
                        ContainerFilledEvent?.Invoke(value);
                }
                // If content gets removed
                else if(value < content)
                {
                    if (value < 0)
                    {
                        // Can't empty more than what's in it
                        UnderflowEvent?.Invoke(-value);
                        value = 0;
                    }
                    else
                        ContainerEmptyEvent?.Invoke(value);
                }
                content = value;
            } 
        }

        public Container()
        {
            OverflowEvent += OnOverFlow;
            UnderflowEvent += OnUnderFlow;
            ContainerFilledEvent += OnContainerFilled;
            ContainerEmptyEvent += OnContainerEmpty;
        }

        public Container(int capacity) : this()
            => Capacity = capacity;

        // Default constructor
        public Container(int capacity, int minimum) : this()
        {
            min_size = minimum;
            Capacity = capacity;
        }

        // Fills the container with an amount
        public int Fill(int amount)
        {
            if (amount < 1)
                return 0;

            var temp = Content;
            Content += amount;

            return temp + amount - Content;
        }
        
        // Empties the entire container
        public void Empty() => Content = 0;
        
        // Removes an amount of contents from the container
        public void Empty(int amount)
        {
            if (amount < 1)
                return;

            Content -= amount;
        }


        public abstract void OnOverFlow(int amount);
        public abstract void OnUnderFlow(int amount);

        public abstract void OnContainerFilled(int amount);

        public abstract void OnContainerEmpty(int amount);

        protected void Debugging(string msg) 
        {
            if(EventTracking)
                Console.WriteLine(msg); 
        }
        
    }
}
