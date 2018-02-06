using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Game
    {
        private List<Player> players;
        private const int MAX_ROUNDS = 20;
        private List<Card> cardsInPlay;
        private string cardsDealt; //holds the cards dealt to each player
        private string battleLog; //holds a log of the results of each battle throughout the game.

        public Game()
        {
            this.players = new List<Player>();
            this.cardsInPlay = new List<Card>();
        }

        //populates the deck, creates players, and deals cards to each player
        //records log of cards dealt to each player
        public void InitializeGame()
        {
            //create players, for now only 2. Could be extended to allow input for number of players. 
            players.Add(new Player("Player 1"));
            players.Add(new Player("Player 2"));

        }

        //method to handle logic for dealing cards
        public void DealCards()
        {

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
    }
}