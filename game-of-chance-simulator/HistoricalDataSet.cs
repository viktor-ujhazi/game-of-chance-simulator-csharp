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
    }
}
