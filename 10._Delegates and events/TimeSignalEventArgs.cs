using System;

namespace _10._Delegates_and_events
{
    public class TimeSignalEventArgs : EventArgs
    {
        public string Message { get; }
        public uint TimeBeforeEvent { get; }
        public TimeSignalEventArgs(string message, uint timeBeforeEvent)
        {
            Message = message;
            TimeBeforeEvent = timeBeforeEvent;
        }
    }
}
