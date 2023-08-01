//using AForge.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube1
{
    internal class Matrix3x3
    {
        static public Form1 mainForm;

        public float[] values;
        public float M11 { get { return values[0]; } set { values[0] = value; }  }
        public float M12 { get { return values[1]; } set { values[1] = value; } }
        public float M13 { get { return values[2]; } set { values[2] = value; } }
        public float M21 { get { return values[3]; } set { values[3] = value; } }
        public float M22 { get { return values[4]; } set { values[4] = value; } }
        public float M23 { get { return values[5]; } set { values[5] = value; } }
        public float M31 { get { return values[6]; } set { values[6] = value; } }
        public float M32 { get { return values[7]; } set { values[7] = value; } }
        public float M33 { get { return values[8]; } set { values[8] = value; } }

        public Matrix3x3()
        {
            values = new float[] { 0, 0, 0,
                                   0, 0, 0, 
                                   0, 0, 0 };
        }

        public Matrix3x3(float m11, float m12, float m13,
                        float m21, float m22, float m23,
                        float m31, float m32, float m33)

        {
            values = new float[] {  m11, m12, m13, 
                                    m21, m22, m23,
                                    m31, m32, m33 };

        }

        public static Matrix3x3 operator *(Matrix3x3 m1, Matrix3x3 m2)
        {
            Matrix3x3 result = new Matrix3x3();
            result.M11 = m1.M11 * m2.M11 + m1.M12 * m2.M21 + m1.M13 * m2.M31;
            result.M12 = m1.M11 * m2.M12 + m1.M12 * m2.M22 + m1.M13 * m2.M32;
            result.M13 = m1.M11 * m2.M13 + m1.M12 * m2.M23 + m1.M13 * m2.M33;
            result.M21 = m1.M21 * m2.M11 + m1.M22 * m2.M21 + m1.M23 * m2.M31;
            result.M22 = m1.M21 * m2.M12 + m1.M22 * m2.M22 + m1.M23 * m2.M32;
            result.M23 = m1.M21 * m2.M13 + m1.M22 * m2.M23 + m1.M23 * m2.M33;
            result.M31 = m1.M31 * m2.M11 + m1.M32 * m2.M21 + m1.M33 * m2.M31;
            result.M32 = m1.M31 * m2.M12 + m1.M32 * m2.M22 + m1.M33 * m2.M32;
            result.M33 = m1.M31 * m2.M13 + m1.M32 * m2.M23 + m1.M33 * m2.M33;
            return result;
        }

        public static Matrix3x3 RotateX(float angle)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);
            return new Matrix3x3(
                                        1, 0, 0,
                                       0, cos, sin,
                                       0, -sin, cos
            );
        }

        public static Matrix3x3 RotateY(float angle)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);
            return new Matrix3x3(
                                    cos, 0, -sin,
                                      0, 1, 0,
                                    sin, 0, cos
            );
        }

        public static Matrix3x3 RotateZ(float angle)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);
            return new Matrix3x3(
                                     cos, sin, 0,
                                     -sin, cos, 0,
                                         0, 0, 1
            );
        }

        public static Vector3 operator *(Matrix3x3 m, Vector3 v)
        {
            float x = m.values[0] * v.X + m.values[1] * v.Y + m.values[2] * v.Z;
            float y = m.values[3] * v.X + m.values[4] * v.Y + m.values[5] * v.Z;
            float z = m.values[6] * v.X + m.values[7] * v.Y + m.values[8] * v.Z;
            return new Vector3(x, y, z);
        }
    }
}
