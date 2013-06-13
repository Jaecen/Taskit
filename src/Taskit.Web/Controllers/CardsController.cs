using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Taskit.Web.Models;

namespace Taskit.Web.Controllers
{
	public class CardsController : Controller
	{
		public ActionResult Index(string sortingAttribute)
		{

			if(sortingAttribute == null)
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
							.FirstOrDefault(),
						Card = c,
					})
					.OrderBy(o => o.Key.DisplayOrder)
					.ToLookup(
						o => o.Key.Value,
						o => o.Card
					);

				var viewModel = new Models.Cards.Index<string>
				{
					SortingAttribute = sortingAttribute,
					SortableAttributes = sortableAttributes,
					Cards = cards,
				};

				return View(viewModel);
			}
		}

		[HttpPost]
		public ActionResult UpdateCardAttribute(int cardId, string attributeKey, string attributeValue)
		{
			using(var dataContext = new DataContext())
			{
				var attribute = dataContext.Cards
					.Where(c => c.Id == cardId)
					.SelectMany(c => c.Attributes)
					.Where(a => a.Key == attributeKey)
					.FirstOrDefault();

				if(attribute == null)
					return new HttpStatusCodeResult(HttpStatusCode.NotFound);

				attribute.Value = attributeValue;
				dataContext.SaveChanges();
				return new HttpStatusCodeResult(HttpStatusCode.OK);
			}
		}

		[HttpPost]
		public ActionResult UpdateCardDisplayOrder(int cardId, int? previousCardId, string attributeKey)
		{
			using(var dataContext = new DataContext())
			{
				var attribute = dataContext.Cards
					.Where(c => c.Id == cardId)
					.SelectMany(c => c.Attributes)
					.Where(a => a.Key == attributeKey)
					.FirstOrDefault();

				if(attribute == null)
					return new HttpStatusCodeResult(HttpStatusCode.NotFound);

				var previousAttributeDisplayIndex = dataContext.Cards
					.Where(c => c.Id == previousCardId)
					.SelectMany(c => c.Attributes)
					.Where(a => a.Key == attributeKey)
					.Select(a => a.DisplayOrder)
					.DefaultIfEmpty(-1)
					.FirstOrDefault();

				attribute.DisplayOrder = previousAttributeDisplayIndex + 1;

				foreach(var followingAttribute in dataContext.Attributes
					.Where(a => a.Key == attributeKey)
					.Where(a => a.DisplayOrder > previousAttributeDisplayIndex))
				{
					followingAttribute.DisplayOrder += 1;
				}

				dataContext.SaveChanges();
				return new HttpStatusCodeResult(HttpStatusCode.OK);
			}
		}
	}
}
