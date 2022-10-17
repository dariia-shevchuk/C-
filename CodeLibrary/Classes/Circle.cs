using CoreLibrary.Interfaces;
using System;

namespace CoreLibrary.Classes
{
    public class Circle : IShape
    {
        public void DrowMe()
        {
            Console.WriteLine("Rysuje koło w konsoli!");
        }
    }
}
