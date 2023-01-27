namespace Project_UI_Brick
{
    partial class Breakout_Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Breakout_Game));
            this.timer_game = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.panel_top = new System.Windows.Forms.Panel();
            this.cb_level = new System.Windows.Forms.ComboBox();
            this.lbl_level = new System.Windows.Forms.Label();
            this.lbl_score = new System.Windows.Forms.Label();
            this.panel_bot = new System.Windows.Forms.Panel();
            this.panel_playground = new System.Windows.Forms.Panel();
            this.lbl_countdown = new System.Windows.Forms.Label();
            this.paddle = new Project_UI_Brick.Paddle();
            this.ball = new Project_UI_Brick.Ball();
            this.timer_countdown = new System.Windows.Forms.Timer(this.components);
            this.panel_top.SuspendLayout();
            this.panel_bot.SuspendLayout();
            this.panel_playground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paddle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            this.SuspendLayout();
            // 
            // timer_game
            // 
            this.timer_game.Interval = 30;
            this.timer_game.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(984, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Currently pressed key: ";
            this.label1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Suppress_Arrow_Keys);
            // 
            // btn_start
            // 
            this.btn_start.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_start.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.Location = new System.Drawing.Point(17, 3);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(99, 33);
            this.btn_start.TabIndex = 2;
            this.btn_start.TabStop = false;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            this.btn_start.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Suppress_Arrow_Keys);
            // 
            // btn_stop
            // 
            this.btn_stop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_stop.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stop.Location = new System.Drawing.Point(132, 3);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(99, 33);
            this.btn_stop.TabIndex = 3;
            this.btn_stop.TabStop = false;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            this.btn_stop.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Suppress_Arrow_Keys);
            // 
            // panel_top
            // 
            this.panel_top.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_top.BackColor = System.Drawing.SystemColors.Control;
            this.panel_top.Controls.Add(this.cb_level);
            this.panel_top.Controls.Add(this.lbl_level);
            this.panel_top.Controls.Add(this.btn_stop);
            this.panel_top.Controls.Add(this.btn_start);
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(1144, 40);
            this.panel_top.TabIndex = 5;
            this.panel_top.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Suppress_Arrow_Keys);
            // 
            // cb_level
            // 
            this.cb_level.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_level.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_level.FormattingEnabled = true;
            this.cb_level.Location = new System.Drawing.Point(908, 6);
            this.cb_level.Name = "cb_level";
            this.cb_level.Size = new System.Drawing.Size(192, 29);
            this.cb_level.TabIndex = 5;
            this.cb_level.TabStop = false;
            this.cb_level.SelectedIndexChanged += new System.EventHandler(this.cb_level_SelectedIndexChanged);
            // 
            // lbl_level
            // 
            this.lbl_level.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_level.AutoSize = true;
            this.lbl_level.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_level.Location = new System.Drawing.Point(822, 9);
            this.lbl_level.Name = "lbl_level";
            this.lbl_level.Size = new System.Drawing.Size(69, 21);
            this.lbl_level.TabIndex = 4;
            this.lbl_level.Text = "Level: ";
            // 
            // lbl_score
            // 
            this.lbl_score.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_score.AutoSize = true;
            this.lbl_score.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_score.Location = new System.Drawing.Point(11, 3);
            this.lbl_score.Name = "lbl_score";
            this.lbl_score.Size = new System.Drawing.Size(71, 21);
            this.lbl_score.TabIndex = 5;
            this.lbl_score.Text = "Score: ";
            // 
            // panel_bot
            // 
            this.panel_bot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_bot.BackColor = System.Drawing.SystemColors.Control;
            this.panel_bot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_bot.Controls.Add(this.lbl_score);
            this.panel_bot.Controls.Add(this.label1);
            this.panel_bot.Location = new System.Drawing.Point(0, 581);
            this.panel_bot.Name = "panel_bot";
            this.panel_bot.Size = new System.Drawing.Size(1144, 30);
            this.panel_bot.TabIndex = 6;
            this.panel_bot.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Suppress_Arrow_Keys);
            // 
            // panel_playground
            // 
            this.panel_playground.BackColor = System.Drawing.Color.Transparent;
            this.panel_playground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_playground.Controls.Add(this.lbl_countdown);
            this.panel_playground.Controls.Add(this.paddle);
            this.panel_playground.Controls.Add(this.ball);
            this.panel_playground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_playground.Location = new System.Drawing.Point(0, 0);
            this.panel_playground.MinimumSize = new System.Drawing.Size(1144, 611);
            this.panel_playground.Name = "panel_playground";
            this.panel_playground.Size = new System.Drawing.Size(1144, 611);
            this.panel_playground.TabIndex = 9;
            // 
            // lbl_countdown
            // 
            this.lbl_countdown.AutoSize = true;
            this.lbl_countdown.BackColor = System.Drawing.Color.Transparent;
            this.lbl_countdown.Font = new System.Drawing.Font("Rockwell", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_countdown.Location = new System.Drawing.Point(276, 402);
            this.lbl_countdown.Name = "lbl_countdown";
            this.lbl_countdown.Size = new System.Drawing.Size(100, 72);
            this.lbl_countdown.TabIndex = 3;
            this.lbl_countdown.Text = "4 !";
            this.lbl_countdown.Visible = false;
            // 
            // paddle
            // 
            this.paddle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.paddle.BackColor = System.Drawing.Color.Transparent;
            this.paddle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("paddle.BackgroundImage")));
            this.paddle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.paddle.Location = new System.Drawing.Point(472, 551);
            this.paddle.Name = "paddle";
            this.paddle.Size = new System.Drawing.Size(200, 30);
            this.paddle.Speed = 20;
            this.paddle.TabIndex = 2;
            this.paddle.TabStop = false;
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.Color.Transparent;
            this.ball.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ball.BackgroundImage")));
            this.ball.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ball.Location = new System.Drawing.Point(555, 342);
            this.ball.Margin = new System.Windows.Forms.Padding(2);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(31, 31);
            this.ball.TabIndex = 1;
            this.ball.TabStop = false;
            this.ball.Velocity = 15;
            this.ball.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Suppress_Arrow_Keys);
            // 
            // timer_countdown
            // 
            this.timer_countdown.Interval = 1000;
            this.timer_countdown.Tick += new System.EventHandler(this.timer_countdown_Tick);
            // 
            // Breakout_Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1144, 611);
            this.Controls.Add(this.panel_bot);
            this.Controls.Add(this.panel_top);
            this.Controls.Add(this.panel_playground);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1160, 650);
            this.Name = "Breakout_Game";
            this.Text = "Breakout Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Breakout_Game_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Breakout_Game_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Suppress_Arrow_Keys);
            this.Resize += new System.EventHandler(this.Breakout_Game_Resize);
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.panel_bot.ResumeLayout(false);
            this.panel_bot.PerformLayout();
            this.panel_playground.ResumeLayout(false);
            this.panel_playground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paddle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Ball ball;
        private System.Windows.Forms.Timer timer_game;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Label lbl_level;
        private System.Windows.Forms.Label lbl_score;
        private System.Windows.Forms.Panel panel_bot;
        private System.Windows.Forms.Panel panel_playground;
        private System.Windows.Forms.ComboBox cb_level;
        private Paddle paddle;
        private System.Windows.Forms.Label lbl_countdown;
        private System.Windows.Forms.Timer timer_countdown;
    }
}

