using System;
using System.Collections.Generic;

namespace DelegeateSecond
{
    public class Garage
    {
        private List<Car> _cars;

        public Garage()
        {
            _cars = new List<Car>
            {
                new Car("CarOne",true, true),
                new Car("CarTwo",false, true),
                new Car("CarThree",true, false),
                new Car("CarFour",false, false),
                new Car("CarFive",true, true),
                new Car("CarSix",false, true),
            };
        }

        public void ProcessCar(Car.CarMaintenceDelegate proc)
        {
            Console.WriteLine("Wywołuje: {0}", proc.Method);

            foreach (Car car in _cars)
            {
                Console.WriteLine("Obsługuje samochód: {0}", car.CarName);
                proc(car);
            }
        }
    }
}
