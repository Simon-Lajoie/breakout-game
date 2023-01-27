using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Project_UI_Brick
{
    public class Paddle : PictureBox
    {
        private int _vec_x = 20; // speed at which the paddle moves on the X axis
        //constructor
        public Paddle()
        {
            this.BackgroundImage = Properties.Resources.paddle;     // sets the image of the paddle
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
        public int Speed  // Speed properties
        {
            get
            {
                return _vec_x;
            }
            set
            {
                _vec_x = value;
            }
        }
        // =====================================================================================         
        // move paddle if arrow key currently pressed         
        // =====================================================================================   
        public void Move_Right(Keys current_pressed_key, Panel panel_playground)     // receives the current pressed key
        {
            if (this.Location.X + this.Width/2 > panel_playground.Width)     // avoid the paddle to dissapear completely off the screen. (By adding the half width of the paddle, half of the paddle can go off the screen. It gives more space for the player.)
            {

            }
            else
            {
                int x = this.Location.X + Speed;             // add vector X to go right
                int y = this.Location.Y;
                this.Location = new Point(x, y);
            }
        }
        public void Move_Left(Keys current_pressed_key)      // receives the current pressed key
        {
            if (this.Location.X + this.Width/2 < 0)          // avoid the paddle to dissapear completely off the screen. .             
            {

            }
            else
            {
                int x = this.Location.X - Speed;             // substract the vector X to go left
                int y = this.Location.Y;
                this.Location = new Point(x, y);
            }
        }
    }
}
