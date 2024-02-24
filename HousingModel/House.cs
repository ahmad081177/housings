using System.ComponentModel.DataAnnotations;

namespace HousingModel
{
    public class House
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int Price { get; set; } = 1;
        public string Description { get; set; } = string.Empty;
        [Required]
        public string MainThumbnailBase64 { get; set; }
        public string Thumbnail1Base64 { get; set; }=string.Empty;
        public string Thumbnail2Base64 { get; set; } = string.Empty;
        public string Thumbnail3Base64 { get; set; } = string.Empty;
        public string Thumbnail4Base64 { get; set; } = string.Empty;
        //TODO - Add movies
        [Required]
        public HouseBuildingDetail BuildingDetails { get; set; } = new();
        [Required]
        public HouseLocation Location { get; set; } = new();
    }
    public class HouseLocation
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [Required]
        public string Country { get; set; }=string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
    }
    public class HouseBuildingDetail
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int SquareRoot { get; set; } = 0;
        [Required]
        public int NumOfRooms { get; set; } = 0;
        public int NumOfBathrooms { get; set; } = 0;
        public bool HasSwimmingPool { get; set; } = false;
        public bool IsPrivate { get; set; }=false;
        public int Level { get; set; } = 1;
    }
}