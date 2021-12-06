using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace CoffeeMachine
{
    public class HotOrder :IOrder
    {
        private string _drink;
        private string _sugar;
        private string _stick;
       
        

        public HotOrder(string drink, string sugar)
        {
            _drink = drink;
            _sugar = sugar;
          
            
            if (Int64.Parse(_sugar) > 0)
            {
                UpdateStickField();
            }
        }
        
        
        public string GetDrink()
        {
            return _drink;
        }
        
        public string GetSugar()
        {
            return _sugar;
        }

        private void UpdateStickField()
        {
            _stick = "0";
        }

        public string GetStick()
        {
            return _stick;
        }

        public bool HasOrderedDrink()
        {
            var drink = GetDrink();
            Regex r = new Regex ("T|C|H");
            return  r.IsMatch (drink);
        }

        public bool VerifyInstruction(IOrder customerOrder)
        {
            throw new NotImplementedException();
        }

        public bool HasOrderedSugar()
        {
            var sugar = GetSugar();
            Regex r = new Regex ("1|2");
            return  r.IsMatch (sugar);
        }
        
        
        public bool HasStick()
        {
            if (HasOrderedSugar())
            {
                return true;
            }

            return false;
        }
        
       
        
       
    }
}