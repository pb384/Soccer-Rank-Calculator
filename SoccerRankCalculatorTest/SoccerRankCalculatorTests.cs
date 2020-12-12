using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoccerRankCalculatorNS;

namespace SoccerRankCalculatorTest
{
    [TestClass]
    public class SoccerRankCalculatorTests
    {
        [TestMethod]
        public void TestGetGames()
        {
            //    var gameList = [
            //    "Lions 3, Snakes 3\n",
            //    "Tarantulas 1, FC Awesome 0\n",
            //    "Lions 1, FC Awesome 1\n",
            //    "Tarantulas 3, Snakes 1\n",
            //    "Lions 4, Grouches 0\n"
            //];

            SoccerRankCalculator src = new SoccerRankCalculator() { };

            var inputFile = "2015-Matches.txt";

            List<string> expected = new List<string>();

            expected.Add("Falcons 3, Snakes 0");
            expected.Add("Diamonds 2, Red Pandas 3");
            expected.Add("Gophers 2, Tigers 2");
            expected.Add("Lions 1, Bears 2");
            expected.Add("Falcons 2, Bears 4");
            expected.Add("Red Pandas 1, Snakes 3");
            expected.Add("Diamonds 3, Gophers 3");
            expected.Add("Tigers 3, Lions 2");

            List<string> actual = src.GetGames(inputFile);

            CollectionAssert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestCompareScore()
        {
            SoccerRankCalculator src = new SoccerRankCalculator() { };

            List<string> input = new List<string>();

            input.Add("Falcons 3, Snakes 0");
            input.Add("Diamonds 2, Red Pandas 3");

            Dictionary<string, int> expected = new Dictionary<string, int>() { };

            expected["Falcons"] = 3;
            expected["Snakes"] = 0;
            expected["Diamonds"] = 3;
            expected["Red Pandas"] = 0;

            Dictionary<string, int> actual = src.CompareScore(input);

            CollectionAssert.AreEqual(expected, actual);

        }
    }


}
