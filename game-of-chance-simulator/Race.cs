using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace GameOfChanceSimulator
{
    class Race
    {
        private static string racersCSV = "Fantastic_Racers.csv";
        public List<RaceCar> allracers { get; } = new List<RaceCar>();
        public RaceCar[] racers { get; } = new RaceCar[3];

        
        public Race()
        {
            chooseRacers(all());
        }

        public List<RaceCar> all()
        {
            if (System.IO.File.Exists(racersCSV))
            {
                string[] csvRacers = System.IO.File.ReadAllLines(racersCSV);

                foreach (var item in csvRacers)
                {
                    string[] values = item.Split(";");

                    RaceCar r = new RaceCar(values[0], Int32.Parse(values[1]), Int32.Parse(values[2]), float.Parse(values[3]));
                    allracers.Add(r);
                }
            }
            else
            {
                throw new FileNotFoundException ("File not found", racersCSV);            }
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
            string ranking="";
            
            Dictionary<string, double> racersPoints = new Dictionary<string, double>();
            List<string> orderedRacersName = new List<string>();
            
            for (int i = 0; i < racers.Length; i++)
            {
                double points = racers[i].Speed * (10 - racers[i].Acceleration) * (10 - racers[i].Reaction);
                string name = racers[i].Name;
                racersPoints.Add(name, points);

            }
            var ordered = racersPoints.OrderBy(x => x.Value);

            foreach (var item in ordered)
            {
                orderedRacersName.Add(item.Key);

            }
            ranking += string.Join(";",orderedRacersName);

            return ranking;
        }

    }
}
