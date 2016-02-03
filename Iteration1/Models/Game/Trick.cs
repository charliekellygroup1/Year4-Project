using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Iteration1.Models.Game
{
    public class Trick
    {
        public Trick(string cardUrl, int trickIndex, CardValue cardValue, Suit cardSuit)
        {
            this.TrickCardUrl = cardUrl;
            this.TrickIndex = trickIndex;
            this.CardValue = cardValue;
            this.CardSuit = cardSuit;
        }
        public Trick()
        { }

        public string TrickCardUrl { get; set; }
        public int TrickIndex { get; set; }
        public int ID { get; set; }
        public CardValue CardValue { get; set; }
        public Suit CardSuit { get; set; }


    }
}