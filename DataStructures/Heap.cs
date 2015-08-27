using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingProblems.DataStructures
{
    public class HeapHelper
    {
        //https://www.hackerrank.com/challenges/find-median-1
        public double getAverage()
        {
            short inputs = Convert.ToInt16(Console.ReadLine());
            double avg = 0;
            //two heap data structures

            short input;
            for (int i = 0; i < inputs; i++)
            {
                input = Convert.ToInt16(Console.ReadLine());
                //if size of first heap > size of second heap
                //add input to first heap, else add to second heap
                //get minValue from each heap and write the average to a console.
            }

            return avg;
        }
    }
}
