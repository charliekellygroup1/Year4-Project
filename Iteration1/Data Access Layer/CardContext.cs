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
        public void UpdateDeck(int id)
        {
            CardContext db = new CardContext();
            string addTrick = "";

            Card playedCard = db.Cards.Find(id);
            playedCard.CardPlayed = true;
            addTrick = playedCard.ImagePath;
            db.Entry(playedCard).State = EntityState.Modified;
            db.SaveChanges();

            int next = 1;
            Trick trick = db.Tricks.Find(next);
            trick.TrickCard = addTrick;
            trick.TrickIndex = id;
            db.Entry(trick).State = EntityState.Modified;
            db.SaveChanges();
        }
        public List<string> GetTrickCards()
        {
            CardContext db = new CardContext();
            var Cards = from q in db.Tricks
                        orderby q.ID
                        select q.TrickCard;

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
        public List<string> GetCurrentDeck()
        {
            CardContext db = new CardContext();
            var Cards = from q in db.Cards
                        orderby q.ID
                        select q.ImagePath;

            List<string> imageUrls = Cards.ToList();
            return imageUrls;
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
                trick.TrickCard = "~Content / images / blankCard.jpg";
            }
            db.SaveChanges();
        }
    }
}