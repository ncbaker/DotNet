using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammingProblems.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> someDictionary = new Dictionary<int, int>();
            
            List<string> friendCourses = new List<string>() { "3", "2", "1", "3", "1", "1" };
            Dictionary<string, int> recs = new Dictionary<string, int>();
            foreach(string course in friendCourses)
                if(recs.Count(c => c.Key == course) == 0)
                    recs.Add(course, 1);
                else 
                    recs[course]++;

            List<KeyValuePair<string, int>> myList = recs.ToList();
            myList.Sort((firstPair,nextPair) =>
            {
                return nextPair.Value.CompareTo(firstPair.Value);
            });
            List<string> recomendations = new List<string>();
            foreach (var i in myList)
                recomendations.Add(i.Key);
        }
    }
}
