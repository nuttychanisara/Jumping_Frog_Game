using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Windows;
using System.Windows.Input;
using Microsoft.VisualBasic;
using System.IO;
using System.Media;



namespace Jumping_Frog
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
            timerGame.Start();
            Application.OpenForms["Menu"].Hide();

            _playerJumpSound = new SoundPlayer(Properties.Resources.กบกระโดด);
            _playerCarSound = new SoundPlayer(Properties.Resources.กบโดนทับ);
            _playerFallSound = new SoundPlayer(Properties.Resources.กบจมน้ำ);
            _PlayWinSound = new SoundPlayer(Properties.Resources.กบถึงเส้นชัย);
            _PlayGameoverSound = new SoundPlayer(Properties.Resources.Gameover);
        }
        private SoundPlayer _playerJumpSound = null;
        private SoundPlayer _playerCarSound = null;
        private SoundPlayer _playerFallSound = null;
        private SoundPlayer _PlayWinSound = null;
        private SoundPlayer _PlayGameoverSound = null;

        private Bitmap[] _picturesCarRightToLeft = {
                Properties.Resources.รูป_รถ1,
                Properties.Resources.รูป_รถ2,
                Properties.Resources.รูป_รถ3,
                Properties.Resources.รูป_รถ4,
                Properties.Resources.รูป_รถ5,
                Properties.Resources.รูป_รถ6,
                Properties.Resources.รูป_รถ7,
                Properties.Resources.รูป_รถ8,
                Properties.Resources.รูป_รถ9,
                Properties.Resources.รูป_รถ10
        };
        private Bitmap[] _picturesCarLeftToRight = {
                Properties.Resources.รูป_รถ1_1,
                Properties.Resources.รูป_รถ2_1,
                Properties.Resources.รูป_รถ3_1,
                Properties.Resources.รูป_รถ4_1,
                Properties.Resources.รูป_รถ5_1,
                Properties.Resources.รูป_รถ6_1,
                Properties.Resources.รูป_รถ7_1,
                Properties.Resources.รูป_รถ8_1,
                Properties.Resources.รูป_รถ9_1,
                Properties.Resources.รูป_รถ10_1
        };
        private void StartJumpMusic()
        {
            _playerJumpSound.Play();
        }
        private void StopJumpMusic()
        {
            _playerJumpSound.Stop();
        }
        private void StartCarSound()
        {
            _playerCarSound.Play();
        }
        private void StartFallSound()
        {
            _playerFallSound.Play();
        }
        private void StartWinSound()
        {
            _PlayWinSound.Play();
        }

        Random rnd = new Random();
        private Bitmap RandomPicCarRightToLeft()
        {
            var i = rnd.Next(0, _picturesCarRightToLeft.Length);
            return _picturesCarRightToLeft[i];
        }

        private Bitmap RandomPicCarLeftToRight()
        {
            var i = rnd.Next(0, _picturesCarLeftToRight.Length);
            return _picturesCarLeftToRight[i];
        }
        private void MoveRightToLeftCar(PictureBox pictureBox)
        {
            if (pictureBox.Location.X < -pictureBox.Width)
            {
                pictureBox.Image = RandomPicCarRightToLeft();
                pictureBox.Location = new Point(this.Width, pictureBox.Location.Y);
            }
            else
            {
                pictureBox.Location = new Point(pictureBox.Location.X - 5, pictureBox.Location.Y);
            }
        }
        private void MoveLeftToRightCar(PictureBox pictureBox)
        {
            if (pictureBox.Location.X > this.Width)
            {
                pictureBox.Image = RandomPicCarLeftToRight();
                pictureBox.Location = new Point(-pictureBox.Width, pictureBox.Location.Y);
            }
            else
            {
                pictureBox.Location = new Point(pictureBox.Location.X + 5, pictureBox.Location.Y);
            }
        }

        private void MoveRightToLeftTurtle23(PictureBox pictureBox)
        {
            if (pictureBox.Location.X < -pictureBox.Width)
            {
                pictureBox.Location = new Point(this.Width, pictureBox.Location.Y);
            }
            else
            {
                pictureBox.Location = new Point(pictureBox.Location.X - 3, pictureBox.Location.Y);
            }
        }
        private void MoveLeftToRightWoods(PictureBox pictureBox)
        {

            if (pictureBox.Location.X > this.Width)
            {
                pictureBox.Location = new Point(-pictureBox.Width, pictureBox.Location.Y);
            }
            else
            {
                pictureBox.Location = new Point(pictureBox.Location.X + 1, pictureBox.Location.Y);
            }
        }
        private void MoveLeftToRightWoods2(PictureBox pictureBox)
        {

            if (pictureBox.Location.X > this.Width)
            {
                pictureBox.Location = new Point(-pictureBox.Width, pictureBox.Location.Y);
            }
            else
            {
                pictureBox.Location = new Point(pictureBox.Location.X + 2, pictureBox.Location.Y);
            }
        }

        private void MoveRightToLeftCars(PictureBox[] pictureBoxs)
        {
            for (int i = 0; i < pictureBoxs.Length; i++)
            {
                MoveRightToLeftCar(pictureBoxs[i]);
            }
        }
        private void MoveLeftToRightCars(PictureBox[] pictureBoxs)
        {
            for (int i = 0; i < pictureBoxs.Length; i++)
            {
                MoveLeftToRightCar(pictureBoxs[i]);
            }
        }
        private void Game_Load(object sender, EventArgs e)
        {
            timerCarTurtle.Start();
            timerGame.Start();
        }
        private void timerCarTurtle_Tick_1(object sender, EventArgs e)
        {
            var carRtoL = new PictureBox[] {
                car1,
                car2,
                car3,
                car6,
                car7,
                car8,
                car9
            };
            MoveRightToLeftCars(carRtoL);
            var carLtoR = new PictureBox[] {
                car4,
                car5,
                car10,
                car11
            };
            MoveLeftToRightCars(carLtoR);

            MoveRightToLeftTurtle23(turtle1);
            MoveRightToLeftTurtle23(turtle2);
            MoveRightToLeftTurtle23(turtle3);
            MoveRightToLeftTurtle23(turtle4);
            MoveRightToLeftTurtle23(turtle5);
            MoveRightToLeftTurtle23(turtle6);
            MoveLeftToRightWoods(wood1);
            MoveLeftToRightWoods(wood2);
            MoveLeftToRightWoods(wood3);
            MoveLeftToRightWoods2(wood4);
            MoveLeftToRightWoods2(wood5);
            MoveLeftToRightWoods2(wood6);
            MoveLeftToRightWoods(wood7);
            MoveLeftToRightWoods(wood8);
            MoveLeftToRightWoods(wood9);
            MoveFrog();
            CheckCarCrashFrog();
            CheckFrogOnTurtle();
            CheckFrogOnWood1();
            CheckFrogOnWood2();
            CheckFrogFallRiver();
            CheckWinPoint();
        }
        private bool goLeft, goRight, goUp, goDown, isGameOver;
        private int speed = 25;
        private int score = 0;

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    goLeft = true;
                    player.Image = Properties.Resources.frogJL;
                    StartJumpMusic();
                    break;
                case Keys.Right:
                    goRight = true;
                    player.Image = Properties.Resources.frogJR;
                    StartJumpMusic();
                    break;
                case Keys.Up:
                    goUp = true;
                    player.Image = Properties.Resources.frog4;
                    StartJumpMusic();
                    break;
                case Keys.Down:
                    goDown = true;
                    player.Image = Properties.Resources.frogJD;
                    StartJumpMusic();
                    break;
            }
        }

        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    goLeft = false;
                    player.Image = Properties.Resources.frogL;

                    break;
                case Keys.Right:
                    goRight = false;
                    player.Image = Properties.Resources.frogR;
                    break;
                case Keys.Up:
                    goUp = false;
                    player.Image = Properties.Resources.frog1;

                    break;
                case Keys.Down:
                    goDown = false;
                    player.Image = Properties.Resources.frog1D;
                    break;
            }
        }
        private void MoveFrog()
        {
            if (goLeft == true && player.Left > 5)
            {
                player.Left -= speed;
            }
            if (goRight == true && player.Left < 370)
            {
                player.Left += speed;
            }
            if (goUp == true && player.Top > 39)
            {
                player.Top -= speed;
            }
            if (goDown == true && player.Top < 395)
            {
                player.Top += speed;
            }
        }
        private void CheckSpeedFrogOnWoodOnTurtle()
        {
            if (player.Left > 0)
            {
                player.Left -= speed;
            }
            if (player.Left < 370)
            {
                player.Left += speed;
            }
            if (player.Top > 39)
            {
                player.Top -= speed;
            }
            if (player.Top < 395)
            {
                player.Top += speed;
            }
        }

        private void CheckCarCrashFrog()
        {
            foreach (Control c in this.Controls)
            {
                if (c is PictureBox && c.Tag == "car")
                {
                    if (player.Bounds.IntersectsWith(c.Bounds))
                    {
                        player.SendToBack();
                        StartCarSound();
                        var cf = new PictureBox
                        {
                            Size = new Size(30, 30),
                            Location = player.Location,
                            Image = Properties.Resources.กบรถชน,
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            BackColor = Color.Transparent,

                        };
                        this.Controls.Add(cf);
                        score -= 200;
                        progressBar1.Value = 0;
                        timerGame.Start();
                        Timer t = new Timer();
                        t.Interval = 3000;
                        t.Tick += new EventHandler(t_Tick);
                        t.Start();
                        void t_Tick(object sender, EventArgs e)
                        {
                            cf.Visible = false;
                            this.Controls.Remove(cf);
                        }
                        life -= 1;
                        ReStartGame();
                        Life_index();
                    }
                }

            }
        }
        private void CheckFrogOnTurtle()
        {
            foreach (Control t in this.Controls)
            {
                if (t is PictureBox && t.Tag == "turtle")
                {
                    if (player.Bounds.IntersectsWith(t.Bounds))
                    {
                        player.BringToFront();
                        MoveRightToLeftTurtle23(player);
                        CheckSpeedFrogOnWoodOnTurtle();
                    }
                }
            }
        }
        private void CheckFrogOnWood1()
        {
            foreach (Control w1 in this.Controls)
            {
                if (w1 is PictureBox && w1.Tag == "wood")
                {
                    if ((player.Bounds.IntersectsWith(w1.Bounds)) && (player.Bounds.IntersectsWith(picWater.Bounds)))
                    {
                        player.BringToFront();
                        MoveLeftToRightWoods(player);
                        CheckSpeedFrogOnWoodOnTurtle();
                    }

                }
            }
        }
        private void CheckFrogOnWood2()
        {
            foreach (Control w2 in this.Controls)
            {
                if (w2 is PictureBox && w2.Tag == "wood2")
                {
                    if ((player.Bounds.IntersectsWith(w2.Bounds)) && (player.Bounds.IntersectsWith(picWater.Bounds)))
                    {
                        player.BringToFront();
                        MoveLeftToRightWoods2(player);
                        CheckSpeedFrogOnWoodOnTurtle();

                    }

                }
            }
        }
        private void CheckFrogFallRiver()
        {
            if (((player.Bounds.IntersectsWith(picWater.Bounds)) && (!player.Bounds.IntersectsWith(wood1.Bounds)) && (!player.Bounds.IntersectsWith(wood2.Bounds)) && (!player.Bounds.IntersectsWith(wood3.Bounds)) && (!player.Bounds.IntersectsWith(wood4.Bounds)) && (!player.Bounds.IntersectsWith(wood5.Bounds)) && (!player.Bounds.IntersectsWith(wood6.Bounds)) && (!player.Bounds.IntersectsWith(wood7.Bounds)) && (!player.Bounds.IntersectsWith(wood8.Bounds)) && (!player.Bounds.IntersectsWith(wood9.Bounds)) && (!player.Bounds.IntersectsWith(wood1.Bounds)) && (!player.Bounds.IntersectsWith(turtle1.Bounds)) && (!player.Bounds.IntersectsWith(turtle2.Bounds)) && (!player.Bounds.IntersectsWith(turtle3.Bounds)) && (!player.Bounds.IntersectsWith(turtle4.Bounds)) && (!player.Bounds.IntersectsWith(turtle5.Bounds)) && (!player.Bounds.IntersectsWith(turtle6.Bounds))))
            {
                var ck1 = new PictureBox
                {
                    Size = new Size(30, 30),
                    Image = Properties.Resources.กบจม,
                    Location = player.Location,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.Transparent,
                };
                this.Controls.Add(ck1);
                score -= 200;
                ck1.BringToFront();
                StartFallSound();
                progressBar1.Value = 0;
                timerGame.Start();
                Timer t = new Timer();
                t.Interval = 1000;
                t.Tick += new EventHandler(t_Tick);
                t.Start();
                void t_Tick(object sender, EventArgs e)
                {
                    ck1.Visible = false;
                    this.Controls.Remove(ck1);
                }
                life -= 1;
                ReStartGame();
                Life_index();
            }

        }
        private void NewPointWin()
        {
            StartWinSound();
            progressBar1.Value = 0;
            timerGame.Start();
            player.Location = new Point(198, 380);
            timerCarTurtle.Start();
        }
        private void CheckWinPoint()
        {
            if (player.Bounds.IntersectsWith(fly1.Bounds))
            {
                fly1.Image = Properties.Resources.frog1;
                score += 500;
                labelScore.Text = score.ToString();
                isFrogWin5Point();

            }
            else if (player.Bounds.IntersectsWith(fly2.Bounds))
            {
                fly2.Image = Properties.Resources.frog1;
                score += 500;
                labelScore.Text = score.ToString();
                isFrogWin5Point();

            }
            else if (player.Bounds.IntersectsWith(fly3.Bounds))
            {
                fly3.Image = Properties.Resources.frog1;
                score += 500;
                labelScore.Text = score.ToString(); ;
                isFrogWin5Point();

            }
            else if (player.Bounds.IntersectsWith(fly4.Bounds))
            {
                fly4.Image = Properties.Resources.frog1;
                score += 500;
                labelScore.Text = score.ToString(); ;
                isFrogWin5Point();

            }
            else if (player.Bounds.IntersectsWith(fly5.Bounds))
            {
                fly5.Image = Properties.Resources.frog1;
                score += 500;
                labelScore.Text = score.ToString(); ;
                isFrogWin5Point();
            }
        }
        private int life = 5;
        private void timerGame_Tick(object sender, EventArgs e)
        {
            switch (progressBar1.Value < progressBar1.Maximum)
            {
                case true:
                    progressBar1.Value += 2;
                    break;
                case false:
                    player.Left += 0;
                    player.Top += 0;
                    timerCarTurtle.Stop();
                    _PlayGameoverSound.Play();
                    timerGame.Stop();
                    DialogResult gameover = MessageBox.Show("Game Over!!" + Environment.NewLine + "Score " + labelScore.Text, "End Game", MessageBoxButtons.OK);
                    if (gameover == DialogResult.OK)
                    {
                        HighScoreGameOver();
                    }
                    
                    break;
            }
        }

        private void ReStartGame()
        {
            goLeft = false;
            goRight = false;
            goUp = false;
            goDown = false;
            isGameOver = false;
            if (score < 0)
            {
                score = 0;
                labelScore.Text = score.ToString(); ;

            }
            else
            {
                labelScore.Text = score.ToString(); ;
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
                player.Image = Properties.Resources.frog1;
                player.Location = new Point(198, 380);
                timerCarTurtle.Start();
                progressBar1.Value = 0;
                timerGame.Start();

            }
        }
        private void Life_index()
        {
            if (life > 0)
            {
                labelLife.Text = "X" + life.ToString();
            }
            else
            {
                player.Left += 0;
                player.Top += 0;
                labelLife.Text = "X0";
                timerCarTurtle.Stop();
                _PlayGameoverSound.Play();
                timerGame.Stop();
                DialogResult gameover = MessageBox.Show("Game Over!!" + Environment.NewLine + "Score " + labelScore.Text, "End Game", MessageBoxButtons.OK);
                if (gameover == DialogResult.OK)
                {
                    HighScoreGameOver();
                }
               
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Game_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                player.Image = Properties.Resources.frog4;
                StartJumpMusic();
            }
            else if (e.Button == MouseButtons.Right)
            {
                player.Image = Properties.Resources.frog4;
                StartJumpMusic();
            }
        }

        private void Game_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                player.Top -= 25;
                player.Image = Properties.Resources.frog1;
            }
            else if (e.Button == MouseButtons.Right)
            {
                player.Top -= 25;
                player.Image = Properties.Resources.frog1;
            }
        }

        private void isFrogWin5Point()
        {
            if (fly1.Image != null && fly2.Image != null && fly3.Image != null && fly4.Image != null && fly5.Image != null)

            {
                player.Left += 0;
                player.Top += 0;
                StartWinSound();
                timerGame.Stop();
                timerCarTurtle.Stop();
                DialogResult gameover = MessageBox.Show("COMPLETE!!" + Environment.NewLine + "Score " + labelScore.Text, "Congratulation", MessageBoxButtons.OK);
                if (gameover == DialogResult.OK)
                {
                    HighScoreGameWin();
                }
                
            }
            else
            {
                NewPointWin();
            }
        }
        public static string Encryption(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += cipher(ch, key);
            return output;
        }

        public static string Decryption(string input, int key)
        {
            return Encryption(input, 26 - key);
        }

        public static char cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {
                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);
        }
        private void HighScoreGameOver()
        {
            DialogResult youLose = MessageBox.Show("คุณแพ้แล้ว!! ต้องการบันทึกสถิติหรือไม่ ?", "You Lose!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (youLose == DialogResult.OK)
            {
                string username = Interaction.InputBox("กรุณากรอกชื่อผู้เล่น(username)เป็นภาษาอังกฤษ", "กรอกชื่อผู้เล่น",
                 "", 590, 300);
                string scoreString = labelScore.Text;
                int key = 13;
                string ciphername = Encryption(username, key);
                string filepath = @"C:\Users\Nutty\OneDrive - kmutnb.ac.th\Desktop\Group1_Jumping_Frog\Highscore.txt";
                
                string text = File.ReadAllText(filepath);
                string[] texts = text.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                if (texts.Length > 1) {
                    int oldScore = Convert.ToInt32(texts[1]);
                    int score = Convert.ToInt32(scoreString);
                    if (score >= oldScore)
                    {
                        StreamWriter sw = File.CreateText(filepath);
                        string name = ciphername + ", " + scoreString;
                        sw.Write(name);
                        sw.Close();
                    }
                }
                else
                {
                    StreamWriter sw = File.CreateText(filepath);
                    string name = ciphername + ", " + scoreString;
                    sw.Write(name);
                    sw.Close();
                }
                
                Application.Exit();
            }
            else if (youLose == DialogResult.Cancel)
            {
                    Application.Exit();
            }
        }
        private void HighScoreGameWin()
        {
            DialogResult youWin = MessageBox.Show("คุณชนะแล้ว!! ต้องการบันทึกสถิติหรือไม่ ?", "You Win!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            string username = Interaction.InputBox("กรุณากรอกชื่อผู้เล่น(username)เป็นภาษาอังกฤษ", "กรอกชื่อผู้เล่น",
                 "", 590, 300);
            string scoreString = labelScore.Text;
            int key = 13;
            string ciphername = Encryption(username, key);
            string filepath = @"C:\Users\Nutty\OneDrive - kmutnb.ac.th\Desktop\Group1_Jumping_Frog\Highscore.txt";

            string text = File.ReadAllText(filepath);
            string[] texts = text.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            if (texts.Length > 1)
            {
                int oldScore = Convert.ToInt32(texts[1]);
                int score = Convert.ToInt32(scoreString);
                if (score >= oldScore)
                {
                    StreamWriter sw = File.CreateText(filepath);
                    string name = ciphername + ", " + scoreString;
                    sw.Write(name);
                    sw.Close();
                }
            }
            else
            {
                StreamWriter sw = File.CreateText(filepath);
                string name = ciphername + ", " + scoreString;
                sw.Write(name);
                sw.Close();
            }

            Application.Exit();
        }
    }
}

