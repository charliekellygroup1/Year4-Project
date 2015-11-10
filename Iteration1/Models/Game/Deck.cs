using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Iteration1.Models.Game
{
    public class Deck
    {
        public List<Card> fullDeck;

        public Deck()
        {
            fullDeck = new List<Card>();
        }
        public Collection<Card> cards
        {
            get
            {
                return new Collection<Card>(cards);
            }
        }
        public List<Card> GetFullDeck()
        {
            fullDeck.Add(new Card(Suit.Clubs, CardValue.Deuce, "~/Content/images/Bmp2.bmp"));
            fullDeck.Add(new Card(Suit.Clubs, CardValue.Three, "~/Content/images/Bmp3.bmp"));
            fullDeck.Add(new Card(Suit.Clubs, CardValue.Four, "~/Content/images/Bmp4.bmp"));
            fullDeck.Add(new Card(Suit.Clubs, CardValue.Five, "~/Content/images/Bmp5.bmp"));
            fullDeck.Add(new Card(Suit.Clubs, CardValue.Six, "~/Content/images/Bmp6.bmp"));
            fullDeck.Add(new Card(Suit.Clubs, CardValue.Seven, "~/Content/images/Bmp7.bmp"));
            fullDeck.Add(new Card(Suit.Clubs, CardValue.Eight, "~/Content/images/Bmp8.bmp"));
            fullDeck.Add(new Card(Suit.Clubs, CardValue.Nine, "~/Content/images/Bmp9.bmp"));
            fullDeck.Add(new Card(Suit.Clubs, CardValue.Ten, "~/Content/images/Bmp10.bmp"));
            fullDeck.Add(new Card(Suit.Clubs, CardValue.Jack, "~/Content/images/Bmp11.bmp"));
            fullDeck.Add(new Card(Suit.Clubs, CardValue.Queen, "~/Content/images/Bmp12.bmp"));
            fullDeck.Add(new Card(Suit.Clubs, CardValue.King, "~/Content/images/Bmp13.bmp"));
            fullDeck.Add(new Card(Suit.Clubs, CardValue.Ace, "~/Content/images/Bmp1.bmp"));

            fullDeck.Add(new Card(Suit.Diamonds, CardValue.Deuce, "~/Content/images/Bmp15.bmp"));
            fullDeck.Add(new Card(Suit.Diamonds, CardValue.Three, "~/Content/images/Bmp16.bmp"));
            fullDeck.Add(new Card(Suit.Diamonds, CardValue.Four, "~/Content/images/Bmp17.bmp"));
            fullDeck.Add(new Card(Suit.Diamonds, CardValue.Five, "~/Content/images/Bmp18.bmp"));
            fullDeck.Add(new Card(Suit.Diamonds, CardValue.Six, "~/Content/images/Bmp19.bmp"));
            fullDeck.Add(new Card(Suit.Diamonds, CardValue.Seven, "~/Content/images/Bmp20.bmp"));
            fullDeck.Add(new Card(Suit.Diamonds, CardValue.Eight, "~/Content/images/Bmp21.bmp"));
            fullDeck.Add(new Card(Suit.Diamonds, CardValue.Nine, "~/Content/images/Bmp22.bmp"));
            fullDeck.Add(new Card(Suit.Diamonds, CardValue.Ten, "~/Content/images/Bmp23.bmp"));
            fullDeck.Add(new Card(Suit.Diamonds, CardValue.Jack, "~/Content/images/Bmp24.bmp"));
            fullDeck.Add(new Card(Suit.Diamonds, CardValue.Queen, "~/Content/images/Bmp25.bmp"));
            fullDeck.Add(new Card(Suit.Diamonds, CardValue.King, "~/Content/images/Bmp26.bmp"));
            fullDeck.Add(new Card(Suit.Diamonds, CardValue.Ace, "~/Content/images/Bmp14.bmp"));

            fullDeck.Add(new Card(Suit.Hearts, CardValue.Deuce, "~/Content/images/Bmp28.bmp"));
            fullDeck.Add(new Card(Suit.Hearts, CardValue.Three, "~/Content/images/Bmp29.bmp"));
            fullDeck.Add(new Card(Suit.Hearts, CardValue.Four, "~/Content/images/Bmp30.bmp"));
            fullDeck.Add(new Card(Suit.Hearts, CardValue.Five, "~/Content/images/Bmp31.bmp"));
            fullDeck.Add(new Card(Suit.Hearts, CardValue.Six, "~/Content/images/Bmp32.bmp"));
            fullDeck.Add(new Card(Suit.Hearts, CardValue.Seven, "~/Content/images/Bmp33.bmp"));
            fullDeck.Add(new Card(Suit.Hearts, CardValue.Eight, "~/Content/images/Bmp34.bmp"));
            fullDeck.Add(new Card(Suit.Hearts, CardValue.Nine, "~/Content/images/Bmp35.bmp"));
            fullDeck.Add(new Card(Suit.Hearts, CardValue.Ten, "~/Content/images/Bmp36.bmp"));
            fullDeck.Add(new Card(Suit.Hearts, CardValue.Jack, "~/Content/images/Bmp37.bmp"));
            fullDeck.Add(new Card(Suit.Hearts, CardValue.Queen, "~/Content/images/Bmp38.bmp"));
            fullDeck.Add(new Card(Suit.Hearts, CardValue.King, "~/Content/images/Bmp39.bmp"));
            fullDeck.Add(new Card(Suit.Hearts, CardValue.Ace, "~/Content/images/Bmp27.bmp"));

            fullDeck.Add(new Card(Suit.Spades, CardValue.Deuce, "~/Content/images/Bmp41.bmp"));
            fullDeck.Add(new Card(Suit.Spades, CardValue.Three, "~/Content/images/Bmp42.bmp"));
            fullDeck.Add(new Card(Suit.Spades, CardValue.Four, "~/Content/images/Bmp43.bmp"));
            fullDeck.Add(new Card(Suit.Spades, CardValue.Five, "~/Content/images/Bmp44.bmp"));
            fullDeck.Add(new Card(Suit.Spades, CardValue.Six, "~/Content/images/Bmp45.bmp"));
            fullDeck.Add(new Card(Suit.Spades, CardValue.Seven, "~/Content/images/Bmp46.bmp"));
            fullDeck.Add(new Card(Suit.Spades, CardValue.Eight, "~/Content/images/Bmp47.bmp"));
            fullDeck.Add(new Card(Suit.Spades, CardValue.Nine, "~/Content/images/Bmp48.bmp"));
            fullDeck.Add(new Card(Suit.Spades, CardValue.Ten, "~/Content/images/Bmp49.bmp"));
            fullDeck.Add(new Card(Suit.Spades, CardValue.Jack, "~/Content/images/Bmp50.bmp"));
            fullDeck.Add(new Card(Suit.Spades, CardValue.Queen, "~/Content/images/Bmp51.bmp"));
            fullDeck.Add(new Card(Suit.Spades, CardValue.King, "~/Content/images/Bmp52.bmp"));
            fullDeck.Add(new Card(Suit.Spades, CardValue.Ace, "~/Content/images/Bmp40.bmp"));

            Deck newDeck = new Deck();
            List<Card> shuffledDeck = newDeck.ShuffleCards(fullDeck);

            List<Card> sortedDeck = newDeck.SortHands(shuffledDeck);

            return sortedDeck;
        }

        private List<Card> SortHands(List<Card> shuffledDeck)
        {
            List<Card> sortedHands = new List<Card>();
            List<Card> sortedHand1 = new List<Card>();
            List<Card> sortedHand2 = new List<Card>();
            List<Card> sortedHand3 = new List<Card>();
            List<Card> sortedHand4 = new List<Card>();

            for (int i = 0; i < 13; i++)
            {
                sortedHand1.Add(shuffledDeck[i]);
                sortedHand2.Add(shuffledDeck[i + 13]);
                sortedHand3.Add(shuffledDeck[i + 25]);
                sortedHand4.Add(shuffledDeck[i + 38]);
            }
            var result1 = sortedHand1.OrderByDescending(a => a.CardSuit.ToString()).ThenByDescending(a => a.CardValue);
            foreach (Card c in result1)
            {
                sortedHands.Add(c);
            }
            var result2 = sortedHand2.OrderByDescending(a => a.CardSuit.ToString()).ThenByDescending(a => a.CardValue);
            foreach (Card c in result2)
            {
                sortedHands.Add(c);
            }
            var result3 = sortedHand3.OrderByDescending(a => a.CardSuit.ToString()).ThenByDescending(a => a.CardValue);
            foreach (Card c in result3)
            {
                sortedHands.Add(c);
            }
            var result4 = sortedHand4.OrderByDescending(a => a.CardSuit.ToString()).ThenByDescending(a => a.CardValue);
            foreach (Card c in result4)
            {
                sortedHands.Add(c);
            }
            return sortedHands;
        }

        private List<Card> ShuffleCards(List<Card> unshuffledDeck)
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 51);

            List<Card> shuffledDeck = new List<Card>();
            /*
            The code for shuffling a deck of cards resulting in a random deck of cards was retrieved online 09/11/2015 from
            http://www.c-sharpcorner.com/UploadFile/87b8e4/how-i-use-C-Sharp-net-to-shuffle-a-sequentially-ordered-deck-of-p/
            */
            int stopvar, a, b, c, d;
            for (a = 0; a < 52; a++)
            {
                shuffledDeck.Add(new Card(Suit.Spades, CardValue.Ace, ""));
            }

            b = 0;
            do
            {
                stopvar = 0;
                c = randomNumber;
                d = c - 1;
                do
                {
                    if (shuffledDeck[c].ImagePath == "")
                    {
                        shuffledDeck[c] = unshuffledDeck[b];
                        b++;
                        stopvar = 1;
                    }
                    if (shuffledDeck[d].ImagePath == "" && stopvar == 0)
                    {
                        shuffledDeck[d] = unshuffledDeck[b];
                        b++;
                        stopvar = 1;
                    }
                    c++;
                    d--;
                } while (d >= 0 && c <= 51 && stopvar == 0);
                // generate a random number between 1 and 51.  
                randomNumber = random.Next(1, 51);
                // end the outer loop.  
            } while (b < 52);
            return shuffledDeck;
        }
    }
}
