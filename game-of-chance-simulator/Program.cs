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
            HistoricalDataSet dataSet = GenerateHistoricalDataSet(Int32.Parse(args[1]));

        }
        
        public static HistoricalDataSet GenerateHistoricalDataSet(int input)
        {
            ConsoleLogger logger = new ConsoleLogger();
            HistoricalDataSet dataSet = new HistoricalDataSet(logger);

            if (input > 0)
            {
                logger.Info($"Generating {input} rounds of data.");
                for (int i = 0; i < input; i++)
                {
                    logger.Info("Generating 1 round of data.");
                    dataSet.Generate();
                }
                logger.Info($"Generated {input} rounds of data.");
            }
            else
                return dataSet.Load();
        }
    }
}
