using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace Iteration1.Models.Game
{
    public enum Suit
    {
        Hearts, Diamonds, Spades, Clubs, Blank
    }
    public enum CardValue
    {
        None = 0, One = 0, Deuce = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace = 14
    }
    public class Card
    {
        public Card(int playerRef, Suit cardSuit, CardValue cardValue, string imagePath, bool played)
        {
            this.PlayerRef = playerRef;
            this.CardSuit = cardSuit;
            this.CardValue = cardValue;
            this.ImagePath = imagePath;
            this.CardPlayed = played;
        }

        public Card()
        {
        }

        //Cards are immutable, a cards suit and value remains the same in this game
        public Suit CardSuit { get; set; }
        public CardValue CardValue { get; set; }
        public string ImagePath { get; set; }
        public int ID { get; private set; }
        public int PlayerRef { get; private set; }
        public bool CardPlayed { get; set; }
    }
}