
//using AForge.Math;
using System;
using System.CodeDom;
using System.Drawing;
using System.Net.Http;
using System.Net.WebSockets;
using System.Numerics;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace Cube1
{
    public partial class Form1 : Form
    {
        Referee referee;
        Ball ball;
        Court court;
        Paddle SWpaddle;
        Paddle NEpaddle;
        Score SWscore;
        Score NEscore;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern short GetKeyState(int keyCode);
        public const int KeyPressed = 0x8000;

        public static bool IsKeyDown(Keys key)
        {
            return Convert.ToBoolean(GetKeyState((int)key) & KeyPressed);
        }

        static public Form1 mainForm;

        float angleX = 0.0f;
        float angleY = 0.0f;
        float angleZ = 0.0f;

        public Color colourSWplayer = Color.FromArgb(236, 10, 155);
        public Color colourNEplayer = Color.FromArgb(27, 160, 242);

        float currentOffset = 2.0f;

        Boolean gameBegin = false;
        Boolean gamePaused = true;
        Boolean NEplayerScored = false;
        Boolean SWplayerScored = false;

        //This was part of a disabled "rotate" feature.
        /*        bool increasingOffset = true;*/
        /*                float currentZ = -8f;*/

        public Form1()
        {
            InitializeComponent();

            var combination = new byte[1];
           

            this.BackColor = Color.FromArgb(187, 210, 60);

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;

            hScrollBarX.Visible = false;
            hScrollBarY.Visible = false;
            hScrollBarZ.Visible = false;


            Vector3.mainForm = this;
            Ball.mainForm = this;
            Court.mainform = this;
            Paddle.mainForm = this;
            Score.mainForm = this;

            // Smoother graphics drawing
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);


            // Set up the form properties
            this.Text = "3D Pong";
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;

            // Construct objects from classes
            referee = new Referee(0.1f, 0.1f, 0.1f, colourSWplayer, colourNEplayer);
            ball = new Ball(.5f, .5f, .15f);
            court = new Court();
            NEpaddle = new Paddle(0.98f, .5f, .05f, colourSWplayer);
            SWpaddle = new Paddle(0.02f, .5f, .05f, colourNEplayer);
            NEscore = new Score(70, 1f, colourNEplayer);
            SWscore = new Score(870, 1f, colourSWplayer);
        }


        private void Form_Paint(object sender, PaintEventArgs e)
        {

            angleX = (float)hScrollBarX.Value / 10f;
            angleY = (float)hScrollBarY.Value / 10f;
            angleZ = (float)hScrollBarZ.Value / 10f;


            /*            angleZ = currentZ / 10f;*/

            float offsetW = this.ClientRectangle.Width / currentOffset;
            float offsetH = this.ClientRectangle.Height / 1.2f;

            label1.Text = $"X Angle={angleX.ToString()}";
            label2.Text = $"Y Angle={angleY.ToString()}";
            label3.Text = $"Z Angle={angleZ.ToString()}";

            // Set up the projection matrix
            float halfWidth = this.ClientRectangle.Width / 2.0f;
            float halfHeight = this.ClientRectangle.Height / 2.0f;
            float halfDepth = 15.0f;

            Matrix3x3 projection;
            {
                projection = new Matrix3x3(
                    halfWidth, 0, 0,
                    0, -halfHeight, 0,
                    0, 0, halfDepth
                );

            }

            // Set up the rotation matrix
            Matrix3x3 rotation = Matrix3x3.RotateX(angleX) * Matrix3x3.RotateY(angleY) * Matrix3x3.RotateZ(angleZ);

            if (gameBegin == false)
            {
                Invalidate();

                referee.pressStart(this.ClientRectangle, e);

                referee.DrawLogo(this.ClientRectangle, e);
            }

            if (gamePaused == true && gameBegin == true && NEplayerScored == true && SWplayerScored == false)
            {

                this.BackColor = colourNEplayer;

                court.DrawCourt(rotation, projection, offsetW, offsetH, e);

                court.DrawCubeBack(rotation, projection, offsetW, offsetH, e);

                court.DrawCubeFront(rotation, projection, offsetW, offsetH, e);

                referee.DrawInterface(this.ClientRectangle, e);

                SWscore.Draw(this.ClientRectangle, e);

                NEscore.Draw(this.ClientRectangle, e);

                referee.SWscored(this.ClientRectangle, e);

                referee.pressContinue(this.ClientRectangle, e);
            }
            if (gamePaused == true && gameBegin == true && SWplayerScored == true && NEplayerScored == false)
            {
                this.BackColor = colourSWplayer;

                court.DrawCourt(rotation, projection, offsetW, offsetH, e);

                court.DrawCubeBack(rotation, projection, offsetW, offsetH, e);

                court.DrawCubeFront(rotation, projection, offsetW, offsetH, e);

                referee.DrawInterface(this.ClientRectangle, e);

                SWscore.Draw(this.ClientRectangle, e);

                NEscore.Draw(this.ClientRectangle, e);

                referee.NEscored(this.ClientRectangle, e);

                referee.pressContinue(this.ClientRectangle, e);

            }
            else if (gamePaused == false && SWplayerScored == false && NEplayerScored == false)
            {
                this.BackColor = Color.FromArgb(253, 161, 148);

                court.DrawCourt(rotation, projection, offsetW, offsetH, e);

                court.DrawCubeBack(rotation, projection, offsetW, offsetH, e);

                NEpaddle.Draw(rotation, projection, offsetW, offsetH, e);

                ball.Draw(rotation, projection, offsetW, offsetH, e);

                SWpaddle.Draw(rotation, projection, offsetW, offsetH, e);

                court.DrawCubeFront(rotation, projection, offsetW, offsetH, e);

                referee.DrawInterface(this.ClientRectangle, e);

                SWscore.Draw(this.ClientRectangle, e);

                NEscore.Draw(this.ClientRectangle, e);

            }
        }
        private bool ScoreTest_SW(Ball ball)
        {
            return ball.ScoreTest_SW(ball);
        }

        private bool ScoreTest_NE(Ball ball)
        {
            return ball.ScoreTest_NE(ball);
        }

        private bool CollisionTest_SW(Paddle SWpaddle, Ball ball)
        {
            if (ball.X <= 0.02f) return ball.Collision(SWpaddle, ball);
            return false;
        }

        private bool CollisionTest_NE(Paddle NEpaddle, Ball ball)
        {
            if (ball.X >= 0.98f) return ball.Collision(NEpaddle, ball);
            return false;
        }

    private void timer1_Tick(object sender, EventArgs e)
        {

            this.Invalidate();


            //This is part of a disabled "rotation" feature (see above as well)

/*            //This will automatically pan the Z axis;
            currentZ += 0.1f;*/


/*            //This is supposed to change the horizontal offset along with the Z axis;
            if (increasingOffset)
            {
                currentOffset += 0.01f;
                if (currentOffset >= 2.8f)
                {
                    increasingOffset = false;
                }
            }
            else
            {
                currentOffset -= 0.01f;
                if (currentOffset <= 1.2f)
                {
                    increasingOffset = true;
                }
            }*/
        

            if (CollisionTest_SW(SWpaddle, ball)) 
            {
                ball.Reverse(ball);
/*                ball.SpeedUp(ball);*/
            }

            if (CollisionTest_NE(NEpaddle, ball))
            {
                    ball.Reverse(ball);
/*                ball.SpeedUp(ball);*/
            }

            if (ScoreTest_SW(ball))
            {
                SWscore.ScorePoint();
                gamePaused = true;
                SWplayerScored = true;
                ball.ResetBall(ball);
            }

            if (ScoreTest_NE(ball))
            {
                NEscore.ScorePoint();
                gamePaused = true;
                NEplayerScored = true;
                ball.ResetBall(ball);
            }
        }

        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            var SWkeyStates = new System.Collections.BitArray(new bool[]
            {IsKeyDown(Keys.A), IsKeyDown(Keys.W), IsKeyDown(Keys.D), IsKeyDown(Keys.S)});

            var NEkeyStates = new System.Collections.BitArray(new bool[]
            {IsKeyDown(Keys.Left), IsKeyDown(Keys.Up), IsKeyDown(Keys.Right), IsKeyDown(Keys.Down)});

            var SWcombination = new byte[1];

            var NEcombination = new byte[1];

            SWkeyStates.CopyTo(SWcombination, 0);

            NEkeyStates.CopyTo(NEcombination, 0);

            if (e.KeyCode == Keys.Enter && gamePaused == true || e.KeyCode == Keys.Space && gamePaused == true)
            {
                gamePaused = false;
                gameBegin = true;
                NEplayerScored = false;
                SWplayerScored = false;
                ball.ResetBall(ball);
            }

            // South West Paddle Keydown Events

            if (e.KeyCode == Keys.A)
                IsKeyDown(Keys.A);

            if (e.KeyCode == Keys.W)
                IsKeyDown(Keys.W);

            if (e.KeyCode == Keys.D)
                IsKeyDown(Keys.D);

            if (e.KeyCode == Keys.S)
                IsKeyDown(Keys.S);

            // North East Paddle Keydown Events

            if (e.KeyCode == Keys.Left)
                IsKeyDown(Keys.Left);

            if (e.KeyCode == Keys.Up)
                IsKeyDown(Keys.Up);

            if (e.KeyCode == Keys.Right)
                IsKeyDown(Keys.Right);

            if (e.KeyCode == Keys.Down)
                IsKeyDown(Keys.Down);

            // South West Paddle Switch

            switch (SWcombination[0])
            {
                case 1:
                    SWpaddle.MoveLeft();
                    break;
                case 2:
                    SWpaddle.MoveUp();
                    break;
                case 3:
                    SWpaddle.MoveUp();
                    SWpaddle.MoveLeft();
                    break;
                case 4:
                    SWpaddle.MoveRight();
                    break;
                case 6:
                    SWpaddle.MoveUp();
                    SWpaddle.MoveRight();
                    break;
                case 8:
                    SWpaddle.MoveDown(); 
                    break;
                case 9:
                    SWpaddle.MoveDown();
                    SWpaddle.MoveLeft();
                    break;
                case 12:
                    SWpaddle.MoveDown();
                    SWpaddle.MoveRight();
                    break;
                default:
                    break;
            }

            // North East Paddle Switch

            switch (NEcombination[0])
            {
                case 1:
                    NEpaddle.MoveLeft();
                    break;
                case 2:
                    NEpaddle.MoveUp();
                    break;
                case 3:
                    NEpaddle.MoveUp();
                    NEpaddle.MoveLeft();
                    break;
                case 4:
                    NEpaddle.MoveRight();
                    break;
                case 6:
                    NEpaddle.MoveUp();
                    NEpaddle.MoveRight();
                    break;
                case 8:
                    NEpaddle.MoveDown();
                    break;
                case 9:
                    NEpaddle.MoveDown();
                    NEpaddle.MoveLeft();
                    break;
                case 12:
                    NEpaddle.MoveDown();
                    NEpaddle.MoveRight();
                    break;
                default:
                    break;
            }
        }
    }

}

