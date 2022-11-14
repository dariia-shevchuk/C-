using System;

namespace DelegateThree
{
    //to jest tylko przykład
    public class Person
    {
        public delegate void AgeChangedDelegate(object sender, AgeChangedEventArg ageChangedEventArg);

        public event AgeChangedDelegate AgeChangedEventHandler;

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

    //to jest tylko przykład
    public class PersonTwo
    {
        //nie deklarujemy delegatu bo używamy generycznego

        public event EventHandler<AgeChangedEventArg> AgeChangedEventHandler;

        private int _age;

        public PersonTwo(string name, int age)
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
