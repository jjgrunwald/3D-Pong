using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube1
{
    internal class Paddle
    {
        static public Form1 mainForm;

        // private fields
        private float _x;
        private float _y;
        private float _z;
        private Color _color;
        private Color _black = Color.Black;
        private float _paddleSize = .25f;
        private float _ySpeed = 0.02f;
        private float _zSpeed = 0.02f;
        private Pen _pen;
        private Brush _brush;


        // constructor
        public Paddle(float x, float y, float z, Color color)
        {
            _x = x;
            _y = y;
            _z = z;
            _color = Color.FromArgb(75, color);
            _pen = new Pen(_black, 2);
            _brush = new SolidBrush(_color);
        }

        //public properties
        public float X { get { return _x; } }
        public float Y { get { return _y; } }
        public float Z { get { return _z; } }
        public float paddleSize { get { return _paddleSize; } }
        public Color color { get { return _color; } }

        public void Draw(Matrix3x3 rotation, Matrix3x3 projection, float offsetW, float offsetH, PaintEventArgs e)
        {
            //Draw the paddle.
            Vector3[] paddle = new Vector3[]
            {
                new Vector3(_x, _y, _z),
                new Vector3(_x, _y+_paddleSize, _z),
                new Vector3(_x, _y+_paddleSize, _z+_paddleSize),
                new Vector3(_x, _y, _z+_paddleSize),
                new Vector3(_x, _y, _z)
            };

            PointF[] displayPaddle = new PointF[paddle.Length];
            for (int i = 0; i < paddle.Length; i++)
            {
                Vector3 p = paddle[i];
                Vector3 vec = new Vector3((float)p.X, (float)p.Y, (float)p.Z);
                vec = rotation * vec;
                vec = projection * vec;
                displayPaddle[i] = new PointF(vec.X + offsetW, vec.Y + offsetH);
            }
            e.Graphics.DrawLines(_pen, displayPaddle);
            e.Graphics.FillPolygon(_brush, displayPaddle);

        }


        public void MoveLeft()
        {
            if (_y < .75)
                _y += _ySpeed;
        }

        public void MoveUp()
        {
            if (_z < .15)
                _z += _zSpeed;
        }

        public void MoveRight()
        {
            _y -= _ySpeed;
            if (_y < 0f) _y = 0f;
        }

        public void MoveDown()
        {
            _z -= _zSpeed;
            if (_z < 0f) _z = 0f;
        }
    }
}
