using Iteration1.Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Iteration1.Models.Game
{
    public class Game
    {
        public static int Teamscore = 0;
        List<Trick> tricks;
        CardContext db;

        public Game(bool half, int score)
        {
            this.IsFirstHalf = half;
            this.Score = score;
            tricks = new List<Trick>();
            db = new CardContext();
        }
        public Game()
        {
            //default constructor
            this.IsFirstHalf = false;
            this.Score = 0;
            tricks = new List<Trick>();
            db = new CardContext();
        }
        public int ID { get; private set; }
        public bool IsFirstHalf { get; private set; }
        public int Score { get; private set; }

        public int AddScore()
        {
            tricks = db.GetTricks();
            Card a = db.GetFirstTrick(tricks[0].ID);
            int trickScore = 0, index = 0, winningPlayer = 0;
            var winner = tricks.Max(card => card.CardValue);
            for (int i = 0; i < tricks.Count; i++)
            {
                if (tricks[i].CardValue == winner)
                {
                    index = tricks[i].TrickIndex;
                    winningPlayer = GetPlayerPosition(index);
                }
            }

            for (int i = 0; i < tricks.Count; i++)
            {
                if (tricks[i].CardValue == CardValue.Five && tricks[i].CardSuit == a.CardSuit || tricks[i].CardValue == CardValue.Nine && tricks[i].CardSuit == a.CardSuit)
                {
                    trickScore += ((int)tricks[i].CardValue * 2);
                }
                else if (tricks[i].CardSuit != a.CardSuit && tricks[i].CardValue == CardValue.Nine || tricks[i].CardSuit != a.CardSuit && tricks[i].CardValue == CardValue.Five)
                {
                    trickScore += (int)tricks[i].CardValue;
                }
                else if (tricks[i].CardSuit == a.CardSuit && tricks[i].CardValue == CardValue.Ace)
                {
                    trickScore += 4;
                }
                else if (tricks[i].CardSuit == a.CardSuit && tricks[i].CardValue == CardValue.King)
                {
                    trickScore += 3;
                }
                else if (tricks[i].CardSuit == a.CardSuit && tricks[i].CardValue == CardValue.Queen)
                {
                    trickScore += 2;
                }
                else if (tricks[i].CardSuit == a.CardSuit && tricks[i].CardValue == CardValue.Jack)
                {
                    trickScore += 1;
                }
                else
                {

                }
            }
            if (winningPlayer == 1 || winningPlayer == 3)
            {
                Teamscore += trickScore;
            }
            Score += trickScore;
            int gameId = db.GetGameID();
            Hand hand = new Hand(gameId, tricks[0].TrickIndex, tricks[1].TrickIndex, tricks[2].TrickIndex, tricks[3].TrickIndex, trickScore, winningPlayer);
            db.Hand.Add(hand);
            db.SaveChanges();
            return trickScore;
        }

        public Card GetFirstCard(List<Card> startDeck, int indexOfPlayer)
        {
            Card firstCard = new Card();
            int caseSwitch = GetPlayerPosition(indexOfPlayer);

            switch (caseSwitch)
            {
                case 1:
                    List<Card> player1Hand = new List<Card>();
                    for (int i = 0; i <= 12; i++)
                    {
                        player1Hand.Add(startDeck[i]);
                    }
                    firstCard = decideTrumps(player1Hand);
                    break;
                case 2:
                    List<Card> player2Hand = new List<Card>();
                    for (int i = 13; i <= 25; i++)
                    {
                        player2Hand.Add(startDeck[i]);
                    }
                    firstCard = decideTrumps(player2Hand);
                    break;
                case 3:
                    List<Card> player3Hand = new List<Card>();
                    for (int i = 26; i <= 38; i++)
                    {
                        player3Hand.Add(startDeck[i]);
                    }
                    firstCard = decideTrumps(player3Hand);
                    break;
                case 4:
                    List<Card> player4Hand = new List<Card>();
                    for (int i = 39; i <= 51; i++)
                    {
                        player4Hand.Add(startDeck[i]);
                    }
                    firstCard = decideTrumps(player4Hand);
                    break;
                default:
                    break;
            }
            //Trick trick1 = new Trick(firstCard.ImagePath, caseSwitch, firstCard.CardValue, firstCard.CardSuit);
            //db.Tricks.Add(trick1);
            //db.SaveChanges();
            return firstCard;
        }

        public int GetPlayerPosition(int indexOfPlayer)
        {
            if (indexOfPlayer >= 0 && indexOfPlayer <= 12)
            {
                return 1;
            }
            else if (indexOfPlayer >= 13 && indexOfPlayer <= 25)
            {
                return 2;
            }
            else if (indexOfPlayer >= 26 && indexOfPlayer <= 38)
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }

        public Card GetFourthCard(List<Card> gameCards, Card a, int indexOfDeuce)
        {

            //find out which player is next
            int caseSwitch = GetPlayerPosition(indexOfDeuce);

            if (caseSwitch == 1)
                caseSwitch = 4;
            else if (caseSwitch == 2)
                caseSwitch = 1;
            else if (caseSwitch == 3)
                caseSwitch = 2;
            else
                caseSwitch = 3;

            //get the next players hand
            Card card = new Card();
            List<Card> playersHand = new List<Card>();
            switch (caseSwitch)
            {
                case 1:
                    for (int i = 0; i <= 12; i++)
                    {
                        playersHand.Add(gameCards[i]);
                    }
                    card = playerPlaysFourth(playersHand, a);
                    break;
                case 2:
                    for (int i = 13; i <= 25; i++)
                    {
                        playersHand.Add(gameCards[i]);
                    }
                    card = playerPlaysFourth(playersHand, a);
                    break;
                case 3:
                    for (int i = 26; i <= 38; i++)
                    {
                        playersHand.Add(gameCards[i]);
                    }
                    card = playerPlaysFourth(playersHand, a);
                    break;
                case 4:
                    for (int i = 39; i <= 51; i++)
                    {
                        playersHand.Add(gameCards[i]);
                    }
                    card = playerPlaysFourth(playersHand, a);
                    break;
                default:
                    break;
            }
            //Trick trick4 = new Trick(card.ImagePath, caseSwitch, card.CardValue, card.CardSuit);
            //db.Tricks.Add(trick4);
            //db.SaveChanges();
            return card;
        }

        //helper method to decide fourth card played
        public Card playerPlaysFourth(List<Card> playersHand, Card a)
        {
            Card fourthCard = new Card();
            bool isTrumps = false;
            int lowestTrumpIndex = 0;
            tricks = db.GetTricks();

            Suit trumpSuit = a.CardSuit;
            //if partner is in the lead then throw a don on it if possible
            //else throw lowest trump, else throw 9 or 5 if no trumps, else throw lowest card of biggest suit
            if (tricks[1].CardValue > tricks[0].CardValue && tricks[1].CardValue > tricks[2].CardValue)
            {
                fourthCard = GiveFat(playersHand, a);
            }
            //else check if any of the cards played are 9's or 5's and check if player has card to try win trick
            else if (tricks[0].CardValue == CardValue.Nine || tricks[1].CardValue == CardValue.Nine || tricks[2].CardValue == CardValue.Nine || tricks[0].CardValue == CardValue.Five || tricks[1].CardValue == CardValue.Five || tricks[2].CardValue == CardValue.Five)
            {
                for (int i = 0; i < playersHand.Count; i++)
                {
                    if (playersHand[i].CardSuit == trumpSuit && playersHand[i].CardValue != CardValue.Nine && playersHand[i].CardValue != CardValue.Five)
                    {
                        //hand already sorted so 1st card is highest, check its higher than opposition card played
                        if (playersHand[i].CardValue > tricks[0].CardValue && playersHand[i].CardValue > tricks[2].CardValue)
                        {
                            fourthCard = playersHand[i];
                            isTrumps = true;
                            break;
                        }
                        else if (playersHand[i].CardSuit == trumpSuit) //can't beat card so throw lowest trump
                        {
                            lowestTrumpIndex = i;
                            fourthCard = playersHand[lowestTrumpIndex];
                            isTrumps = true;
                        }
                    }

                }
            }
            //Play lowest trump
            else
            {
                //reduce list to just trumps if there are trumps in hand and if there is, must be a don
                List<Card> playerTrumps = new List<Card>();
                for (int i = 0; i < playersHand.Count; i++)
                {
                    if (playersHand[i].CardSuit == trumpSuit)
                    {
                        //Highest trump will be in index zero, lowest trump will be in index n-1
                        playerTrumps.Add(playersHand[i]);
                    }
                }
                for (int i = 0; i < playerTrumps.Count; i++)
                {
                    if (playerTrumps[i].CardValue != CardValue.Nine) //can't beat card so throw lowest trump thats not a don
                    {
                        if (playerTrumps[i].CardValue != CardValue.Five)
                            lowestTrumpIndex = i;
                        fourthCard = playerTrumps[lowestTrumpIndex];
                        isTrumps = true;
                    }
                }
                if (playerTrumps.Count > 0)
                {
                    //only a don in hand
                    if (fourthCard.PlayerRef == 0)
                    {
                        fourthCard = playerTrumps[playerTrumps.Count - 1];
                        isTrumps = true;
                    }
                }
            }
            //if no trumps throw lowest card of most suit
            if (!isTrumps)
            {
                fourthCard = getNoTrumps(playersHand);
            }
            return fourthCard;
        }

        //method to get third card in opening hand where deuce pitched
        public Card GetThirdCard(List<Card> startDeck, Card a, int indexOfDeuce)
        {
            //find out which player is next
            int caseSwitch = GetPlayerPosition(indexOfDeuce);

            if (caseSwitch == 1)
                caseSwitch = 3;
            else if (caseSwitch == 2)
                caseSwitch = 4;
            else if (caseSwitch == 3)
                caseSwitch = 1;
            else
                caseSwitch = 2;

            //get the next players hand
            Card card = new Card();
            List<Card> playersHand = new List<Card>();
            switch (caseSwitch)
            {
                case 1:
                    for (int i = 0; i <= 12; i++)
                    {
                        playersHand.Add(startDeck[i]);
                    }
                    card = playerPlaysThird(playersHand, a);
                    break;
                case 2:
                    for (int i = 13; i <= 25; i++)
                    {
                        playersHand.Add(startDeck[i]);
                    }
                    card = playerPlaysThird(playersHand, a);
                    break;
                case 3:
                    for (int i = 26; i <= 38; i++)
                    {
                        playersHand.Add(startDeck[i]);
                    }
                    card = playerPlaysThird(playersHand, a);
                    break;
                case 4:
                    for (int i = 39; i <= 51; i++)
                    {
                        playersHand.Add(startDeck[i]);
                    }
                    card = playerPlaysThird(playersHand, a);
                    break;
                default:
                    break;
            }
            //Trick trick3 = new Trick(card.ImagePath, caseSwitch, card.CardValue, card.CardSuit);
            //db.Tricks.Add(trick3);
            //db.SaveChanges();
            return card;
        }
        //private helper method to decide what card player playing third plays in opening hand
        public Card playerPlaysThird(List<Card> playersHand, Card a)
        {
            Card thirdCard = new Card();
            bool isTrumps = false;
            int lowestTrumpIndex = 0;
            tricks = db.GetTricks();

            Suit trumpSuit = a.CardSuit;
            //if partner led out an ace of trumps then throw a don on it if possible
            //else throw lowest trump, else throw 9 or 5 if no trumps, else throw lowest card of biggest suit
            if (tricks[0].CardValue == CardValue.Ace)
            {
                thirdCard = GiveFat(playersHand, a);
            }
            //else check if any of the cards played are 9's or 5's and check if player has card to try win trick
            else if (tricks[0].CardValue == CardValue.Nine || tricks[1].CardValue == CardValue.Nine || tricks[0].CardValue == CardValue.Five || tricks[1].CardValue == CardValue.Five)
            {
                for (int i = 0; i < playersHand.Count; i++)
                {
                    if (playersHand[i].CardSuit == trumpSuit && playersHand[i].CardValue != CardValue.Nine && playersHand[i].CardValue != CardValue.Five)
                    {
                        //hand already sorted so 1st card is highest, check its higher than opposition card played and partners card
                        if (playersHand[i].CardValue > tricks[1].CardValue && playersHand[i].CardValue > tricks[0].CardValue)
                        {
                            thirdCard = playersHand[i];
                            isTrumps = true;
                            break;
                        }
                        else if (playersHand[i].CardSuit == trumpSuit) //can't beat card so throw lowest trump
                        {
                            lowestTrumpIndex = i;
                            thirdCard = playersHand[lowestTrumpIndex];
                            isTrumps = true;
                        }
                    }
                }
            }
            //if there are no 9's or 5's played check partner has dons covered i.e. is in lead and played a 10 or above
            else
            {
                if (tricks[0].CardValue > tricks[1].CardValue && tricks[0].CardValue >= CardValue.Ten)
                {
                    //play lowest trump that is not a 9 or 5
                    for (int i = 0; i < playersHand.Count; i++)
                    {
                        if (playersHand[i].CardSuit == trumpSuit)
                        {
                            lowestTrumpIndex = i;
                            thirdCard = playersHand[lowestTrumpIndex];
                            isTrumps = true;
                        }
                    }

                }
                //Partner not covering dons so player tries to
                else
                {
                    for (int i = 0; i < playersHand.Count; i++)
                    {
                        if (playersHand[i].CardSuit == trumpSuit && playersHand[i].CardValue != CardValue.Nine && playersHand[i].CardValue != CardValue.Five)
                        {
                            //hand already sorted so 1st card is highest, check its higher than opposition card played
                            if (playersHand[i].CardValue > tricks[1].CardValue)
                            {
                                thirdCard = playersHand[i];
                                isTrumps = true;
                                break;
                            }
                            else if (playersHand[i].CardSuit == trumpSuit) //can't beat card so throw lowest trump
                            {
                                lowestTrumpIndex = i;
                                thirdCard = playersHand[lowestTrumpIndex];
                                isTrumps = true;
                            }

                        }
                    }
                    Suit trumps = a.CardSuit;
                    //reduce list to just trumps if there are trumps in hand and if there is, must be a don
                    List<Card> playerTrumps = new List<Card>();
                    for (int i = 0; i < playersHand.Count; i++)
                    {
                        if (playersHand[i].CardSuit == trumps)
                        {
                            //Highest trump will be in index zero, lowest trump will be in index n-1
                            playerTrumps.Add(playersHand[i]);
                        }
                    }
                    if (playerTrumps.Count > 0)
                    {
                        //only a don in hand
                        if (thirdCard.PlayerRef == 0)
                        {
                            thirdCard = playerTrumps[playerTrumps.Count - 1];
                            isTrumps = true;
                        }
                    }
                    //if no trumps throw lowest card of most suit
                    if (!isTrumps)
                    {
                        thirdCard = getNoTrumps(playersHand);
                    }
                }
            }
            return thirdCard;
        }
        //this method is called when a player wants to give points to their parnter i.e. partner played an ace or partner is in lead when player is to play fourth card
        public Card GiveFat(List<Card> playersHand, Card a)
        {
            Card fat = new Card();
            int lowestTrumpIndex = 0, i = 0;
            bool found = false;
            for (i = 0; i < playersHand.Count; i++)
            {
                //Hand is sorted highest to lowest by suit, so will find a nine before five
                if (playersHand[i].CardSuit == a.CardSuit && playersHand[i].CardValue == CardValue.Nine)
                {
                    fat = playersHand[i];
                    found = true;
                    break;
                }
                else if ((playersHand[i].CardSuit == a.CardSuit && playersHand[i].CardValue == CardValue.Five))
                {
                    fat = playersHand[i];
                    found = true;
                    break;
                }
                else if (playersHand[i].CardSuit == a.CardSuit)
                {
                    lowestTrumpIndex = i;
                    fat = playersHand[lowestTrumpIndex];
                    found = true;
                }
                else
                {
                    //found = false;
                }
            }
            //if there are no trumps check if player has a 9 or 5 of any other suit
            if (!found)
            {
                bool noNines = true;
                for (int j = 0; j < playersHand.Count; j++)
                {
                    if (playersHand[j].CardValue == CardValue.Nine)
                    {
                        fat = playersHand[j];
                        noNines = false;
                        break;
                    }
                }
                if (noNines)//no nines so go back to start and check for fives
                {
                    for (int k = 0; k < playersHand.Count; k++)
                    {
                        if (playersHand[k].CardValue == CardValue.Five)
                        {
                            fat = playersHand[k];
                            noNines = false;
                            break;
                        }
                    }
                }
                if (noNines) //if we got to here, no fat or trumps in hand so play lowest card of the suit with most cards
                {
                    fat = getNoTrumps(playersHand);
                }
            }

            return fat;
        }

        // method to get second card played in opening hand where deuce pitched
        public Card GetSecondCard(List<Card> startDeck, Card a, int indexOfDeuce)
        {
            //find out which player is next
            int caseSwitch = GetPlayerPosition(indexOfDeuce);

            if (caseSwitch == 1)
                caseSwitch = 2;
            else if (caseSwitch == 2)
                caseSwitch = 3;
            else if (caseSwitch == 3)
                caseSwitch = 4;
            else
                caseSwitch = 1;
            //get the next players hand
            Card card = new Card();
            List<Card> playersHand = new List<Card>();
            switch (caseSwitch)
            {
                case 1:
                    //Player 1 decides his own card to play
                    for (int i = 0; i <= 12; i++)
                    {
                        playersHand.Add(startDeck[i]);
                    }
                    card = playerPlaysSecond(playersHand, a);
                    break;
                case 2:
                    for (int i = 13; i <= 25; i++)
                    {
                        playersHand.Add(startDeck[i]);
                    }
                    card = playerPlaysSecond(playersHand, a);
                    break;
                case 3:
                    for (int i = 26; i <= 38; i++)
                    {
                        playersHand.Add(startDeck[i]);
                    }
                    card = playerPlaysSecond(playersHand, a);
                    break;
                case 4:
                    for (int i = 39; i <= 51; i++)
                    {
                        playersHand.Add(startDeck[i]);
                    }
                    card = playerPlaysSecond(playersHand, a);
                    break;
                default:
                    break;
            }
            //Trick trick2 = new Trick(card.ImagePath, caseSwitch, card.CardValue, card.CardSuit);
            //db.Tricks.Add(trick2);
            //db.SaveChanges();
            return card;
        }

        //private helper method to decide what card player playing second plays in opening hand
        public Card playerPlaysSecond(List<Card> playerHand, Card a)
        {
            //if player 2 is playing second then player 1 played first
            Card secondCard = new Card();
            //plays the lowest non-don trump in hand, if only dons, he plays the lowest don
            Suit trumps = a.CardSuit;
            //reduce list to just trumps if there are trumps in hand
            List<Card> playerTrumps = new List<Card>();
            for (int i = 0; i < playerHand.Count; i++)
            {
                if (playerHand[i].CardSuit == trumps)
                {
                    //Highest trump will be in index zero, lowest trump will be in index n-1
                    playerTrumps.Add(playerHand[i]);
                }
            }

            //check there is trumps in hand
            if (playerTrumps.Count > 0)
            {
                bool lowestCard = true;
                int lastIndex = playerTrumps.Count - 1;
                do
                {
                    //simplest case - play the last trump added if it is not a don, else keep going
                    if (playerTrumps[lastIndex].CardValue != CardValue.Five && playerTrumps[lastIndex].CardValue != CardValue.Nine)
                    {

                        secondCard = playerTrumps[lastIndex];
                        lowestCard = false;

                    }
                    else
                    {
                        lastIndex--;
                        lowestCard = false;
                    }
                } while (lowestCard == true && lastIndex >= 0);
                //only a don in hand
                if (secondCard.PlayerRef == 0)
                {
                    secondCard = playerTrumps[playerTrumps.Count - 1];
                }

            }
            else    //if no trumps he plays lowest card of the cards he has the most of in a suit that is not a 9 or 5
            {
                secondCard = getNoTrumps(playerHand);
            }
            return secondCard;
        }
        // helper method to decide which card to play in opening hand by player when no trumps in hand
        public Card getNoTrumps(List<Card> noTrumpsHand)
        {
            int diamonds = 0, spades = 0, clubs = 0, hearts = 0;
            Card noTrumps = new Card();
            //count how many of each suit are in hand
            for (int i = 0; i < noTrumpsHand.Count; i++)
            {
                if (noTrumpsHand[i].CardSuit == Suit.Diamonds)
                {
                    diamonds++;
                }
                else if (noTrumpsHand[i].CardSuit == Suit.Spades)
                {
                    spades++;
                }
                else if (noTrumpsHand[i].CardSuit == Suit.Clubs)
                {
                    clubs++;
                }
                else
                {
                    hearts++;
                }
            }
            //check which suit has higest number of cards, if more than one suit share highest, go for index 3
            int[] cardSuits = { diamonds, spades, clubs, hearts };
            Array.Sort(cardSuits);
            Suit suit = Suit.Blank;
            if (cardSuits[3] == diamonds)
            {
                suit = Suit.Diamonds;
            }
            else if (cardSuits[3] == spades)
            {
                suit = Suit.Spades;
            }
            else if (cardSuits[3] == clubs)
            {
                suit = Suit.Clubs;
            }
            else
            {
                suit = Suit.Hearts;
            }
            //reduce list to just higehest set
            List<Card> player2NoTrumps = new List<Card>();
            for (int i = 0; i < noTrumpsHand.Count; i++)
            {
                if (noTrumpsHand[i].CardSuit == suit)
                {
                    //Highest trump will be in index zero, lowest trump will be in index n-1
                    player2NoTrumps.Add(noTrumpsHand[i]);
                }
            }
            //Now play the lowest card of that suit that is not a 9 or 5
            int lastIndex = player2NoTrumps.Count - 1;
            bool foundNoDon = true;
            do
            {
                if (player2NoTrumps[lastIndex].CardValue != CardValue.Nine && noTrumpsHand[lastIndex].CardValue != CardValue.Five)
                {
                    //hand already sorted so last card is lowest
                    noTrumps = player2NoTrumps[lastIndex];
                    foundNoDon = false;
                }
                else
                {
                    lastIndex--;
                }

            } while (foundNoDon == true);


            return noTrumps;
        }

        public Card decideTrumps(List<Card> pitchersCards)
        {
            int diamonds = 0, spades = 0, clubs = 0, hearts = 0;
            Card trumps = new Card();
            //count how many of each suit are in hand
            for (int i = 0; i < pitchersCards.Count; i++)
            {
                if (pitchersCards[i].CardSuit == Suit.Diamonds)
                {
                    diamonds++;
                }
                else if (pitchersCards[i].CardSuit == Suit.Spades)
                {
                    spades++;
                }
                else if (pitchersCards[i].CardSuit == Suit.Clubs)
                {
                    clubs++;
                }
                else
                {
                    hearts++;
                }
            }
            //check which suit has higest number of cards, if more than one suit share highest, go for index 4
            int[] cardSuits = { diamonds, spades, clubs, hearts };
            Array.Sort(cardSuits);
            Suit trumpSuit = Suit.Blank;
            if (cardSuits[3] == diamonds)
            {
                trumpSuit = Suit.Diamonds;
            }
            else if (cardSuits[3] == spades)
            {
                trumpSuit = Suit.Spades;
            }
            else if (cardSuits[3] == clubs)
            {
                trumpSuit = Suit.Clubs;
            }
            else
            {
                trumpSuit = Suit.Hearts;
            }
            //Now play the highest card of that suit that is not a 9 or 5 
            //Minimum number of cards is 4 so there has to be at least 2 cards other than 9 or 5
            for (int i = 0; i < pitchersCards.Count; i++)
            {
                if (pitchersCards[i].CardSuit == trumpSuit && pitchersCards[i].CardValue != CardValue.Nine && pitchersCards[i].CardValue != CardValue.Five)
                {
                    //hand already sorted so 1st card is highest unless a 9 or 5
                    trumps = pitchersCards[i];
                    break;
                }
            }
            return trumps;
        }
    }
}