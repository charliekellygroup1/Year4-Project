using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Iteration1.Models
{
    public class Hand
    {
        public Hand (int gameID, int firstCard, int secondCard, int thirdCard, int fourthCard, int trickScore, int winningPlayer)
        {
            this.GameID = gameID;
            this.FirstCard = firstCard;
            this.SecondCard = secondCard;
            this.ThirdCard = thirdCard;
            this.FourthCard = fourthCard;
            this.TrickScore = trickScore;
            this.WinningPlayer = winningPlayer;
        }

        public int FirstCard { get; private set; }
        public int FourthCard { get; private set; }
        public int GameID { get; private set; }
        public int ID { get; private set; }
        public int SecondCard { get; private set; }
        public int ThirdCard { get; private set; }
        public int TrickScore { get; private set; }
        public int WinningPlayer { get; private set; }
    }
}