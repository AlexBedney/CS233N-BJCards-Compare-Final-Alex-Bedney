using System;
using System.Collections.Generic;
using CardClasses;

namespace CardTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //Old tester methods
            /*
            TestingConstructors();
            TestingGetters();
            TestingSetters();
            TestingBools();
            */

            //Hand tester methods
            /*
            HandConstructor();
            AddTesters();
            IndexTester();
            /**/

            //BJHand tester methods
            /*
            BJHandConstructor();
            BJHasAceTester();
            BJScoreAndIsBustedTester();
             /**/

            //ComparisonTester();
            EnumerableTester();
        }

        static void EnumerableTester()
        {
            Deck deck = new Deck();
            deck.Shuffle();
            Hand hand = new Hand(deck, 8);

            foreach (Card c in hand)
                Console.WriteLine(c.ToString());
        }

        static void ComparisonTester()
        {
            Deck deck = new Deck();
            deck.Shuffle();
            List<Card> sortList = new List<Card>();
            for (int i = 0; i < 8; i++)
                sortList.Add(deck[i]);
            Console.WriteLine("Unsorted list of cards: ");
            foreach (Card c in sortList)
                Console.WriteLine(c.ToString());

            int prevInd = 0;
            for (int i = 1; i < sortList.Count; i++)
                sortList[prevInd].CompareTo(sortList[i]);
            sortList.Sort();
            Console.WriteLine("Sorted list of cards: ");
            foreach (Card c in sortList)
                Console.WriteLine(c.ToString());
        }

        static void BJHandConstructor()
        {
            Deck d1 = new Deck();
            BJHand b1 = new BJHand();
            BJHand b2 = new BJHand(d1, 2);

            Console.WriteLine("expecting nothing: " + b1.ToString());
            Console.WriteLine("Expecting two cards to be drawn: " + b2.ToString());

            d1.Shuffle();
            BJHand b3 = new BJHand(d1, 2);
            Console.WriteLine("Expecting two more cards to be drawn: " + b3.ToString());
        }

        static void BJHasAceTester()
        {
            Deck d1 = new Deck();
            BJHand b1 = new BJHand(d1, 2);
            d1.Shuffle();
            BJHand b2 = new BJHand(d1, 2);

            Console.WriteLine("Expecting true: " + b1.HasAce);
            Console.WriteLine("B2's hand: ");
            Console.WriteLine(b2.ToString());
            Console.WriteLine("Expecting true depending on previous cards listed: " + b2.HasAce);
        }

        static void BJScoreAndIsBustedTester()
        {
            Deck d1 = new Deck();
            d1.Shuffle();
            BJHand b1 = new BJHand(d1, 2);
            d1.Shuffle();
            BJHand b2 = new BJHand(d1, 3);

            Console.WriteLine(b1.ToString());
            Console.WriteLine("Expecting the score: " + b1.Score);
            Console.WriteLine("Expecting bool: " + b1.IsBusted);


            Console.WriteLine(b2.ToString());
            Console.WriteLine("Expecting the score: " + b2.Score);
            Console.WriteLine("Expecting True if score > 21: " + b2.IsBusted);
        }

        static void HandConstructor()
        {
            Deck d1 = new Deck();
            d1.Shuffle();
            Hand h1 = new Hand();
            Hand h2 = new Hand(d1, 3);

            Console.WriteLine(d1.ToString());
            Console.WriteLine("Hand 1:");
            Console.WriteLine(h1.ToString());
            Console.WriteLine("Hand 2:");
            Console.WriteLine(h2.ToString());
        }

        static void AddTesters()
        {
            Deck d1 = new Deck();
            d1.Shuffle();
            Hand h1 = new Hand(d1, 3);

            Console.WriteLine("Hand 1 before adding:");
            Console.WriteLine(h1.ToString());
            h1.AddCard(d1[4]);
            Console.WriteLine("Hand 1 after adding and before delete:");
            Console.WriteLine(h1.ToString());
        }

        static void IndexTester()
        {
            Deck d1 = new Deck();
            Hand h1 = new Hand(d1, 3);

            Console.WriteLine("Hand 1:");
            Console.WriteLine(h1.ToString());
            Console.WriteLine(h1.IndexOf(1, 2));
        }

        //
        /*
        static void TestingConstructors()
        {
            Card c1 = new Card();
            Card c2 = new Card(11, 1);

            Console.WriteLine("Expecting nothing: " + c1.ToString());
            Console.WriteLine("Expecting Jack of Clubs: " + c2.ToString());
        }

        static void TestingGetters()
        {
            // Gets and validates value for card
            Console.Write("Please enter what value you want the card to be: ");
            string valueInput = Console.ReadLine();
            int valNum = ValidNum(ref valueInput, 13);
            // Gets and validates the suit of the card
            Console.Write("Please enter what suit you want the card to be: ");
            string suitInput = Console.ReadLine();
            int suitNum = ValidNum(ref suitInput, 4);
            Card c1 = new Card(valNum, suitNum);

            Console.WriteLine("Expecting: " + valueInput + " of " + suitInput);
            Console.WriteLine(c1.ToString());
        }

        static void TestingSetters()
        {
            //Builds a card to later have it's values changed
            Card c1 = new Card(5, 3);

            c1.Value = 7;
            c1.Suit = 2;

            Console.WriteLine("Expecting 7 of Diamonds: " + c1.ToString());
        }

        static int ValidNum(ref string s, int max)
        {
            //Takes in string and sees if it can be parsed
            bool valid = false;
            do
            {
                int num = 0;
                if (int.TryParse(s, out num) != false && (int.Parse(s) >= 1 && int.Parse(s) <= max))
                    return num = int.Parse(s);
                else
                {
                    Console.Write("That is an invalid number, please try again: ");
                    s = Console.ReadLine();
                }
            } while (!valid);

            return 0;
        }

        static void TestingBools()
        {
            //Tests each appropriate bool function within the Card class displaying expected value and given value
            Card c1 = new Card(1, 1);
            Card c2 = new Card(11, 2);
            Console.Write("Expecting False for Isface: ");
            Console.WriteLine(c1.IsFaceCard());
            Console.Write("Expecting True for Isface: ");
            Console.WriteLine(c2.IsFaceCard());

            Console.Write("Expecting False for IsRed: ");
            Console.WriteLine(c1.IsRed());
            Console.Write("Expecting True for IsRed: ");
            Console.WriteLine(c2.IsRed());

            Console.Write("Expecting True for IsBlack: ");
            Console.WriteLine(c1.IsBlack());
            Console.Write("Expecting False for IsBlack: ");
            Console.WriteLine(c2.IsBlack());

            Console.Write("Expecting False for IsDiamond: ");
            Console.WriteLine(c1.IsDiamond());
            Console.Write("Expecting True for IsDiamond: ");
            Console.WriteLine(c2.IsDiamond());

            Console.Write("Expecting True for IsClub: ");
            Console.WriteLine(c1.IsClub());
            Console.Write("Expecting False for IsClub: ");
            Console.WriteLine(c2.IsClub());

            Console.Write("Expecting True for IsAce: ");
            Console.WriteLine(c1.IsAce());
            Console.Write("Expecting False for IsAce: ");
            Console.WriteLine(c2.IsAce());
        }
        */
    }
}
