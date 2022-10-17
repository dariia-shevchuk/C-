using CoreLibrary.Interfaces;
using System.Collections;

namespace SecondDemo
{
    public class StringCollection : IEnumerable
    {
        private ArrayList _arrayList1 = new ArrayList();

        public StringCollection()
        {

        }

        public string GetPerson(int pos)
        {
            return (string)_arrayList1[pos]; //dalej rzutujemy 
        }

        public void AddItem(string person) 
        {
            _arrayList1.Add(person);//zapewniam bezpieczeństow typów
        }

        public void ClearPeople()
        {
            _arrayList1.Clear();
        }

        public int Count
        {
            get
            {
                return _arrayList1.Count;
            }
        }

        public IEnumerator GetEnumerator()
        {
            //obsługa wyliczenia foreach
            return _arrayList1.GetEnumerator();
        }
    }
}
