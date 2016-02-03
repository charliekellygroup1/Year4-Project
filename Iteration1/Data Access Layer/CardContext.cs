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
            Card playedCard = db.Cards.Find(id);

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
    }
}