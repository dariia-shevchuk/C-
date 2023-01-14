namespace LanguageDemo.View
{
    public class Menu
    {


        public void ShowChangngeDb()
        {
            Console.Clear();
            Console.WriteLine($"--- Zmiana bazy ---");
            Console.WriteLine($"0 - Mongo");
            Console.WriteLine($"1 - Sql");
        }

        public void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine($"--- Menu ---");
            Console.WriteLine($"1 - Zmiana bazy");
            Console.WriteLine("2 - Car");
            Console.WriteLine("3 - Song");
        }

        public void ShowCrud(string title)
        {
            Console.Clear();
            Console.WriteLine($"--- Crud {title} ---");
            Console.WriteLine($"1 - Dodaj");
            Console.WriteLine("2 - Zmień");
            Console.WriteLine("3 - Usuń");
        }
    }
}
