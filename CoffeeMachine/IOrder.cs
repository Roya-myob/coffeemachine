using System;

namespace CoffeeMachine
{
    public interface IOrder
    {
       
        public bool HasOrderedSugar();
        public bool HasOrderedDrink();
        public string GetDrink();
        public string GetSugar();

        public DateTime? GetSoldDate();


    }
}