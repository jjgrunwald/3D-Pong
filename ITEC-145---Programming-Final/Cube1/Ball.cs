using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Cube1
{
    internal class Ball
    {
        static public Form1 mainForm;

        //private fields
        private float _x;
        private float _y;
        private float _z;

        private Color _black = Color.Black;
        private Color _aqua = Color.Aquamarine;
        private Color _shadowColor = Color.FromArgb(75, 0, 0, 0);

        private float _xSpeed = .0026f;
        private float _ySpeed = .002f;
        private float _zSpeed = .0016f;

/*        //Comment this in for the ball to be static
        private float _xSpeed = 0f;
        private float _ySpeed = 0f;
        private float _zSpeed = 0f;
*/
        private Pen _blackPen;
        private Brush _aquaBrush;
        private SolidBrush _shadowBrush;

        //constructor
        public Ball(float x, float y, float z)
        {
            _x = x;
            _y = y;
            _z = z;
            _blackPen = new Pen(_black, 1);
            _aquaBrush = new SolidBrush(_aqua);
            _shadowBrush = new SolidBrush(_shadowColor);
        }

        //public properties
        public float X { get { return _x; } }
        public float Y { get { return _y; } }
        public float Z { get { return _z; } }

        //Public Methods

        public void Draw(Matrix3x3 rotation, Matrix3x3 projection, float offsetW, float offsetH, PaintEventArgs e)
        {
            _x += _xSpeed;
            _y += _ySpeed;
            _z += _zSpeed;

            if (_y > 1 || _y < 0.05)
            {
                _ySpeed = -_ySpeed;
                _y += _ySpeed;
            }
            if (_z > .3 || _z < 0)
            {
                _zSpeed = -_zSpeed;
                _z += _zSpeed;
            }

            Vector3 vec = new Vector3(_x, _y, _z);
            vec = rotation * vec;
            vec = projection * vec;

            //Vector for shadow
            Vector3 shadowVec = new Vector3(_x, _y, 0);
            shadowVec = rotation * shadowVec;
            shadowVec = projection * shadowVec;

            //Drawing shadow (below ball)
            e.Graphics.FillEllipse(_shadowBrush, shadowVec.X + offsetW, shadowVec.Y + offsetH, (offsetW / 21) + vec.Z, (offsetH / 21) + vec.Z);

            //Drawing ball
            e.Graphics.FillEllipse(_shadowBrush, vec.X + offsetW, vec.Y + offsetH, (offsetW / 21) + vec.Z + 2, (offsetH / 21) + vec.Z + 2);

            e.Graphics.FillEllipse(_aquaBrush, vec.X + offsetW, vec.Y + offsetH, (offsetW / 21) + vec.Z, (offsetH / 21) + vec.Z);

            e.Graphics.DrawEllipse(_blackPen, vec.X + offsetW, vec.Y + offsetH, (offsetW / 21) + vec.Z + 2, (offsetH / 21) + vec.Z + 2);


        }

        public bool Collision(Paddle checkPaddle, Ball ball)
        {
                if (Y >= checkPaddle.Y)
                {
                    if (Y <= checkPaddle.Y + checkPaddle.paddleSize)
                    {
                        if (Z >= checkPaddle.Z)
                        {
                            if (Z <= checkPaddle.Z + checkPaddle.paddleSize)
                            {
                               return true;
                            }
                        }
                    }
                }
            return false;
        }

        public bool ScoreTest_SW (Ball ball)
        {
            if (ball.X <= 0.0f)
            {
                return true;
            }

            return false;
        }

        public bool ScoreTest_NE(Ball ball)
        {
            if (ball.X >= 1.0f)
            {
                return true;
            }

            return false;
        }

        public void SpeedUp(Ball ball)
        {
            _xSpeed += 0.2f*_xSpeed;
        }

        public void Reverse(Ball ball)
        {
            _xSpeed = -_xSpeed;
            _x += _xSpeed;
        }

        public void ResetBall(Ball ball)
        {
            _x = .5f;
            _y = .5f;
            _z = .15f;
        }
    }
}
