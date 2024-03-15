using RewardPoints;
using static RewardPointCalculation.RewardModel;



public class Program
{
    public static void Main(string[] args)
    {
        // Sample customer data
        var customers = new List<Customer>()
        {
            new Customer
            {
                Name = "Amandeep Singh",
                Transactions = new List<Transaction>()
                {
                    new Transaction { Date = new DateTime(2023, 12, 01), Amount = 120 },
                    new Transaction { Date = new DateTime(2024, 01, 15), Amount = 180 },
                    new Transaction { Date = new DateTime(2024, 02, 10), Amount = 200 },
                }
            },
            new Customer
            {
                Name = "Mandeep Singh",
                Transactions = new List<Transaction>()
                {
                    new Transaction { Date = new DateTime(2023, 12, 05), Amount = 175 },
                    new Transaction { Date = new DateTime(2024, 01, 20), Amount = 1250 },
                    new Transaction { Date = new DateTime(2024, 02, 05), Amount = 600 },
                }
            },
        };

        // Calculate and print the reward points
        foreach (var customer in customers)
        {
            Console.WriteLine($"Customer: {customer.Name}");
            Console.WriteLine("Monthly Points:");
            var monthlyPoints = RewardCalculator.CalculateMonthlyPoints(customer.Transactions);
            foreach (var month in monthlyPoints)
            {
                Console.WriteLine($"\tMonth {month.Month}: {month.Points}");
            }
            Console.WriteLine($"Total Points: {RewardCalculator.CalculateTotalPoints(customer.Transactions)}");
        }
    }


}

