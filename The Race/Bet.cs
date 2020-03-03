using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Race
{
    public class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        public string GetDescription()
        {
            if (Amount == 0)
                return Bettor.Name + " hasn't placed a bet";
            else
                return Bettor.Name + " bets " + Amount + " on dog " + Dog;
        }


        public int Payout(int winner)
        {
            if (winner == Dog)
                return Amount;
            else
                return -Amount;
        }
    }
}
