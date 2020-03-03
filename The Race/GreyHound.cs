using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Race
{
    public class GreyHound
    {
        public int StartPosition;
        public int RaceTrackLength;
        public PictureBox MyPictureBox;
        public int Location =0;
        public Random Randomizer;


        public bool Run()
        {
            Location += Randomizer.Next(1, 4);
            MyPictureBox.Left = StartPosition + Location;

            if (MyPictureBox.Left >= RaceTrackLength)
                return true;
            else
                return false;

        }

        public void TakeStartingPosition()
        {
            Location = 0;
            MyPictureBox.Left = StartPosition;
        }
    }
}
