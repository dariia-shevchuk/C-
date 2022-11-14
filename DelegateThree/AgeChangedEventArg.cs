using System;

namespace DelegateThree
{
    //ta klasa zawiera wszelkie wazne informacje o naszym zdarzeniu
    public class AgeChangedEventArg : EventArgs
    {
        public int OldAge { get; }
        public int NewAge { get; set; }

        public AgeChangedEventArg(int oldAge, int newAge)
        {
            OldAge = oldAge;
            NewAge = newAge;
        }

    }
}
