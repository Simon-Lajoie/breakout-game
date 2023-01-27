using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// ==============================================================================================================================================================================
// Simon Lajoie
// ==============================================================================================================================================================================
// BREAKOUT GAME FEATURES
// ==============================================================================================================================================================================
// - Includes all the basic functionnalities (moving ball, bricks, paddle, bounces, new ball direction each game, etc.)
// - 4 LEVELS : Easy, Medium, Hard, Extreme
// - The level extreme features a paddle that is constantly in movement. (example: If Right arrow is pressed, the paddle will move to the right until the Left arrow is pressed.)
// - Icons for the form and executable
// - Fully resizable form. (Bricks, ball and paddle position have scaling values)
// - Countdown before the game starts
// - Random image are assigned to each bricks when drawing them
// - Brick class, needs 2 hit to destroy the bricks.
// - Embed pictures using resources
// ==============================================================================================================================================================================  

namespace Project_UI_Brick
{
    public partial class Breakout_Game : Form
    {
        // =====================================================================================         
        // global variables         
        // =====================================================================================   
        private int score = 0;
        private List<Brick> Brick_List = new List<Brick>();
        private List<string> Levels_List = new List<string>();
        private bool Game_Over;
        private bool brick_hit;
        private Keys current_Pressed_Key;
        private const int POINTS_PER_TOUCH_BRICK = 5;
        private const int POINTS_PER_BREAK_BRICK = 10;
        private const int POINTS_PER_PADDLE_TOUCH = -1;
        private const int NUM_ROW_EASY = 4;
        private const int NUM_ROW_MEDIUM = 5;
        private const int NUM_ROW_HARD = 6;
        private const int NUM_ROW_EXTREME = 6;
        private const int NUM_COL_EASY = 5;
        private const int NUM_COL_MEDIUM = 10;
        private const int NUM_COL_HARD = 15;
        private const int NUM_COL_EXTREME = 15;
        private int num_row_level;
        private int num_col_level;
        private const int PADDLE_WIDTH_EASY = 200;
        private const int PADDLE_WIDTH_MEDIUM = 170;
        private const int PADDLE_WIDTH_HARD = 140;
        private const int PADDLE_WIDTH_EXTREME = 120;
        private const int INTERVAL_EASY = 20;
        private const int INTERVAL_MEDIUM = 20;   
        private const int INTERVAL_HARD = 20;
        private const int INTERVAL_EXTREME = 20;
        private const int BALL_VELOCITY_EASY = 10;
        private const int BALL_VELOCITY_MEDIUM = 15;
        private const int BALL_VELOCITY_HARD = 20;
        private const int BALL_VELOCITY_EXTREME = 15;
        private const int PADDLE_SPEED_EASY = 10;
        private const int PADDLE_SPEED_MEDIUM = 15;
        private const int PADDLE_SPEED_HARD = 25;
        private const int PADDLE_SPEED_EXTREME = 20;
        private bool is_extreme = false;
        private int seconds = 0;
        // =====================================================================================        
        // Initialize the Form         
        // =====================================================================================  
        public Breakout_Game()
        {
            InitializeComponent();
            // set the event handler to Suppress_Arrow_Keys for every control on the form. 
            foreach (Control control in this.Controls)
            {
                control.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Suppress_Arrow_Keys);   // (Copied from the Form1.Designer.cs form)
            }
            // fill the list of level and put them in combo box
            Levels_List.Add("Easy");
            Levels_List.Add("Medium");
            Levels_List.Add("Hard");
            Levels_List.Add("Extreme");
            cb_level.DataSource = Levels_List;           
        }

