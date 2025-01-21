using System;

namespace AnimalRacers
{
    class Squirrel : Character
    {
        private int jumpBonusTurns = 0; 

        public override char Symbol => 'B';

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

            if (!map.IsWithinBounds(newX, newY))
            {
                Console.WriteLine("The squirrel hit the wall!");
                return false; 
            }

            if (map.GetCell(newX, newY) == '#')
            {
                if (jumpBonusTurns > 0)
                {
                    Console.WriteLine("The squirrel jumps over the obstacle!");
                    jumpBonusTurns--;
 
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


                    if (!map.IsWithinBounds(newX, newY) || map.GetCell(newX, newY) == '#')
                    {
                        Console.WriteLine("The squirrel can't jump further!");
                        return false; 
                    }
                }
                else
                {
                    Console.WriteLine("The squirrel hit an obstacle!");
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
            jumpBonusTurns = 2; 
            Console.WriteLine("The squirrel ate food and can jump over obstacles for 2 turns!");
        }
    }
}
