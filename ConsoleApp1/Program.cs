using ConsoleApp1.DataBase;
using ConsoleApp1.Models;
using LanguageDemo.View;

//------- do dostaje z IoC
var sqlCrud = new SqlCrud();
var mongCrud = new MongoCrud();
var curdProvider = new CrudProviader(sqlCrud, mongCrud);
var menu = new Menu();
var service = new Service(curdProvider);
//-----------------------

while(true)
{
    menu.ShowMainMenu();
    var res = Console.ReadLine();
    switch (res)
    {
        case "1":
            ChangeDB();
            break;
        case "2":
            CrudCar();
            break;
        case "3":
            CrudSong();
            break;
        default:
            break;
    }
}

void CrudSong()
{
    menu.ShowCrud("Song");
    var res = Console.ReadLine();

}

void CrudCar()
{
    menu.ShowCrud("Car");
    var res = Console.ReadLine();
    switch (res)
    {
        case "1":
            var car = new Car { Id = 1, Name = "Test" };
            service.Add(car);
            break;
        default:
            break;
    }

}

void ChangeDB()
{
    menu.ShowChangngeDb();
    var res = Console.ReadLine();
    switch(res)
    {
        case "0":
            curdProvider.SetCurrentCrudOption("Mongo");
            break;
        case "1":
            curdProvider.SetCurrentCrudOption("Sql");
            break;
    }
}