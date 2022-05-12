using System;

namespace _10._Delegates_and_events
{
    public class EventTrackingTypeThree
    {
        private void ProcessTheSignal(object sender, TimeSignalEventArgs e)
        {
            Console.WriteLine(e.Message + " in event tracking type three, set time: " + e.TimeBeforeEvent.ToString());
        }
        public void Register(Сlock сlock)
        {
            сlock.TimeSignal += ProcessTheSignal;
        }

        public void Unregister(Сlock сlock)
        {
            сlock.TimeSignal -= ProcessTheSignal;
        }
    }
}
