namespace ElectricCarChargers.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class Charger
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(ChargerModelMaxLength)]
        public String Model { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Range(ChargerPriceMinValue, ChargerPriceMaxValue)]
        public Decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; init; }

        public IEnumerable<Accesories> Accesories { get; set; } = new List<Accesories>();
    }
}
