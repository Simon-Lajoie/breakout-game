using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Project_UI_Brick
{
    public class Brick : PictureBox
    {
        static private Random random_generator = new Random();
        private int num;
        public bool InPlay  // in play properties
        {
            set
            {
                this.Visible = value;
            }
            get
            {
                return this.Visible;
            }
        }

        public int max_num_hits_allowed { get; set;}

        public int num_hits { get; set; }

        //contructor
        public Brick()
        {   
            // create a random number
            num = random_generator.Next(1, 5);
            if (num == 1)
            {
                this.BackgroundImage = Properties.Resources.Brick1;
            }
            else if (num == 2)
            {
                this.BackgroundImage = Properties.Resources.Brick2;
            }
            else if (num == 3)
            {
                this.BackgroundImage = Properties.Resources.Brick3;
            }
            else if (num == 4)
            {
                this.BackgroundImage = Properties.Resources.Brick4;
            }
            else
            {
                this.BackgroundImage = Properties.Resources.Brick5;
            }
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackColor = Color.Transparent;
            num_hits = 0;                                               // set number of this to 0
            max_num_hits_allowed = 1;                                   // set maximum number of hits to 1
            InPlay = true;                                              // set 'in play' properties to true
        }
        // =====================================================================================             
        // if this brick is visible, was it hit?  (if yes, return true, else return false)                 
        // ===================================================================================== 
        public bool Brick_Collision(Ball ball, int score)                 
        {
            if (this.InPlay && ball.Bounds.IntersectsWith(this.Bounds))                 
            {
                num_hits++;                                             // if yes, add 1 to the num_hits and check if it is bigger than the maximum amount of hit that it is allowed
                if (num_hits > this.max_num_hits_allowed)               
                {
                    this.InPlay = false;                                // if yes, consider the brick destroyed and not in play anymore. Make the brick invisible.               
                }
                else
                {                                                                     // if it was hit, but not destroyed, change the brick image to a broken brick.
                    if (num == 1)
                    {
                        this.BackgroundImage = Properties.Resources.Brick1_broken;
                    }
                    else if (num == 2)
                    {
                        this.BackgroundImage = Properties.Resources.Brick2_broken;
                    }
                    else if (num == 3)
                    {
                        this.BackgroundImage = Properties.Resources.Brick3_broken;
                    }
                    else if (num == 4)
                    {
                        this.BackgroundImage = Properties.Resources.Brick4_broken;
                    }
                    else
                    {
                        this.BackgroundImage = Properties.Resources.Brick5_broken;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
