using System;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public interface ISoldDrinkRepository
    {

        public List<IOrder> GetSoldDrink(DateTime date);

    }
}