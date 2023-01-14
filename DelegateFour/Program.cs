using System;
using System.Collections.Generic;

namespace DelegateFour
{
    class Program
    {
        // we wszystkich przykładach do tej pory żeby obsłużyć delegat 
        // tworzyliśmy metode tylko po to żeby ja powiązać z delegatem
        // nigdy wiecej nie była nam potrzebna
        // teraz napiszemy metodę bez nazwy w miejscu gdzie bedzie przekazywana do delegata
        // skopiujmy przykład z urodzinami z poprzedniego projektu
        static void Main(string[] args)
        {
            Console.WriteLine("***");
            FirstExample();
            //zaletą takiego rozwiązania jest to, że  w metodzie delegata mamy dostęp do zmiennych lokalnych
            Console.WriteLine("***");
            SecondExample();
            Console.WriteLine("***");
            //Operator Lambda
            ThirdExample();
            // jeszcze mniej pisania
            FourthExample();
            // Najczęstrze delegaty generyczne
            FifthExample();

            FindAllExample();
            //To na koniec napiszmy własną metode FindAll
            FinaleExample();
        }

        private static void FinaleExample()
        {
            List<int> list = new List<int>();
            for (int i = 1; i < 30; i++)
                list.Add(i);

            Console.WriteLine("\n\n **Nasza metoda FindAll**\n\n");
            var result = list.MyFindAllMethod(i => i % 2 == 0); // patrz klase ListExtensions
            foreach (var item in result)
                Console.Write(" {0}", item); //wyswietle tylko parzyste
        }

        private static void FindAllExample()
        {
            List<int> list = new List<int>();
            for (int i = 1; i < 30; i++)
                list.Add(i);

            foreach (var item in list)
                Console.Write(" {0}", item); //wyswietle wszystkie liczby

            Console.WriteLine("\n\n Tylko parzyste 1");
            var evenNumbers = list.FindAll(new Predicate<int>(IdEvenNumber));//metoda FindAll Przyjmuje Predicate<T> w naszym przykładzie T to int            
            foreach (var item in evenNumbers)
                Console.Write(" {0}", item); //wyswietle tylko parzyste
            Console.WriteLine("\n\n Tylko parzyste 2");

            var evenNumbersTwo = list.FindAll(delegate (int i) { return i % 2 == 0; });//metoda FindAll Przyjmuje Predicate<T> w naszym przykładzie T to int            
            foreach (var item in evenNumbersTwo)
                Console.Write(" {0}", item); //wyswietle tylko parzyste

            Console.WriteLine("\n\n Tylko parzyste 3");

            var evenNumbersThree = list.FindAll(i => i % 2 == 0);//metoda FindAll Przyjmuje Predicate<T> w naszym przykładzie T to int            
            foreach (var item in evenNumbersThree)
                Console.Write(" {0}", item); //wyswietle tylko parzyste

        }

        //jeszcze raz to samo 
        private static bool IdEvenNumber(int obj)
        {
            return obj % 2 == 0;
        }

        private static void FifthExample()
        {
            //Func<TOut>, Func<T1, TOut>, Func<T1, T2, TOut> ... Func<T1,...T16,  TOut>
            //gdzie TOut to typ zwracany przez metode a T1 ... T16 to parametry metody
            //oznacza to że Func moze wskazywać metode która zwraca jakis prametr i nie przyjmuje lub przyjmuje do 16 parametrów
            //przykład 
            Func<int, string, string> funcDelegate = new Func<int, string, string>(MethodForFunc);  // wskazuje metode która przyjmuje int oraz string a zwraca string
            Console.WriteLine(funcDelegate(15, "Test"));


            //Action, Action<T1>, Action<T1, T2> ... Action<T1, T2, ... , T16>
            //Wskazuje metode która zwraca void i przyjmuje od zera do 16 parametró
            //przykład
            Action<int, int, string> actionDelegate = new Action<int, int, string>(MethodForAction);
            actionDelegate(1, 15, "Test");

            //Predicate, Predicate<T>
            //Wskazuje metode, która zwraca bool i przyjmuje jeden parametr
            Predicate<int> predicate = new Predicate<int>(MethodForPradicate);
            Console.WriteLine("czy 5 jest liczbą parzystą: {0}", predicate(5));
        }

