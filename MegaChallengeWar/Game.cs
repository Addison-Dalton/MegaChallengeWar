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
        private string winningPlayer;
        private bool outOfCards;


        public Game()
        {
            this.players = new List<Player>();
            this.cardsInPlay = new List<Card>();
            this.deck = new Deck();
            this.cardsDealt = "<h4>Dealing cards...</h4> <br />";
            this.battleLog = "<h4>Begin Battle...</h4> <br />";
            this.outOfCards = false;
        }

        //populates the deck, creates players, and deals cards to each player
        //records log of cards dealt to each player
        public void InitializeGame()
        {
            //populate deck
            deck.PopulateDeck();

            //create players
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

        //stores string of the player name and card dealt to player for each card dealt in DealCards. 
        private void RecordCardsDealt(Player player, Card cardDrawn)
        {
            this.cardsDealt += String.Format("{0} is dealt the {1} <br />", player.Name, cardDrawn.Name);
        }

        //call this if regular battle event
        private void RecordBattleLog(Card player1Card, Card player2Card, Player winningPlayer)
        {
            this.battleLog += String.Format("Battle Cards: {0} versus {1} <br /> Bounty... <br />", player1Card.Name, player2Card.Name);

            foreach (Card card in this.cardsInPlay)
            {
                this.battleLog += String.Format("&#9;{0} <br />", card.Name);
            }

            this.battleLog += String.Format("<strong>{0} wins!</strong> <br /><br />", winningPlayer.Name);
        }

        //call this in event of war
        private void RecordBattleLog()
        {
            //record the war to battlelog
            this.battleLog += "*******<strong>WAR</strong>*******<br />";
        }

        private void SetGameWinner()
        {
            if(this.players[0].GetHandCount() > this.players[1].GetHandCount())
            {
                this.winningPlayer += String.Format("<br /><h3>{0} wins the game!</h3> <br/ >Final Card Count: <br />", this.players[0].Name);
            }
            else if(this.players[0].GetHandCount() < this.players[1].GetHandCount())
            {
                this.winningPlayer += String.Format("<br /><h3>{0} wins the game!</h3> <br/ >Final Card Count: <br />", this.players[1].Name);
            }
            else
            {
                this.winningPlayer += String.Format("<br /><h3>Tied Game!</h3> <br/ >Final Card Count: <br />", this.players[1].Name);
            }

            foreach(Player player in this.players)
            {
                this.winningPlayer += String.Format("{0} has {1} cards left. <br />", player.Name, player.GetHandCount().ToString());
            }
        }

        //method to handle the game itself
        public void Play()
        {
            int numberOfRounds = 0;
            while(numberOfRounds < MAX_ROUNDS && outOfCards == false)
            {
                Round();
                numberOfRounds++;
            }

            SetGameWinner();
        }

        //method to handle logic for each round of the game
        public void Round()
        {
            //each player plays a card, if player has no more cards...
            foreach(Player player in this.players)
            {
                if(player.GetHandCount() > 0)
                {
                    this.cardsInPlay.Add(player.PlayCard());
                }
                else
                {
                    this.outOfCards = true;
                    return;
                }
            }

            //pass the two card drawn to Battle
            Battle(this.cardsInPlay[0], this.cardsInPlay[1]);

           
            //remove all cards from play
            this.cardsInPlay.Clear();
        }

        public void Battle(Card player1Card, Card player2Card)
        {
            //if the two cards passed as equal value, a war is called
            //otherwise give all cards in play to player with the card of highest value
            if (player1Card.Value == player2Card.Value)
            {
                RecordBattleLog(); //for war
                War();
            }
            else if (player1Card.Value > player2Card.Value)
            {
                RecordBattleLog(player1Card, player2Card, this.players[0]);
                this.players[0].AddCardsToHand(this.cardsInPlay);
            }
            else
            {
                RecordBattleLog(player1Card, player2Card, this.players[1]);
                this.players[1].AddCardsToHand(this.cardsInPlay);
            }
        }

        //method to handle logic for War event
        public void War()
        {
            List<Card> newBattleCards = new List<Card>();

            //for each player
            foreach(Player player in this.players)
            { 
                //draw three cards, save the second card drawn as it will be the new battle card, add all cards to current cards in play
                for(int i = 0; i < 3; i++)
                {
                    if(player.GetHandCount() > 0)
                    {
                        Card playerCard = player.PlayCard();
                        this.cardsInPlay.Add(playerCard);
                        //on second iteration
                        if (i == 1)
                        {
                            newBattleCards.Add(playerCard);
                        }
                    }
                    else
                    {
                        this.outOfCards = true;
                        return;
                    }
                }
            }

            //call Battle again with new battlecards
            Battle(newBattleCards[0], newBattleCards[1]);
        }

        //method that returns a string of the cardsDealt and battleLog.
        public string GetGameSummary()
        {
            return this.cardsDealt + this.battleLog + this.winningPlayer;
        }
    }
}