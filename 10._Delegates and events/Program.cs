using System;

namespace _10._Delegates_and_events
{
    class Program
    {
        static void Main()
        {

            EventTrackingTypeOne eventTrackingTypeOne = new EventTrackingTypeOne();
            EventTrackingTypeTwo eventTrackingTypeTwo = new EventTrackingTypeTwo();
            EventTrackingTypeThree eventTrackingTypeThree = new EventTrackingTypeThree();
            Console.WriteLine("Events");
            Сlock clock = new Сlock();
            while (true)
            {
                try
                {
                    Console.WriteLine("What should be done?:");
                    Console.WriteLine("1. Start timing (enter <1>)");
                    Console.WriteLine("2. Register for event type one (enter <2>)");
                    Console.WriteLine("3. Register for event type two (enter <3>)");
                    Console.WriteLine("4. Register for event type three (enter <4>)");
                    Console.WriteLine("5. Unregister for event type one (enter <5>)");
                    Console.WriteLine("6. Unregister for event type two (enter <6>)");
                    Console.WriteLine("7. Unregister for event type three (enter <7>)");
                    Console.WriteLine("Enter <Q> to exit");
                    switch (Console.ReadKey(true).KeyChar)
                    {
                        case '1':
                            {
                                while (true)
                                {
                                    Console.WriteLine("Enter the time before the signal (second):");
                                    if (uint.TryParse(Console.ReadLine().ToString(), out uint timeBeforeEvent))
                                    {
                                        clock.SimulateNewSignal(timeBeforeEvent);
                                        break;
                                    }
                                    Console.WriteLine("Invalid format, please input again!");
                                }
                            }
                            break;

                        case '2':
                            {
                                eventTrackingTypeOne.Register(clock);
                                Console.WriteLine("Type one registered to event.");
                            }
                            break;

                        case '3':
                            {
                                eventTrackingTypeTwo.Register(clock);
                                Console.WriteLine("Type two registered to event.");
                            }
                            break;
                        case '4':
                            {
                                eventTrackingTypeThree.Register(clock);
                                Console.WriteLine("Type three registered to event.");
                            }
                            break;

                        case '5':
                            {
                                eventTrackingTypeOne.Unregister(clock);
                                Console.WriteLine("Type one unregistered to event.");
                            }
                            break;
                        case '6':
                            {
                                eventTrackingTypeTwo.Unregister(clock);
                                Console.WriteLine("Type two unregistered to event.");
                            }
                            break;

                        case '7':
                            {
                                eventTrackingTypeThree.Unregister(clock);
                                Console.WriteLine("Type three unregistered to event.");
                            }
                            break;

                        case 'q':
                            Environment.Exit(0);
                            break;

                        default:
                            break;
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
