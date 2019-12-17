using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Emmers
{
    public abstract class Container
    {
        #region Variables
        /// <summary>
        /// The maximum capacity a container can have
        /// </summary>
        private int capacity;

        /// <summary>
        /// The content inside a container
        /// </summary>
        private int content = 0;

        /// <summary>
        /// The minimum size for a container
        /// </summary>
        protected int min_size { get; set; }

        /// <summary>
        /// Flag to enable/disable debugging of a container
        /// </summary>
        public bool EventTracking { get; set; } = true;

        /// <summary>
        /// The maximum capacity the container can have
        /// </summary>
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

        /// <summary>
        /// The content that is inside of the container
        /// </summary>
        public int Content 
        { 
            get => content; 
            private set
            {
                // If content is added
                if(value > content)
                {
                    ContainerFillingEvent?.Invoke(this, value - content);
                    if (value > capacity)
                    {
                        
                        // Calculate the overflow
                        int overflow = (value - capacity);
                        OverflowEvent?.Invoke(this, overflow);
                        value = capacity;
                    }
                    else
                        ContainerFilledEvent?.Invoke(this, value);
                }
                // If content gets removed
                else if(value < content)
                {
                    ContainerEmptyingEvent?.Invoke(this, content - value);
                    if (value < 0)
                    {
                        // Can't empty more than what's in it
                        UnderflowEvent?.Invoke(this, -value);
                        value = 0;
                    }
                    else
                        ContainerEmptiedEvent?.Invoke(this, value);
                }
                content = value;
            } 
        }
        #endregion

        #region Events
        public delegate void ContainerHandler(object sender, int amount);

        public event ContainerHandler OverflowEvent;
        public event ContainerHandler UnderflowEvent;
        public event ContainerHandler ContainerFillingEvent;
        public event ContainerHandler ContainerFilledEvent;
        public event ContainerHandler ContainerEmptyingEvent;
        public event ContainerHandler ContainerEmptiedEvent;

        public event ContainerHandler CreationEvent;
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public Container()
        {
            // Binding methods to the proper events
            CreationEvent += OnContainerCreation;
            OverflowEvent += OnOverFlow;
            UnderflowEvent += OnUnderFlow;
            ContainerFillingEvent += OnContainerFilling;
            ContainerEmptyingEvent += OnContainerEmptying;
            ContainerFilledEvent += OnContainerFilled;
            ContainerEmptiedEvent += OnContainerEmpty;
        }

        /// <summary>
        /// Parameterised constructor
        /// </summary>
        /// <param name="capacity">The amount of capacity the container can have</param>
        /// <param name="minimum">The minimum size the container needs to be</param>
        public Container(int capacity, int minimum) : this()
        {
            min_size = minimum;
            Capacity = capacity;

            // Invoking creation event
            CreationEvent?.Invoke(this, Capacity);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Fills the container with an amount of content
        /// </summary>
        /// <param name="amount">The amount of content the container needs to be filled with</param>
        /// <returns></returns>
        public int Fill(int amount)
        {
            if (amount < 1)
                return 0;

            var temp = Content;
            Content += amount;

            return temp + amount - Content;
        }
        
        /// <summary>
        /// Removes all content from the container
        /// </summary>
        public void Empty() => Content = 0;
        
        /// <summary>
        /// Removes an amount of content from the container
        /// </summary>
        /// <param name="amount"></param>
        public void Empty(int amount)
        {
            if (amount < 1)
                return;

            Content -= amount;
        }

        /// <summary>
        /// Writes a debug message if the <see cref="EventTracking"/> flag is true
        /// </summary>
        /// <param name="msg"></param>
        protected void Debugging(string msg)
        {
            if (EventTracking)
                Console.WriteLine(msg);
        }
        #endregion

        #region EventMethods
        /// <summary>
        /// Method that gets called on creation of the container
        /// </summary>
        /// <param name="sender">The sender as an object</param>
        /// <param name="amount">The amount as an Integer</param>
        protected virtual void OnContainerCreation(object sender, int amount)
            => Debugging($"Container created of type {sender.GetType().Name} with {amount}L capacity");

        /// <summary>
        /// Method that gets called when a container is overflowing
        /// </summary>
        /// <param name="sender">The sender as an object</param>
        /// <param name="amount">The amount as an Integer</param>
        protected virtual void OnOverFlow(object sender, int amount)
            => Debugging($"Prevented {sender.GetType().Name} from overflowing by {amount}L");

        /// <summary>
        /// Method that gets called when a container is underflowing
        /// </summary>
        /// <param name="sender">The sender as an object</param>
        /// <param name="amount">The amount as an Integer</param>
        protected virtual void OnUnderFlow(object sender, int amount)
            => Debugging($"Prevented {sender.GetType().Name} from underflowing by {amount}L");

        /// <summary>
        /// Method that gets called when a container is trying to fill by an amount
        /// </summary>
        /// <param name="sender">The sender as an object</param>
        /// <param name="amount">The amount as an Integer</param>
        protected virtual void OnContainerFilling(object sender, int amount)
            => Debugging($"Trying to fill {sender.GetType().Name} with: {amount}L");

        /// <summary>
        /// Method that gets called when a container is trying to empty by an amount
        /// </summary>
        /// <param name="sender">The sender as an object</param>
        /// <param name="amount">The amount as an Integer</param>
        protected virtual void OnContainerEmptying(object sender, int amount)
            => Debugging($"Trying to empty {amount}L from {sender.GetType().Name}");

        /// <summary>
        /// Method that gets called when a container has been filled by an amount
        /// </summary>
        /// <param name="sender">The sender as an object</param>
        /// <param name="amount">The amount as an Integer</param>
        protected virtual void OnContainerFilled(object sender, int amount)
        {
            if (amount == Capacity)
                Debugging($"{sender.GetType().Name} is full!");
            // If container is almost full (10% left)
            else if (Capacity - amount <= Capacity * 0.1)
                Debugging($"{sender.GetType().Name} is almost full! ({amount}/{Capacity}L)");
        }

        /// <summary>
        /// Method that gets called when a container has been emptied by an amount
        /// </summary>
        /// <param name="sender">The sender as an object</param>
        /// <param name="amount">The amount as an Integer</param>
        protected virtual void OnContainerEmpty(object sender, int amount)
        {
            if (amount == 0)
                Debugging($"{sender.GetType().Name} is empty!");
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Overridden <see cref="ToString"/> Method to return values from the container
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => $"Type: {this.GetType().Name}\n" +
            $"Capacity: {Capacity}L\n" +
            $"Content: {Content}L";
        #endregion
    }
}
