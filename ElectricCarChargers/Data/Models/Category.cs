namespace ElectricCarChargers.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class Category
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(CategoryDescriptionMaxLength)]
        public string? Description { get; set; }

        public IEnumerable<Charger> Chargers { get; init; } = new List<Charger>();

    }
}
