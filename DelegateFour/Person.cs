using System;

namespace DelegateFour
{
    public class Person
    {
        //nie deklarujemy delegatu bo używamy generycznego

        public event EventHandler<AgeChangedEventArg> AgeChangedEventHandler;

        private int _age;

        public Person(string name, int age)
        {
            Name = name;
            _age = age;
        }

        public string Name { get; }

        public void MakeOneYeraOder()
        {
            int oldAge = _age;
            _age++;
            //pierwszy parametr informuje kto wywołuje zdarzenie drugi zawiera ważne informacje o zdarzniu
            AgeChangedEventHandler?.Invoke(this, new AgeChangedEventArg(oldAge, _age));
        }
    }
}
