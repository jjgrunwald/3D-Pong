using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube1
{
    internal class Score
    {
        static public Form1 mainForm;

        //private fields

        private float _x;
        private float _y;
        private float scorePoints = 0;
        private Font _font = new Font("Impact", 77);
        private Font _bigFont = new Font("Impact", 83);
        private SolidBrush _shadowBrush;
        private SolidBrush _brush;
        private SolidBrush _blackBrush;
        private Color _color;
        private Color _shadowColor = Color.FromArgb(75, 0, 0, 0);

        //public properties
        public float X { get { return _x; } }
        public float Y { get { return _y; } }
        public Color color { get { return _color; } }

        //constructor
        public Score(float x, float y, Color color)
        {
            _x = x;
            _y = y;
            _color = color;
            _brush = new SolidBrush(_color);
            _blackBrush = new SolidBrush(Color.Black);
            _shadowBrush = new SolidBrush(_shadowColor);

        }

        public void Draw(Rectangle formSize, PaintEventArgs e)
        {

            float scaleX = formSize.Width / 995f;
            float scaleY = formSize.Height / 720f;

            float adjustedX = _x * scaleX;
            float adjustedY = _y * scaleY;

            e.Graphics.DrawString(scorePoints.ToString(), _font, _shadowBrush, adjustedX + 10, adjustedY + 10);
            e.Graphics.DrawString(scorePoints.ToString(), _bigFont, _blackBrush, adjustedX, adjustedY);
            e.Graphics.DrawString(scorePoints.ToString(), _font, _brush, adjustedX, adjustedY);
        }



        public void ScorePoint()
        {
            scorePoints++;
        }

    }
}