        // =====================================================================================        
        // get the level from the drop down and make the changes based on the selected level 
        // =====================================================================================           
        private void cb_level_SelectedIndexChanged(object sender, EventArgs e)
        {
            Check_Selected_Level();
        }
        public void Check_Selected_Level()         // Select level based on the selected item in the combo box. If 0 -> easy, 1 -> medium, 2 -> hard, else -> extreme
        {
            if (cb_level.SelectedIndex != -1)
            {
                if (cb_level.SelectedIndex == 0)              // LEVEL EASY
                {
                    New_Game_Easy();
                }
                else if (cb_level.SelectedIndex == 1)         // LEVEL MEDIUM
                {
                    New_Game_Medium();
                }
                else if (cb_level.SelectedIndex == 2)         // LEVEL HARD
                {
                    New_Game_Hard();
                }
                else                                          // LEVEL EXTREME
                {
                    New_Game_Extreme();
                }
            }
        }
        public void New_Game_Easy()                   // LEVEL EASY
        {
            paddle.Width = PADDLE_WIDTH_EASY;         // resize the paddle based on the level         
            paddle.Speed = PADDLE_SPEED_EASY;         // change the paddle speed based on the level
            ball.Velocity = BALL_VELOCITY_EASY;       // change the ball velocity based on the level
            num_row_level = NUM_ROW_EASY;             // change the row number of brick based ont the level
            num_col_level = NUM_COL_EASY;             // change the column number of brick based on the level
            Draw_Bricks();                            // draw the bricks based on the level
            is_extreme = false;                       // set 'is extreme' to false to not activate the constant paddle movement feature.
            timer_game.Interval = INTERVAL_EASY;      // change the time interval based on the level
        }
        public void New_Game_Medium()                 // LEVEL MEDIUM
        {
            paddle.Width = PADDLE_WIDTH_MEDIUM;
            paddle.Speed = PADDLE_SPEED_MEDIUM;
            ball.Velocity = BALL_VELOCITY_MEDIUM;
            num_row_level = NUM_ROW_MEDIUM;
            num_col_level = NUM_COL_MEDIUM;
            Draw_Bricks();
            is_extreme = false;
            timer_game.Interval = INTERVAL_MEDIUM;
        }
        public void New_Game_Hard()                   // LEVEL HARD
        {
            paddle.Width = PADDLE_WIDTH_HARD;
            paddle.Speed = PADDLE_SPEED_HARD;
            ball.Velocity = BALL_VELOCITY_HARD;
            num_row_level = NUM_ROW_HARD;
            num_col_level = NUM_COL_HARD;
            Draw_Bricks();
            is_extreme = false;
            timer_game.Interval = INTERVAL_HARD;
        }
        public void New_Game_Extreme()               // LEVEL EXTREME
        {
            paddle.Width = PADDLE_WIDTH_EXTREME;
            paddle.Speed = PADDLE_SPEED_EXTREME;
            ball.Velocity = BALL_VELOCITY_EXTREME;
            num_row_level = NUM_ROW_EXTREME;
            num_col_level = NUM_COL_EXTREME;
            Draw_Bricks();
            is_extreme = true;                        // set 'is extreme' to true. It activates the special feature where the paddle is in constant movement.
            timer_game.Interval = INTERVAL_EXTREME;
        }
        // =====================================================================================               
        // draw the 'bricks' based on the level         
        // =====================================================================================       
        public void Draw_Bricks()
        {
            // remove all previous bricks from the list 

            for (int index = 0; index < Brick_List.Count; ++index)
            {
                this.Brick_List[index].Dispose();
            }
            Brick_List.Clear();
            int width = panel_playground.Width / (num_col_level + 1);    
            int width_distance_inbetween = width / (num_col_level + 1);
            // get size of game panel to determine size of bricks     
            int height_Area = (int)((panel_playground.Height) * 0.50);   // 0.50 represent 50% of the playground area where the bricks will be. It scales well. Anything bigger will make the bricks too close to the paddle.
            int height = (height_Area / (num_row_level * 2));            // multiply the height by the number of row * 2 to get a decent, but not too big height for the bricks.
            int height_distance_inbetween = (int)(height_Area / (num_row_level) * 0.3); // 0.3 gave me a distance that I was satisfied with and scales well.
            // for each row and column create a new brick
            for (int row = 0; row < num_row_level; row++)
            {
                for (int col = 0; col < num_col_level; col++)
                {
                    Brick brick = new Brick();
                    brick.Size = new Size(width, height);
                    int x = (width_distance_inbetween * (col + 1)) + (width * col);   // the X location of a brick is calculated based on the X distance in between each brick * the column in which the current brick is + the width of the brick * the current column.
                    int y = (height_distance_inbetween * (row + 1)) + (height * row); // the Y location of a brick is calculated based on the Y distance in between each brick * the row in which the current brick is + the width of the brick * the current row.
                    brick.Location = new Point(x, y + panel_top.Height);              // add the height of the top panel so the bricks doesnt appear over the top panel
                    Brick_List.Add(brick);                                            // store the bricks in a List  
                    panel_playground.Controls.Add(brick);
                }
            }
            // bring each brick to the front so when the ball collides we don't see a square around the ball. (without it, when the ball bounds and brick bounds collide, we see a square of the background color appear briefly, even if the ball background was transparent)
            foreach (Brick brick in Brick_List)
            {
                brick.BringToFront();
            }
        }
        // =====================================================================================         
        // start a new game when 'Start' button is clicked and reset all settings
        // =====================================================================================  
        private void btn_start_Click(object sender, EventArgs e)   // NOTE ABOUT SCALING VALUES: How did I calculate them ? I just placed the controls at the wanted position on the form. Then I divided the X position by the playground panel Width and the Y position by the playground panel Height. I got the percentage of the width and the height they were at and I used that value.
        {
            Game_Over = false;                                                                                               // set the game over to false
            score = 0;                                                                                                       // set the score to 0
            lbl_score.Text = "Score: " + score;                                                                              // reset the label score text
            Check_Selected_Level();                                                                                          // check the selected level and draw the bricks and set new settings based on level
            ball.Normal();                                                                                                   // reset the ball image back to normal
            ball.Location = new Point((int) (panel_playground.Width * 0.026), (int) (panel_playground.Height* 0.50));        // set the ball starting location with scaling values
            ball.Start_Ball_Direction();                                                                                     // set a random direction for the ball
            paddle.Location = new Point((int)(panel_playground.Width * 0.07), paddle.Top);                                   // set paddle location with scaling values
            cb_level.Enabled = false;                                                                                        // disable the 'combo box level" during the game
            btn_start.Enabled = false;                                                                                       // disable the 'start button' during the game
            current_Pressed_Key = Keys.None;                                                                                 // set the current pressed key to none
            timer_countdown.Enabled = true;                                                                                  // start the countdown timer
            lbl_countdown.Location = new Point((int)(panel_playground.Width * 0.25), (int)(panel_playground.Height * 0.62)); // set the label location with scaling values
            lbl_countdown.Visible = true;                                                                                    // make the countdown label visible
        }
        // the timer countdown execute the coutdown event every 1 seconds
        private void timer_countdown_Tick(object sender, EventArgs e)
        {
            seconds++;                         // every 1000 ticks add 1 seconds
            Countdown();
        }
        // Display the coutdown based on the current second and make the game starts after 3 seconds
        public void Countdown()
        {
            if (seconds == 1)
            {
                lbl_countdown.Text = "3 !";
            }
            else if (seconds == 2)
            {
                lbl_countdown.Text = "2 !";
            }
            else if (seconds == 3)
            {
                lbl_countdown.Text = "1 !";
            }
            else
            {
                seconds = 0;                              // reset seconds to 0
                lbl_countdown.Visible = false;            // make the countdown label invisible
                lbl_countdown.Text = "4 !";               // reset countdown label text to '4 !'
                timer_countdown.Enabled = false;          // stop the countdown timer
                timer_game.Enabled = true;                // start the game timer which starts the game
            }
        }
        // =====================================================================================         
        // play the game         
        // =====================================================================================        
        private void timer_Tick(object sender, EventArgs e)
        {
            // update paddle position  
            if (current_Pressed_Key == Keys.Right)                           // if the current pressed key is right , move the paddle to the right.
            {
                paddle.Move_Right(current_Pressed_Key, panel_playground);    // send the current_pressed_key to the function in the paddle class
            }
            else if (current_Pressed_Key == Keys.Left)                       // if the current pressed key is left , move the paddle to the left.
            {
                paddle.Move_Left(current_Pressed_Key);                       // send the current_pressed_key to the function in the paddle class
            }

            // update currently pressed key label
            label1.Text = "Currently pressed key: " + current_Pressed_Key.ToString();

            // update score label                 
            lbl_score.Text = "Score: " + score.ToString();      
            
            // update ball location 
            ball.Move_Ball();

            // bounce on the paddle? (if yes, change direction)
            if (ball.Paddle_Collision(paddle, Game_Over))
            {
                score += POINTS_PER_PADDLE_TOUCH;
            }

            // bounce off the top and sides of play area? (if yes, change direction)  
            ball.Top_And_Side_Collision(panel_playground, panel_top);

            // did we hit the bottom of the play area? game over!   
            if (ball.Bottom_Collision(paddle, panel_bot))
            {
                Game_Over = true;
            }
            // ==============================================================================================================            
            // Loop through all bricks and check if any brick was hit. If yes return true and update the brick and the score                 
            // ==============================================================================================================
            foreach (Brick brick in Brick_List)                   
            {
                if (brick.Brick_Collision(ball, score))           // send the ball and the score to function in the brick class that check if there was a brick collision
                {
                    brick_hit = true;
                    if (!brick.InPlay)
                    {
                        score += POINTS_PER_BREAK_BRICK;          // if brick is not in play anymore, it means it was destroyed. Add 10 points.
                    }
                    else
                    {
                        score += POINTS_PER_TOUCH_BRICK;          // if the ball had a collision with the brick but it wasn't destroyed, it means it was touched. Add 5 points.
                    }
                }
            }
            // if we hit a brick, maybe the game is over? (i.e. no bricks left?)
            if (brick_hit)
            {
                int num_in_play = 0;
                foreach (Brick brick in Brick_List)
                {
                    if (brick.InPlay)
                    {
                        num_in_play++;
                    }
                }
                if (num_in_play > 0)    // There is still bricks in play, game is not over. Change ball direction because a brick was hit. I only make the ball direction change here and not when I check the collision because
                {                       // if the bricks are small like in the hard level, the ball can sometimes touch 2 bricks at same time and I only want the ball to change direction once or it would cause bugs.
                    ball.FlatTop();
                }
                else
                {
                    Game_Over = true;       // There is no more bricks in play, game is over. Set game over to true
                }
                brick_hit = false;          // need to set the brick hit to false after it was set to true to avoid the ball to bounce infinitely up and down.
            }
            // =======================================
            // game over?   (if yes, stop the timer)
            // =======================================
            if (Game_Over)
            {
                timer_game.Enabled = false;
                MessageBox.Show("Game over ! \nScore: " + score);
                cb_level.Enabled = true;
                btn_start.Enabled = true;
            }                          
        }

