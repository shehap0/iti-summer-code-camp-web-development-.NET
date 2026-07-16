namespace Assignment
{
    class Customer
    {
        protected string name;

        public string Name { get { return name; } set { name = value; } }

        public Customer()
        {
            name = "Unknown";
        }
        public Customer(string _name)
        {
            name =_name;
        }

        public virtual double CalculateFinalBill(double amount)
        {
            return amount;
        }
    }
}
