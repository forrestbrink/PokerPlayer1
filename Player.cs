using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerPlayer
{
    class Player
    {
        public List<Card> Hand { get; set; }
        public Player()
        {
            //new list of hands
            this.Hand = new List<Card>();
            Deck deck = new Deck();
            //shuffle
            deck.Shuffle();
            this.Hand = deck.Deal(5);
            Console.WriteLine(string.Join("\n", this.Hand.Select(x => x.GetCardString())));
        }
        //check for royal flush
        public bool RoyalFlush()
        {
            if ((this.Hand.Select(x => x.Rank).Distinct().OrderBy(x => x).Last() - this.Hand.Select(x => x.Rank).Distinct().OrderBy(x => x).First() == 4) &&
                (this.Hand.Select(x => x.Suit).Distinct().Count() == 1) && (this.Hand.Select(x => x.Rank).OrderBy(x => x).Last() == Rank.Ace))
            {
                return true;
            }
            else return false;
        }

        //check for straight flush
        public bool StraightFlush()
        {
            if ((this.Hand.Select(x => x.Rank).Distinct().OrderBy(x => x).Last() - this.Hand.Select(x => x.Rank).Distinct().OrderBy(x => x).First() == 4) && (this.Hand.Select(x => x.Suit).Distinct().Count() == 1))
            {
                return true;
            }
            else return false;
        }

        //check for four of a kind
        public bool FourOfAKind()
        {
            if (this.Hand.Select(x => x.Rank).Distinct().Count() == 2)
            {
                IEnumerable<IGrouping<Rank, Card>> group = this.Hand.GroupBy(x => x.Rank);
                return group.Any(x => x.Count() == 4);
            }
            else return false;
        }

        //check for full house
        public bool FullHouse()
        {
            if (this.Hand.Select(x => x.Rank).Distinct().Count() == 2)
            {
                IEnumerable<IGrouping<Rank, Card>> group = this.Hand.GroupBy(x => x.Rank);
                return group.Any(x => x.Count() == 3);
            }
            else return false;
        }

        //check for flush
        public bool Flush()
        {
            return this.Hand.Select(x => x.Suit).Distinct().Count() == 1;
        }

        //check for straigh
        public bool Straight()
        {
            if (this.Hand.Select(x => x.Rank).Distinct().OrderBy(x => x).Last() - this.Hand.Select(x => x.Rank).Distinct().OrderBy(x => x).First() == 4)
            {
                return true;
            }
            else return false;
        }

        //check for three of a kind
        public bool ThreeOfAKind()
        {
            IEnumerable<IGrouping<Rank, Card>> group = this.Hand.GroupBy(x => x.Rank);
            return group.Any(x => x.Count() == 3);
        }

        //check for two pair
        public bool TwoPair()
        {
            return this.Hand.GroupBy(x => x.Rank).Where(x => x.Count() == 2).Count() == 2;
        }

        //check for pair
        public bool Pair()
        {
            return this.Hand.Select(x => x.Rank).Distinct().Count() == 4;
        }

        //find high card
        public void HasHighCard()
        {
            if (Pair() == false && TwoPair() == false && ThreeOfAKind() == false && Straight() == false && Flush() == false && FullHouse() == false
                && FourOfAKind() == false && StraightFlush() == false)
            {
                Console.WriteLine("\nHigh card is: " + this.Hand.Select(x => x.Rank).OrderBy(x => x).Last().ToString());
            }
        
        }
         }
        static void AddHighScore(int playerscore)
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            ForrestEntities db = new ForrestEntities();

            HighScore newHighScore = new HighScore();
            newHighScore.Name = playername;
            newHighScore.Date = DateTime.Now;
            newHighScore.Game = "Poker Player";
            newHighScore.Score = playerscore;

            db.HighScores.Add(newHighScore);

            db.Save();
        }
        static void DisplayHighScore()
    {
            Console.WriteLine("High Scores");
            Console.WriteLine("---------------------------------");
            Console.WriteLine();

            ForrestEntities db = new ForrestEntities();
            List<HighScore> HighScoreList = db.HighScores.Where(x => x.Game == "Poker Player").OrderBy(x => x.Score).Take(10).ToList();

            foreach (HighScore highscore in HighScoreList)
	{
		    Console.WriteLine("{0}, {1} Took {2} tries to win! {3}", HighScoreList.IndexOf(highscore) + 1, highscore.Score, highscore.Date.Value.ToShortDateString());
	}
    }
}
    }
}
