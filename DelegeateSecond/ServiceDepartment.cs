using System;

namespace DelegeateSecond
{
    public class ServiceDepartment
    {
        public void WashCar(Car car)
        {
            if (car.IsDirty)
            {
                Console.WriteLine("Myje ten samochód");
                return;
            }
            Console.WriteLine("Ten samochód jest czysty");



        }

        public void RotateTires(Car car)
        {
            if (car.ShouldByRotate)
            {
                Console.WriteLine("Zmieniam opony");
                return;
            }
            Console.WriteLine("Ten samochód ma opony ok!");
        }
    }
}
