using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Game
    {
        private List<Player> players;
        private Deck deck;
        private const int MAX_ROUNDS = 20;
        private List<Card> cardsInPlay;
        private string cardsDealt; //holds the cards dealt to each player
        private string battleLog; //holds a log of the results of each battle throughout the game.


        public Game()
        {
            this.players = new List<Player>();
            this.cardsInPlay = new List<Card>();
            this.deck = new Deck();
            this.cardsDealt = "<h4>Dealing cards...</h4> <br />";
        }

        //populates the deck, creates players, and deals cards to each player
        //records log of cards dealt to each player
        public void InitializeGame()
        {
            //populate deck
            deck.PopulateDeck();

            //create players, for now only 2. Could be extended to allow input for number of players. 
            players.Add(new Player("Player 1"));
            players.Add(new Player("Player 2"));

            //deal cards to each player
            DealCards();

        }

        //loops through each player, assigning a card at random to the players hand until the deck is empty.
        //calls method to record the cards dealt to each player
        public void DealCards()
        {
            while(this.deck.GetDeckSize() > 0)
            {
                foreach(Player player in this.players)
                {
                    Card cardDrawn = this.deck.GetCard();
                    player.AddCardToHand(cardDrawn);
                    RecordCardsDealt(player, cardDrawn);
                }
            }
        }

        private void RecordCardsDealt(Player player, Card cardDrawn)
        {
            this.cardsDealt += String.Format("{0} is dealt the {1} <br />", player.Name, cardDrawn.Name);
        }

        //method to handle the game itself
        public void Play()
        {

        }

        //method to handle logic for each round of the game
        public void Battle()
        {

        }

        //method to handle logic for War event
        public void War()
        {

        }

        //method that returns a string of the cardsDealt and battleLog.
        public string GetGameSummary()
        {
            return this.cardsDealt;
        }
    }
}