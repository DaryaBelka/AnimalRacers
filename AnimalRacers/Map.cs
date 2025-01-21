using AnimalGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Random;

namespace AnimalRacers
{
    class Map
    {
        private readonly int width;
        private readonly int height;
        private char[,] grid;
        private Random random = new Random();
        private List<(int X, int Y)> obstacles = new List<(int X, int Y)>();

        public int Width => width; 
        public int Height => height; 

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
            grid = new char[height, width];
            Clear();
        }

        public void PlaceCharacter(Character character)
        {
            foreach (var segment in character.GetBody())
            {
                grid[segment.Y, segment.X] = character.Symbol;
            }
        }

        public void UpdateCharacterPosition(Character character)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (grid[y, x] == character.Symbol)
                    {
                        grid[y, x] = '.';
                    }
                }
            }

            PlaceObstacles();
            PlaceCharacter(character);
        }

        public void PlaceFood(Character character)
        {
            List<(int X, int Y)> freeSpaces = new List<(int X, int Y)>();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (grid[y, x] == '.')
                    {
                        freeSpaces.Add((x, y));
                    }
                }
            }

            if (freeSpaces.Count == 0) return;

            var randomIndex = random.Next(0, freeSpaces.Count);
            var (foodX, foodY) = freeSpaces[randomIndex];

            grid[foodY, foodX] = '@';

        }

        public void PlaceObstacles()
        {
            foreach (var obstacle in obstacles)
            {
                grid[obstacle.Y, obstacle.X] = '#';
            }
        }

        public void PlaceObstacles(int count)
        {
            for (int i = 0; i < count; i++)
            {
                int x, y;
                do
                {
                    x = random.Next(0, width);
                    y = random.Next(0, height);
                } while (grid[y, x] != '.');

                obstacles.Add((x, y));
            }
        }

        public bool IsWithinBounds(int x, int y)
        {
            return x >= 0 && x < width && y >= 0 && y < height;
        }

        public char GetCell(int x, int y)
        {
            return grid[y, x];
        }

        public void SetCell(int x, int y, char value)
        {
            grid[x, y] = value;
        }

        public void Display()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(grid[y, x]);
                }
                Console.WriteLine();
            }
        }

        public void Clear()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    grid[y, x] = '.';
                }
            }
        }
    }
}