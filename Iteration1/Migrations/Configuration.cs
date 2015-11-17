namespace Iteration1.Migrations
{
    using Models.Game;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
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
            Deck d = new Deck();
            List<Card> noviceGame = new List<Card>();
            noviceGame = d.GetFullDeck();
            noviceGame.ToList().ForEach(n => context.Cards.Add(n));
            context.SaveChanges();
        }
    }
}
