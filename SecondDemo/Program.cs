using CoreLibrary.Classes;
using CoreLibrary.Interfaces;
using System;
using System.Collections;

namespace SecondDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Problem ze wszystkimi kolekcjami z przestrzeni nazw using System.Collections
            //wynika z tego, że operują one na ogólnym type danych czyli object
            // np: ArrayList 'ma' metodę Add(object? value) przez co
            // 1 -> nie mamy bezpieczeństwa typów
            // 2 -> musimy pamietać o rzutowaniu

            Problems();

            //Problem bezpieczeństwa typów możemy rozwiązać implementując własna kolekcje
            // np.
            FunWithPeopleCollection();
            // w tym pzypadku zachowujemy bezpieczeństwo typów ale dalej jest problem z rzutowaniem obiektów
            //do tego jeżeli potrzebujemy inną kolekcje np typu string, int, Ishape i tak dalej 
            //to bedziemy musieli powielać nasza kolekcje ludzi zmieniając tylko typ 
            //co sprawi że będzie dłużo powtarzającego sie kodu w naszej aplikacji 
            // porównaj klase PeopleCollection oraz StringCollection
            FunWithStringCollection();
            //dbanie o program w którym jest dłużo powtarzającego się kodu to prawdziwy koszmar
            //wyobraż sobie że masz program w którym jest zdefiniowanych 300 kolekcji ze scisłą kontrolom typu
            //i nagle trzeba cos we wszystkich dodać albo zmienić. Powodzenia
            //Rozwiązaniem są TYPY GENERYCZNE
            //np kolekcje generyczne pozwalają odłożyć specyfikacje zawieranego typu do czasu tworzenia
            //Np 
            FunWithGenericCollection();
        }

        private static void FunWithGenericCollection()
        {
            System.Collections.Generic.List<int> myList;
            //jak przejżymy definicje takiej klasy to zobaczymy że bardzo dużo metod operuje na tak zwanym T
            //public void Add(T item);
            //void AddRange(IEnumerable<T> collection);
            //public bool Contains(T item);
            //public int IndexOf(T item);
            //public int LastIndexOf(T item);
            // i tak dalej...
            // w momęcie tworzenia listy wskazałem w nawiasach ostrych 
            // typ int to oznacza za w tym obiekcie wszystkie wystąpienia T
            // zostaną zamienion na int
            System.Collections.Generic.List<IPerson> PeopleList = new System.Collections.Generic.List<IPerson>();
            // tu każde T zostanie zamienione na IPerson
            PeopleList.Add(new Employee("Jacek", "Placek", 27));
            //mamy zapewnione bezpieczeństwo typów 
            //nie ma rzutowania
            //nie powtrzamy kodu
        }

        private static void FunWithStringCollection()
        {
            var stringCollection = new StringCollection();

            stringCollection.AddItem("Jacek");
            stringCollection.AddItem("Franek");
            stringCollection.AddItem("Miś");
            Console.WriteLine("Liczba elementów w kolekcji: {0}", stringCollection.Count);
            foreach (var item in stringCollection)
                Console.WriteLine(item);
            Console.WriteLine("Wyczyść kolekcje");
            stringCollection.ClearPeople();
            Console.WriteLine("Liczba elementów w kolekcji: {0}", stringCollection.Count);
        }

        private static void FunWithPeopleCollection()
        {
            var peopleCollection = new PeopleCollection();

            peopleCollection.AddItem(new Employee("Jacek", "Placek", 20));
            peopleCollection.AddItem(new Employee("Franek", "Kimono", 55));
            peopleCollection.AddItem(new Employee("Miś", "Koralgol", 7));
            Console.WriteLine("Liczba elementów w kolekcji: {0}", peopleCollection.Count);
            foreach (var item in peopleCollection)
                Console.WriteLine(item);
            Console.WriteLine("Wyczyść kolekcje");
            peopleCollection.ClearPeople();
            Console.WriteLine("Liczba elementów w kolekcji: {0}", peopleCollection.Count);
        }

        private static void Problems()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.AddRange(new IPerson[] {
                    new Employee("Jacke", "Placke", 30),
                    new Employee("Krzysiek", "Kowalski", 18),
                    new Employee("Ela", "Nazwisko", 26),
                    new Employee("Ryszard", "Nazwisko", 28)
            });

            //Wyswietl wszystkich imiona
            foreach (var item in arrayList)
                Console.WriteLine(((IPerson)item).FirstName); // rzutowanie object na IPerson

            arrayList.Add(new Circle()); //brak bezpieczeństwa typów moge dodać co chcem do kolekcji
            Console.WriteLine();
            foreach (var item in arrayList)
            {
                //Błąd nie wszystko w mojej kolekcji jest IPerson
                try
                {
                    Console.WriteLine(((IPerson)item).FirstName); // rzutowanie object na IPerson 
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine("Błąd rzutowania!: {0}", ex.Message);
                }

            }
        }
    }
}