        private static bool MethodForPradicate(int obj)
        {
            return obj % 2 == 0;
        }

        private static void MethodForAction(int arg1, int arg2, string arg3)
        {
            Console.WriteLine($"MethodForAction({arg1}, {arg2}, {arg3}");
        }

        private static string MethodForFunc(int arg1, string arg2)
        {
            return $"{arg1}: {arg2}";
        }

        private static void FourthExample()
        {
            var birthdayCount = 0;

            var peaple = new List<Person>
            {
                new Person("Jacek", 17),
                new Person("Ala", 23),
                new Person("Franek", 73),
                new Person("Iza", 35)
            };

            foreach (var person in peaple)
            {
                person.AgeChangedEventHandler += (sender, arg) => //skoro wiem ze AgeChangedEventHandler to delegat, który wksazuje metody void Nazwa(object sender, AgeChangedEventArg arg) to w nasiwasach to pomine kompilator itak wie
                {
                    Console.WriteLine($"Hura urodziny {arg.NewAge}");
                    birthdayCount++;
                }; //zwróć uwage ze za ostatnią klamrą tez jest średnik
            }

            var lifeClass = new LifeClass(peaple);
            Console.WriteLine("Zaczynamy");
            lifeClass.BeginLife();
            Console.WriteLine("Było {0} urodzin", birthdayCount);
        }

        private static void ThirdExample()
        {
            var birthdayCount = 0;

            var peaple = new List<Person>
            {
                new Person("Jacek", 17),
                new Person("Ala", 23),
                new Person("Franek", 73),
                new Person("Iza", 35)
            };

            foreach (var person in peaple)
            {
                person.AgeChangedEventHandler += (object sender, AgeChangedEventArg arg) => // nie pisze juz delegate tylko używanm operatora lambda( => )
                {
                    Console.WriteLine($"Hura urodziny {arg.NewAge}");
                    birthdayCount++;
                }; //zwróć uwage ze za ostatnią klamrą tez jest średnik
            }

            var lifeClass = new LifeClass(peaple);
            Console.WriteLine("Zaczynamy");
            lifeClass.BeginLife();
            Console.WriteLine("Było {0} urodzin", birthdayCount);
        }

        private static void SecondExample()
        {
            var birthdayCount = 0;

            var peaple = new List<Person>
            {
                new Person("Jacek", 17),
                new Person("Ala", 23),
                new Person("Franek", 73),
                new Person("Iza", 35)
            };

            foreach (var person in peaple)
            {
                person.AgeChangedEventHandler += delegate (object sender, AgeChangedEventArg arg)
                    {
                        Console.WriteLine($"Hura urodziny {arg.NewAge}");
                        birthdayCount++;
                    }; //zwróć uwage ze za ostatnią klamrą tez jest średnik
            }

            var lifeClass = new LifeClass(peaple);
            Console.WriteLine("Zaczynamy");
            lifeClass.BeginLife();
            Console.WriteLine("Było {0} urodzin", birthdayCount);
        }

        private static void FirstExample()
        {
            var peaple = new List<Person>
            {
                new Person("Jacek", 17),
                new Person("Ala", 23),
                new Person("Franek", 73),
                new Person("Iza", 35)
            };

            //jestem zainteresowany zmianą wieku każdego ale nie pisze dodatkowej metody
            foreach (var person in peaple)
            {
                person.AgeChangedEventHandler += delegate (object sender, AgeChangedEventArg arg) { Console.WriteLine($"Hura urodziny {arg.NewAge}"); }; //zwróć uwage ze za ostatnią klamrą tez jest średnik
            }

            var lifeClass = new LifeClass(peaple);
            Console.WriteLine("Zaczynamy");
            lifeClass.BeginLife();
        }
    }
}
