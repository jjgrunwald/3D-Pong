using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube1
{
    internal class Referee
    {
        private float _x;
        private float _y;
        private Color _gray = Color.LightGray;
        private Color _black = Color.Black;
        private Color _white = Color.White;
        private Color _shadowColor = Color.FromArgb(75, 0, 0, 0);
        private Color _colourSWplayer;
        private Color _colourNEplayer;
        private Pen _grayPen;
        private Pen _blackPen;
        private Brush _whiteBrush;
        private Brush _SWbrush;
        private Brush _NEbrush;
        private SolidBrush _shadowBrush;
        private Bitmap _logo;
        private Bitmap _controls;
        private const string BLUE = "BLUE ";
        private const string RED = "RED ";
        private const string SCORED = "HAS SCORED!";
        private const string CONTINUE = "PRESS SPACEBAR OR ENTER TO CONTINUE";
        private const string CONTROLS = "PLAYER CONTROLS:";
        private const string START = "PRESS SPACEBAR OR ENTER TO START";
        private const string CREDITS = "ITEC 145 PROGRAMMING FUNDAMENTALS - FINAL PROJECT BY J.J. GRUNWALD";
        private Font _font = new Font("Impact", 28);
        private Font _mediumFont = new Font("Impact", 40);
        private Font _smallFont = new Font("Impact", 20);

        // constructor
        public Referee(float x, float y, float z, Color colourSWplayer, Color colourNEplayer)
        {
            _x = x;
            _y = y;
            _colourSWplayer = colourSWplayer;
            _colourNEplayer = colourNEplayer;
            _blackPen = new Pen(_black, 170);
            _grayPen = new Pen(_gray, 160);
            _shadowBrush = new SolidBrush(_shadowColor);
            _whiteBrush = new SolidBrush(_white);
            _SWbrush = new SolidBrush(_colourSWplayer);
            _NEbrush = new SolidBrush(_colourNEplayer);
            _logo = new Bitmap(new Bitmap("../../../Resources/3dpong_logo.png"));
            _controls = new Bitmap(new Bitmap("../../../Resources/controls.png"));
        }

        //public properties
        public float X { get { return _x; } }
        public float Y { get { return _y; } }
        public Color colourSWplayer { get { return _colourSWplayer; } }
        public Color colourNEplayer { get { return _colourNEplayer; } }

        public void DrawLogo(Rectangle formSize, PaintEventArgs e)
        {

            float screenTop = (formSize.Width / 2) - 260;
            float screenBottom = formSize.Height / 16;

            e.Graphics.DrawImage(_logo, screenTop, screenBottom);
        }

        public void DrawInterface(Rectangle formSize, PaintEventArgs e)
        {
            float screenTop = (formSize.Width / 2) - 260;
            float screenBottom = formSize.Height / 24;

            e.Graphics.DrawRectangle(_blackPen, formSize);
            e.Graphics.DrawRectangle(_grayPen, formSize);
            e.Graphics.DrawImage(_logo, screenTop, screenBottom);
        }

        public void SWscored(Rectangle formSize, PaintEventArgs e)
        {
            float middleW = (formSize.Width / 2) -130;
            float middleH = formSize.Height-65;

            e.Graphics.DrawString((BLUE + SCORED), _font, _shadowBrush, middleW + 5, middleH + 5);
            e.Graphics.DrawString((BLUE + SCORED), _font, _NEbrush, middleW, middleH);
        }

        public void NEscored(Rectangle formSize, PaintEventArgs e)
        {
            float middleW = (formSize.Width / 2) -130;
            float middleH = formSize.Height -65;

            e.Graphics.DrawString((RED + SCORED), _font, _shadowBrush, middleW+5, middleH+5);
            e.Graphics.DrawString((RED + SCORED), _font, _SWbrush, middleW, middleH);
        }

        public void pressStart(Rectangle formSize, PaintEventArgs e)
        {
            float middleW = (formSize.Width / 2) - 300;
            float middleH = (formSize.Height) - 200;

            e.Graphics.DrawImage(_controls, middleW+400, middleH-250);

            e.Graphics.DrawString((RED), _mediumFont, _shadowBrush, middleW +20, middleH - 205);
            e.Graphics.DrawString((RED), _mediumFont, _SWbrush, middleW +15, middleH - 210);

            e.Graphics.DrawString((CONTROLS), _font, _shadowBrush, middleW + 115, middleH - 190);
            e.Graphics.DrawString((CONTROLS), _font, _whiteBrush, middleW + 110, middleH - 200);


            e.Graphics.DrawString((BLUE), _mediumFont, _shadowBrush, middleW, middleH -115);
            e.Graphics.DrawString((BLUE), _mediumFont, _NEbrush, middleW-5 , middleH -120);

            e.Graphics.DrawString((CONTROLS), _font, _shadowBrush, middleW +115, middleH - 100);
            e.Graphics.DrawString((CONTROLS), _font, _whiteBrush, middleW+110, middleH - 110);

            e.Graphics.DrawString((START), _mediumFont, _shadowBrush, middleW -90, middleH + 60);
            e.Graphics.DrawString((START), _mediumFont, _whiteBrush, middleW -95, middleH + 50);

            e.Graphics.DrawString((CREDITS), _smallFont, _shadowBrush, middleW -95, middleH +150);
            e.Graphics.DrawString((CREDITS), _smallFont, _whiteBrush, middleW -100, middleH+140);
        }

        public void pressContinue(Rectangle formSize, PaintEventArgs e)
        {
            float middleW = (formSize.Width / 2) - 300;
            float middleH = (formSize.Height / 3) - 50;


            e.Graphics.DrawString((CONTINUE), _font, _shadowBrush, middleW + 5, middleH + 5);
            e.Graphics.DrawString((CONTINUE), _font, _whiteBrush, middleW, middleH);
        }
    }
}
