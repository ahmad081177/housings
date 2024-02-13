using System.ComponentModel.DataAnnotations;

namespace HousingModel
{
    public class House
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required]
        public int Price { get; set; }

        [Required]
        public string MainThumbnailBase64 { get; set; }
        public string Thumbnail1Base64 { get; set; }=string.Empty;
        public string Thumbnail2Base64 { get; set; } = string.Empty;
        public string Thumbnail3Base64 { get; set; } = string.Empty;
        public string Thumbnail4Base64 { get; set; } = string.Empty;
        //TODO - Add movies
        [Required]
        public HouseBuildingDetail BuildingDetails { get; set; }
        [Required]
        public HouseLocation Location { get; set; }
    }
    public class HouseLocation
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [Required]
        public string Country { get; set; }
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
    }
    public class HouseBuildingDetail
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int SquareRoot { get; set; }
        [Required]
        public int NumOfRooms { get; set; }
        public int NumOfBathrooms { get; set; }
        public bool HasSwimmingPool { get; set; } = false;
        public bool IsPrivate { get; set; }=false;
        public int Level { get; set; }
    }
}