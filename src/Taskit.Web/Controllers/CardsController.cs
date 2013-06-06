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
		public ActionResult Index()
		{
			IEnumerable<Card> cards;
			using(var dataContext = new DataContext())
				cards = dataContext.Cards.ToArray();

			return View(cards);
		}
	}
}
