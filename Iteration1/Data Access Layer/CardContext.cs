using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Iteration1.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Iteration1.Models.Game;

namespace Iteration1.Data_Access_Layer
{
    public class CardContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public CardContext() : base("DefaultConnection")
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

            Trick trick = new Trick(addTrick, id);
            db.Tricks.Add(trick);
            db.SaveChanges();
        }
        public List<string> GetTrickCards()
        {
            CardContext db = new CardContext();
            var Cards = from q in db.Tricks
                        orderby q.TrickIndex
                        select q.TrickCard;

            List<string> imageUrls = Cards.ToList();
            return imageUrls;
        }
        public List<int> GetTrickIndexes()
        {
            CardContext db = new CardContext();
            var Tricks = from q in db.Tricks
                         orderby q.TrickIndex
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
    }
}