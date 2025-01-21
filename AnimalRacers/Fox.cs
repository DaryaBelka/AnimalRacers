using System;

namespace AnimalRacers
{
    internal class Fox : Character
    {
        public override char Symbol => 'F';
        private bool hasJumpBonus = false; 

        public override bool Move(ConsoleKey direction, Map map)
        {
            int newX = X, newY = Y;

            int step = hasJumpBonus ? 3 : 1;

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
            {
                return false; 
            }

            map.SetCell(X, Y, '.');

            X = newX;
            Y = newY;

            map.SetCell(X, Y, Symbol);

            if (hasJumpBonus)
            {
                hasJumpBonus = false;
            }

            return true;
        }
        public override void OnEat()
        {
            hasJumpBonus = true; 
            Console.WriteLine("The fox gets a jump boost! It can move 3 cells for the next turn!");
        }
    }
}
