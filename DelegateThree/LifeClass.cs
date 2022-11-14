using System.Collections.Generic;
using System.Threading;

namespace DelegateThree
{
    internal class LifeClass
    {
        private IEnumerable<Person> peaple;

        public LifeClass(IEnumerable<Person> peaple)
        {
            this.peaple = peaple;
        }

        //ta metoda zwieksza wiek kazdego co 2 s
        internal void BeginLife()
        {

            foreach (var person in peaple)
            {

                //czekam 2 s
                Thread.Sleep(2000);
                //zwiekszam wiek
                person.MakeOneYeraOder();
            }

        }
    }

    //to tylko przykład 
    internal class LifeClassTwo
    {
        private IEnumerable<PersonTwo> peaple;

        public LifeClassTwo(IEnumerable<PersonTwo> peaple)
        {
            this.peaple = peaple;
        }

        //ta metoda zwieksza wiek kazdego co 2 s
        internal void BeginLife()
        {

            foreach (var person in peaple)
            {

                //czekam 2 s
                Thread.Sleep(2000);
                //zwiekszam wiek
                person.MakeOneYeraOder();
            }

        }
    }
}