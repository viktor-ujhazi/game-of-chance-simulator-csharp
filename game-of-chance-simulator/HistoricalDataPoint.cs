/* 
    - HistoricalDataPoint encapsulates all state the describes the input and output for a round of game. 
        E.g. in a horse race simulator it could store the names of the horses that participated in a 
        race and the order that they've finished after the race. Note: a HistoricalDataPoint instance 
        should be mappable to a line in history.csv and vica versa.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfChanceSimulator
{
    class HistoricalDataPoint
    {

        //List<string> racers = new List<string>() ;
        public string racers;
        public string Ranking { get; set; } 

        public HistoricalDataPoint()
        {
            Race race1 = new Race();
            Ranking = race1.winner(race1.racers);
            string[] racer = new string[3];
            for (int i = 0; i < racers.Length; i++)
            {
                racer[i] = race1.racers[i].Name;
            }
            racers = string.Join(";",racer);
        }
        
        
        public HistoricalDataPoint(string ranking)
        {
            Ranking = ranking;

        }
    }
}
