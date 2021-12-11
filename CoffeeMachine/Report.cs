using System;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public class Report
    {
        private readonly DateTime _date;
        private readonly List<IOrder> _soldItems;
        public Report(List<IOrder> soldItems, DateTime date)
        {
            _date = date;
            _soldItems = soldItems;
        }

        public DateTime GetDateOfSoldItems()
        {
            return _date;
        }

        public DateTime GetGeneratedDate()
        {
            return new DateTime();
        }
        public List<IOrder> GetSoldItems()
        {
           return _soldItems;
        } 
    }
}