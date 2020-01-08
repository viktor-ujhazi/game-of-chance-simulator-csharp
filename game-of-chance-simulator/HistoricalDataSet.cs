/* 
    - HistoricalDataSet contains the constructor: HistoricalDataSet(ILogger). 
        Note: there can be more constructors which can declare more parameters if required.
    - HistoricalDataSet contains a read-only property to expose the number of the underlying 
        data points: int Size.Note: can be declared as an automatic property.
    - HistoricalDataSet contains a read-only property to expose the underlying list of 
        historical data points: IReadOnlyList<HistoricalDataPoint> DataPoints. 
        Note: can be declared as an automatic property.
    - HistoricalDataSet contains a public method that can generate new data points: 
        void Generate(). Note: calling the method generates a single new(randomized) 
        HistoricalDataPoint instance, it adds this to the list of available DataPoints 
        stored by the class and finally appends a new entry to history.csv.
    - HistoricalDataSet contains a public method that can load already generated historcal 
        data as data points: void Load(). Note: calling the method reads already generated data 
        points from history.csv, it creates an instance of HistoricalDataPoint for each entry in the CSV file.

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfChanceSimulator
{
    class HistoricalDataSet
    {
        private int size;
        int Size { get { return size; } }
        private List<HistoricalDataPoint> dataPoints;
        IReadOnlyList<HistoricalDataPoint> DataPoints { get { return dataPoints.AsReadOnly(); } }

        private ILogger logger;

        public HistoricalDataSet(ILogger logger)
        {
            this.logger = logger;
        }

        public void Generate()
        {
            


            //logger.Info("");
            //var randomString = strings.PickRandom();

        }

        public void Load()
        {
            
            string filename = "history.csv";
            if (System.IO.File.Exists(filename))
            {
                String[] table = System.IO.File.ReadAllLines(filename);
                logger.Info($"Number of simulations: {table.Length}");
                string[] winner = CountWinRatio(filename);
                logger.Info($"Result: {winner[0]} chance of winning: {winner[1]}");
            }
            else
            {
                logger.Error($"{filename} file does not exist.");
            }
            
        }

        public string[] CountWinRatio(string filename)
        {
            String[] table = System.IO.File.ReadAllLines(filename);
            IDictionary<string, int> myDict = new Dictionary<string, int>();

            foreach (string line in table)
            {
                List<string> temp = new List<string>(line.Split(" "));
                for (int i = 0; i < temp.Count; i++)
                {
                    if (temp[i] == "Ranking:")
                    {
                        if (myDict.ContainsKey(temp[i + 1]))
                            myDict[temp[i + 1]]++;
                        else
                            myDict.Add(new KeyValuePair<string, int>(temp[i + 1], 1));
                        break;
                    }
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

            string[] result = {win_name, (win_points/sum *100).ToString()};
            return result;
        }
    }
}
