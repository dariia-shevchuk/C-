// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.Linq;

internal class DataCollection : IEnumerable
{
    private DateTime _startDate;
    private DateTime _endDate;

    public DataCollection(DateTime startDate, DateTime endDate)
    {
        _startDate = startDate;
        _endDate = endDate;
    }

    public IEnumerator GetEnumerator()
    {
        return new DataEnumerator(_startDate, _endDate);
    }
}

public class DataEnumerator : IEnumerator
{
    private DateTime _startDate;
    private DateTime _endDate;
    private DateTime _currentDate;

    public DataEnumerator(DateTime startDate, DateTime endDate)
    {
        _startDate = startDate;
        _endDate = endDate;
        _currentDate = _startDate.AddDays(-1);

        var array = new List<DateTime>();
    }

    public object Current
    {
        get { return _currentDate.ToShortDateString(); }
    }

    public bool MoveNext()
    {
        _currentDate = _currentDate.AddDays(1);
        return _currentDate < _endDate;
    }

    public void Reset()
    {
        _currentDate = _startDate.AddDays(-1);
    }
}