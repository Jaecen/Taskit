using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Taskit.Web.Models
{
	public class DataContext : DbContext
	{
		public IDbSet<Person> People { get { return Set<Person>(); } }
		public IDbSet<Card> Cards { get { return Set<Card>(); } }
		public IDbSet<Attribute> Attributes { get { return Set<Attribute>(); } }
	}
}