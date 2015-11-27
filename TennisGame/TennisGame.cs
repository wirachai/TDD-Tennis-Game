using System;

namespace TennisGame
{
    public class TennisGame
    {
        private const int maxScore = 3;
        private int player1Score;
        private int player2Score;
        
        public TennisGame(int player1Score, int player2Score)
        {
            this.player1Score = player1Score;
            this.player2Score = player2Score;
        }

        public string GetScore()
        {
            if (IsWin())
            {
                return "Win " + GetAdvantagePlayer();
            }

            if (IsAdvantageScore())
            {
                return "Adv " + GetAdvantagePlayer();
            }

            if (IsDeuce())
            {
                return "Deuce";
            }

            string[] scores = { "Love", "Fifteen", "Thirty", "Forty" };
            return scores[player1Score] + "-" + scores[player2Score];
        }

        public void WonPoint(string playerName)
        {
            if (playerName.Equals("player1"))
            {
                player1Score++;
            }
            else
            {
                player2Score++;
            }
        }

        private bool IsAdvantageScore()
        {
            int diffScore = GetDifferenceScore();
            return (player1Score > maxScore || player2Score > maxScore)
                    && diffScore == 1;
        }

        private bool IsWin()
        {
            int diffScore = GetDifferenceScore();
            return (player1Score > maxScore || player2Score > maxScore)
                    && diffScore >= 2;
        }

        private bool IsDeuce()
        {
            int diffScore = GetDifferenceScore();
            return (player1Score >= maxScore && player2Score >= maxScore)
                    && diffScore == 0;
        }

        private string GetAdvantagePlayer()
        {
            return (player1Score > player2Score ? "Player1" : "Player2");
        }

        private int GetDifferenceScore()
        {
            return Math.Abs(player1Score - player2Score);
        }
    }
}