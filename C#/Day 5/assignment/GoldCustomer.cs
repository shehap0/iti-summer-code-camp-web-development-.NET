namespace Assignment
{
    class GoldCustomer : Customer
    {
        public GoldCustomer()
        {

        }
        public GoldCustomer(string _name):base(_name)
        {

        }
        public override double CalculateFinalBill(double amount)
        {
            return amount - (amount * 0.30);
        }
    }
}
