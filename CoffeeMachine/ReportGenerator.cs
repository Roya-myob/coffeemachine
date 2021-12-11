using System;
using System.Threading.Channels;

namespace CoffeeMachine
{
    public class ReportGenerator
    {


        private readonly ISoldDrinkRepository _soldDrinkRepository;
        public ReportGenerator(ISoldDrinkRepository soldDrinkRepository)
        {
            _soldDrinkRepository = soldDrinkRepository;
        }
        
        public Report CreateReport(DateTime date)
        {
            var soldItems = _soldDrinkRepository.GetSoldDrink(date);
            return new Report(soldItems, date);

        }
    }
}