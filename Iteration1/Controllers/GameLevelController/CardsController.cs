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
        [HttpGet]
        [Route("NoviceLevel")]
        public ActionResult NoviceLevel()
        {
            bool firstHalf = Game.isFirstHalf;
            Game.isPastFirstTrick = false;
            Game game = new Game(firstHalf, 0);
            Card card1 = new Card();
            Card card2 = new Card();
            Card card3 = new Card();
            Deck deck = new Deck();
            int cardIndex = 0, firstPosition = 0;

            if (firstHalf)
            {
                db.ResetCardsPlayed();
                db.SaveChanges();
                Game.TrickCount = 0;
                Game.Teamscore = 0;
                Game.OppScore = 0;
                Game.isGameOver = false;
                Game.NextPitcher = 0;
                List<Card> startingDeck = db.GetDeck();
                int deuceIndex = card1.getDeuceIndex(startingDeck);
                firstPosition = game.GetPlayerPosition(deuceIndex);
                game.SetNextPitcher(firstPosition);
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
            }
            else
            {
                db.ResetCardsPlayed();
                db.SaveChanges();

                List<Card> startingDeck = db.GetDeck();
                firstPosition = Game.NextPitcher;
                int deuceIndex = game.GetIndexOfPlayerById(firstPosition);
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
            }
            ViewBag.Words = db.GetCurrentDeck();
            ViewBag.Played = db.GetCardsPlayed();
            ViewBag.TrickUrls = db.GetTrickCards(); ;
            ViewBag.TrickIndexes = db.GetTrickIndexes();
            ViewBag.PlayerScore = Game.Teamscore;
            ViewBag.OppScore = Game.OppScore;
            ViewBag.PlayableCards = game.PlayableCards(firstPosition);

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("PlayCard/{id}")]
        public ActionResult PlayCard(int id)
        {
            bool firstHalf = Game.isFirstHalf;
            Game game = new Game(true, 0);
            Card card1 = new Card();
            Card card2 = new Card();
            Card card3 = new Card();
            Card card4 = new Card();
            Deck deck = new Deck();
            int cardIndex = 0;
            List<Card> startingDeck = db.GetDeck();
            int firstPosition = 0, deuceIndex = 0;
            if(firstHalf)
            {
                deuceIndex = card1.getDeuceIndex(startingDeck);
                firstPosition = game.GetPlayerPosition(deuceIndex);
            }
            else
            {
                firstPosition = Game.NextPitcher;
                deuceIndex = game.GetIndexOfPlayerById(firstPosition);
            }
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
                firstPosition = db.GetTrickWinner();
                if (firstPosition == 1)
                {
                    db.UpdateDeck(id, 1);
                    db.SaveChanges();
                    card1 = db.GetFirstTrick(1);
                    card2 = game.GetSecondContinuous(firstPosition + 1);
                    cardIndex = db.GetCardId(card2.PlayerRef);
                    db.UpdateDeck(cardIndex, 2);
                    card3 = game.GetThirdContinuous(firstPosition + 2);
                    cardIndex = db.GetCardId(card3.PlayerRef);
                    db.UpdateDeck(cardIndex, 3);
                    card4 = game.GetFourthContinuous(firstPosition + 3);
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
                    card4 = game.GetFourthContinuous(firstPosition - 1);
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
                    card3 = game.GetThirdContinuous(firstPosition - 2);
                    cardIndex = db.GetCardId(card3.PlayerRef);
                    db.UpdateDeck(cardIndex, 3);
                    card4 = game.GetFourthContinuous(firstPosition - 1);
                    cardIndex = db.GetCardId(card4.PlayerRef);
                    db.UpdateDeck(cardIndex, 4);
                    db.SaveChanges();

                }
            }
            
            ViewBag.Words = db.GetCurrentDeck();
            ViewBag.Played = db.GetCardsPlayed();
            ViewBag.TrickUrls = db.GetTrickCards();
            ViewBag.TrickIndexes = db.GetTrickIndexes();
            game.AddScore();
            ViewBag.PlayerScore = Game.Teamscore;
            ViewBag.OppScore = Game.OppScore;
            bool[] stopSelectCard = new bool[13];
            ViewBag.PlayableCards = stopSelectCard;
            bool hideNext = false;
            ViewBag.HideNextButton = hideNext;

            int winner = db.GetTrickWinner();
            if (winner > 0)
            {
                ViewBag.Winner = winner;
                ViewBag.TrickScore = db.GetTrickScore();
            }
            bool firstHalfOver = false;
            if (Game.TrickCount == 13)
            {
                firstHalfOver = true;
                Game.isFirstHalf = false;
            }
            bool gameOver = false;
            if (Game.TrickCount == 26)
            {
                gameOver = true;
                firstHalfOver = true;
                Game.isGameOver = true;
                Game.isFirstHalf = true;
            }
            if (Game.Teamscore >= 80 || Game.OppScore >= 80)
            {
                gameOver = true;
                firstHalfOver = true;
                Game.isGameOver = true;
                Game.isFirstHalf = true;
            }
            ViewBag.HalfOver = firstHalfOver;
            ViewBag.GameOver = gameOver;
            ViewBag.NextPitcher = Game.NextPitcher;

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
            ViewBag.PlayerScore = Game.Teamscore;
            ViewBag.OppScore = Game.OppScore;
            ViewBag.PlayableCards = game.PlayableCards(winner);
            bool hideNext = true;
            ViewBag.HideNextButton = hideNext;
            bool firstHalfOver = false;
            if (Game.TrickCount == 13)
            {
                firstHalfOver = true;
                Game.isFirstHalf = false;
            }
            bool gameOver = false;
            if (Game.TrickCount == 26)
            {
                gameOver = true;
                Game.isGameOver = true;
                Game.isFirstHalf = true;
            }
            if (Game.Teamscore >= 80 || Game.OppScore >= 80)
            {
                gameOver = true;
                firstHalfOver = true;
                Game.isGameOver = true;
                Game.isFirstHalf = true;
            }
            ViewBag.HalfOver = firstHalfOver;
            ViewBag.GameOver = gameOver;
            ViewBag.NextPitcher = Game.NextPitcher;

            return View();
        }
    }

}
