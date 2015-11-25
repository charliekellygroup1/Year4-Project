using System.Web.Mvc;
using Iteration1.Data_Access_Layer;
using System.Collections.Generic;

namespace Iteration1.Controllers.GameLevelController
{
    [RoutePrefix("Cards")]
    public class CardsController : Controller
    {
        private CardContext db = new CardContext();

        // GET: Deck
        [AllowAnonymous]
        [Route("NoviceLevel")]
        public ActionResult NoviceLevel()
        {
            db.ResetCardsPlayed();
            db.SaveChanges();
            ViewBag.Words = db.GetCurrentDeck();

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("PlayCard/{id}")]
        public ActionResult PlayCard(int id)
        {
            db.UpdateDeck(id);
            ViewBag.Words = db.GetCurrentDeck();
            ViewBag.Played = db.GetCardsPlayed();
            ViewBag.TrickUrls = db.GetTrickCards();;
            ViewBag.TrickIndexes = db.GetTrickIndexes();

            return View();
        }
    }
}
