using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class BJHand : Hand
    {
        public BJHand() : base() { }
        
        public BJHand(Deck d, int numCards) : base(d, numCards) { }

        public bool HasAce
        {
            get
            {
                if (HasCard(1))
                    return true;
                else
                    return false;
            }
        }

        public int Score
        {
            get
            {
                int score = 0;
                foreach(Card c in cards)
                {
                    if (c.IsFaceCard())
                        score += 10;
                    else
                        score += c.Value;
                }

                if (this.HasAce && score <= 11)
                    score += 10;

                return score;
            }
        }

        public bool IsBusted
        {
            get
            {
                if (Score > 21)
                    return true;
                else
                    return false;
            }
        }


    }
}
