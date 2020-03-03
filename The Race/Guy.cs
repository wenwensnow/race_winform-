using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Race
{
    public class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;

        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateLabels()
        {
            MyLabel.Text = MyBet.GetDescription();
            MyRadioButton.Text = Name + " has " + Cash + " bucks"; 
        }

        public void Clearbet()
        {
            MyBet.Amount = 0; 
        }

        public bool PlaceBet(int BetAmount, int DogToWin)
        {

            if (BetAmount <= Cash)
            {
                MyBet.Amount = BetAmount;
                MyBet.Dog = DogToWin;
                return true;
            }
            else
            {
                MyBet.Amount = 0;
                return false;
            }
        }

        public void Collect(int Winner)
        {

            Cash+=MyBet.Payout(Winner);
            Clearbet();
            UpdateLabels();
        }




    }
}
