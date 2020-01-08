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
            
            try 
            {
                int arg1 = 0;
                int.TryParse(args[1], out arg1);
                logger.Info($"Generating {arg1} rounds of data.");
                for (int i = 0; i < arg1; i++)
                {
                    logger.Info("Generating 1 round of data.");
                    dataSet.Generate();
                }
                logger.Info($"Generated {arg1} rounds of data.");
            }
            catch
            {
                dataSet.Load();
            }
            
                      
            
            return dataSet;
        }
    }
}
