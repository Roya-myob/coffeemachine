namespace CoffeeMachine
{
    public class Drink
    {
        private readonly string _name;
        private readonly double _price;

        public Drink(string name, double price)
        {
            _name = name;
            _price = price;
        }
        
        public string GetName()
        {
            return this._name;
        }

        public double GetPrice()
        {
            return this._price;
        }
    }
}