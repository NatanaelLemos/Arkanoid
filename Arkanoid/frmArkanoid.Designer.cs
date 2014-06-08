namespace Arkanoid
{
    partial class frmArkanoid
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
            this.board = new System.Windows.Forms.PictureBox();
            this.tmrMovements = new System.Windows.Forms.Timer(this.components);
            this.ball = new Arkanoid.Ball();
            ((System.ComponentModel.ISupportInitialize)(this.board)).BeginInit();
            this.SuspendLayout();
            // 
            // board
            // 
            this.board.BackColor = System.Drawing.Color.Red;
            this.board.Location = new System.Drawing.Point(156, 431);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(102, 15);
            this.board.TabIndex = 1;
            this.board.TabStop = false;
            // 
            // tmrMovements
            // 
            this.tmrMovements.Interval = 10;
            this.tmrMovements.Tick += new System.EventHandler(this.tmrMovements_Tick);
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.Color.Red;
            this.ball.Location = new System.Drawing.Point(199, 408);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(20, 20);
            this.ball.TabIndex = 2;
            // 
            // frmArkanoid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 451);
            this.Controls.Add(this.ball);
            this.Controls.Add(this.board);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1366, 738);
            this.MinimizeBox = false;
            this.Name = "frmArkanoid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arkanoid";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmArkanoid_FormClosing);
            this.Shown += new System.EventHandler(this.frmArkanoid_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.board)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox board;
        private System.Windows.Forms.Timer tmrMovements;
        private Ball ball;

    }
}

