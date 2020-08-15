/*
 Write classes for events, one class which exposes an event and another which handles the event.
1)    Create a class to pass as an argument for the event handlers
2)    Set up the delegate for the event
3)    Declare the code for the event
4)    Create code the will be run when the event occurs 
5)    Associate the event with the event handler
 */

using System;

namespace Net022FinalEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            person.name = "Will";

            var newevent = new Mine();
            newevent.MyEvent += person.HandleEvent;

            newevent.MyEventFunc();
        }

        public class Person
        {
            public string name { get; set; }

            public void HandleEvent(object sender, MyEventArgs e)
            {
                Console.WriteLine("My event occurs at {0}", e.time);
            }
        }


        public class Mine
        {
            public event MyEventHandeler MyEvent;

            public void MyEventFunc()
            {
                MyEventHandeler myevent = MyEvent;
                if (MyEvent != null)
                {
                    myevent(this, new MyEventArgs(DateTime.Now));
                }
            }
        }

        public delegate void MyEventHandeler(object source, MyEventArgs e);

        public class MyEventArgs : EventArgs
        {
            public DateTime time { get; set; }
            public MyEventArgs(DateTime time)
            {
                this.time = time;
            }
        }
    }
}
