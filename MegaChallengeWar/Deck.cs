using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Deck
    {
        private List<Card> cards;
        private Random rand = new Random();

        public Deck()
        {
            this.cards = new List<Card>();
        }

        //populates deck with 52 standard cards of type Card
        public void PopulateDeck()
        {

        }

        //randomly gets card from deck, then removes that card from the deck. 
        public Card GetCard()
        {
            int cardIndex = rand.Next(this.cards.Count);
            Card cardDrawn = this.cards[cardIndex];
            this.cards.RemoveAt(cardIndex);
            return cardDrawn;
        }
    }
}