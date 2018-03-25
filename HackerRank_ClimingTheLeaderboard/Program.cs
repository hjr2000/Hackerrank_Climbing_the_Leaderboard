using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank_ClimingTheLeaderboard
{
    class Program
    {
        static int[] ClimbingLeaderboard(int[] scores, int[] alice)
        {           
            var listOfAliceScoreIndexes = new List<int>();
            int[] uniqueValuesArray = scores.Distinct().ToArray();
            List<int> listOfUniqueValues = uniqueValuesArray.OfType<int>().ToList();

            foreach (int aliceScore in alice)
            {
                listOfAliceScoreIndexes.Add(GetScoreIndex(listOfUniqueValues, aliceScore));
            }

            var arrayOfAliceScoreIndexes = listOfAliceScoreIndexes.ToArray();
            ////////////////////////////////////////////////////////////////////////////////////

            // Find the position of the last score
            // Get last alice score
            var lastAliceScore = alice[alice.Length - 1];

            var scoreStarterIndex = 0;
            var scoreRanking = 1;
            var listOutputRankings = new List<int>();

            for(int scoreIndex = scoreStarterIndex; scoreIndex < scores.Length-1; scoreIndex++)
            {
                // Get score according to index
                var score = scores[scoreIndex];
                if (lastAliceScore > score || lastAliceScore == score)
                {
                    listOutputRankings.Add(scoreRanking);
                    scoreRanking++;
                }
            }


            return arrayOfAliceScoreIndexes;


        }

        private static int GetScoreIndex(List<int> listOfUniqueValues, int aliceScore)
        {             
            listOfUniqueValues.Add(aliceScore);
            var listOfUniqueValueDescending = listOfUniqueValues.OrderByDescending(i => i);
            var uniqueValuesArrayWithAliceScore = listOfUniqueValueDescending.Distinct().ToArray();
            var index = Array.IndexOf(uniqueValuesArrayWithAliceScore, aliceScore);
            return index +1;
        }

        static void Main(string[] args)
        {
            int n = 7; // Convert.ToInt32(Console.ReadLine());
            //string[] scores_temp = Console.ReadLine().Split(' ');
            int[] scores = { 100, 100, 50, 40, 40, 20, 10 };// Array.ConvertAll(scores_temp, Int32.Parse);
            int m = 4; // Convert.ToInt32(Console.ReadLine());
            //string[] alice_temp = Console.ReadLine().Split(' ');
            int[] alice = { 5, 25, 50, 120 };// Array.ConvertAll(alice_temp, Int32.Parse);
            int[] result = ClimbingLeaderboard(scores, alice);
            Console.WriteLine(String.Join("\n", result));
        }
    }
}
