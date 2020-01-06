using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfChanceSimulator
{
    class RaceCar
    {
        public string Name { get; set; }
        public int Acceleration { get; set; }
        public int Speed { get; set; }
        public float Reaction { get; set; }

        public RaceCar(string name, int acceleration, int speed, float reaction)
        {
            Name = name;
            Acceleration = acceleration;
            Speed = speed;
            Reaction = reaction;
        }

    }
}
