using System;

namespace DelegeateFirst
{
    //definiowanie delegatów
    //ten delegat może wskazywać dowolną metode przyjmującą dwie 
    //liczby całkowite i zwracającą liczbe całkowitą 
    public delegate int FirstDelegate(int x, int y);

    //w tyn momęcie kompilator generuje za nas zapieczętowana klase 

    //sealed class FirstDelegate : System.MulticastDelegate
    //{
    //    public FirstDelegate(object target, uint functionAddress);
    //    public int Invoke(int x, int y);
    //    public IAsyncResult BeginInvoke(int x, int y, AsyncCallback cb, object state);
    //    public int EndInvoke(IAsyncResult result);
    //    ....  
    //}

    //najważniejsza jest tutaj metoda "Invoke" ponieważ służy ona do wywoływania każdej metody 
    //przechowywanej przez delegat synchronicznie. Metoda ta nie musi być wywoływana jawnie.

    //Metody BeginInvoke i EndInvoke dają możliwość asynchronicznego wywołania bieżącej metody, 
    //w osobnym wątku

    //inny przykład delegata
    public delegate string MySecondDelegate(out bool x, ref bool y, int c);
    //klasa jaka powstanie wyglada mniej wiecej tak

    //sealed class MySecondDelegate : System.MulticastDelegate
    //{
    //    public FirstDelegate(object target, uint functionAddress);
    //    public string Invoke(out bool x, ref bool y, int c);
    //    public IAsyncResult BeginInvoke(out bool x, ref bool y, int c,
    //                                          AsyncCallback cb, object state);
    //    public string EndInvoke(out bool x, ref bool y, IAsyncResult result);
    //    ....  
    //}

    //interesująca jest równiesz klasa bazowa System.MulticastDelegate oraz jej klasa bazowa Dlegate... 

    //public abstract class MulticastDelegate : Delegate
    //{
    //    to jest chyba najciekawsze w tej klasie
    //    zwraca liste wskazywanych metod  
    //    public sealed override Delegate[] GetInvocationList();
    //}


    //public abstract class Delegate : ICloneable, ISerializable
    //{
    //    //To jest najciekawsze z tej klasy
    //    
    //    //zwraca typ zawierający szczegółowe informacje o metodzie zarządzanej przez delegat
    //    public MethodInfo Method { get; }
    //
    //    //jeżeli metoda jest statyczna to zwraca null, w innym obiekt, który reprezentyje metode w delegacie
    //    public object? Target { get; }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            //utwórz obiekt FirstDelegate, który wskazyje na metode SampleMath.Add
            var firstDelegate = new FirstDelegate(SampleMath.Add); //nie wywołuje metody SampleMath.Add tylko ja przekazuje do konstuktora

            //wywołaj metode add niebezpośrednio tylko używając delegata
            var result = firstDelegate(5, 15); // niejawne wywołanie metody Invoke
            Console.WriteLine("5 + 10 = {0}",result);

            //analiza delegata
            Console.WriteLine("\n *** Analiza Delegata ***\n");
            foreach (var d in firstDelegate.GetInvocationList())
            {
                Console.WriteLine("Nazwa metody {0}", d.Method);
                Console.WriteLine("Nazwa typu {0}", d.Target); // tu bedzie pusta bo metoda Add jest statyczna
            }

            //metoda instancyjna
            var math = new SampleMathVersionTwo();
            var FirstDelegateVersionTwo = new FirstDelegate(math.Subtract);
           
            Console.WriteLine("5 - 10 = {0}", FirstDelegateVersionTwo.Invoke(5, 10)); // dla przykładu jawne wywołanie metody Invoke
                    
            Console.WriteLine("\n*** Druga analiza Delegata ***\n");
            foreach (var d in FirstDelegateVersionTwo.GetInvocationList())
            {
                Console.WriteLine("Nazwa metody {0}", d.Method);
                Console.WriteLine("Nazwa typu {0}", d.Target); // tu juz nie bedzie null
            }
            Console.ReadLine();
        }
    }
}
