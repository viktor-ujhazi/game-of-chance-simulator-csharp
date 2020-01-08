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
        public List<HistoricalDataPoint> DataPoints = new List<HistoricalDataPoint>();
        //IReadOnlyList<HistoricalDataPoint> DataPoints { get { return dataPoints.AsReadOnly(); } }

        private ILogger logger;
        public string filename = "history.csv";

        public HistoricalDataSet(ILogger logger)
        {
            this.logger = logger;
            
        }

        public void Generate()
        {
            HistoricalDataPoint data = new HistoricalDataPoint();
            DataPoints.Add(data);
            
            logger.Info($"Ranking: {data.Ranking}");
            System.IO.File.AppendAllText(filename, data.Ranking);

        }

        public void Load(HistoricalDataSet dataset)
        {
            
            if (System.IO.File.Exists(filename))
            {
                String[] table = System.IO.File.ReadAllLines(filename);
                foreach (string item in table)
                {
                    HistoricalDataPoint data = new HistoricalDataPoint(item);
                    dataset.DataPoints.Add(data);
                }
                //-RESULT
                logger.Info($"Number of simulations: {table.Length}");
                string[] winner = CountWinRatio(DataPoints);
                logger.Info($"Result: {winner[0]} chance of winning: {winner[1]}%");
                
            }
            else
            {
                logger.Error($"{filename} file does not exist.");
            }
            
        }

        public string[] CountWinRatio(List<HistoricalDataPoint> table)
        {
            //String[] table = System.IO.File.ReadAllLines(filename);
            IDictionary<string, int> myDict = new Dictionary<string, int>();

            foreach (HistoricalDataPoint line in table)
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

            string[] result = {win_name, Math.Round(win_points/sum *100, 2).ToString()};
            return result;
        }
    }
}
