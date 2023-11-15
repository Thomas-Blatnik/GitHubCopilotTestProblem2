using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public class PremiumCalculator
    {
        public static decimal CalculatePremium(Customer customer, List<Customer> allCustomers)
        {
            decimal startingPremium = decimal.Parse(customer.CurrentMonthlyPremiumCents);

            decimal newPremium = GetAddressAdjustment(customer, startingPremium);

            newPremium = GetEduAdjustment(customer, newPremium);

            newPremium = GetFavoriteColorDiscount(customer, newPremium);

            newPremium = GetTDiscount(customer, newPremium);

            newPremium = GetZipAdjustment(customer, newPremium);

            newPremium = GetYearAdjustment(customer, newPremium);

            newPremium = GetUniqueColorPremium(customer, newPremium, allCustomers);

            newPremium = GetNameDiscount(customer, newPremium, allCustomers);

            decimal finalPremium = 0;

            if (newPremium > 0)
            {
                finalPremium = Math.Floor(newPremium);
            }
            else
            {
                finalPremium = Math.Ceiling(newPremium);
            }

            return finalPremium;
        }

        public static decimal GetAddressAdjustment(Customer customer, decimal currentPremium)
        {
            string[] addressParts = customer.AddressLine1.Split(" ");
            int addressNumber = int.Parse(addressParts[0]);

            int adjustment = addressNumber % 2 == 0 ? 700 : 800;

            return currentPremium + adjustment;
        }

        public static decimal GetEduAdjustment(Customer customer, decimal currentPremium)
        {
            decimal newPremium;

            if(customer.Email.EndsWith(".edu"))
            {

                newPremium = currentPremium * Convert.ToDecimal(0.75);

            }
            else
            {
                newPremium = currentPremium + 525;
            }

            return newPremium;
        }

        public static decimal GetFavoriteColorDiscount(Customer customer, decimal currentPremium)
        {
            decimal newPremium = currentPremium;

            if(customer.VehicleColor.ToLower() == customer.FavoriteColor.ToLower())
            {
                newPremium -= Convert.ToDecimal(125);
            }

            return newPremium;
        }

        public static decimal GetTDiscount(Customer customer, decimal currentPremium)
        {
            decimal newPremium = currentPremium;

            if (customer.LastName.ToLower().Contains('t'))
            {
                newPremium -= Convert.ToDecimal(329);
            }

            return newPremium;
        }

        public static decimal GetZipAdjustment(Customer customer, decimal currentPremium)
        {
            string firstTwo = customer.Zip.Substring(0, 2);
            string lastTwo = customer.Zip.Substring(customer.Zip.Length - 2,2);

            decimal newPremium = currentPremium + decimal.Parse(firstTwo);
            newPremium -= (decimal.Parse(lastTwo) * 100);

            return newPremium;
        }

        public static decimal GetYearAdjustment(Customer customer, decimal currentPremium)
        {
            string modelYear = customer.VehicleYear;

            decimal[] digits = modelYear.Select(x => decimal.Parse(x.ToString())).ToArray();

            decimal greatest = digits.Max();

            return currentPremium + (greatest * 100);
        }

        public static decimal GetUniqueColorPremium(Customer customer, decimal currentPremium, List<Customer> allCustomers)
        {
            decimal newPremium = currentPremium;

            int numberWithColor = allCustomers.Where(c => c.VehicleMake == customer.VehicleMake && c.VehicleColor == customer.VehicleColor).Count(); 
        
            if(numberWithColor < 2)
            {
                newPremium *= Convert.ToDecimal(1.5);
            }

            return newPremium;
        }

        public static decimal GetNameDiscount(Customer customer, decimal currentPremium, List<Customer> allCustomers)
        {
            decimal newPremium = currentPremium;

            int numberWithName = allCustomers.Where(c => c.FirstName == customer.FirstName).Count();

            if(numberWithName > 1)
            {
                newPremium *= Convert.ToDecimal(0.5);
            }

            return newPremium;
        }
    }
}
