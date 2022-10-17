using System;
using System.Collections;
//Todo 13.10.2021 od tego zacznę
namespace SecondInterfacesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Tablica Interfejsów ***");
            // możemy tworzyźć tablice interfejsów
            IShape[] arrayOfShapes = new IShape[]
            {
                new Rectangle(),
                new Circle(),
                new Circle(),
                new Circle(),
                new Rectangle(),
                new Rectangle(),
                new Rectangle(),
            };
            // wydaje się, że tylko tablice / kolekcje mogą używać foreach 
            foreach (IShape shape in arrayOfShapes)
                shape.DrowMe();
            //ale czy na pewno
            /**********************************************************************************/
            Console.WriteLine("*** Ciekawe i potrzebne interfejsy ***");
            Console.WriteLine("*** Wyliczenia / IEnumerator , IEnumetable ***");
            // dzięki temu, że nasza klasa dziedziczy po IEnumerable możemy jej użyć w pętli foreach
            ShapeContainer shapeContainer = new ShapeContainer();
            foreach (IShape item in shapeContainer)
            {
                item.DrowMe();
            }
            //to samo możemy zrobić bez pętli foreach
            Console.WriteLine();
            IEnumerator enumerator = shapeContainer.GetEnumerator();
            while (enumerator.MoveNext())
            {
                IShape currentShape = (IShape)enumerator.Current;
                currentShape.DrowMe();
            }

            //tu nastąpi rozmowa o słowie yield (Tłumaczenie)
            //...
            //

            /**********************************************************************************/
            Console.WriteLine("\n*** ICloneable ***\n");
            //przed implementacją interfejsu
            Point pointOne = new Point(15, 15);
            Point pointTwo = pointOne;
            //zmiana X w pointTwo
            pointTwo.X = 300;
            Console.WriteLine(pointOne);
            Console.WriteLine(pointTwo);
            // po implementacji interfejsu ICloneable
            //Point pointThree = new Point(100, 100);
            //Point pointFour = (Point)pointThree.Clone();
            ////zmiana x w punkcie czwartym
            //pointFour.X = 200;
            //Console.WriteLine(pointThree);
            //Console.WriteLine(pointFour);

            //bardziej skomplikowany przykład klonowania

            Device deviceOne = new Device("MyModel", 1, "MyName", new Battery { BateryName = "MySuperBattery", Voltage = 20 });
            Device deviceTwo = (Device)deviceOne.Clone();
            deviceTwo.Battery.Voltage = 60;

            Console.WriteLine(deviceOne);
            Console.WriteLine(deviceTwo);

            //po głębokim klonowaniu

            //Device deviceThree = new Device("MyModel", 1, "MyName", new Battery { BateryName = "MySuperBattery", Voltage = 20 });
            //Device deviceFour = (Device)deviceThree.Clone();
            //deviceFour.Battery.Voltage = 60;
            //Console.WriteLine(deviceThree);
            //Console.WriteLine(deviceFour);
            /**********************************************************************************/
            Console.WriteLine("\n*** IComparable ***\n");
            //Mam klasę reprezentująca pracownika Employee
            //firma zatrudnia wielu pracowników (tablica)
            Employee[] myEmployees = new Employee[]
            {
                new Employee(5, "Jacek", "Placke", 3000),
                new Employee(2, "Marysie", "Placke", 4000),
                new Employee(8, "Ryszard", "Test", 4600),
                new Employee(13, "Witek", "Nazwisko", 2700),
                new Employee(4, "Ania", "Pytalska", 5500),
                new Employee(1, "Jacek", "Podbagiński", 5000),
                new Employee(1, "Piotr", "Adamczyk", 5000),
            };
            //Przed sortowaniem
            foreach (Employee emp in myEmployees)
            {
                Console.WriteLine(emp);
            }
            //W moim programie potrzebuję posortować taką tablicę

            //Array.Sort(myEmployees);

            //w tym przypadku kompilator zwróci nam błąd "At least one object must implement IComparable"
            // komilator nie wie jak ma sortować nasze obiekty
            //no to zaimplementujemy sobie nasz interfejs "IComparable"

            //Array.Sort(myEmployees);
            //Console.WriteLine("\nPosortowana Tablica\n");
            //foreach (Employee emp in myEmployees)
            //{
            //    Console.WriteLine(emp);
            //}


            //Udało nam się posortować naszych pracowników, ale...
            Console.WriteLine("\n*** IComparable ***\n");
            // proacowników sortujemy do tej pory po Id
            // co w przypadku, gdy ten sposób sortowania jest dobry ale
            // czasami potrzebujemy posortować naszych proacowników po nazwisku albo po wynagrodzeniu
            // samej klasy już nie zmieniamy, ponieważ większość naszego programu sortuje po Id i to ma zostać
            //możemy napisać osobną klasę, która będzie dostarczała informacje jak sortować pracowników

            Console.WriteLine("\nSortowanie po nazwisku\n");
            Array.Sort(myEmployees, new LastNameComparer());
            foreach (Employee emp in myEmployees)
            {
                Console.WriteLine(emp);
            }
            Console.WriteLine();

            Console.WriteLine("\nSortowanie po wynagrodzeniu\n");
            Array.Sort(myEmployees, new SalaryComparer());
            foreach (Employee emp in myEmployees)
            {
                Console.WriteLine(emp);
            }

            /**********************************************************************************/
            //Wywołania zwrotne
            Console.WriteLine("\nWywołania zwrotne\n");
            // zakładam, że mam piec centralnego ogrzewania w domu
            // jest to inteligentny piec, który w razie zagrożenia wykona jakąś akcję lub wiele akcji
            // a w przypdaku skrajnej sytuacji wykona inną akcję lub wiele akcji
            Stove stove = new Stove();
            for (int i = 0; i < 10; i++)
            {
                //w pierwszej implementacji piec nie robi nic specjalnego, tylko wyświetla komunikat 
                //w kolejnej implementacji chcę sam mieć możliwośćdecuydowania z zewnątrz, co piec ma robić w tych sytuacjach
                //dlatego dodam do projektu interfejs IStoveNotification                
                stove.RaiseTemperature();
            }

            Stove smsStove = new Stove();
            var smsNotification = new SmsStoveNotification();
            smsStove.Subscribe(smsNotification); // będzie wysyłał sms
            for (int i = 0; i < 10; i++)
            {
                smsStove.RaiseTemperature();
            }
            smsStove.Unsubscribe(smsNotification);

            Stove fullStove = new Stove(); // będzie wysyłał sms oraz email-e
            var emailNotification = new EmailStoveNotification();
            fullStove.Subscribe(smsNotification);
            fullStove.Subscribe(emailNotification);
            for (int i = 0; i < 10; i++)
            {
                fullStove.RaiseTemperature();
            }
            fullStove.Unsubscribe(smsNotification);
            fullStove.Unsubscribe(emailNotification);

        }
    }

    public interface IShape
    {
        void DrowMe();
    }

    public class Rectangle : IShape
    {
        public void DrowMe()
        {
            Console.WriteLine("Rysuje prostokąt");
        }
    }

    public class Circle : IShape
    {
        public void DrowMe()
        {
            Console.WriteLine("Rysuje koło");

        }
    }

    public class ShapeContainer : IEnumerable
    {
        private IShape[] _shapes;

        public ShapeContainer()
        {
            _shapes = new IShape[]
            {
                new Rectangle(),
                new Circle(),
                new Circle(),
                new Circle(),
                new Rectangle(),
                new Rectangle(),
                new Circle(),
                new Circle(),
                new Rectangle(),
            };
        }

        public IEnumerator GetEnumerator()
        {
            //zwraca Ienumerator obiektu tablicy
            return _shapes.GetEnumerator();

            //yield
            // foreach (IShape shape in _shapes)
            //   yield return shape;
        }
    }

    public class Point //: ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point()
        {

        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"X={X}, Y={Y}";
        }

        //public object Clone()
        //{
        //    return new Point(X, Y);
        //}
    }

    public class Device : ICloneable
    {
        public Device(string model, int id, string name, Battery battery)
        {
            Model = model;
            Id = id;
            Name = name;
            Battery = battery;
        }

        public string Model { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public Battery Battery { get; set; }

        public object Clone()
        {
            //Płytkie klonowanie
            Device result = (Device)this.MemberwiseClone();

            //głebokie klonowanie
            //Battery battery = new Battery();
            //battery.BateryName = Battery.BateryName;
            //battery.Voltage = Battery.Voltage;
            //result.Battery = battery;
            return result;
        }

        public override string ToString()
        {
            return $"Device: {Name},ID {Id} Model {Model},{Battery}";
        }
    }

    public class Battery
    {
        public int Voltage { get; set; }
        public string BateryName { get; set; }

        public override string ToString()
        {
            return $"Batery Name {BateryName}, Voltage {Voltage}";
        }
    }

    public class Employee : IComparable
    {
        public Employee(int id, string fristName, string lastName, decimal salary)
        {
            Id = id;
            FristName = fristName;
            LastName = lastName;
            Salary = salary;
        }

        public int Id { get; set; }

        public string FristName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        /// <summary>
        /// nie jawna implementacja (nie wszyscy muszą wiedziec ze mozna sortowac pracowników
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        int IComparable.CompareTo(object obj)
        {
            if (obj is Employee anatherEmployee)
            {
                if (Id > anatherEmployee.Id)
                    return 1;
                if (Id < anatherEmployee.Id)
                    return -1;
                else
                    return 0;

            }
            return -1;
        }

        public override string ToString()
        {
            return $"Id: {Id}, FristName: {FristName}, LastName: {LastName}, Salary: {Salary}";
        }
    }

    public class LastNameComparer : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            if (x is Employee xEmp && y is Employee yEmp)
            {
                return string.Compare(xEmp.LastName, yEmp.LastName);
            }
            return -1;
        }
    }

    public class SalaryComparer : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            if (x is Employee xEmp && y is Employee yEmp)
            {

                if (xEmp.Salary > yEmp.Salary)
                    return 1;
                if (xEmp.Salary < yEmp.Salary)
                    return -1;
                else
                    return 0;

            }
            return -1;
        }
    }

    public class Stove
    {
        private int temp = 20;

        //durga wersja
        private ArrayList Notification = new ArrayList();


        public void RaiseTemperature()
        {
            temp += 20;
            if (temp > 140) // moment, w którym zacznie ostrzegać o zagrożeniu
            {
                //Pierwsza implementacja
                Console.WriteLine("Uwaga temperatura przekroczyła 140 stopni. Piec wybucha");

                //druga wersja
                //foreach (IStoveNotification item in Notification)
                //    item.StoveExploded();

                return;


            }
            else if (temp > 100)
            {
                //Pierwsza implementacja
                Console.WriteLine("Uwaga temperatura przekroczyła 100 stopni. Uwarzaj bo piec wybuchnie");
                //druga wersja
                //foreach (IStoveNotification item in Notification)
                //    item.StoveWorning();

            }
            Console.WriteLine($"Aktualna temperatura {temp} stopni");
        }

        public void Subscribe(IStoveNotification stoveNotification)
        {
            Notification.Add(stoveNotification);
        }

        public void Unsubscribe(IStoveNotification stoveNotification)
        {
            Notification.Remove(stoveNotification);
        }


    }

    public interface IStoveNotification
    {
        /// <summary>
        /// metoda ostrzega o zagrożeniu
        /// </summary>
        void StoveWorning();

        /// <summary>
        /// Gdy piec wybuchnie
        /// </summary>
        void StoveExploded();
    }

    public class SmsStoveNotification : IStoveNotification
    {
        public void StoveWorning()
        {
            Console.WriteLine("Uwaga wysyłam sms do właściciela pieca o zagrożeniu");
        }

        public void StoveExploded()
        {
            Console.WriteLine("Piec wybuchł wysyłam sms do służby ratunkowych!");
        }
    }

    public class EmailStoveNotification : IStoveNotification
    {
        public void StoveWorning()
        {
            Console.WriteLine("Uwaga wysyłam wiadomość elektorniczną do właściciela pieca o zagrożeniu");
        }

        public void StoveExploded()
        {
            Console.WriteLine("Piec wybuchł wysyłam wiadomość elektorniczną do służby ratunkowych!");
        }
    }


}
