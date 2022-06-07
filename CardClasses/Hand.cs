using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class Hand
    {
        protected List<Card> cards = new List<Card>();

        public Hand() { }

        public Hand(Deck d, int numCard)
        {
            for (int i = 0; i < numCard; i++)
                cards.Add(d[i]);
        }

        public int NumCards
        {
            get
            {
                return cards.Count;
            }
        }

        public void AddCard(Card c)
        {
            cards.Add(c);
        }

        

        public Card GetCard(int index)
        {
            return cards[index];
        }

        public bool HasCard(Card c)
        {
            if (IndexOf(c) > -1)
                return true;
            else
                return false;
        }

        public bool HasCard(int value)
        {
            if (IndexOf(value) > -1)
                return true;
            else
                return false;
        }

        public bool HasCard(int value, int suit)
        {
            if (IndexOf(value, suit) > -1)
                return true;
            else
                return false;
        }

        // Looked at in break room during class, exempted due to strange bug
        /*
        public Card DiscardCard(int index)
        {
            Card out = cards[index];
            return out;
        }
        */

        public int IndexOf(Card c)
        {
            for (int i = 0; i < cards.Count; i++)
                if (cards[i] == c)
                    return i;
            return -1;
        }

        public int IndexOf(int value)
        {

            for (int i = 0; i < cards.Count; i++)
                if (cards[i].Value == value)
                    return i;
            return -1;
        }

        public int IndexOf(int value, int suit)
        {
            for (int i = 0; i < cards.Count; i++)
                if (cards[i].Value == value && cards[i].Suit == suit)
                    return i;
            return -1;
        }

        public override string ToString()
        {
            string output = "";
            foreach (Card c in cards)
                output += c.ToString() + "\n";
            return output;
        }
    }
}
