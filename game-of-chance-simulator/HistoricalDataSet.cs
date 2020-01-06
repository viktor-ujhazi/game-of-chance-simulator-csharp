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
        int Size { get; set; }
        int[] MyList;
        private List<HistoricalDataPoint> dataPoints;
        IReadOnlyList<HistoricalDataPoint> DataPoints { get { return dataPoints.AsReadOnly(); } }

        public HistoricalDataSet(ILogger ilog)
        {

        }

        public HistoricalDataSet(int size)
        {
            this.Size = size;
            int[] MyList = new int[size];
        }

        public void Generate()
        {
            var rand = new Random();
            for (int i = 0; i < 6; i++)
                //MyList[i] = rand.Next();
                dataPoints.Add(rand.Next(1, 100));
            dataPoints[i] = rand.Next();

            dataPoints.Add
        }

        public void Load()
        {
            string filename = "history.csv";
        }

    }
}
