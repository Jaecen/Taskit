namespace Taskit.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
	using Taskit.Web.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Taskit.Web.Models.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Taskit.Web.Models.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

			context.People.AddOrUpdate(
				p => p.Name,
				new Person { Name = "Scott Friend" },
				new Person { Name = "Jason Addington" },
				new Person { Name = "Josh Belden" }
			);

			context.Cards.AddOrUpdate(
				c => c.Name,
				new Card { Name = "UI", Description = "For interfacing with users." },
				new Card { Name = "Schema", Description = "Datification!" },
				new Card { Name = "Code", Description = "Not sure if we really need this." }
			);
        }
    }
}
