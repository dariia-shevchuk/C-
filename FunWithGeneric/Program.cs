using CoreLibrary.Classes;
using CoreLibrary.Interfaces;
using System;

namespace FunWithGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            //******** Metody generyczne 
            // kompilator wywnioskue jaki jest typ
            Test(5, 10);
            Test(new Employee("Jacek", "Placke", 27), new Employee("Ala", "Makota", 7));
            Test(1.75f, 5.55f);
            // Tu juz nie wie jaki jest typ
            Test<IShape>(new Circle(), new Rectangle());

            //************ Klase
            Console.WriteLine("\n*********************\n");
            Console.WriteLine(new Point<int>(5, 15));
            Console.WriteLine(new Point<float>(5f, 15f));
            Console.WriteLine(new Point<decimal>(5m, 15m));
            // ok ale teraz moge podać jako typ generyczny co tylko chce
            // Console.WriteLine(new Point<IPerson>(new Employee("Jacek", "Placke", 27), new Employee("Ala", "Makota", 7))); 
            //co jest troche bez sensu żeby punkt mial takie współrzędne
            //dlatego istnieje cos takiego jak ograniczenie typu generycznego
            // za pomoca słowa where
            // where T: struct Parametr typu <T> musi dziedziczyć po System.ValueType
            // where T: class  Parametr typu <T> nie może dziedziczyć po System.ValueType
            // where T: new() Parametr typu <T> musi mieć domyślny konstruktor. Ważne, jeżeli typ generyczny musi tworzyć instancję parametru typu
            // where T: nazwaKlasyBazwoey Parametr typu <T> musi wywodzić się z klasy bazowej
            // where T: nazwaInterfejsu Parametr typu <T> musi musi implementować interfejs, wiele interfejsów oddzielamy przecinkiem
            //przykłady 
            //public class MyGenericClass<T> where T: new()
            //public class MyGenericClass<T> : IPerson where T: struct
            //public class MyGenericClass<T> : BaseAbsttractClass, IPerson where T: ISomInterface, new()
            //public class MyGenericClass<TArg1, TArg2> where TArg1: new() where TArg2: struct
            //teraz możemy ograniczyć w klasie Point typ generyczny 

            //Słowo default 
            //Dodanie metody Reset() w klasie Point
            var myPoint = new Point<int>(100, 200);
            Console.WriteLine("Przed resetem");
            Console.WriteLine(myPoint);
            myPoint.Reset();
            Console.WriteLine("Po reseće");
            Console.WriteLine(myPoint);
            //słowo default ustawia wartość w przypadku:
            //liczb - 0
            //typy referencyjne - null
            //pól struktur - 0 dla typów wartościowych lub null dla typów referencyjnych


            //************* interfejsy
            //patrz interfejs
            Console.WriteLine("\n*** Interfaces ***\n");
            var baseMath = new BaseMath();
            Console.WriteLine(baseMath.Add(5, 50));
            Console.WriteLine(baseMath.Divide(500, 5));
        }

        private static void Test<T>(T a, T b)
        {
            Console.WriteLine($"\n*** {typeof(T)} ***\n");
            Console.WriteLine("Przed\n");
            ShowInfo(a, b);
            Swap(ref a, ref b);
            Console.WriteLine("\nPo\n");
            ShowInfo(a, b);
        }

        private static void ShowInfo<T>(T first, T second)
        {
            Console.WriteLine("Pierwszy element: {0}", first);
            Console.WriteLine("Drugi element: {0}", second);
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }
    }

}
