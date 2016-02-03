namespace Iteration1.Migrations
{
    using Models.Game;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.SqlClient;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Iteration1.Data_Access_Layer.CardContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Iteration1.Data_Access_Layer.CardContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
           /* List<Trick> seedTricks = new List<Trick>();
            Trick trick = new Trick("~Content/images/blankCard.jpg", 0, CardValue.None, Suit.Blank);
            seedTricks.Add(trick);
            seedTricks.Add(trick);
            seedTricks.Add(trick);
            seedTricks.Add(trick);
            seedTricks.ToList().ForEach(n => context.Tricks.Add(n));
            context.SaveChanges();
            /*try
             {
                 Deck d = new Deck();
                 List<Card> noviceGame = new List<Card>();
                 noviceGame = d.GetFullDeck();
                 noviceGame.ToList().ForEach(n => context.Cards.Add(n));
                 context.SaveChanges();
             }
             catch (SqlException ex) // This will catch all SQL exceptions
             {
                 ex.Message.ToString();
             }
             catch (InvalidOperationException ex) // This will catch SqlConnection Exception
             {
                 ex.Message.ToString();
             }
             catch (Exception ex) // This will catch every Exception
             {
                 ex.Message.ToString();
             }
             finally // don't forget to close your connection when exception occurs.
             {

                 context.SaveChanges();

             }*/
        }
    }
}
