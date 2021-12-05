using System;
using CoffeeMachine;
using Xunit;

namespace CoffeeMachineTests
{
    public class CoffeeMachineTest
    {
        #region Iteration One
        [Theory]
        [InlineData("C","0")]
    //    [InlineData("T","1")]
     //   [InlineData("H","2")]
        public void DrinkMaker_Receive_Correct_Instructions_For_Drink_Order(string drink, string sugar)
        {
            CoffeeMachineGame coffeeMachine = new CoffeeMachineGame();
            var result = coffeeMachine.VerifyInstruction(new Order(drink,sugar));
            Assert.Equal(true,result);
        }
        
        [Theory]
        [InlineData("C","3")]
        [InlineData("Z","0")]
        [InlineData("B","1")]
        public void DrinkMaker_Receive_InCorrect_Instructions_For_Drink_Order(string drink, string sugar)
        {
            CoffeeMachineGame coffeeMachine = new CoffeeMachineGame();
            var result = coffeeMachine.VerifyInstruction(new Order(drink,sugar));
            Assert.Equal(false,result);
        }
        
        
        [Theory]
        [InlineData("C","1")]
        [InlineData("C","2")]
        public void DrinkMaker_Add_A_Stick_When_Order_Contains_Sugar(string drink, string sugar)
        {
            CoffeeMachineGame coffeeMachine = new CoffeeMachineGame();
            var restul =  coffeeMachine.HasStick((new Order(drink,sugar)));
            Assert.Equal(true, restul);
        }
        
        [Theory]
        [InlineData("C","0")]
        public void DrinkMaker_Not_Add_A_Stick_When_Order_Contains_No_Sugar(string drink, string sugar)
        {
            CoffeeMachineGame coffeeMachine = new CoffeeMachineGame();
            var restul =  coffeeMachine.HasStick((new Order(drink,sugar)));
            Assert.Equal(false, restul);
        }
        #endregion

        #region Iteration two
        [Theory]
        [InlineData("C","2",0.6, "Coffee", 0.6)]
        [InlineData("T","2",0.6, "Tea", 0.4)]
        [InlineData("H","2",0.6, "Hot Chocolate", 0.5)]
        public void Make_Drink_When_There_is_plenty_of_money(string drink, string sugar, double money, string expectedName, double expectedPrice)
        {
            // Arrange or Setup
           CoffeeMachineGame coffeeMachine = new CoffeeMachineGame();
           
           // Act or Action
           
           // verifyOrder
           // isMoneyEnough
           
           Drink madeDrink = coffeeMachine.TakeOrder(new Order(drink, sugar), money);
           
           // Assert or Expectation
           Assert.Equal(madeDrink.GetName(), expectedName);
           Assert.Equal(madeDrink.GetPrice(), expectedPrice);
           
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
           Assert.Throws<InvalidMoneyException>( () => coffeeMachine.TakeOrder(new Order(drink, sugar), money));

       }
 
        #endregion
    }
}