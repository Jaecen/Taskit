using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Taskit.Web.Models
{
	public class DataContext : DbContext
	{
		public IDbSet<Person> People { get; set; }
		public IDbSet<Card> Cards { get; set; }
		public IDbSet<Attribute> Attributes { get; set; }
	}
}