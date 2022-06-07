using System;

namespace CardClasses
{
    public class Card : IComparable<Card>
    {
        private static string[] values = { "", "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "Ten", "Jack", "Queen", "King" };
        private static string[] suits = { "", "Clubs", "Diamonds", "Hearts", "Spades" };
        private static Random generator = new Random();

        private int value;
        private int suit;

        public Card() { }

        public Card(int Value, int Suit)
        {
            value = Value;
            suit = Suit;
        }

        public int Value
        {
            get
            {
                return value;
            }
            set
            {
                if (!(this.value < 1 || this.value > 13))
                    this.value = value;
                else
                    throw new ArgumentException("Value must be between 1 and 13");
            }
        }

        public int Suit
        {
            get
            {
                return suit;
            }
            set
            {
                if (!(this.suit < 1 && this.suit > 4))
                    this.suit = value;
                else
                    throw new ArgumentException("Value must be between 1 and 4");
            }
        }

        public bool HasMatchingSuit(Card other)
        {
            if (this.suit == other.suit)
                return true;
            else
                return false;
        }

        public bool HasMatchingValue(Card other)
        {
            if (this.value == other.value)
                return true;
            else
                return false;
        }

        public bool IsAce()
        {
            if (this.value == 1)
                return true;
            else
                return false;
        }

        public bool IsBlack()
        {
            if (this.suit == 1 || this.suit == 4)
                return true;
            else
                return false;
        }

        public bool IsClub()
        {
            if (this.suit == 1)
                return true;
            else
                return false;
        }
        public bool IsDiamond()
        {
            if (this.suit == 2)
                return true;
            else
                return false;
        }
        public bool IsFaceCard()
        {
            if (this.value >= 11)
                return true;
            else
                return false;
        }
        public bool IsHeart()
        {
            if (this.suit == 3)
                return true;
            else
                return false;
        }
        public bool IsRed()
        {
            if (this.suit == 2 || this.suit == 3)
                return true;
            else
                return false;
        }
        public bool IsSpade()
        {
            if (this.suit == 4)
                return true;
            else
                return false;
        }

        public int CompareTo(Card other)
        {
            return String.Compare(this.value.ToString(), other.value.ToString(), StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return values[value] + " of " + suits[suit];
        }
    }
}
