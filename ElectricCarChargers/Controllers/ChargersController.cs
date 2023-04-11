namespace ElectricCarChargers.Controllers
{
    using ElectricCarChargers.Data;
    using ElectricCarChargers.Data.Models;
    using ElectricCarChargers.Models.Chargers;
    using Microsoft.AspNetCore.Mvc;

    public class ChargersController : Controller
    {
        private readonly ElectricCarChargersDbContext data;

        public ChargersController(ElectricCarChargersDbContext data) 
            => this.data = data;

        public IActionResult Add() => View(new AddChargerFormModel
        {
            Categories = this.GetCategories()
        });

        [HttpPost]
        public IActionResult Add(AddChargerFormModel charger)
        {
            if (!this.data.Categories.Any(c => c.Id == charger.CategoryId))
            {
                this.ModelState.AddModelError(nameof(charger.CategoryId), "Category does not exist!");
            }

            if (!ModelState.IsValid)
            {
                charger.Categories = this.GetCategories();

                return View(charger);
            }

            var chargerData = new Charger
            {
                Model = charger.Model,
                Description = charger.Description,
                ImageUrl = charger.ImageUrl,
                Price = charger.Price,
                CategoryId = charger.CategoryId
            };

            this.data.Chargers.Add(chargerData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        private IEnumerable<ChargerCategoryViewModel> GetCategories()
            => this.data
                .Categories
                .Select(c => new ChargerCategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToList();
    }
}
