using System;

namespace AnimalRacers
{
    internal class Rat : Character
    {
        public override char Symbol => 'R';
        private int speed = 1; 
        private int speedBonusTurns = 0; 

        public override bool Move(ConsoleKey direction, Map map)
        {
            int newX = X, newY = Y;

     
            int step = (speedBonusTurns > 0) ? speed + 1 : speed;

    
            switch (direction)
            {
                case ConsoleKey.W:
                    newY -= step;
                    break;
                case ConsoleKey.S:
                    newY += step;
                    break;
                case ConsoleKey.A:
                    newX -= step;
                    break;
                case ConsoleKey.D:
                    newX += step;
                    break;
            }

            if (!map.IsWithinBounds(newX, newY) || map.GetCell(newX, newY) == '#')
                return false;


            map.SetCell(X, Y, '.');
            X = newX;
            Y = newY;
            map.SetCell(X, Y, Symbol);


            if (speedBonusTurns > 0)
                speedBonusTurns--;

            return true;
        }

        public override void OnEat()
        {
            speedBonusTurns = 3; 
            Console.WriteLine("The rat ate food and gets a speed boost for 3 turns!");
        }
    }
}
