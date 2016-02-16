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
            Game.isPastFirstTrick = false;

            Game game = new Game(true, 0);
            Game.Teamscore = 0;
            Card card1 = new Card();
            Card card2 = new Card();
            Card card3 = new Card();
            Deck deck = new Deck();
            int cardIndex = 0;
            List<Card> startingDeck = db.GetDeck();
            int deuceIndex = card1.getDeuceIndex(startingDeck);
            int firstPosition = game.GetPlayerPosition(deuceIndex);
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
            ViewBag.Score = Game.Teamscore;

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
            int firstPosition = game.GetPlayerPosition(deuceIndex);
            if (!Game.isPastFirstTrick)
            {
                Game.isPastFirstTrick = true;
                if (firstPosition == 1)
                {
                    db.UpdateDeck(id, 1);
                    db.SaveChanges();
                    card1 = db.GetFirstTrick(1);
                    Game.trumpSuit = card1.CardSuit;
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
            }
            else
            {
                int firstToPlay = db.GetTrickWinner();
                if (firstToPlay == 1)
                {
                    db.UpdateDeck(id, 1);
                    db.SaveChanges();
                    card1 = db.GetFirstTrick(1);
                    Game.trumpSuit = card1.CardSuit;
                    card2 = game.GetSecondContinuous(firstToPlay + 1);
                    cardIndex = db.GetCardId(card2.PlayerRef);
                    db.UpdateDeck(cardIndex, 2);
                    card3 = game.GetThirdContinuous(firstToPlay + 2);
                    cardIndex = db.GetCardId(card3.PlayerRef);
                    db.UpdateDeck(cardIndex, 3);
                    card4 = game.GetFourthContinuous(firstToPlay + 3);
                    cardIndex = db.GetCardId(card4.PlayerRef);
                    db.UpdateDeck(cardIndex, 4);
                    db.SaveChanges();
                }
                else if (firstToPlay == 2)
                {
                    db.UpdateDeck(id, 4);
                    db.SaveChanges();
                }
                else if (firstToPlay == 3)
                {
                    db.UpdateDeck(id, 3);
                    db.SaveChanges();
                    card1 = db.GetFirstTrick(1);
                    card4 = game.GetFourthContinuous(firstToPlay + 1);
                    cardIndex = db.GetCardId(card4.PlayerRef);
                    db.UpdateDeck(cardIndex, 4);
                    db.SaveChanges();
                }
                else
                {
                    //player is player 4
                    db.UpdateDeck(id, 2);
                    db.SaveChanges();
                    card1 = db.GetFirstTrick(1);
                    card3 = game.GetThirdContinuous(firstToPlay - 2);
                    cardIndex = db.GetCardId(card3.PlayerRef);
                    db.UpdateDeck(cardIndex, 3);
                    card4 = game.GetFourthContinuous(firstToPlay - 1);
                    cardIndex = db.GetCardId(card4.PlayerRef);
                    db.UpdateDeck(cardIndex, 4);
                    db.SaveChanges();

                }
            }
            
            ViewBag.Words = db.GetCurrentDeck();
            ViewBag.Played = db.GetCardsPlayed();
            ViewBag.TrickUrls = db.GetTrickCards(); ;
            ViewBag.TrickIndexes = db.GetTrickIndexes();
            game.AddScore();
            ViewBag.Score = Game.Teamscore;

            int winner = db.GetTrickWinner();
            if (winner > 0)
            {
                ViewBag.Winner = winner;
                ViewBag.TrickScore = db.GetTrickScore();
            }
            if (Game.TrickCount == 13)
            {
                bool firstHalfOver = true;
                ViewBag.Halftime = firstHalfOver;
            }

            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("PlayCard")]
        public ActionResult PlayCard()
        {
            int winner = db.GetTrickWinner();
            ViewBag.NextPlayer = winner;
            db.ResetTricks();
            Card card1 = new Card();
            Card card2 = new Card();
            Card card3 = new Card();
            Card card4 = new Card();
            Game game = new Game();
            int cardIndex = 0;
            
            if (winner == 2)
            {
                card1 = game.GetFirstContinuous(winner);
                cardIndex = db.GetCardId(card1.PlayerRef);
                db.UpdateDeck(cardIndex, 1);
                db.SaveChanges();

                card2 = game.GetSecondContinuous(winner + 1);
                cardIndex = db.GetCardId(card2.PlayerRef);
                db.UpdateDeck(cardIndex, 2);
                db.SaveChanges();

                card3 = game.GetThirdContinuous(winner + 2);
                cardIndex = db.GetCardId(card3.PlayerRef);
                db.UpdateDeck(cardIndex, 3);
                db.SaveChanges();
            }
            else if (winner == 3)
            {
                card1 = game.GetFirstContinuous(winner);
                cardIndex = db.GetCardId(card1.PlayerRef);
                db.UpdateDeck(cardIndex, 1);
                db.SaveChanges();

                card2 = game.GetSecondContinuous(winner + 1);
                cardIndex = db.GetCardId(card2.PlayerRef);
                db.UpdateDeck(cardIndex, 2);
                db.SaveChanges();
            }
            else if (winner == 4)
            {
                card1 = game.GetFirstContinuous(winner);
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
            ViewBag.Score = Game.Teamscore;
            

            return View();
        }
    }

}
