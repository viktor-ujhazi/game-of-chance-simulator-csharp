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
        int Number { get; set; }
    }
}
