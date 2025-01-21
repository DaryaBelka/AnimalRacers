using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRacers
{
    abstract class Character
    {
        public int X { get; set; }
        public int Y { get; set; }
        public abstract char Symbol { get; }
        public abstract bool Move(ConsoleKey direction, Map map);
        public virtual void OnEat() { }

        public virtual List<(int X, int Y)> GetBody()
        {
            return new List<(int X, int Y)> { (X, Y) };
        }
    }
}