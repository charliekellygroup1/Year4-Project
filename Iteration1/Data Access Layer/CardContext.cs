using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Iteration1.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Iteration1.Models.Game;
using System.Data.SqlClient;

namespace Iteration1.Data_Access_Layer
{
    public class CardContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        // public CardContext() : base("DefaultConnection")
        public CardContext() : base("ConnectionStringName")
            { }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Trick> Tricks { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Hand> Hand { get; set; }
        public void UpdateDeck(int id, int position)
        {
            CardContext db = new CardContext();
            string addTrick = "";

            Card playedCard = db.Cards.Find(id);
            playedCard.CardPlayed = true;
            addTrick = playedCard.ImagePath;
            db.Entry(playedCard).State = EntityState.Modified;
            db.SaveChanges();

            int next = position;
            CardValue cardValue = playedCard.CardValue;
            Suit suit = playedCard.CardSuit;
            Trick trick = db.Tricks.Find(next);
            trick.TrickCardUrl = addTrick;
            trick.TrickIndex = id;
            trick.CardValue = cardValue;
            trick.CardSuit = suit;
            db.Entry(trick).State = EntityState.Modified;
            db.SaveChanges();
        }
        public List<string> GetTrickCards()
        {
            CardContext db = new CardContext();
            var Cards = from q in db.Tricks
                        orderby q.ID
                        select q.TrickCardUrl;

            List<string> imageUrls = Cards.ToList();
            return imageUrls;
        }
        public List<int> GetTrickIndexes()
        {
            CardContext db = new CardContext();
            var Tricks = from q in db.Tricks
                         orderby q.ID
                         select q.TrickIndex;
            
            List<int> trickIndexes = Tricks.ToList();
            return trickIndexes;
        }
        public Card GetFirstTrick(int id)
        {
            CardContext db = new CardContext();
            Trick firstTrick = db.Tricks.Find(id);
            Card playedCard = db.Cards.Find(firstTrick.TrickIndex);

            return playedCard;

        }
        public List<string> GetCurrentDeck()
        {
            CardContext db = new CardContext();
            var Cards = from q in db.Cards
                        orderby q.ID
                        select q.ImagePath;

            List<string> imageUrls = Cards.ToList();
            return imageUrls;
        }
        public List<Card> GetDeck()
        {
            CardContext db = new CardContext();
            var Cards = from q in db.Cards
                        select q;

            List<Card> cards = Cards.ToList();
            return cards;
        }
        public List<Trick> GetTricks()
        {
            CardContext db = new CardContext();
            var Cards = from q in db.Tricks
                        orderby q.ID
                        select q;

            List<Trick> cards = Cards.ToList();
            return cards;
        }
        public void ResetTricks()
        {
            CardContext db = new CardContext();
            var Cards = from q in db.Tricks
                        orderby q.ID
                        select q;

            List<Trick> cards = Cards.ToList();
            foreach(var t in cards)
            {
                t.TrickCardUrl = "~Content/images/blankCard.jpg";
                t.TrickIndex = 0;
                t.CardValue = CardValue.None;
                t.CardSuit = Suit.Blank;
                db.Entry(t).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public List<bool> GetCardsPlayed()
        {
            CardContext db = new CardContext();
            var Cards = from q in db.Cards
                        orderby q.ID
                        select q.CardPlayed;

            List<bool> cardsPlayed = Cards.ToList();
            return cardsPlayed;
        }
        public void ResetCardsPlayed()
        {
            CardContext db = new CardContext();
            foreach (var card in db.Cards.Where(x => x.CardPlayed == true).ToList())
            {
                card.CardPlayed = false;
            }
            db.SaveChanges();
            db = new CardContext();
            foreach (var trick in db.Tricks.Where(x => x.TrickIndex > 0).ToList())
            {
                trick.TrickIndex = 0;
                trick.TrickCardUrl = "~Content / images / blankCard.jpg";
                trick.CardSuit = Suit.Blank;
                trick.CardValue = CardValue.None;
            }
            db.SaveChanges();
        }
        public int GetCardId(int playerRef)
        {
            CardContext db = new CardContext();
            int foundId = 0;
            foreach (var cardId in db.Cards.Where(x => x.PlayerRef == playerRef))
            {
                 foundId = cardId.ID;
            }
            db.SaveChanges();
            return foundId;
        }
        public int GetGameID()
        {
            CardContext db = new CardContext();
            int gameId = 0;
            var lastGameID = db.Game.Max(g => g.ID);

            gameId = lastGameID;

            return gameId;
        }
        public int GetTrickWinner()
        {
            int winner = 0;
            CardContext db = new CardContext();
            var lastHandID = db.Hand.Max(h => h.ID);

            var winnerIndex = (from x in db.Hand where x.ID == lastHandID select x.WinningPlayer).First();
            winner = winnerIndex;

            return winner;
        }
        public int GetTrickScore()
        {
            int score = 0;
            CardContext db = new CardContext();
            var lastHandID = db.Hand.Max(h => h.ID);

            var winnerIndex = (from x in db.Hand where x.ID == lastHandID select x.TrickScore).First();
            score = winnerIndex;

            return score;
        }
        public List<string> GetLastTrick()
        {
            List<string> lastTrick = new List<string>();
            int[] ids = new int[4];
            CardContext db = new CardContext();
            var lastHandID = db.Hand.Max(h => h.ID);

            var card1 = (from x in db.Hand where x.ID == lastHandID select x.FirstCard).First();
            ids[0] = card1;
            var card2 = (from x in db.Hand where x.ID == lastHandID select x.SecondCard).First();
            ids[1] = card2;
            var card3 = (from x in db.Hand where x.ID == lastHandID select x.ThirdCard).First();
            ids[2] = card3;
            var card4 = (from x in db.Hand where x.ID == lastHandID select x.FourthCard).First();
            ids[3] = card4;

            var url1 = (from x in db.Cards where x.ID == ids[0] select x.ImagePath).First();
            lastTrick.Add(url1);
            var url2 = (from x in db.Cards where x.ID == ids[1] select x.ImagePath).First();
            lastTrick.Add(url2);
            var url3 = (from x in db.Cards where x.ID == ids[2] select x.ImagePath).First();
            lastTrick.Add(url3);
            var url4 = (from x in db.Cards where x.ID == ids[3] select x.ImagePath).First();
            lastTrick.Add(url4);


            return lastTrick;
        }
    }
}