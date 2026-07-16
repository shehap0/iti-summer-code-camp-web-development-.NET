namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double orderAmount = 1000;

            Customer[] customers = {
                new Customer("shehap"),
                new SilverCustomer("doma"),
                new GoldCustomer("esawy")
            };

            Console.WriteLine("--- final bills for order amount: 1000 EGP ---");

            for (int i = 0; i < customers.Length; i++)
            {
                string tier = "";
                if (customers[i] is GoldCustomer)
                    tier = "gold";
                else if (customers[i] is SilverCustomer)
                    tier = "silver";
                else
                    tier = "regular";

                Console.WriteLine($"Customer: {customers[i].Name} ({tier}) | To Pay: {customers[i].CalculateFinalBill(orderAmount)} EGP");
            }
        }
    }
}