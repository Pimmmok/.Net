using System;
using System.Threading;

namespace _10._Delegates_and_events
{
    public class Сlock
    {
        public uint TimeBeforeEvent { get; set; }

        public event EventHandler<TimeSignalEventArgs> TimeSignal;
        protected virtual void OnSignal(TimeSignalEventArgs e)
        {
            TimeSignal?.Invoke(this, e);
        }
        public void SimulateNewSignal(uint timeBeforeEvent)
        {
            TimeSignalEventArgs e = new TimeSignalEventArgs("----------- Clock STOP",
                                                            timeBeforeEvent);
            Console.WriteLine("Clock start, time: " + timeBeforeEvent.ToString());
            for (uint i = 0; i < timeBeforeEvent; i++)
            {
                Console.WriteLine("Before the event is called: " + (timeBeforeEvent - i).ToString() + " second");
                Thread.Sleep(1000);
            }
            OnSignal(e);
        }
    }
}
