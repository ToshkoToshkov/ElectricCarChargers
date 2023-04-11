namespace ElectricCarChargers.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class Accesories
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(AccesoryTypeMaxLength)]
        public string AccesoryType { get; set; }

        [MaxLength(AccesoryDescriptionMaxLength)]
        public string Description { get; set; }

        public int ChargerId { get; set; }

        public Charger Charger { get; init; }

    }
}
