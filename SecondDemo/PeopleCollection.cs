using System.Collections;

namespace SecondDemo
{
    public class PeopleCollection : IEnumerable
    {
        private ArrayList _arrayList1 = new ArrayList();

        public PeopleCollection()
        {

        }

        public IPerson GetPerson(int pos)
        {
            return (IPerson)_arrayList1[pos]; //dalej rzutujemy 
        }

        public void AddItem(IPerson person) // można dodać tylko obiekty implementujące IPerson
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
