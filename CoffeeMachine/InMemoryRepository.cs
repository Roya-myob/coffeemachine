using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeMachine
{
    public class InMemoryRepository: ISoldDrinkRepository
    {
        private readonly List<IOrder> _soldItems;

        public InMemoryRepository()
        {
            _soldItems =  new List<IOrder>
            {
                new HotOrder("tea", "1", DateTime.Parse("01/01/2021")),
                new HotOrder("tea", "0", DateTime.Parse("02/01/2021")),
                new HotOrder("hot chocolate", "0", DateTime.Parse("02/01/2021")),
                new HotOrder("hot chocolate", "0", DateTime.Parse("02/01/2021")),
                new HotOrder("coffee", "1"),
                new ColdOrder("orange juice"),
                new ColdOrder("orange juice"),
            };
        }
        

        public List<IOrder> GetSoldDrink(DateTime date)
        {
            List<IOrder> items = new List<IOrder>();

            foreach (var order in _soldItems)
            {
                if (order.GetSoldDate()?.ToShortDateString() == date.ToShortDateString())
                {
                    items.Add(order);
                }
            }

            return items;
        }
    }
}