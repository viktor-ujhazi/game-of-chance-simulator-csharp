/*
    - Program contains a static main method: void Main(string[]).
    - Program contains the static method: HistoricalDataSet GenerateHistoricalDataSet(string[]). 
        Note: calling the method generates historical data (as many rounds as the rounds 
        parameter specifies) or if the parameter's value is 0 it loads existing data from a 
        file called history.csv. 
 
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace GameOfChanceSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            HistoricalDataSet dataSet = GenerateHistoricalDataSet(args);
            new DataEvaluator(dataSet, new ConsoleLogger());
        }
        
        public static HistoricalDataSet GenerateHistoricalDataSet(string[] args)
        {
            ConsoleLogger logger = new ConsoleLogger();
            HistoricalDataSet dataSet = new HistoricalDataSet(logger);
            try
            {
                Race race = new Race();
                int arg1 = 0;
                string str = "";
                for (int i = 0; i < race.allracers.Count; i++)
                {
                    if (race.allracers.Count == i + 1)
                        str += race.allracers[i].Name;
                    else
                        str += race.allracers[i].Name + ", ";
                }

                if (args.Length > 0 && int.TryParse(args[0], out arg1))
                {
                    logger.Info($"Cars participating: {str}");
                    logger.Info($"Generating {arg1} rounds of data.");
                    for (int i = 0; i < arg1; i++)
                    {
                        logger.Info("Generating 1 round of data.");
                        dataSet.Generate();
                    }
                    logger.Info($"Generated {arg1} rounds of data.");

                }
                else
                {
                    dataSet.Load(dataSet);
                }
            }
            catch (FileNotFoundException e)
            {
                
                logger.Error($"{e.Message}:  {e.FileName}");
                System.Environment.Exit(0);
            }
            
            return dataSet;
        }
    }
}
