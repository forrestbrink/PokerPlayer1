using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerPlayer
{
    class Program
    {
        //creat enumerator for the hands of poker
        public enum HandRank
        {
            HighCard,
            OnePair,
            TwoPairs,
            ThreeofKind,
            Straight,
            Flush,
            FullHouse,
            FourofaKind,
            StraightFlush,
            RoyalFlush
        }
        static void Main(string[] args)
        {
            Player player = new Player();
            //print to console what hand the user has
            if (player.Pair() == true)
            {
                Console.WriteLine("\nYou have a Pair");
            }
            if (player.TwoPair() == true)
            {
                Console.WriteLine("\nYou have a Two Pair");
            }
            if (player.ThreeOfAKind() == true)
            {
                Console.WriteLine("\nYou have Three of A Kind");
            }
            if (player.Straight() == true)
            {
                Console.WriteLine("\nYou have a Straight");
            }
            if (player.FullHouse() == true)
            {
                Console.WriteLine("\nYou have a Full House");
            }
            if (player.RoyalFlush() == true)
            {
                Console.WriteLine("\nYou have a Royal Flush");
            }
            if (player.FourOfAKind() == true)
            {
                Console.WriteLine("\nYou have Four Of A Kind");
            }
            if (player.StraightFlush() == true)
            {
                Console.WriteLine("\nYou have a Straight Flush");
            }
            player.HasHighCard();
            //keep window open
            Console.ReadKey();
        }
    }
}
