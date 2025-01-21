using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnimalRacersGame.Pages
{
    public class ChooseAnimalModel : PageModel
    {
        public List<AnimalViewModel> Animals { get; private set; } 

        public ChooseAnimalModel()
        {
            Animals = new List<AnimalViewModel>
            {
                new AnimalViewModel("Snake", "/images/Snake.png"),
                new AnimalViewModel("Squirrel", "/images/Squirrel.png"),
                new AnimalViewModel("Rat", "/images/Rat.png"),
                new AnimalViewModel("Wolf", "/images/Wolf.png"),
                new AnimalViewModel("Fox", "/images/Fox.png")
            };
        }

        public IActionResult OnPost(string animal)
        {
            if (string.IsNullOrEmpty(animal))
            {
                ModelState.AddModelError(string.Empty, "Please select an animal to continue.");
                return Page();
            }

            TempData["SelectedAnimal"] = animal; 
            return RedirectToPage("Game"); 
        }
    }

    public class AnimalViewModel
    {
        public string Name { get; }
        public string ImagePath { get; }

        public AnimalViewModel(string name, string imagePath)
        {
            Name = name;
            ImagePath = imagePath;
        }
    }
}
