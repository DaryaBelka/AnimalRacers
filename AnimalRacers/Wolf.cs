using System;

namespace AnimalRacers
{
    internal class Wolf : Character
    {
        public override char Symbol => 'W';
        private int wallPassTurns = 0; 

        public override bool Move(ConsoleKey direction, Map map)
        {
            int newX = X, newY = Y;

            switch (direction)
            {
                case ConsoleKey.W:
                    newY--;
                    break;
                case ConsoleKey.S:
                    newY++;
                    break;
                case ConsoleKey.A:
                    newX--;
                    break;
                case ConsoleKey.D:
                    newX++;
                    break;
            }

  
            newX = (newX < 0) ? map.Width - 1 : (newX >= map.Width) ? 0 : newX;
            newY = (newY < 0) ? map.Height - 1 : (newY >= map.Height) ? 0 : newY;

 
            if (map.GetCell(newX, newY) == '#')
            {
                if (wallPassTurns > 0) 
                {
                    Console.WriteLine("The wolf passes through the wall!");
                    wallPassTurns--;
                }
                else
                {
                    return false; 
                }
            }

            map.SetCell(X, Y, '.');
            X = newX;
            Y = newY;
            map.SetCell(X, Y, Symbol);

            return true;
        }

        public override void OnEat()
        {
            wallPassTurns = 3; 
            Console.WriteLine("The wolf gains the ability to pass through walls for 3 turns!");
        }
    }
}
