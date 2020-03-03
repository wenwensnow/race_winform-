using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Race
{
    public partial class Form1 : Form
    {
        Guy [] guys = new Guy[3];
        Random random = new Random();
        GreyHound [] hounds = new GreyHound [4];
  

        private void btn_bet_Click(object sender, EventArgs e)
        {
            string name="";
           foreach(RadioButton radioButton in radiogroup.Controls.OfType<RadioButton>())
            {
                if (radioButton.Checked) {

                    name = radioButton.Name.Substring(0,3);
                    break;
                }
            }

            Console.WriteLine(name);
            Bet_money(name);
          
        }

        public void Bet_money(string name)
        {
            int Amount = Convert.ToInt32(numericUpDown1.Value);
            int dog = Convert.ToInt32(numericUpDown2.Value);

            if (name.Contains("joe"))
            {
                if (guys[0].PlaceBet(Amount, dog))
                {
                    guys[0].MyBet.Amount = Amount;
                    guys[0].MyBet.Dog = dog;
                    guys[0].UpdateLabels();
                }
                else
                {
                    guys[0].MyBet.Amount = 0;
                    guys[0].UpdateLabels();
                }
            }

            else if (name.Contains("bob"))
            {
                if (guys[1].PlaceBet(Amount, dog))
                {
                    guys[1].MyBet.Amount = Amount;
                    guys[1].MyBet.Dog = dog;
                    guys[1].UpdateLabels();
                }
                else
                {
                    guys[1].MyBet.Amount = 0;
                    guys[1].UpdateLabels();
                }
            }
            else
            {
                if (guys[2].PlaceBet(Amount, dog))
                {
                    guys[2].MyBet.Amount = Amount;
                    guys[2].MyBet.Dog = dog;
                    guys[2].UpdateLabels();
                }
                else
                {
                    guys[2].MyBet.Amount = 0;
                    guys[2].UpdateLabels();
                }
            }
           
        }

        private void btn_race_Click(object sender, EventArgs e)
        {
            inital_race();
            timer1.Start();
        }

        private void inital_race()
        {
            if (hounds[0] != null)
            {
                foreach (GreyHound hound in hounds)
                    hound.TakeStartingPosition();

            }

            else
            {
                hounds[0] = new GreyHound()
                {
                    MyPictureBox = dog1,
                    StartPosition = dog1.Left,
                    RaceTrackLength = raceTracker.Width - dog1.Width,
                    Randomizer = random
                };
                hounds[1] = new GreyHound()
                {
                    MyPictureBox = dog2,
                    StartPosition = dog2.Left,
                    RaceTrackLength = raceTracker.Width - dog2.Width,
                    Randomizer = random
                };
                hounds[2] = new GreyHound()
                {
                    MyPictureBox = dog3,
                    StartPosition = dog3.Left,
                    RaceTrackLength = raceTracker.Width - dog3.Width,
                    Randomizer = random
                };
                hounds[3] = new GreyHound()
                {
                    MyPictureBox = dog4,
                    StartPosition = dog4.Left,
                    RaceTrackLength = raceTracker.Width - dog4.Width,
                    Randomizer = random
                };
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            for(int i = 0; i < 4; i++)
            {
                if (hounds[i].Run())
                {
                    timer1.Stop();
                    groupBox1.Enabled = true;
                    foreach (Guy guy in guys)                    
                        guy.Collect(i+1);
                    foreach (GreyHound hound in hounds)
                        hound.TakeStartingPosition();

                    MessageBox.Show("Dog " + i+1 + " won the race");
                    break;
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            guys[0] = new Guy { Name = "Joe", Cash = 50, MyRadioButton = joeradioButton, MyLabel = joeBetlabel, MyBet = new Bet { Amount=0} };
            guys[0].MyBet.Bettor = guys[0];
            guys[2] = new Guy { Name = "al", Cash = 45, MyRadioButton = alRadioButton, MyLabel = alBetLabel, MyBet = new Bet { Amount = 0 } };
            guys[2].MyBet.Bettor = guys[2];
            guys[1] = new Guy { Name = "bob", Cash = 70,MyRadioButton=bobradioButton,MyLabel=bobBetlabel, MyBet = new Bet { Amount=0}  };
            guys[1].MyBet.Bettor = guys[1];
            updateStatus();
            
        }

        public void updateStatus() // update bet and radiobutton
        {
            foreach (Guy guy in guys)
                guy.UpdateLabels();
        }


    }
}
