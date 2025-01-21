using System;
using System.Collections.Generic;

namespace AnimalRacers
{
    class Snake : Character
    {
        private List<(int X, int Y)> body = new List<(int X, int Y)> { (5, 5) };

        public Snake()
        {
            X = 5;
            Y = 5;
        }

        public override char Symbol => 'S';

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

            if (!map.IsWithinBounds(newX, newY) || map.GetCell(newX, newY) == '#')
                return false;


            foreach (var segment in body)
            {
                if (segment.X == newX && segment.Y == newY)
                {
                    Console.WriteLine("The snake hit itself! You lose a life.");
                    return false;
                }
            }

            body.Insert(0, (newX, newY));

 
            if (map.GetCell(newX, newY) == '@') 
            {
                OnEat(); 
            }
            else
            {
                var tail = body[^1];
                map.SetCell(tail.X, tail.Y, '.');
                body.RemoveAt(body.Count - 1);
            }

            X = newX;
            Y = newY;

            map.SetCell(newX, newY, Symbol);

            return true;
        }

        public override void OnEat()
        {
            Console.WriteLine("The snake ate food and grew longer!");
        }

        public override List<(int X, int Y)> GetBody()
        {
            return new List<(int X, int Y)>(body);
        }
    }
}
