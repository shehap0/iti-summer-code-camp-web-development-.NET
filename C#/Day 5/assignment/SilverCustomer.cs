namespace Assignment
{
    class SilverCustomer:Customer
    {
        public SilverCustomer()
        {

        }
        public SilverCustomer(string _name):base(_name)
        {

        }
        public override double CalculateFinalBill(double amount)
        {
            return amount - (amount*0.15);
        }
    }
}
