using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfChanceSimulator
{
    class RaceCar
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public int Acceleration { get; set; }
        public float Reaction { get; set; }

        public RaceCar(string name, int speed, int acceleration, float reaction)
        {
            Name = name;
            Speed = speed;
            Acceleration = acceleration;
            Reaction = reaction;
        }

    }
}
