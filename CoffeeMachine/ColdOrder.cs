using System.Text.RegularExpressions;

namespace CoffeeMachine
{
    public class ColdOrder : IOrder
    {
        private string _drink;
        
        public ColdOrder(string drink)
        {
            _drink = drink;
        }
        public string GetDrink()
        {
            return _drink;
        }

        public bool HasOrderedSugar()
        {
            throw new System.NotImplementedException();
        }

        public bool HasOrderedDrink()
        {
            var drink = GetDrink();
            Regex r = new Regex ("O");
            return  r.IsMatch (drink);
        }

        public bool VerifyInstruction(IOrder customerOrder)
        {
            throw new System.NotImplementedException();
        }

        public bool HasOrderedSugar(IOrder customerOrder)
        {
            throw new System.NotImplementedException();
        }

        public string GetSugar()
        {
            throw new System.NotImplementedException();
        }
    }
}