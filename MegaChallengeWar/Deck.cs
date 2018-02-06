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
            List<string> cardSuits = new List<string> { "Clubs", "Diamonds", "Hearts", "Spades" };
            List<string> cardRank = new List<string> { "Ace", "King", "Queen", "Jack", "10", "9", "8", "7", "6", "5", "4", "3", "2" };

            //create a Card object for each rank of each suit
            foreach(string suit in cardSuits)
            {
                int cardValue = cardRank.Count; 
                foreach(string rank in cardRank)
                {
                    this.cards.Add(new Card(rank + " of " + suit, cardValue));
                    cardValue--; //subatract value so that next card is of lesser rank. continues to last card "2" which should be of least rank
                }
            }
        }

        //randomly gets card from deck, then removes that card from the deck. 
        public Card GetCard()
        {
            int cardIndex = rand.Next(GetDeckSize());
            Card cardDrawn = this.cards[cardIndex];
            this.cards.RemoveAt(cardIndex);
            return cardDrawn;
        }

        public int GetDeckSize()
        {
            return this.cards.Count;
        }
    }
}