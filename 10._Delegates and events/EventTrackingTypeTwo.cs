using System;

namespace _10._Delegates_and_events
{
    public class EventTrackingTypeTwo
    {
        private readonly EventHandler<TimeSignalEventArgs> handler = (object sender, TimeSignalEventArgs e) =>
        Console.WriteLine(e.Message + " in event tracking type two, set time: " + e.TimeBeforeEvent.ToString());

        public void Register(Сlock сlock)
        {
            сlock.TimeSignal += handler;
        }

        public void Unregister(Сlock сlock)
        {
            сlock.TimeSignal -= handler;
        }
    }
}
