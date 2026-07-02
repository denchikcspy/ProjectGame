using System;


namespace WindowsFormsApp5.Entities.RandomEvents
{
    public enum EventType
    {
        Positive = 1,
        Negative
    }

    public abstract class Event
    {
        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public EventType Type { get; protected set; }

        public Event(string name, EventType type)
        {
            this.Name = name;
            this.Type = type;
        }


        public abstract void execute(Player player);
    }
}
