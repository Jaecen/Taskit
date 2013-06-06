using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taskit.Web.Models
{
	public class Person
	{
		public int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual ICollection<Card> Cards { get; set; }

		public Person()
		{
			Cards = new List<Card>();
		}
	}
}