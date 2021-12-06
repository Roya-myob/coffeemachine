namespace CoffeeMachine
{
    public interface IOrder
    {
        public bool VerifyInstruction(IOrder customerOrder);
        
        public bool HasOrderedSugar();
        public bool HasOrderedDrink();
        public string GetDrink();
        public string GetSugar();



    }
}