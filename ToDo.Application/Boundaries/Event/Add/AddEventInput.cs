using System;
using ToDo.Domain;
using ToDo.Domain.Events;

namespace ToDo.Application.Boundaries.Event.Add
{
    public sealed class AddEventInput
    {
        private const int MaxNameLength = 40;
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime StartDate { get; private set; }
        public TimeSpan Duration { get; private set; }

        public AddEventInput(string name, string description, DateTime startDate, TimeSpan duration)
        {
            if(string.IsNullOrEmpty(name))
                throw new NameShouldNotBeNullOrEmptyException("The event name is required.");

            if(name.Length > MaxNameLength)
                throw new NameIsTooLongException("The name is too long.");

            if(duration.TotalMilliseconds < 0)
                throw new DurationCannotBeNegativeException("Only a positive duration is allowed.");

            Name = name;
            Description = description;
            StartDate = startDate;
            Duration = duration;
        }
    }
}
