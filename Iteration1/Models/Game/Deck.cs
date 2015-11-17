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
            fullDeck.Add(new Card(100, Suit.Clubs, CardValue.Deuce, "~/Content/images/Bmp2.bmp", false));
            fullDeck.Add(new Card(101, Suit.Clubs, CardValue.Three, "~/Content/images/Bmp3.bmp", false));
            fullDeck.Add(new Card(102, Suit.Clubs, CardValue.Four, "~/Content/images/Bmp4.bmp", false));
            fullDeck.Add(new Card(103, Suit.Clubs, CardValue.Five, "~/Content/images/Bmp5.bmp", false));
            fullDeck.Add(new Card(104, Suit.Clubs, CardValue.Six, "~/Content/images/Bmp6.bmp", false));
            fullDeck.Add(new Card(105, Suit.Clubs, CardValue.Seven, "~/Content/images/Bmp7.bmp", false));
            fullDeck.Add(new Card(106, Suit.Clubs, CardValue.Eight, "~/Content/images/Bmp8.bmp", false));
            fullDeck.Add(new Card(107, Suit.Clubs, CardValue.Nine, "~/Content/images/Bmp9.bmp", false));
            fullDeck.Add(new Card(108, Suit.Clubs, CardValue.Ten, "~/Content/images/Bmp10.bmp", false));
            fullDeck.Add(new Card(109, Suit.Clubs, CardValue.Jack, "~/Content/images/Bmp11.bmp", false));
            fullDeck.Add(new Card(110, Suit.Clubs, CardValue.Queen, "~/Content/images/Bmp12.bmp", false));
            fullDeck.Add(new Card(111, Suit.Clubs, CardValue.King, "~/Content/images/Bmp13.bmp", false));
            fullDeck.Add(new Card(112, Suit.Clubs, CardValue.Ace, "~/Content/images/Bmp1.bmp", false));

            fullDeck.Add(new Card(200, Suit.Diamonds, CardValue.Deuce, "~/Content/images/Bmp15.bmp", false));
            fullDeck.Add(new Card(201, Suit.Diamonds, CardValue.Three, "~/Content/images/Bmp16.bmp", false));
            fullDeck.Add(new Card(202, Suit.Diamonds, CardValue.Four, "~/Content/images/Bmp17.bmp", false));
            fullDeck.Add(new Card(203, Suit.Diamonds, CardValue.Five, "~/Content/images/Bmp18.bmp", false));
            fullDeck.Add(new Card(204, Suit.Diamonds, CardValue.Six, "~/Content/images/Bmp19.bmp", false));
            fullDeck.Add(new Card(205, Suit.Diamonds, CardValue.Seven, "~/Content/images/Bmp20.bmp", false));
            fullDeck.Add(new Card(206, Suit.Diamonds, CardValue.Eight, "~/Content/images/Bmp21.bmp", false));
            fullDeck.Add(new Card(207, Suit.Diamonds, CardValue.Nine, "~/Content/images/Bmp22.bmp", false));
            fullDeck.Add(new Card(208, Suit.Diamonds, CardValue.Ten, "~/Content/images/Bmp23.bmp", false));
            fullDeck.Add(new Card(209, Suit.Diamonds, CardValue.Jack, "~/Content/images/Bmp24.bmp", false));
            fullDeck.Add(new Card(210, Suit.Diamonds, CardValue.Queen, "~/Content/images/Bmp25.bmp", false));
            fullDeck.Add(new Card(211, Suit.Diamonds, CardValue.King, "~/Content/images/Bmp26.bmp", false));
            fullDeck.Add(new Card(212, Suit.Diamonds, CardValue.Ace, "~/Content/images/Bmp14.bmp", false));

            fullDeck.Add(new Card(300, Suit.Hearts, CardValue.Deuce, "~/Content/images/Bmp28.bmp", false));
            fullDeck.Add(new Card(301, Suit.Hearts, CardValue.Three, "~/Content/images/Bmp29.bmp", false));
            fullDeck.Add(new Card(302, Suit.Hearts, CardValue.Four, "~/Content/images/Bmp30.bmp", false));
            fullDeck.Add(new Card(303, Suit.Hearts, CardValue.Five, "~/Content/images/Bmp31.bmp", false));
            fullDeck.Add(new Card(304, Suit.Hearts, CardValue.Six, "~/Content/images/Bmp32.bmp", false));
            fullDeck.Add(new Card(305, Suit.Hearts, CardValue.Seven, "~/Content/images/Bmp33.bmp", false));
            fullDeck.Add(new Card(306, Suit.Hearts, CardValue.Eight, "~/Content/images/Bmp34.bmp", false));
            fullDeck.Add(new Card(307, Suit.Hearts, CardValue.Nine, "~/Content/images/Bmp35.bmp", false));
            fullDeck.Add(new Card(308, Suit.Hearts, CardValue.Ten, "~/Content/images/Bmp36.bmp", false));
            fullDeck.Add(new Card(309, Suit.Hearts, CardValue.Jack, "~/Content/images/Bmp37.bmp", false));
            fullDeck.Add(new Card(310, Suit.Hearts, CardValue.Queen, "~/Content/images/Bmp38.bmp", false));
            fullDeck.Add(new Card(311, Suit.Hearts, CardValue.King, "~/Content/images/Bmp39.bmp", false));
            fullDeck.Add(new Card(312, Suit.Hearts, CardValue.Ace, "~/Content/images/Bmp27.bmp", false));

            fullDeck.Add(new Card(400, Suit.Spades, CardValue.Deuce, "~/Content/images/Bmp41.bmp", false));
            fullDeck.Add(new Card(401, Suit.Spades, CardValue.Three, "~/Content/images/Bmp42.bmp", false));
            fullDeck.Add(new Card(402, Suit.Spades, CardValue.Four, "~/Content/images/Bmp43.bmp", false));
            fullDeck.Add(new Card(403, Suit.Spades, CardValue.Five, "~/Content/images/Bmp44.bmp", false));
            fullDeck.Add(new Card(404, Suit.Spades, CardValue.Six, "~/Content/images/Bmp45.bmp", false));
            fullDeck.Add(new Card(405, Suit.Spades, CardValue.Seven, "~/Content/images/Bmp46.bmp", false));
            fullDeck.Add(new Card(406, Suit.Spades, CardValue.Eight, "~/Content/images/Bmp47.bmp", false));
            fullDeck.Add(new Card(407, Suit.Spades, CardValue.Nine, "~/Content/images/Bmp48.bmp", false));
            fullDeck.Add(new Card(408, Suit.Spades, CardValue.Ten, "~/Content/images/Bmp49.bmp", false));
            fullDeck.Add(new Card(409, Suit.Spades, CardValue.Jack, "~/Content/images/Bmp50.bmp", false));
            fullDeck.Add(new Card(410, Suit.Spades, CardValue.Queen, "~/Content/images/Bmp51.bmp", false));
            fullDeck.Add(new Card(411, Suit.Spades, CardValue.King, "~/Content/images/Bmp52.bmp", false));
            fullDeck.Add(new Card(412, Suit.Spades, CardValue.Ace, "~/Content/images/Bmp40.bmp", false));

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
                sortedHand3.Add(shuffledDeck[i + 26]);
                sortedHand4.Add(shuffledDeck[i + 39]);
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

            List<Card> shuffledDeck = unshuffledDeck;
            // using Knuth Shuffle (see at http://rosettacode.org/wiki/Knuth_shuffle)
            Card temp;
            int j;

            for (int i = 0; i < shuffledDeck.Count; i++)
            {
                j = random.Next(shuffledDeck.Count);
                temp = shuffledDeck[i];
                shuffledDeck[i] = shuffledDeck[j];
                shuffledDeck[j] = temp;
            }
            return shuffledDeck;
        }
    }
}
