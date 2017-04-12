using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAttemptLibrary
{
    public class House
    {


        public House(string Price, string Address, string Zip, string Bedrooms, string Bathrooms, string Sqft, string Year, string HOA, string LeaseLengthMonths, string ArePetsAllowed, string FloorNumber, string UnitNumber, string CanBeOwned)

        {
            this.Price = Price;
            this.Address = Address;
            this.Zip = Zip;
            this.Bedrooms = Bedrooms;
            this.Bathrooms = Bathrooms;
            this.Sqft = Sqft;
            this.Year = Year;
            this.HOA = HOA;
            this.LeaseLengthMonths = LeaseLengthMonths;
            this.ArePetsAllowed = ArePetsAllowed;
            this.FloorNumber = FloorNumber;
            this.UnitNumber = UnitNumber;
            this.CanBeOwned = CanBeOwned;

        }
        
        public string Price { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string Bedrooms { get; set; }
        public string Bathrooms { get; set; }
        public string Sqft { get; set; }
        public string Year { get; set; }
        public string HOA { get; set; }
        public string LeaseLengthMonths { get; set; }
        public string ArePetsAllowed { get; set; }
        public string FloorNumber { get; set; }
        public string UnitNumber { get; set; }
        public string CanBeOwned { get; set; }
        


        public bool IsSold { get; set; }
        public void MarkAsSold()
        {
            this.IsSold = true;
        }

        public bool IsLeased { get; set; }
        public void MarkAsLeased()
        {
            this.IsLeased = true;
        }


        public class countItems
        {
            public uint count { get; set; }

        }

    }

}



