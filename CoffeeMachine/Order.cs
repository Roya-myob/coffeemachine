using System.Linq;

namespace CoffeeMachine
{
    public class Order
    {
        private string _drink;
        private string _sugar;
        private string _stick;
        

        public Order(string drink, string sugar)
        {
            _drink = drink;
            _sugar = sugar;
        }

        public string getDrink()
        {
            return _drink;
        }
        
        public string getSugar()
        {
            return _sugar;
        }

        public void UpdateStickField()
        {
            _stick = "0";
        }

        public string getStick()
        {
            return _stick;
        }
        
        
    }
}