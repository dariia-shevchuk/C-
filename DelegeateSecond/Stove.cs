using System;

namespace DelegeateSecond
{
    public class Stove
    {
        //zdefinioanie delegatów
        public delegate void ExploadDelegate(string message);
        public delegate void WorningDelegate(string message);

        private int temp = 20;

        //zmiene składowe każdego delegata
        private ExploadDelegate _exploadDelegate;
        private WorningDelegate _worningDelegate;

        //dodaj metody do delegatów
        public void OnExpload(ExploadDelegate eDelegate)
        {
            _exploadDelegate += eDelegate;
        }

        public void OnWorning(WorningDelegate wDelegate)
        {
            _worningDelegate += wDelegate;
        }

        //usuń składowe od delegata
        public void RemoveExpload(ExploadDelegate eDelegate)
        {
            _exploadDelegate -= eDelegate;
        }

        public void RemoveWorning(WorningDelegate wDelegate)
        {
            _worningDelegate -= wDelegate;
        }

        public void RaiseTemperature()
        {
            temp += 20;
            if (temp > 140)
            {

                _exploadDelegate?.Invoke("W domu przy ulicy... Piec wybuchł!"); //znak zapytania sprawdza czy delegat nie jest null
                return;


            }
            else if (temp > 100) // moment, w którym zacznie ostrzegać o zagrożeniu
            {
                _worningDelegate?.Invoke("Uwaga zbyt wysoka temperatura");
            }
            Console.WriteLine($"Aktualna temperatura {temp} stopni");
        }



    }
}
