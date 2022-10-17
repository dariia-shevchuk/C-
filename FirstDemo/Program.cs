using CoreLibrary.Classes;
using CoreLibrary.Interfaces;
using System;
using System.Collections;

namespace FirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Problem z tablicami
            // Kompilator zarezerwował w pamieci tylko miejsce na 
            IShape[] shapes = new IShape[]// Kompilator zarezerwował w pamieci tylko miejsce na 5 obiektów
            {
                new Circle(),
                new Rectangle(),
                new Circle(),
                new Rectangle(),
                new Circle(),
            };
            //Tablice maja niezmienną wielkość

            //próba dodania kolejnego elementu do tablicy spowoduje Wyjątek
            //shapes[5] = new Rectangle();  //<- Błąd aplikacji

            //jeżeli chcieli byśmy umiescić obiekty w bardziej elastycznych kontenerach 
            //możwmy wykorzystać colekcje zdefiniowane w przestrzeni nazw using System.Collections
            //Patrz plik SystemCollections.txt
            FunWithArrayList();
            FunWithQueue();
            FunWithStack();

        }

        private static void FunWithStack()
        {
            Console.WriteLine("*** Stack ***");
            Stack stringStack = new Stack();
            stringStack.Push("Pierwszy");
            stringStack.Push("Drugi");
            stringStack.Push("Trzeci");

            //spójż na najwyższy element, strąć go i spójż ponownie
            Console.WriteLine("Element na samej górze list: {0}", stringStack.Peek());
            Console.WriteLine("Element strącony z samej góry list: {0}", stringStack.Pop());
            Console.WriteLine("Element na samej górze list: {0}", stringStack.Peek());
            Console.WriteLine("Element strącony z samej góry list: {0}", stringStack.Pop());
            Console.WriteLine("Element na samej górze list: {0}", stringStack.Peek());
            Console.WriteLine("Element strącony z samej góry list: {0}", stringStack.Pop());

            try
            {
                Console.WriteLine("Element na samej górze list: {0}", stringStack.Peek());
                Console.WriteLine("Element strącony z samej góry list: {0}", stringStack.Pop());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd!: {0}", ex.Message);
            }

        }

        private static void FunWithQueue()
        {
            Console.WriteLine("*** Queue ***");
            Queue employeeQueue = new Queue();
            //dodaj kilka osób
            employeeQueue.Enqueue(new Employee("Pierwszy", "Nazwisko", 18));
            employeeQueue.Enqueue(new Employee("Drugi", "Nazwisko", 18));
            employeeQueue.Enqueue(new Employee("Trzeci", "Nazwisko", 18));

            Console.WriteLine("Ilość elementów w kolekcji: {0}\n", employeeQueue.Count);

            //podejżyj pierwszą osobe z kolekcji
            Console.WriteLine("Pierwszy element w kolekcji \t {0}", employeeQueue.Peek());
            //wyswietl jeszcze raz ilość elementów 
            //nikt ne został usunięty z kolekcji
            Console.WriteLine("Ilość elementów w kolekcji: {0}\n", employeeQueue.Count);
            Console.WriteLine("usunięty element w kolekcji \t {0}", employeeQueue.Dequeue());
            Console.WriteLine("usunięty element w kolekcji \t {0}", employeeQueue.Dequeue());
            Console.WriteLine("usunięty element w kolekcji \t {0}", employeeQueue.Dequeue());
            Console.WriteLine("Ilość elementów w kolekcji: {0}\n", employeeQueue.Count);

            //spróbuj usunąć element z kolekcji
            try
            {
                Console.WriteLine("\n Próbuje usunąć element z kolekcji");
                employeeQueue.Dequeue();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd!: {0}", ex.Message);
            }


        }

        private static void FunWithArrayList()
        {
            Console.WriteLine("*** ArrayList ***");
            ArrayList arrayList = new ArrayList();
            // dodajemy całą tablice do arrayList
            arrayList.AddRange(new IPerson[] {
                    new Employee("Jacke", "Placke", 30),
                    new Employee("Krzysiek", "Kowalski", 18),
                    new Employee("Ela", "Nazwisko", 26),
                    new Employee("Ryszard", "Nazwisko", 28)
            });

            Console.WriteLine("Ilość elementów w arrayList: {0}", arrayList.Count);
            //Wyświetl wszystkich
            foreach (var emp in arrayList)
                Console.WriteLine(emp);

            Console.WriteLine("Wstawiam nowy element");
            arrayList.Insert(2, new Employee("Iwona", "Król", 45));

            //uzyskaj tablice obiektów z arrayLsit 
            object[] employess = arrayList.ToArray();
            Console.WriteLine("Ilość elementów w employess: {0}", employess.Length);
            foreach (var emp in employess)
                Console.WriteLine((Employee)emp);


        }
    }
}
