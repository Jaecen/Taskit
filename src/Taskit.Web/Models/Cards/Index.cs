using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taskit.Web.Models.Cards
{
	public class Index<TKey>
	{
		public string SortingAttribute { get; set; }
		public IEnumerable<string> SortableAttributes { get; set; }
		public ILookup<TKey, Card> Cards { get; set; }
	}
}