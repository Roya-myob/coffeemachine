
using CoffeeMachine;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;

namespace CoffeeMachineTests
{
    public class ExtractProtocolTest
    {
        [Theory]
        [InlineData("T:1:0", "Drink maker makes 1 tea with 1 sugar and a stick")]
        [InlineData("H::", "Drink maker makes 1 chocolate with no sugar")]
        [InlineData("C:2:0", "Drink maker makes 1 coffee with 2 sugars and a stick")]
        [InlineData("O::", "Drink maker makes 1 orange juice")]
        [InlineData("Hh:1:", "Drink maker makes 1 extra hot chocolate with 1 sugar and a stick")]
        [InlineData("Th:2:0", "Drink maker makes 1 extra hot tea with 2 sugars and a stick")]
        [InlineData("T:2:0", "Drink maker makes 1 tea with 2 sugars and a stick")]
        //[InlineData("M:message-content")]
        public void DrinkMaker_Uses_Protocol_To_Send_Commands_To_DrinkMaker(string stringProtocol, string expected)
        {
            Protocol protocol = new Protocol(stringProtocol);
            var result = protocol.ExtractCommand();
            Assert.Equal(expected, result);
        }
    }
}