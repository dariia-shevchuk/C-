using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateThree
{
    class Program
    {
        // w przykładzie z piecem w którym zastąpiliśmy interfejsy delegatami 
        // musieliśmy dodać funkcje, które pozwalają nam dodawać i usuwać metody do delegatów
        // w C# dodano "składniowy cókierek" który moze to zrobić za nas
        // tak zwany event
        // teraz przeróbmy przykład z delegatami na przykład z eventami
        static void Main(string[] args)
        {
            var runner = new TestRunner(new List<Test>
            {
                new Test("Test 1", true),
                new Test("Test 2", true),
                new Test("Test 3", false),
                new Test("Test 4", true),
                new Test("Test 5", false),
                new Test("Test 6", true),
                new Test("Test 7", true),
                new Test("Test 8", false),
                new Test("Test 9", true),
                new Test("Test 10", false),
            });

            foreach (var item in runner.Tests)
            {
                item.OnTestStateEventHandler += Item_OnTestStateEventHandler;
            }

            var isEnd = false;
            runner.RunnTest()
                .ContinueWith((t) => isEnd = true);

            while(!isEnd)
            {
                Thread.Sleep(200);
                Console.Write(" > ");
            }

            Console.WriteLine("Koniec czekania");
            foreach (var test in runner.Tests)
            {
                Console.WriteLine($"Test {test.TestName} status: {test.State}");
            }
            Console.WriteLine();




            //var warningDelegate = new Stove.WorningDelegate(SendSmsToOwner);
            //var explodedDelegate = new Stove.ExploadDelegate(SendSmsToEmergency);

            //var stove = new Stove();

            ////zamiast wywoływać metode przypisująca delegatom zachowania 
            ////dzieki słówku event mozemy poprostu przypisywac te delegaty bezpośrednio

            //stove.OnExploaded += explodedDelegate;
            //stove.OnWrninged += warningDelegate;

            ////kolejny skladniowe uproszczenie 
            ////skoro wiem ze delegat moze wskazywać na metode która zwraca void i przyjmuje string 
            ////to moge przesłać bezpośrednio taka metode nie musze najpierw tworzyć delegata wskazującego na tą metode
            //var emailNotification = new EmailNotification();
            //stove.OnExploaded += emailNotification.SendEmailToEmergency;
            //stove.OnWrninged += emailNotification.SendEmailToOwner;


            //for (int i = 0; i < 7; i++)
            //{
            //    stove.RaiseTemperature();
            //}


            ////sprzątamy po sobie
            //stove.OnExploaded -= explodedDelegate;
            //stove.OnWrninged -= warningDelegate;
            //stove.OnExploaded -= emailNotification.SendEmailToEmergency;
            //stove.OnWrninged -= emailNotification.SendEmailToOwner;

            Console.WriteLine("\n*** Zdarzenia formalnie wzorcowe ***\n");
            // Microsoft wprowadza zalecany wzożec dla zdażeń nasz poprzedni przykład nie był z nim zgodny ale ja zalecam jego stosowanie
            // chodzi o to zeby zdażenia przyjmowały metody zgodne z takim wcorcem 
            // void NazwaMetody(object sender, TuKlasaDzieciczącaPoEventArgs arg)
            // jak bedziecie badali kod żródłowy to zobaczycie że wszystkie zdażenia w sa pisane w takim wzorcu np
            //sprawdzmy klase System.ComponentModel.BackgroundWorker
            //posiada one trzy zdażenia 
            //public event DoWorkEventHandler? DoWork;
            //public event ProgressChangedEventHandler? ProgressChanged;
            //public event RunWorkerCompletedEventHandler? RunWorkerCompleted;
            //kazde jest wzorcowo poprawne naprzykład DoWorkEventHandler wygląda następująco 
            //public delegate void DoWorkEventHandler(object? sender, DoWorkEventArgs e); 
            //gdzie DoWorkEventArgs to klas która dziedziczy po EventArgs
            //ok, teraz my napiszmy składniowo wzorcowe zdarzenie
            //Utwórzmy sobie pracownika który bedzie mial zdarzenie zmiany wieku
            //Tworze sobie kolekcje ludzi
            var peaple = new List<Person>
            {
                new Person("Jacek", 17),
                new Person("Ala", 23),
                new Person("Franek", 73),
                new Person("Iza", 35)
            };


            //jestem zainteresowany zmianą wieku każdego
            foreach (var person in peaple)
            {
                person.AgeChangedEventHandler += Person_AgeChangedEventHandler;
            }

            var lifeClass = new LifeClass(peaple);
            Console.WriteLine("Zaczynamy");
            lifeClass.BeginLife();
            Console.WriteLine("Na koniec sprzątam");
            foreach (var person in peaple)
            {
                person.AgeChangedEventHandler -= Person_AgeChangedEventHandler;
            }

            //elegancki wzorcowe zdarzenie ale 
            //zeby nie bylo to jest jeszcze cos :)
            //Generyczny degat EventHandler<T> gdzie T to klasa dziedzicząca po EventArg
            //no to kolejny przykład napiszmy klase PersoneTwo która bedzie robiłą to samo co poprzednia tylo z generycznym delegatem

            Console.WriteLine("\n *** Przykłąd generyczny *** \n");

            var peapleTwo = new List<PersonTwo>
            {
                new PersonTwo("Jacek Two", 17),
                new PersonTwo("Ala Two", 23),
                new PersonTwo("Franek Two", 73),
                new PersonTwo("Iza Two", 35)
            };

            //jestem zainteresowany zmianą wieku każdego
            foreach (var person in peapleTwo)
            {
                person.AgeChangedEventHandler += Person_AgeChangedEventHandler;
            }

            var lifeClassTwo = new LifeClassTwo(peapleTwo);
            Console.WriteLine("Zaczynamy");
            lifeClassTwo.BeginLife();
            Console.WriteLine("Na koniec sprzątam");
            foreach (var person in peapleTwo)
            {
                person.AgeChangedEventHandler -= Person_AgeChangedEventHandler;
            }
        }

        private static void Item_OnTestStateEventHandler(object sender, TestStateChangedEventArg arg)
        {
            if(arg.NewState == TestState.Faild && sender is Test test)
            {
                Console.WriteLine("Ojojoj {0} ma status {1}", test.TestName, arg.NewState);
            }
        }



        private static void Person_AgeChangedEventHandler(object sender, AgeChangedEventArg ageChangedEventArg)
        {
            if(sender is Person person)
            {
                Console.WriteLine($"Hura {person.Name} miał {ageChangedEventArg.OldAge} lat ale od teraz ma {ageChangedEventArg.NewAge} trzeba swiętować");
                ageChangedEventArg.NewAge = 1888;
        }

            ////to jest tylko przykład i to jest bardzo brzydkie chodzi tylko o DelegatGeneryczny
            //if(sender is PersonTwo personTwo)
            //{
            //    Console.WriteLine($"Hura {personTwo.Name} miał {ageChangedEventArg.OldAge} lat ale od teraz ma {ageChangedEventArg.NewAge} trzeba swiętować");

            //}
        }

        public static void SendSmsToOwner(string msg)
        {
            Console.WriteLine("Wysyłam sms do włściciela o treści: {0}", msg);
        }

        public static void SendSmsToEmergency(string msg)
        {
            Console.WriteLine("Wysyłam sms do szpitala o treści: {0}", msg);
        }
    }

    public class TestRunner
    {
        public TestRunner(IEnumerable<Test> tests)
        {
            Tests = tests;
        }

        public IEnumerable<Test> Tests { get; }

        public Task RunnTest()
        {
            return Task.Run(() =>
            {
                foreach (var test in Tests)
                {
                    test.RunTest();
                }
            });
        }
    }

    public class TestStateChangedEventArg : EventArgs
    {
        public TestStateChangedEventArg(TestState oldState, TestState newState)
        {
            OldState = oldState;
            NewState = newState;
        }

        public TestState OldState { get; }
        public TestState NewState { get; }
    }

    public class Test
    {
        public delegate void TestStateChangedDelegate(object? sender, 
            TestStateChangedEventArg arg);
        public event TestStateChangedDelegate OnTestStateEventHandler;



        public Test(string testName, bool endWithSuccess)
        {
            TestName = testName;
            _endWithSuccess = endWithSuccess;
        }

        private bool _endWithSuccess;
        private TestState _state;

        public string TestName { get;  }
        public TestState State 
        {  
            get => _state;
            private set
            {
                if (value == _state) return;
                var oldState = _state;
                _state = value;
                OnTestStateEventHandler?.Invoke(this, new TestStateChangedEventArg(oldState, _state));
            }
        } 

        public void RunTest()
        {
            Console.WriteLine($"Test {TestName} uruchomiony");
            State = TestState.Running;

            Thread.Sleep(2000);

            if (_endWithSuccess)
            {
                State = TestState.Success;
                return;
            }
            State = TestState.Faild;


        }
        
    }

    public enum TestState
    {
        Waiting,
        Running,
        Success,
        Faild        
    }
}
