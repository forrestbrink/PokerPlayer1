using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerPlayer
{
    class Deck
    {
        public List<Card> Cards { get; set; }
        public List<Card> DealtCards { get; set; }
        public Deck()
        {
            //initialize the list of cards
            this.Cards = new List<Card>();
            //initialize the list of dealt cards
            this.DealtCards = new List<Card>();

            //for each suit
            for (int s = 1; s <= 4; s++)
            {
                //an for each rank
                for (int r = 2; r <= 14; r++)
                {
                    //create a new card and add it to the card list.
                    this.Cards.Add(new Card((Rank)r, (Suit)s));
                }
            }
        }
        //shuffle cards
        public void Shuffle()
        {
            //return card to deck
            this.Cards.AddRange(DealtCards);
            //clear list
            this.DealtCards.Clear();
            List<Card> shuffled = new List<Card>();
            //create random number generator
            Random rng = new Random();
            //loop through deck of cards
            while (this.Cards.Count > 0)
            {
                //random card
                Card card = this.Cards[rng.Next(0, this.Cards.Count - 1)];
                shuffled.Add(card);
                this.Cards.Remove(card);
            }
            this.Cards = shuffled;
        }

        public void PrintDeck()
        {
            Console.WriteLine(string.Join("\n", this.Cards.Select(x => x.GetCardString())));
        }

        public List<Card> Deal(int numberOfCards)
        {
            List<Card> hand = new List<Card>();
            for (int i = 0; i < numberOfCards; i++)
            {
                hand.Add(Cards.Last());
                DealtCards.Add(Cards.Last());
                Cards.Remove(Cards.Last());
            }
            return hand;
        }
    }
}
