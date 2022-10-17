using System;

namespace FirstInterfacesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //tworzymy obiekt typu Circle
            Circle circle = new Circle();
            //I go rysujemy (wywołujemy wewnątrz funkcje circle.DrowMe())
            Drow(circle);
            //Dodając nowy kształt do aplikacji należy też dodać nową metodę, która go narysuje np.:
            var rec = new Rectangle();
            Drow(rec);
            //i tak dalej za kazdym razem gdy zostanie dodany nowy kształt... :(


            //Rozwiązanie tego problemu 
            //zdefiniowanie interfejsu
            NewCircle newCircle = new NewCircle();
            NewRecatngle newRecatngle = new NewRecatngle();
            //dla wszystkich IShape
            Drow(newCircle);
            Drow(newRecatngle);
            //Problem rozwiązany

            Console.WriteLine("\n*** HIERARCHIA ***\n");
            //Interfejsy mogą po sobie dziedziczyć, np. ISuperShape dziedziczy po IShape
            // w takim przypadku każda klasa, która dziedziczy po ISuperShape jest też IShape
            Hexagon hexagon = new Hexagon();
            //dlatego można go przekazać jako parametr IShape do funkcji 
            Drow(hexagon);

            //ale nie każdy IShape jest ISuperShape

            //!!błąd kompilatora
            //Drow3D(newCircle);

            Drow3D(hexagon);

            Console.WriteLine("\n*** Operator is ***\n");

            //dzięki operatorowi is możemy sprawdzić czy nasz obiekt jest danego typu, np.:
            int a = 7;
            DateTime date = DateTime.Now;
            Console.WriteLine(a is object); //true (Wszystko w C# dziedziczy ostatecznie po object
            Console.WriteLine(date is object); // true
            Console.WriteLine(newCircle is object); //true
            Console.WriteLine("********************************************");
            //Sprawdźmy typ
            ShowInfo(a);
            ShowInfo(date);
            ShowInfo(hexagon);
            ShowInfo(newRecatngle);
            ShowInfo(rec);

            Console.WriteLine("\n*** Interfejs jako typ zwracany  ***\n");
            // funkcja może zwracać interfejs, np.:
            IShape shape = CreateShape(1);
            shape.DrowMe();
            shape = CreateShape(2);
            shape.DrowMe();
            shape = CreateShape(123456789);
            shape.DrowMe();


            Console.WriteLine("\n*** Interfejsy z taką samą sygnaturą metody  ***\n");
            DataSender dataSender = new DataSender();
            //wysyłam dane przez NFC
            dataSender.SendData(new byte[] { 1, 2, 3, 4, 5 });
            (dataSender as ITcp).SendData(new byte[] { 4, 5, 6, 7, 8, 9, 10 });



        }

        //******* złe rozwiązanie 
        public static void Drow(Circle circle)
        {
            circle.DrowMe();
        }

        public static void Drow(Rectangle rectange)
        {
            rectange.DrowMe();
        }
        //************

        //jedna metoda do rysowania wszystkich kstałtów, które implementują IShape
        public static void Drow(IShape shape)
        {
            Console.WriteLine("*** Metoda rysująca wszystkie IShape ***");
            shape.DrowMe();
        }

        //jedna metoda do rysowania w 3D
        public static void Drow3D(ISuperSahpe superSahpe)
        {
            superSahpe.Drow3D();
        }

        public static void ShowInfo(object obj)
        {
            if (obj is ISuperSahpe superShape)
            {
                Console.WriteLine("To jest super kształt, namaluje go");
                superShape.Drow3D();
                Console.WriteLine();

            }
            else if (obj is IShape shape)
            {
                Console.WriteLine("To jest zwykly kształt namaluje go");
                shape.DrowMe();
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("Nie wiem jak to namalować... to jest " + obj.ToString());
                Console.WriteLine();
            }
        }

        public static IShape CreateShape(int value)
        {
            switch (value)
            {
                case 1:
                    return new NewCircle();
                case 2:
                    return new NewRecatngle();
                default:
                    return new Hexagon();

            }
        }
    }

    /// <summary>
    /// Klasa, która nie implementuje żadnej abstrakcji
    /// </summary>
    public class Circle
    {
        /// <summary>
        /// Metoda "rysuje" koło
        /// </summary>
        public void DrowMe()
        {
            Console.WriteLine("Rysuje okrąg");
        }
    }

    /// <summary>
    /// Klasa, która nie implementuje żadnej abstrakcji
    /// </summary>
    public class Rectangle
    {
        /// <summary>
        /// Metoda "rysuje" prostokąt
        /// </summary>
        public void DrowMe()
        {
            Console.WriteLine("Rysuje prostokąt");
        }
    }

    public interface IShape
    {
        //Błędy
        //Interfejsy nie mogą mieć pól
        //public string name;
        //Nie mogą mieć konstruktora
        //public IShape() { name = "test"; }
        //nie zawierają implementacji
        //byte GetName() { return name; }

        void DrowMe();
    }

    public class NewCircle : IShape
    {
        public void DrowMe()
        {
            Console.WriteLine("Rysuje koło");
        }
    }

    public class NewRecatngle : IShape
    {
        public void DrowMe()
        {
            Console.WriteLine("Rysuje prostokąt");
        }
    }

    public interface ISuperSahpe : IShape
    {
        void Drow3D();
    }

    public class Hexagon : ISuperSahpe
    {

        /// <summary>
        /// Metoda z interfejsu ISuperShape
        /// </summary>
        public void Drow3D()
        {
            Console.WriteLine("Rysuje sześciokąt w super 3D");
        }

        /// <summary>
        /// Metoda z interfejsu IShape
        /// </summary>
        public void DrowMe()
        {
            Console.WriteLine("Rysuje sześciokąt");
        }
    }

    public interface INfc
    {
        void SendData(byte[] data);
    }

    public interface ITcp
    {
        void SendData(byte[] data);
    }

    public class DataSender : INfc, ITcp
    {
        /// <summary>
        /// Jawna implementacja metody z interfejsu INfc
        /// </summary>
        /// <param name="data"></param>
        public void SendData(byte[] data)
        {
            Console.WriteLine("Wysyłam dane przez NFC o długości " + data.Length);
        }

        /// <summary>
        /// Niejawna implementacja metody z interfejsu ITcp 
        /// (aby jej użyć musimy rzutować obiekt na ITcp np.za pomocą słowa "as"
        /// </summary>
        /// <param name="data"></param>
        void ITcp.SendData(byte[] data)
        {
            Console.WriteLine("Wysyłam dane przez TCP o długości " + data.Length);
        }
    }
}
