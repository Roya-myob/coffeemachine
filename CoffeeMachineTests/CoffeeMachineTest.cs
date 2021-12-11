using System;
using CoffeeMachine;
using Xunit;

namespace CoffeeMachineTests
{
    public class CoffeeMachineTest
    {
       // #region Iteration One
        [Theory]
        //[InlineData("C","0")]
        [InlineData("T","1")]
        [InlineData("H","2")]
        public void DrinkMaker_Receive_Correct_Instructions_For_Drink_Order(string drink, string sugar)
        {
            CoffeeMachineGame coffeeMachine = new CoffeeMachineGame();
            
            var result= coffeeMachine.VerifyInstruction(new HotOrder(drink, sugar));
            
            // This is wrong. 
            // I have created hotOrder object and then passing hotOrder to itself to check! 
            // I moved the VerifyInstruction to CoffeeMachine as it's a business rule and 
            //CoffeeMachineGame coffeeMachine = new CoffeeMachineGame();
            // HotOrder hotOrder = new HotOrder(drink, sugar);
            // var result = hotOrder.VerifyInstruction(hotOrder);
            
           
           // var result = coffeeMachine.VerifyInstruction(new Order(drink,sugar));
            Assert.Equal(true,result);
        }
        
        
        
        
        [Theory]
        [InlineData("C","3")]
        [InlineData("Z","0")]
        [InlineData("B","1")]
        public void DrinkMaker_Receive_InCorrect_Instructions_For_Drink_Order(string drink, string sugar)
        {
            CoffeeMachineGame coffeeMachine = new CoffeeMachineGame();
            var result = coffeeMachine.VerifyInstruction(new HotOrder(drink,sugar));
            Assert.Equal(false,result);
        }
        
        
        /*[Theory]
        [InlineData("C","1")]
        [InlineData("C","2")]
        public void DrinkMaker_Add_A_Stick_When_Order_Contains_Sugar(string drink, string sugar)
        {
            CoffeeMachineGame coffeeMachine = new CoffeeMachineGame();
            var restul =  coffeeMachine.HasStick((new HotOrder(drink,sugar)));
            Assert.Equal(true, restul);
        }*/
        
        /*
        [Theory]
        [InlineData("C","0")]
        public void DrinkMaker_Not_Add_A_Stick_When_Order_Contains_No_Sugar(string drink, string sugar)
        {
            CoffeeMachineGame coffeeMachine = new CoffeeMachineGame();
            var restul =  coffeeMachine.HasStick((new Order(drink,sugar)));
            Assert.Equal(false, restul);
        }*/
      

        #region Iteration two
        [Theory]
        [InlineData("C","2",0.6, "Coffee", 0.6)]
        [InlineData("T","2",0.6, "Tea", 0.4)]
        [InlineData("H","2",0.6, "Hot Chocolate", 0.5)]
        public void Make_Drink_When_There_is_plenty_of_money(string drink, string sugar, double money, string expectedName, double expectedPrice)
        {
            
           CoffeeMachineGame coffeeMachine = new CoffeeMachineGame();
           
           var madeHotDrink = coffeeMachine.TakeOrder(new HotOrder(drink, sugar), money);
        
           Assert.Equal(madeHotDrink.GetName(), expectedName);
           Assert.Equal(madeHotDrink.GetPrice(), expectedPrice);
           
        }
        
       [Theory]
       [InlineData("C","2",0.2)]
       [InlineData("T","2",0.2)]
       [InlineData("H","2",0.2)]
       public void Dont_Make_Drink_When_There_is_not_enough_money(string drink, string sugar, double money)
       {
           // Arrange or Setup
           CoffeeMachineGame coffeeMachine = new CoffeeMachineGame();
           
           // Assert or Expectation
           Assert.Throws<InvalidMoneyException>( () => coffeeMachine.TakeOrder(new HotOrder(drink, sugar), money));

       }
 
        #endregion
        
        
        
        #region iteration three
        [Theory]
        [InlineData("O", 0.6, "Orange Juice",0.6)]
        public void Make_Orange_Juice_Drink_When_There_is_plenty_of_money(string drink, double money, string expectedName, double expectedPrice)
        {
            
            CoffeeMachineGame coffeeMachine = new CoffeeMachineGame();

            var madeColdDrink = coffeeMachine.TakeOrder(new ColdOrder(drink), money);
            
          
            Assert.Equal(madeColdDrink.GetName(), expectedName);
            Assert.Equal(madeColdDrink.GetPrice(), expectedPrice);
           
        }
        

        #endregion
    }

    
}