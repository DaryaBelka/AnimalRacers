using System;

namespace AnimalRacers
{
    public class Game
    {
        private Map map;
        private Character character;

        public int Lives { get; private set; } = 5; 

        public char?[][] GetMapState()
        {
            var result = new char?[map.Height][];
            for (int y = 0; y < map.Height; y++)
            {
                result[y] = new char?[map.Width];
                for (int x = 0; x < map.Width; x++)
                {
                    char cell = map.GetCell(x, y);
                    result[y][x] = cell == '.' ? null : (char?)cell; 
                }
            }
            return result;
        }

        public void Initialize(string selectedAnimal)
        {
            character = CharacterFactory.CreateCharacter(selectedAnimal);
            map = new Map(10, 10); 
            map.PlaceCharacter(character);
            map.PlaceFood(character); 
            map.PlaceObstacles(10); 
        }

        public bool MakeMove(ConsoleKey key)
        {
            bool success = character.Move(key, map);

            if (!success)
            {
                Lives--;
                if (Lives <= 0)
                {
                    Console.WriteLine("Game over!!!");
                    return false; 
                }
            }

            if (map.GetCell(character.X, character.Y) == '@' )
            {
                map.PlaceFood(character);
                character.OnEat(); 
            }

            if (map.GetCell(character.X, character.Y) == '#')
            {
                Lives--;
                if (Lives <= 0)
                {
                    Console.WriteLine("Game over!!!");
                    return false; 
                }
            }

            map.UpdateCharacterPosition(character);
            return true; 
        }
    }
}