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
        None = 0, One = 1, Deuce = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace = 14
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
            //default values
            this.PlayerRef = 0;
            this.CardSuit = Suit.Blank;
            this.CardValue = CardValue.None;
            this.ImagePath = "";
            this.CardPlayed = false;
        }

        //Cards are immutable, a cards suit and value remains the same in this game
        public Suit CardSuit { get; set; }
        public CardValue CardValue { get; set; }
        public string ImagePath { get; set; }
        public int ID { get; private set; }
        public int PlayerRef { get; private set; }
        public bool CardPlayed { get; set; }

        public override bool Equals(Object obj)
        {
            Card card = obj as Card;

            if (card == null)
            {
                return false;
            }
            // must match all attributes to be equal
            if ((card.PlayerRef == this.PlayerRef) && (card.ID == this.ID) && (card.CardPlayed == this.CardPlayed) && (card.CardSuit == this.CardSuit) && (card.CardValue == this.CardValue) && (card.ImagePath == this.ImagePath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // needed if overriding Equals
        public override int GetHashCode()
        {
            // return a hash (key) value for this object

            return CardSuit.GetHashCode() + CardValue.GetHashCode() + ImagePath.GetHashCode() + ID.GetHashCode() + PlayerRef.GetHashCode() + CardPlayed.GetHashCode();
        }

        public int getDeuceIndex(List<Card> list)
        {
            int index = 0;
           
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].CardSuit == Suit.Diamonds && list[i].CardValue == CardValue.Deuce)
                    {
                        index = i;
                        break;
                    }
                }
            }
            else
            {
                throw new ArgumentException("Empty list");
            }

            return index;
        }
    }
}