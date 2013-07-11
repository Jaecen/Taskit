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
			context.Database.ExecuteSqlCommand("delete from attributes");
			context.Database.ExecuteSqlCommand("delete from cards");

			context.People.AddOrUpdate(
				p => p.Name,
				new Person { Name = "Scott Friend" },
				new Person { Name = "Jason Addington" },
				new Person { Name = "Josh Belden" }
			);

			context.Cards.AddOrUpdate(
				c => c.Name,
				new Card
				{
					Name = "UI",
					Description = "For interfacing with users.",
					Attributes = 
					{ 
						new Models.Attribute { Key = "Project", Value = "Taskit", DisplayOrder = 0 },
						new Models.Attribute { Key = "Status", Value = "In Progress", DisplayOrder = 1 },
						new Models.Attribute { Key = "Due Date", Value = "2014-06-21", DisplayOrder = 2 }
					}
				},
				new Card
				{
					Name = "Schema",
					Description = "Datification!",
					Attributes = 
					{ 
						new Models.Attribute { Key = "Project", Value = "Taskit", DisplayOrder = 0 },
						new Models.Attribute { Key = "Status", Value = "New", DisplayOrder = 1 },
						new Models.Attribute { Key = "Due Date", Value = "2014-06-30", DisplayOrder = 2 }
					}
				},
				new Card
				{
					Name = "Code",
					Description = "Needs more bugs.",
					Attributes = 
					{ 
						new Models.Attribute { Key = "Project", Value = "Taskit", DisplayOrder = 0 },
						new Models.Attribute { Key = "Status", Value = "Complete", DisplayOrder = 1 },
					}
				}
			);
		}
	}
}
