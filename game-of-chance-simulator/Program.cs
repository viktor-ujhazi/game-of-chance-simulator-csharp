/*
    - Program contains a static main method: void Main(string[]).
    - Program contains the static method: HistoricalDataSet GenerateHistoricalDataSet(string[]). 
        Note: calling the method generates historical data (as many rounds as the rounds 
        parameter specifies) or if the parameter's value is 0 it loads existing data from a 
        file called history.csv. 
 
 */

using System;
using System.Collections.Generic;

namespace GameOfChanceSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            HistoricalDataSet dataSet = GenerateHistoricalDataSet(args);

        }
        
        public static HistoricalDataSet GenerateHistoricalDataSet(string[] args)
        {
            ConsoleLogger logger = new ConsoleLogger();
            HistoricalDataSet dataSet = new HistoricalDataSet(logger);
            Race race = new Race();

            string str = "";
            for (int i = 0; i < race.allracers.Count; i++)
            {
                if (race.allracers.Count == i + 1)
                    str += race.allracers[i].Name;
                else
                    str += race.allracers[i].Name + ", ";
            }
            logger.Info($"Cars participating: {str}");
            
            try 
            {
                int arg1 = 0;
                int.TryParse(args[0], out arg1);
                logger.Info($"Generating {arg1} rounds of data.");
                for (int i = 0; i < arg1; i++)
                {
                    logger.Info("Generating 1 round of data.");
                    dataSet.Generate();
                }
                logger.Info($"Generated {arg1} rounds of data.");
                
                string[] winner = dataSet.CountWinRatio(dataSet.DataPoints);
                logger.Info($"Result: {winner[0]} chance of winning: {winner[1]}%");
            }
            catch
            {
                dataSet.Load(dataSet);
            }
            
                      
            
            return dataSet;
        }
    }
}
