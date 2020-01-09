/*
    - DataEvaluator contains the constructor: DataEvaluator(HistoricalDataSet, ILogger). 
        Note: there can be more constructors which can declare more parameters if required.
    - DataEvaluator contains a public method that evaluates historical data points in order 
        to generate a result object: Result Run(). Note: calling the method uses the data 
        evaluator's state (the data points it was supplied during its construction) to do 
        some calculation in order to be able to create a Result instance. E.g. in a horse race 
        simulator it counts and determines which horse won first place most frequently and what's 
        the percentage of winning when betting on that horse. Important: keep it dead simple, 
        creating a game with convulated logic is not the point.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfChanceSimulator
{
    class DataEvaluator
    {
        private ILogger logger;

        public DataEvaluator(HistoricalDataSet historical, ILogger logger)
        {
            
            Result result=Run(historical.DataPoints);
            logger.Info($"Number of simulations: {result.NumberOfSimulations}");
            logger.Info($"Result: Car to bet on: {result.BestChoice}, chance of winning: {result.BestChoiceChance}%");
        }


        public Result Run(List<HistoricalDataPoint> DataPoints)
        {

            IDictionary<string, int> myDict = new Dictionary<string, int>();

            foreach (HistoricalDataPoint line in DataPoints)
            {
                List<string> temp = new List<string>(line.Ranking.Split(";"));
                for (int i = 0; i < temp.Count; i++)
                {
                    if (myDict.ContainsKey(temp[i]))
                        myDict[temp[i]]++;
                    else
                        myDict.Add(new KeyValuePair<string, int>(temp[i], 1));

                }
            }

            float sum = 0;
            string win_name = "";
            int win_points = 0;
            foreach (KeyValuePair<string, int> key in myDict)
            {
                sum += key.Value;
                if (key.Value > win_points)
                {
                    win_name = key.Key;
                    win_points = key.Value;
                }
            }

            int numberOfSimulations=DataPoints.Count;
            string bestChoice=win_name;
            double bestChoiceChance= Math.Round(win_points / sum * 100, 2);

            Result result = new Result( numberOfSimulations, bestChoice, bestChoiceChance);


            return result;

        }
        
    }
}
