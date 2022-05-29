// See https://aka.ms/new-console-template for more information

var dataCollection = new DataCollection(new DateTime(2019, 2, 1),
    new DateTime(2022, 5, 31));
foreach (var item in dataCollection)
{
    Console.WriteLine(item);
}

//2022-01-01
//2022-01-02
//2022-01-03
//2022-01-04
//...
//2022-01-31
//2022-02-01
//2022-02-02
//2022-02-03
//...
//2022-02-28
//2022-03-01
//...
//2022-03-31
//