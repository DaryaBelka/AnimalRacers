using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AnimalRacers;

namespace AnimalRacersGame.Pages
{
    public class Game : PageModel
    {
        private static AnimalRacers.Game _game; 
        public char?[][] Map { get; private set; } 
        public int Lives => _game?.Lives ?? 0; 
        public string GameOverMessage { get; private set; } 
        public bool IsGameOver { get; private set; } 
        public int MapWidth => Map?.Length > 0 ? Map[0].Length : 0; 


        public void OnGet()
        {
            if (_game == null)
            {
                string selectedAnimal = TempData["SelectedAnimal"]?.ToString() ?? "Snake";

                _game = new AnimalRacers.Game();
                _game.Initialize(selectedAnimal);
            }

            Map = _game.GetMapState();
        }

        public IActionResult OnPost(string action)
        {
            if (_game == null)
            {
                return RedirectToPage("ChooseAnimal");
            }

            ConsoleKey key = action.ToLower() switch
            {
                "up" => ConsoleKey.W,
                "down" => ConsoleKey.S,
                "left" => ConsoleKey.A,
                "right" => ConsoleKey.D,
                _ => throw new ArgumentException($"Invalid action: {action}")
            };

            bool gameContinues = _game.MakeMove(key);

            if (!gameContinues)
            {
                GameOverMessage = "Game Over! You ran out of lives.";
                IsGameOver = true;
                _game = null;
            }
            else
            {
                Map = _game.GetMapState(); 
            }

            return Page();
        }
    }
}
