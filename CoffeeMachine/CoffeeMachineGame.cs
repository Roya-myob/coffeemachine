using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Transactions;

namespace CoffeeMachine
{
    public class CoffeeMachineGame
    {

        
        private Drink ConvertOrderToDrink(IOrder customerOrder)
        {
            double price = 0.0;
            string name = "";
            
            var drink = customerOrder.GetDrink();
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
            if (drink == "O")
            {
                price = 0.6;
                name = "Orange Juice";
            }

            return new Drink(name, price);
        }
        public bool VerifyInstruction(IOrder customerOrder)
        {
            if (customerOrder.HasOrderedDrink() && customerOrder.HasOrderedSugar())
            {
                return true;
            }

            return false;
        }

       
        
        
        
        public bool VerifyAmountIsPaid(IOrder customerOrder, double price, double amount)
        {
            if (amount >= price)
            {
                return true;
            }

            return false;
        }
        

        public Drink TakeOrder(IOrder customerOrder, double money)
        {
            Drink Drink = this.ConvertOrderToDrink(customerOrder);
            
            if (money < Drink.GetPrice())
            {
                throw new InvalidMoneyException("Not Enough Money");
            }

            return Drink;
        }
        
    }

    public class InvalidMoneyException : Exception
    {
        public InvalidMoneyException(string msg): base(msg)
        {
        }
    }
    
    
    
}
