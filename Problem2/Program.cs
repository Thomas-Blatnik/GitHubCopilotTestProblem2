using Problem2;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

List<Customer> customers = File.ReadAllLines("C:\\Side Projects\\Copilot\\CopilotTest\\Problem2\\Problem\\problem-input.csv")
                                           .Skip(1)
                                           .Select(v => Customer.FromCsv(v))
                                           .ToList();

foreach (var customer in customers)
{
    customer.NewMonthlyPremium = PremiumCalculator.CalculatePremium(customer, customers);
}


using (var file = File.CreateText("C:\\Side Projects\\Copilot\\CopilotTest\\Problem2\\Problem2\\solution.csv"))
{
    file.WriteLine("CustomerID,NewMonthlyPremium");

    foreach (var customer in customers)
    {
        file.WriteLine($"{customer.CustomerID},{customer.NewMonthlyPremium}");
    }
}


Console.WriteLine("Done Calculating");
Console.ReadLine();

