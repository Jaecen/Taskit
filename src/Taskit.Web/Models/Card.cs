using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taskit.Web.Models
{
	public class Card
	{
		public int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual string Description { get; set; }
		public virtual ICollection<Attribute> Attributes { get; protected set; }
		public virtual ICollection<Person> People { get; protected set; }

		public Card()
		{
			Attributes = new List<Attribute>();
			People = new List<Person>();
		}
	}
}