using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Transactions;

namespace CoffeeMachine
{
    public class CoffeeMachineGame
    {
        private Order _customerOrder;

        public bool VerifyInstruction(Order customerOrder)
        {
            if (HasOrderedDrink(customerOrder) && HasOrderedSugar(customerOrder))
            {
                return true;
            }

            return false;
        }

       

        public bool HasOrderedDrink(Order customerOrder)
        {
            var drink = customerOrder.getDrink();
            Regex r = new Regex ("T|C|H");
            return  r.IsMatch (drink);
        }
        
        
        
        public bool HasOrderedSugar(Order customerOrder)
        {
            var sugar = customerOrder.getSugar();
            Regex r = new Regex ("1|2");
            return  r.IsMatch (sugar);
        }
       

        public Order AddStick(Order customerOrder)
        {
            if (HasOrderedSugar(customerOrder))
            {
                customerOrder.UpdateStickField();
               
            }
            return customerOrder;
        }

        public bool HasStick(Order customerOrder)
        {
            if (HasOrderedSugar(customerOrder))
            {
                return true;
            }

            return false;
        }

        private Drink ConvertOrderToDrink(Order customerOrder)
        {
            double price = 0.0;
            string name = "";
            
            var drink = customerOrder.getDrink();
            if (drink == "C")
            {
                price = 0.6;
                name = "Coffee";
            }
            if (drink == "T")
            {
                price = 0.4;
                name = "Tea";
            }
            if (drink == "H")
            {
                price = 0.5;
                name = "Hot Chocolate";
            }

            return new Drink(name, price);
        }
        
        public bool VerifyAmountIsPaid(Order customerOrder, double price, double amount)
        {
            if (amount >= price)
            {
                return true;
            }

            return false;
        }



        public Drink TakeOrder(Order order, double money)
        {
            Drink drink = this.ConvertOrderToDrink(order);
            
            if (money < drink.GetPrice())
            {
                throw new InvalidMoneyException("Not Enough Money");
            }

            return drink;
        }
        
    }

    public class InvalidMoneyException : Exception
    {
        public InvalidMoneyException(string msg): base(msg)
        {
        }
    }
    
}
