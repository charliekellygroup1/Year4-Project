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
        Hearts, Diamonds, Spades, Clubs
    }
    public enum CardValue
    {
        Deuce = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace = 14
    }
    public class Card
    {
        public Card(Suit cardSuit, CardValue cardValue, string imagePath)
        {
            this.CardSuit = cardSuit;
            this.CardValue = cardValue;
            this.ImagePath = imagePath;
        }
        //Cards are immutable, a cards suit and value remains the same in this game
        public Suit CardSuit { get; set; }
        public CardValue CardValue { get; set; }
        public string ImagePath { get; set; }
        public int ID { get; private set; }

        public Collection<Card> cards
        {
            get
            {
                return new Collection<Card>(cards);
            }
        }
        public class CardDBContext : DbContext
        {
            public CardDBContext() : base("Default Connection")
            { }

            public DbSet<Card> card { get; set; }
        }
    }
}