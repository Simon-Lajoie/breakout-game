using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Project_UI_Brick
{
    public class Ball : PictureBox
    {
        private int vec_x;
        private int vec_y;
        private int _velocity;
        static private Random random_generator = new Random();
        public Ball()
        {
            Normal();
            this.BackgroundImageLayout = ImageLayout.Stretch;
            vec_x = 0;
            vec_y = 0;
            _velocity = 15;
        }
        public int Velocity  // Velocity properties
        {
            get
            {
                return _velocity;
            }
            set
            {
                _velocity = value;
            }
        }
        // =====================================================================================         
        // Move the ball 
        // =====================================================================================  
        public void Move_Ball()
        {
            Normal();
            int x = this.Location.X + vec_x;  // add the current X location + the vector X for the new X position
            int y = this.Location.Y + vec_y;  // add the current Y location + the vector Y for the new Y position
            this.Location = new Point(x, y);
        }
        // =====================================================================================         
        // Randomize a new angle for the ball direction (to the right) 
        // =====================================================================================  
        public void Start_Ball_Direction()
        {
            int angle = random_generator.Next(30, 75);
            double rad = Math.PI * angle / 180;
            vec_x = (int)(Velocity * Math.Cos(rad));
            vec_y = (int)(Velocity * Math.Sin(rad));
        }
        // =====================================================================================         
        // bounce on top, Right ot Left?       
        // =====================================================================================  
        public void Top_And_Side_Collision(Panel panel_playground, Panel panel_top)
        {
            if (this.Top < panel_top.Height)    // if the distance between the top edge of the ball and the top wall is smaller than the height of the top panel, change Y direction 
            {
                FlatTop();
            }
            else if (this.Left < 0 || this.Right > panel_playground.Width)    // if the distance between the left edge of the ball and the left wall is smaller than 0, or 
            {                                                                 // if the distance between the right edge of the ball and the left wall is bigger than the width of the playground, change the X direction
                this.FlatSide();
            }
        }
        // =====================================================================================         
        // bounce on paddle?  (if yes, return true and add 1 point)
        // =====================================================================================   
        public bool Paddle_Collision(Paddle paddle, bool Game_Over)
        {
            if (this.Bounds.IntersectsWith(paddle.Bounds))  // if the ball touches the paddle , return true and change the Y direction
            {
                FlatTop();
                return true;

            }
            return false;
        }
        public bool Bottom_Collision(Paddle paddle, Panel panel_bot) 
        {
            if (this.Bottom >  panel_bot.Location.Y)      // if the distance between the bottom edge of the ball and the top wall is bigger than the location Y of the bot panel
            {                                                                 // if yes return true and game is over, else return false
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Normal()
        {
            this.BackgroundImage = Properties.Resources.Ball;
        }
        public void FlatTop()
        {
            vec_y = vec_y * -1;                                           // inverse Y direction of ball
            this.BackgroundImage = Properties.Resources.Ball_flat;
        }
        public void FlatSide()
        {
            vec_x = vec_x * -1;                                           // inverse X direction of ball
            this.BackgroundImage = Properties.Resources.Ball_squished;
        }
    }
}
