using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Arkanoid
{
    public partial class frmArkanoid : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern short GetAsyncKeyState(Keys vKey);

        private Boolean _movingLeft;
        private Boolean _movingTop;
        private Boolean _lockThread;
        private Boolean _started;

        private Thread _MoveBallThread;
        private List<PictureBox> _blocks;
        private Label _lblStart;

        public frmArkanoid()
        {
            InitializeComponent();
        }

        private void frmArkanoid_Shown(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(430, 490);
            GenerateBlocks();
            StartPrompt();
            tmrMovements.Enabled = true;
        }

        private void GenerateBlocks()
        {
            _blocks = new List<PictureBox>();
            Random a = new Random();
            PictureBox ptbBlock;
            Int32 columnWidth = Convert.ToInt32((this.Width - 2) / 10);

            //10 lines
            for (int i = 0; i < 10; i++)
            {
                //10 columns
                for (int j = 0; j < 10; j++)
                {
                    ptbBlock = new PictureBox();
                    ptbBlock.BackColor = System.Drawing.Color.FromArgb(a.Next(255), a.Next(255), a.Next(255));
                    ptbBlock.Location = new System.Drawing.Point(j * columnWidth, i * 20);
                    ptbBlock.Name = "ptbBlock";
                    ptbBlock.Size = new System.Drawing.Size(columnWidth - 1, 19);
                    ptbBlock.TabStop = false;
                    this.Controls.Add(ptbBlock);
                    _blocks.Add(ptbBlock);
                }
            }
            Application.DoEvents();
        }

        private void StartPrompt()
        {
            _lblStart = new Label();
            _lblStart.Text = "Press <<space>> to start the game";
            _lblStart.TextAlign = ContentAlignment.MiddleCenter;
            _lblStart.AutoSize = false;
            _lblStart.Height = this.Height / 4;
            _lblStart.Width = this.Width / 2;
            _lblStart.Left = ((this.Width / 2) - (_lblStart.Width / 2));
            _lblStart.Top = ((this.Height / 2));
            _lblStart.Font = new Font(FontFamily.GenericSerif, 14);
            _lblStart.BackColor = Color.FromArgb(3, 3, 3);
            _lblStart.ForeColor = Color.White;
            this.Controls.Add(_lblStart);
        }

        private void MoveBall()
        {
            Delegate delegateMoveBall = new Action(() =>
                    {

                        if ((ball.Top <= 0)) _movingTop = !_movingTop;
                        if ((ball.Left <= 0) || ((ball.Left + ball.Width) >= this.Width)) _movingLeft = !_movingLeft;

                        if ((ball.Top + ball.Height) >= this.Height)
                        {
                            _MoveBallThread.Abort();
                            MessageBox.Show("You lose");
                            this.Close();
                        }

                        ball.Left += (_movingLeft ? 5 : -5);
                        ball.Top += (_movingTop ? 5 : -5);

                        _lockThread = true;

                        foreach (PictureBox ptb in _blocks)
                        {
                            if ((((ptb.Top + ptb.Height) >= ball.Top) && ((ball.Top + ball.Height) > (ptb.Top + ptb.Height))) ||
                                ((ptb.Top <= (ball.Top + ball.Height)) && (ball.Top < ptb.Top)))
                            {
                                if ((ptb.Left <= ball.Left) && ((ptb.Left + ptb.Width) >= (ball.Left + ball.Width)))
                                {
                                    ptb.Dispose();
                                    _blocks.Remove(ptb);
                                    _movingTop = !_movingTop;
                                    break;
                                }
                            }
                        }
                        _lockThread = false;
                    });
            while (true)
            {
                if (_lockThread) continue;
                this.Invoke(delegateMoveBall);
                Thread.Sleep(10);
                Application.DoEvents();
            }
        }

        private void frmArkanoid_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_MoveBallThread != null && _MoveBallThread.IsAlive)
                _MoveBallThread.Abort();
        }

        private void tmrMovements_Tick(object sender, EventArgs e)
        {
            if (_lockThread) return;
            if ((ball.Top + ball.Height) >= board.Top)
            {
                if ((ball.Left <= (board.Left + board.Width)) && ((ball.Left + ball.Width) >= board.Left))
                {
                    _movingTop = !_movingTop;
                }
            }

            if (!_started)
            {
                if (frmArkanoid.GetAsyncKeyState(Keys.Space) != 0)
                {
                    _lblStart.Dispose();
                    _started = true;
                    _MoveBallThread = new Thread(MoveBall);
                    _MoveBallThread.Start();
                }
                return;
            }

            if (frmArkanoid.GetAsyncKeyState(Keys.Right) != 0)
            {
                board.Left += 5;
            }
            else if (frmArkanoid.GetAsyncKeyState(Keys.Left) != 0)
            {
                board.Left -= 5;
            }
        }
    }
}