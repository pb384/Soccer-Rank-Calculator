using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerRankCalculatorNS
{
    public class SoccerRankCalculator
    {
        public SoccerRankCalculator() { }
        
        /// <summary>
        /// Step 1:
        /// This method converts input file that has one game per line 
        /// into a list i.e., 
        /// every line is a list item
        /// </summary>
        /// <param name="inputFile"></param>
        /// <returns>List of games</returns>
        public List<string> GetGames(string inputFile)
        {
            List<string> gameList = new List<string>();

            try
            {
                String line;

                StreamReader sr = new StreamReader(inputFile);

                line = sr.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);
                    gameList.Add(line); 
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            return gameList;
        }

        /// <summary>
        /// Step 2:
        /// This method compares scores between teams in every game,
        /// generates tournament points based on winning, loosing and tie condition  
        /// and
        /// creates a dictionary that has team names and corresponding tournament points
        /// i.e., 
        /// winning team -  3  points
        /// loosing team - 0  points
        /// tie -  1 point each 
        /// </summary>
        /// <param name="gameList"></param>
        /// <returns>Dictionary with key as Game name and Value  as  tournament points</returns>
        public Dictionary<string, int> CompareScore(List<string> gameList)
        {
            Dictionary<string, int> scores = new Dictionary<string, int>();

            foreach(var game in gameList)
            {
                //divide teams in a game
                var teams = game.Split(',').Select(p => p.Trim()).ToArray();
                
                //parse team 1 name and its score
                int t1idx = teams[0].LastIndexOf(' ');
                var team1Name = teams[0].Substring(0, t1idx);
                var team1Score = Convert.ToInt32(teams[0].Substring(t1idx));

                //parse team 2 name and its score
                int t2idx = teams[1].LastIndexOf(' ');
                var team2Name = teams[1].Substring(0, t2idx);
                var team2Score = Convert.ToInt32(teams[1].Substring(t2idx));
                
                //calculate tourament points based on win, loose  and tie condition
                int team1WinningPoints = 0;
                int team2WinningPoints = 0; 
                if(team1Score > team2Score)
                {
                    //team 1 won
                    team1WinningPoints = 3;
                }
                else if(team1Score < team2Score){
                    //team 2 won
                    team2WinningPoints = 3; 
                }else{
                    //tie condition
                    team1WinningPoints = 1;
                    team2WinningPoints = 1;
                }

                //add to dictionary for entire tournament
                if (!scores.ContainsKey(team1Name))
                {
                    scores[team1Name] = team1WinningPoints;
                }
                else
                {
                    scores[team1Name] += team1WinningPoints;
                }

                if (!scores.ContainsKey(team2Name))
                {
                    scores[team2Name] = team2WinningPoints;
                }
                else
                {
                    scores[team2Name] += team2WinningPoints;
                }
                
            }
            
            return scores;
        }

        /// <summary>
        /// Step 3:
        /// This method sorts the tournament Dictionary that 
        /// has teams with corresponding scores first by 
        /// their score and then by their name alphabetically.
        /// Then generates ranks and  outputs the results
        /// Tied teams will appear in alphabetical order with the same rank.
        /// </summary>
        /// <param name="scores"></param>
        public void CalculateRankings(Dictionary<string, int> scores)
        {
            try
            {
                //using Linq to sort by scores and then by team name alphabetically
                var sortedScores = from score in scores
                                   orderby score.Value descending,
                                        score.Key
                                   select score;

                StreamWriter sw = new StreamWriter("2015-Ranking.txt");

                int currRank = 1;
                int teamsWithCurrRank = 0;
                int prevScore = sortedScores.First().Value;

                foreach (var team in sortedScores)
                {
                    int rank;
                    if (prevScore == team.Value)
                    {
                        //initial condition or tie condition
                        rank = currRank;
                        teamsWithCurrRank += 1;
                    }
                    else
                    {
                        //not a tie condition, hence calculate new rank 
                        prevScore = team.Value;
                        currRank += teamsWithCurrRank;
                        rank = currRank;
                        teamsWithCurrRank = 1;
                    }

                    Console.WriteLine($"{rank}. {team.Key} {team.Value}");
                    sw.WriteLine($"{rank}. {team.Key} {team.Value}");
                }

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputFile"></param>
        public void StartCalculator(string inputFile)
        {
            List<string> gameList = GetGames(inputFile);
            Dictionary<string, int> scores = CompareScore(gameList);
            CalculateRankings(scores);
        }

        /// <summary>
        /// Main method to start with
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                SoccerRankCalculator soccerRankCal = new SoccerRankCalculator() { };
                if (File.Exists(args[0]))
                {
                    soccerRankCal.StartCalculator(args[0]);
                    Console.ReadLine();
                }
            }

        }


    }
}
