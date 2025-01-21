namespace AnimalRacers
{
    static class CharacterFactory
    {
        public static Character CreateCharacter(int choice)
        {
            return choice switch
            {
                1 => new Snake { X = 5, Y = 5 },
                2 => new Squirrel { X = 5, Y = 5 },
                3 => new Rat { X = 5, Y = 5 },
                4 => new Wolf { X = 5, Y = 5 },
                5 => new Fox { X = 5, Y = 5 },
                _ => new Snake { X = 5, Y = 5 },
            };
        }

        public static Character CreateCharacter(string animalName)
        {
            return animalName.ToLower() switch
            {
                "snake" => new Snake { X = 5, Y = 5 },
                "squirrel" => new Squirrel { X = 5, Y = 5 },
                "rat" => new Rat { X = 5, Y = 5 },
                "wolf" => new Wolf { X = 5, Y = 5 },
                "fox" => new Fox { X = 5, Y = 5 },
                _ => new Snake { X = 5, Y = 5 },
            };
        }
    }
}