        // =====================================================================================         
        // User pressed key! (anywhere on the form).          - Keydown event handler -   
        // =====================================================================================   
        private void Breakout_Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
            {
                if (current_Pressed_Key != e.KeyCode)    // check if the current key is not the same as the new key
                {
                    current_Pressed_Key = e.KeyCode;     // if the arrow key Right or Left is pressed, set a new key variable to the current key
                }
            }
        }        
        // ===================================================================================== 
        // User let the key go (key up)     
        // =====================================================================================  
        private void Breakout_Game_KeyUp(object sender, KeyEventArgs e)
        {
            if (is_extreme)
            {
                // If the mode is extreme, do nothing. It keeps the paddle constantly moving.
            }
            else
            {
                if (e.KeyCode == current_Pressed_Key) // check if the released key is the same as the current_Pressed_Key
                {
                    current_Pressed_Key = Keys.None;    // If not, stop the paddle from moving when a the Right or Left key is released.
                }
            }
        }
        // =====================================================================================   
        // Stop Game       
        // =====================================================================================  
        private void btn_stop_Click(object sender, EventArgs e)
        {
            Game_Over = true;
        }
        // =====================================================================================        
        // Super important! suppresses .NET default behaviour  
        // of arrow keys behaving like tab keys 
        // =========================================================================
        private void Suppress_Arrow_Keys(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
            {
                e.IsInputKey = true;
            }
        }
        // =====================================================================================   
        // When the form is resized, redraw the bricks so they scale with the form dimension
        // =====================================================================================  
        private void Breakout_Game_Resize(object sender, EventArgs e)
        {
            Draw_Bricks();
        }
    }
}
