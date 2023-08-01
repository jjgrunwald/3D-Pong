using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Cube1
{
    internal class Court
    {
        static public Form1 mainform;

        //private fields
        private Color _black = Color.FromArgb(120, 0, 0, 0);
        private Color _lightBlue = Color.FromArgb(86, 181, 191);
        private Color _white = Color.White;
        private Pen _vertices;
        private Pen _courtLine;
        private Brush _court;

        //constructor
        public Court()
        {
            _vertices = new Pen(_black, 4f);
            _courtLine = new Pen(_white, 6);
            _court = new SolidBrush(_lightBlue);
        }

        public void DrawCourt(Matrix3x3 rotation, Matrix3x3 projection, float offsetW, float offsetH, PaintEventArgs e)
        {

            //Vertices for bottom of cube (polygon)
            Vector3[] bottom_vertices = new Vector3[]
            {
                    new Vector3(0f, 0f, 0f),
                    new Vector3(1f, 0f, 0f),
                    new Vector3(1f, 1f, 0f),
                    new Vector3(0f, 1f, 0f)
            };

            PointF[] displayBottomVertices = new PointF[bottom_vertices.Length];
            for (int i = 0; i < bottom_vertices.Length; i++)
            {
                Vector3 p = bottom_vertices[i];
                Vector3 vec = new Vector3((float)p.X, (float)p.Y, (float)p.Z);
                vec = rotation * vec;
                vec = projection * vec;
                displayBottomVertices[i] = new PointF(vec.X + offsetW, vec.Y + offsetH);
            }
            e.Graphics.FillPolygon(_court, displayBottomVertices);

            //Center line on court
            Vector3[] centerLine = new Vector3[]
{
                            new Vector3(0.5f, 1f, 0f),
                            new Vector3(0.5f, 0f, 0f),
};

            PointF[] displayCenterLine = new PointF[centerLine.Length];
            for (int i = 0; i < centerLine.Length; i++)
            {
                Vector3 p = centerLine[i];
                Vector3 vec = new Vector3((float)p.X, (float)p.Y, (float)p.Z);
                vec = rotation * vec;
                vec = projection * vec;
                displayCenterLine[i] = new PointF(vec.X + offsetW, vec.Y + offsetH);
            }
            e.Graphics.DrawLines(_courtLine, displayCenterLine);


            //South West player's lines on court
            Vector3[] SWline = new Vector3[]
                            {
                            new Vector3(0f, 0.33f, 0f),
                            new Vector3(0.25f, 0.33f, 0f),
                            new Vector3(0.25f, 0.67f, 0f),
                            new Vector3(0f, 0.67f, 0f),
                            };
    
                     PointF[] displaySWline = new PointF[SWline.Length];
                    for (int i = 0; i<SWline.Length; i++)
                    {
                        Vector3 p = SWline[i];
                    Vector3 vec = new Vector3((float)p.X, (float)p.Y, (float)p.Z);
                    vec = rotation* vec;
                    vec = projection* vec;
                    displaySWline[i] = new PointF(vec.X + offsetW, vec.Y + offsetH);
                }
                e.Graphics.DrawLines(_courtLine, displaySWline);


                    //North East player's lines on court
                      Vector3[] NEline = new Vector3[]
                         {
                            new Vector3(1f, 0.33f, 0f),
                            new Vector3(0.75f, 0.33f, 0f),
                            new Vector3(0.75f, 0.67f, 0f),
                            new Vector3(1f, 0.67f, 0f),
                         };

                    PointF[] displayNEline = new PointF[NEline.Length];
                    for (int i = 0; i < NEline.Length; i++)
                    {
                        Vector3 p = NEline[i];
                        Vector3 vec = new Vector3((float)p.X, (float)p.Y, (float)p.Z);
                        vec = rotation * vec;
                        vec = projection * vec;
                        displayNEline[i] = new PointF(vec.X + offsetW, vec.Y + offsetH);
                    }
                    e.Graphics.DrawLines(_courtLine, displayNEline);


                    }

        public void DrawCubeBack(Matrix3x3 rotation, Matrix3x3 projection, float offsetW, float offsetH, PaintEventArgs e)
        {
 

            //Vertices for floor.
            Vector3[] floor_vertices = new Vector3[]
            {
                new Vector3(0f, 0f, 0f),
                new Vector3(1f, 0f, 0f),
                new Vector3(1f, 1f, 0f),
                new Vector3(0f, 1f, 0f),
                new Vector3(0f, 0f, 0f)
            };

            PointF[] displayFloorVertices = new PointF[floor_vertices.Length];
            for (int i = 0; i < floor_vertices.Length; i++)
            {
                Vector3 p = floor_vertices[i];
                Vector3 vec = new Vector3((float)p.X, (float)p.Y, (float)p.Z);
                vec = rotation * vec;
                vec = projection * vec;
                displayFloorVertices[i] = new PointF(vec.X + offsetW, vec.Y + offsetH);
            }
            e.Graphics.DrawLines(_courtLine, displayFloorVertices);

            //North vertices for corners of cube.
            Vector3[] n_corner_vertices = new Vector3[]
            {
                new Vector3(1f, 1f, 0f),
                new Vector3(1f, 1f, .4f)
            };

            PointF[] displayNorthCornerVertices = new PointF[n_corner_vertices.Length];
            for (int i = 0; i < n_corner_vertices.Length; i++)
            {
                Vector3 p = n_corner_vertices[i];
                Vector3 vec = new Vector3((float)p.X, (float)p.Y, (float)p.Z);
                vec = rotation * vec;
                vec = projection * vec;
                displayNorthCornerVertices[i] = new PointF(vec.X + offsetW, vec.Y + offsetH);
            }
            e.Graphics.DrawLines(_vertices, displayNorthCornerVertices);

        }

        public void DrawCubeFront(Matrix3x3 rotation, Matrix3x3 projection, float offsetW, float offsetH, PaintEventArgs e)
        {

            //Vertices for ceiling.
            Vector3[] ceiling_vertices = new Vector3[]
            {
                new Vector3(0f, 0f, .4f),
                new Vector3(1f, 0f, .4f),
                new Vector3(1f, 1f, .4f),
                new Vector3(0f, 1f, .4f),
                new Vector3(0f, 0f, .4f)
            };

            PointF[] displayCeilingVertices = new PointF[ceiling_vertices.Length];
            for (int i = 0; i < ceiling_vertices.Length; i++)
            {
                Vector3 p = ceiling_vertices[i];
                Vector3 vec = new Vector3((float)p.X, (float)p.Y, (float)p.Z);
                vec = rotation * vec;
                vec = projection * vec;
                displayCeilingVertices[i] = new PointF(vec.X + offsetW, vec.Y + offsetH);
            }
            e.Graphics.DrawLines(_vertices, displayCeilingVertices);


            //South vertices for corners of cube.
            Vector3[] s_corner_vertices = new Vector3[]
            {
                new Vector3(0f, 0f, 0f),
                new Vector3(0f, 0f, .4f)
            };

            PointF[] displaySouthCornerVertices = new PointF[s_corner_vertices.Length];
            for (int i = 0; i < s_corner_vertices.Length; i++)
            {
                Vector3 p = s_corner_vertices[i];
                Vector3 vec = new Vector3((float)p.X, (float)p.Y, (float)p.Z);
                vec = rotation * vec;
                vec = projection * vec;
                displaySouthCornerVertices[i] = new PointF(vec.X + offsetW, vec.Y + offsetH);
            }
            e.Graphics.DrawLines(_vertices, displaySouthCornerVertices);


            //East vertices for corners of cube.
            Vector3[] e_corner_vertices = new Vector3[]
            {
                new Vector3(1f, 0f, 0f),
                new Vector3(1f, 0f, .4f)
            };

            PointF[] displayEastCornerVertices = new PointF[e_corner_vertices.Length];
            for (int i = 0; i < s_corner_vertices.Length; i++)
            {
                Vector3 p = e_corner_vertices[i];
                Vector3 vec = new Vector3((float)p.X, (float)p.Y, (float)p.Z);
                vec = rotation * vec;
                vec = projection * vec;
                displayEastCornerVertices[i] = new PointF(vec.X + offsetW, vec.Y + offsetH);
            }
            e.Graphics.DrawLines(_vertices, displayEastCornerVertices);


            //West vertices for corners of cube.
            Vector3[] w_corner_vertices = new Vector3[]
            {
                new Vector3(0f, 1f, 0f),
                new Vector3(0f, 1f, .4f)
            };

            PointF[] displayWestCornerVertices = new PointF[w_corner_vertices.Length];
            for (int i = 0; i < w_corner_vertices.Length; i++)
            {
                Vector3 p = w_corner_vertices[i];
                Vector3 vec = new Vector3((float)p.X, (float)p.Y, (float)p.Z);
                vec = rotation * vec;
                vec = projection * vec;
                displayWestCornerVertices[i] = new PointF(vec.X + offsetW, vec.Y + offsetH);
            }
            e.Graphics.DrawLines(_vertices, displayWestCornerVertices);



        }



    }
}
