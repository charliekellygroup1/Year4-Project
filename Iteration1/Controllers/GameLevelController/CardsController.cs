using System.Web.Mvc;
using Iteration1.Data_Access_Layer;
using System.Collections.Generic;
using Iteration1.Models.Game;

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

            Game game = new Game(true, 0);
            Card card1 = new Card();
            Card card2 = new Card();
            Card card3 = new Card();
            Deck deck = new Deck();
            int cardIndex = 0;
            List<Card> startingDeck = db.GetDeck();
            int deuceIndex = card1.getDeuceIndex(startingDeck);
            int firstPosition = game.GetFirstPlayerPosition(deuceIndex);
            if (firstPosition == 2)
            {
                card1 = game.GetFirstCard(startingDeck, deuceIndex);
                cardIndex = db.GetCardId(card1.PlayerRef);
                db.UpdateDeck(cardIndex, 1);
                card2 = game.GetSecondCard(startingDeck, card1, deuceIndex);
                cardIndex = db.GetCardId(card2.PlayerRef);
                db.UpdateDeck(cardIndex, 2);
                card3 = game.GetThirdCard(startingDeck, card1, deuceIndex);
                cardIndex = db.GetCardId(card3.PlayerRef);
                db.UpdateDeck(cardIndex, 3);
                db.SaveChanges();
            }
            else if (firstPosition == 3)
            {
                card1 = game.GetFirstCard(startingDeck, deuceIndex);
                cardIndex = db.GetCardId(card1.PlayerRef);
                db.UpdateDeck(cardIndex, 1);
                card2 = game.GetSecondCard(startingDeck, card1, deuceIndex);
                cardIndex = db.GetCardId(card2.PlayerRef);
                db.UpdateDeck(cardIndex, 2);
                db.SaveChanges();
            }
            else if (firstPosition == 4)
            {
                card1 = game.GetFirstCard(startingDeck, deuceIndex);
                cardIndex = db.GetCardId(card1.PlayerRef);
                db.UpdateDeck(cardIndex, 1);
                db.SaveChanges();
            }
            else
            {
                //do nothing player one chooses own card
            }


            ViewBag.Words = db.GetCurrentDeck();
            ViewBag.Played = db.GetCardsPlayed();
            ViewBag.TrickUrls = db.GetTrickCards(); ;
            ViewBag.TrickIndexes = db.GetTrickIndexes();

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("PlayCard/{id}")]
        public ActionResult PlayCard(int id)
        {
            Game game = new Game(true, 0);
            Card card1 = new Card();
            Card card2 = new Card();
            Card card3 = new Card();
            Card card4 = new Card();
            Deck deck = new Deck();
            int cardIndex = 0;
            List<Card> startingDeck = db.GetDeck();
            int deuceIndex = card1.getDeuceIndex(startingDeck);
            int firstPosition = game.GetFirstPlayerPosition(deuceIndex);
            if (firstPosition == 1)
            {
                db.UpdateDeck(id, 1);
                db.SaveChanges();
                card1 = db.GetFirstTrick(1);
                card2 = game.GetSecondCard(startingDeck, card1, deuceIndex);
                cardIndex = db.GetCardId(card2.PlayerRef);
                db.UpdateDeck(cardIndex, 2);
                card3 = game.GetThirdCard(startingDeck, card1, deuceIndex);
                cardIndex = db.GetCardId(card3.PlayerRef);
                db.UpdateDeck(cardIndex, 3);
                card4 = game.GetFourthCard(startingDeck, card1, deuceIndex);
                cardIndex = db.GetCardId(card4.PlayerRef);
                db.UpdateDeck(cardIndex, 4);
                db.SaveChanges();
            }
            else if (firstPosition == 2)
            {
                db.UpdateDeck(id, 4);
                db.SaveChanges();
            }
            else if (firstPosition == 3)
            {
                db.UpdateDeck(id, 3);
                db.SaveChanges();
                card1 = db.GetFirstTrick(1);
                card4 = game.GetFourthCard(startingDeck, card1, deuceIndex);
                cardIndex = db.GetCardId(card4.PlayerRef);
                db.UpdateDeck(cardIndex, 4);
                db.SaveChanges();
            }
            else
            {
                db.UpdateDeck(id, 2);
                db.SaveChanges();
                card1 = db.GetFirstTrick(1);
                card3 = game.GetThirdCard(startingDeck, card1, deuceIndex);
                cardIndex = db.GetCardId(card3.PlayerRef);
                db.UpdateDeck(cardIndex, 3);
                card4 = game.GetFourthCard(startingDeck, card1, deuceIndex);
                cardIndex = db.GetCardId(card4.PlayerRef);
                db.UpdateDeck(cardIndex, 4);
                db.SaveChanges();

            }
            ViewBag.Words = db.GetCurrentDeck();
            ViewBag.Played = db.GetCardsPlayed();
            ViewBag.TrickUrls = db.GetTrickCards();;
            ViewBag.TrickIndexes = db.GetTrickIndexes();
            ViewBag.Score = Game.Teamscore;

            return View();
        }
    }
}
