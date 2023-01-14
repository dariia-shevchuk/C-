using System;

namespace DelegateThree
{
    public class Stove
    {
        //zdefinioanie delegatów
        public delegate void ExploadDelegate(string message);
        public delegate void WorningDelegate(string message);

        private int temp = 20;

        //zmiene eventy
        public event ExploadDelegate OnExploaded;
        public event WorningDelegate OnWrninged;

        //tego juz nie potzrebujemy dzieki temu że dodalismy wyżej słówk event
        //public void OnExpload(ExploadDelegate eDelegate)
        //{
        //    _exploadDelegate += eDelegate;
        //}

        //public void OnWorning(WorningDelegate wDelegate)
        //{
        //    _worningDelegate += wDelegate;
        //}

        //public void RemoveExpload(ExploadDelegate eDelegate)
        //{
        //    _exploadDelegate -= eDelegate;
        //}

        //public void RemoveWorning(WorningDelegate wDelegate)
        //{
        //    _worningDelegate -= wDelegate;
        //}

        public void RaiseTemperature()
        {
            temp += 20;
            if (temp > 140)
            {

                OnExploaded?.Invoke("W domu przy ulicy... Piec wybuchł!"); //znak zapytania sprawdza czy delegat nie jest null
                return;


            }
            else if (temp > 100) // moment, w którym zacznie ostrzegać o zagrożeniu
            {
                OnWrninged?.Invoke("Uwaga zbyt wysoka temperatura");
            }
            Console.WriteLine($"Aktualna temperatura {temp} stopni");
        }



    }
}
