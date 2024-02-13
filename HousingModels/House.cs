using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingModels
{
    public class Address
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Road { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

    }
    public class House
    {
        public int ID { get; set; }
        // Location
        public Address Address { get; set; }

        // Physical Attributes
        public int Area { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int Stories { get; set; }
        public int Age { get; set; }
        public int TotalRooms { get; set; }

        public int Price { get; set; }

        // Amenities
        public bool Basement { get; set; }
        public bool Parking { get; set; }

        // Miscellaneous
        public string Description { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
