using System;
using System.Collections.Generic;
using System.Text;


namespace GameOfChanceSimulator
{
    class Race
    {
        public List<RaceCar> allracers { get; } = new List<RaceCar>();
        public RaceCar[] racers { get; } = new RaceCar[3];

        
        public Race()
        {
            all();
        }

        public List<RaceCar> all()
        {
            string[] csvRacers = System.IO.File.ReadAllLines("Fantastic_Racers.csv");

            foreach (var item in csvRacers)
            {
                string[] values = item.Split(";");
                
                RaceCar r = new RaceCar(values[0], Int32.Parse(values[1]), Int32.Parse(values[2]), float.Parse(values[3]));
                allracers.Add(r);
            }
            
            return allracers;
        }

        public RaceCar[] chooseRacers(List<RaceCar> allracers)
        {
            Random rnd = new Random();
            int r;
            int[] picked = new int[racers.Length];
            for (int i = 0; i < racers.Length; i++)
            {
                picked[i] = -1;
            }
            for (int i = 0; i < racers.Length; i++)
            {
                bool e;
                do
                {
                    e= false;
                    r = rnd.Next(0, allracers.Count);
                    if (!((IList<int>)picked).Contains(r))
                    {
                        picked[i] = r;
                        e = true;
                    }
                } while (!e);
                
                


                racers[i] = allracers[picked[i]];
            }

            return racers;
        }

        public string winner(RaceCar[] racers)
        {
            string ranking;
            string[] racers1 = new string[3];
            for (int i = 0; i < racers1.Length; i++)
            {
                racers1[i] = racers[i].Name;
            }
            ranking = string.Join(";",racers1);
            

            return ranking;
        }

    }
}
