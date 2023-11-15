using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email {  get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip {  get; set; }
        public string FavoriteColor { get; set; }
        public string FavoriteQuote { get; set; }
        public string VehicleVIN { get; set; }
        public string VehicleMake { get; set;}
        public string VehicleModel { get; set; }
        public string VehicleYear { get; set; }
        public string VehicleColor { get; set; }
        public string CurrentMonthlyPremiumCents { get; set; }
        public decimal NewMonthlyPremium {  get; set; }


        public static Customer FromCsv(string csvLine)
        {
            string csvLineNoQuotes = csvLine.Replace("\"", "");
            string[] values = csvLineNoQuotes.Split(',');
            Customer customer = new Customer();
            customer.CustomerID = values[0];
            customer.FirstName = values[1];
            customer.LastName = values[2];
            customer.Email = values[3];
            customer.AddressLine1 = values[4];
            customer.AddressLine2 = values[5];
            customer.City = values[6];
            customer.State = values[7];
            customer.Zip = values[8];
            customer.FavoriteColor = values[9];
            customer.FavoriteQuote = values[10];
            customer.VehicleVIN = values[11];
            customer.VehicleMake = values[12];
            customer.VehicleModel = values[13];
            customer.VehicleYear = values[14];
            customer.VehicleColor = values[15];
            customer.CurrentMonthlyPremiumCents = values[16];

            return customer;
        }
    }
    
}
