using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Player
    {
        public string Name { get; set; }
        private List<Card> hand;

        public Player(string name)
        {
            this.Name = name;
            this.hand = new List<Card>();
        }

        //adds a list of the won cards from the last cards in play during a battle to the players current hand.
        public void AddCardsToHand(List<Card> newCards)
        {
            this.hand.AddRange(newCards);
        }

        //returns the card on top of the players hand/deck (first item in list) and removes it from hand.
        public Card PlayCard()
        {
            Card playedCard = this.hand.First();
            this.hand.RemoveAt(0);
            return playedCard;
        }

        //returns number of cards in players hand.
        public int GetScore()
        {
            return this.hand.Count;
        }
    }
}