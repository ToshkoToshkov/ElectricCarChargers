namespace ElectricCarChargers.Models.Chargers
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class AddChargerFormModel
    {
        [Required]
        [StringLength(ChargerModelMaxLength, MinimumLength = ChargerModelMinLength, ErrorMessage = "The model name must be between {2} and {1} symbols")]
        public String Model { get; init; }

        [Required]
        [StringLength(ChargerDescriptionMaxLength, MinimumLength = ChargerDescriptionMinLength, ErrorMessage = "The model name must be between {2} and {1} symbols")]
        public string Description { get; init; }

        [Display(Name = "Image URL")]
        [Required]
        [Url]
        public string ImageUrl { get; init; }

        [Range(ChargerPriceMinValue,ChargerPriceMaxValue)]
        public Decimal Price { get; init; }

        [Display(Name ="Category")]
        public int CategoryId { get; init; }

        public IEnumerable<ChargerCategoryViewModel> Categories { get; set; }
    }
}
