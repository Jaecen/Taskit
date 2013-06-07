using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taskit.Web.Models;

namespace Taskit.Web.Controllers
{
	public class CardsController : Controller
	{
		public ActionResult Index(string sortingAttribute)
		{

            if (sortingAttribute == null)
                sortingAttribute = "Status";

			using(var dataContext = new DataContext())
			{
				var sortableAttributes = dataContext.Attributes
					.Select(a => a.Key)
					.Distinct()
					.OrderBy(a => a)
					.ToArray();

				var cards = dataContext.Cards
					.Select(c => new
					{
						Key = c.Attributes
							.Where(a => a.Key == sortingAttribute)
							.Select(a => a.Value)
							.FirstOrDefault(),
						Card = c
					})
					.ToLookup(o => o.Key, o => o.Card);

				// TODO: We need data types on attributes to support natural sorting
				var viewModel = new Models.Cards.Index<String>
				{
					SortingAttribute = sortingAttribute,
					SortableAttributes = sortableAttributes,
					Cards = cards,
				};

				return View(viewModel);
			}
		}
	}
}
