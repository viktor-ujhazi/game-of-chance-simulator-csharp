/* 
   - Result contains the constructor: Result(int, string, float). 
        Note: there shouldn't be other constructor declared on this class.
   - Result contains a read-only property to expose the number of data points the result
        is based on: int NumberOfSimulations. Note: can be declared as an automatic property.
   - Result contains a read-only property to expose what's the best choice to win in this game: 
        string BestChoice. E.g. the name of the best horse to bet on in a horse race simulator. 
        Note: can be declared as an automatic property.
   - Result contains a read-only property to expose what's the chance of winning when betting on 
        the best choice in this game: float BestChoiceChance. E.g. something like 0.4f 
        (which translates to 40 % - should be a floating point number in range between 0.0f and 1.0f). 
        Note: can be declared as an automatic property.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfChanceSimulator
{
    class Result
    {
        int NumberOfSimulations { get; set; }
        string BestChoice { get; set; }
        float BestChoiceChance { get; set; }
    }
}
