using System;
using CardClasses;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                create a deck
                shuffle it
                create 2 bjhands
                add a card from the deck to the player's hand
                add a card from the deck to the dealer's hand
                repeat that process one more time
    
                show the player's hand and score
                show just the 2nd card for the dealer
    
                ask the user if they want another card
                while the answer is yes
                    add a card from the deck to the player's hand
                    show the player's hand and the score
                    ask again
                end while    

                if the player is busted
                    print("You busted.  The dealer (computer) wins!")
                else
                    show the dealer's hand
                    while the dealer's score < 17
                        deal a card
                        show it
                        add the card to the dealer's hand and show the dealer's score
	            end while
                    if dealer is busted
                        print("The dealer busted.  You win!")
                    else if the player's score > dealer's score
                        print("You win.")
                    else if the dealer's score > the player's score
                        print("The dealer wins.")
                    else
                        print("It's a tie.")
                    end if
                end if
             */
            bool playing = true;
            string playAgain;
            do {
                Deck deck = new Deck();
                BJHand dealer = new BJHand();
                BJHand player = new BJHand();

                //Shuffles and adds a card to each hand since Discard is exempt
                bool matching = false;
                Card dealCard = new Card();
                Card playCard = new Card();
                do
                {
                    deck.Shuffle();
                    dealCard = deck[0];
                    deck.Shuffle();
                    playCard = deck[0];
                    if (dealCard.HasMatchingSuit(playCard) && dealCard.HasMatchingValue(playCard))
                        matching = true;
                    else
                    {
                        matching = false;
                        dealer.AddCard(dealCard);
                        player.AddCard(playCard);
                    }
                } while (matching);
                //reapeat one more time to 
                do
                {
                    deck.Shuffle();
                    dealCard = deck[0];
                    deck.Shuffle();
                    playCard = deck[0];
                    if (dealCard.HasMatchingSuit(playCard) && dealCard.HasMatchingValue(playCard))
                        matching = true;
                    else
                    {
                        matching = false;
                        dealer.AddCard(dealCard);
                        player.AddCard(playCard);
                    }
                } while (matching);

                //After making sure no duplicates were drawn, display  player cards/score and Dealer's second card
                Console.WriteLine("Your hand: ");
                Console.WriteLine(player.ToString());
                Console.WriteLine("Score: " + player.Score);
                Console.WriteLine("Dealer's 2nd card: " + dealCard);

                //ask if they want to draw another and break down the input into either a "n" or a "y"
                Console.Write("Do you want to draw another card?(y/n): ");
                string drawing = ((Console.ReadLine().Trim()).ToLower()).Substring(0, 1);

                int drawNum = 2;
                while(drawing == "y")
                {
                    drawNum++;
                    player.AddCard(deck[drawNum]);
                    Console.WriteLine("Your new hand: ");
                    Console.WriteLine(player.ToString());
                    Console.WriteLine("Score: " + player.Score);
                    Console.Write("Want to draw again?: ");
                    drawing = ((Console.ReadLine().Trim()).ToLower()).Substring(0, 1);
                }

                if (player.IsBusted)
                {
                    Console.WriteLine("You're busted, the Dealer wins");
                    Console.Write("Would you like to play again?(y/n): ");
                    playAgain = ((Console.ReadLine().Trim()).ToLower()).Substring(0, 1);
                    if (playAgain == "y")
                        playing = true;
                    else
                        playing = false;
                }
                else
                {
                    Console.WriteLine("Dealer's Hand:");
                    Console.WriteLine(dealer.ToString());
                    Console.WriteLine(dealer.Score);
                    int compNum = drawNum + 1;
                    while (dealer.Score < 17)
                    {
                        dealer.AddCard(deck[compNum]);
                        Console.WriteLine("Dealer draws " + deck[compNum].ToString());
                        compNum++;
                        Console.WriteLine(dealer.Score);
                    }
                    //Determine who won or if it was a tie and ak if the player wants to play again in any situation
                    if (dealer.IsBusted)
                        Console.WriteLine("Dealer busted, you win!");
                    else if (dealer.Score > player.Score)
                        Console.WriteLine("Dealer wins");
                    else if (player.Score > dealer.Score)
                        Console.WriteLine("You win!");
                    else
                        Console.WriteLine("It's a tie, well played");
                    Console.Write("Would you like to play again?(y/n): ");
                    playAgain = ((Console.ReadLine().Trim()).ToLower()).Substring(0, 1);
                    if (playAgain == "y")
                        playing = true;
                    else
                        playing = false;
                }
            } while (playing);
        }
    }
}
