using System;

namespace CrowdSimulator
{
    public class Vec2
    {
        float x, y;

        public Vec2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vec2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Vec2(float Val)
        {
            x = Val;
            y = Val;
        }

        public static Vec2 operator +(Vec2 A, Vec2 B)
        {
            return new Vec2(A.X + B.X, A.Y + B.Y);
        }

        public static Vec2 operator -(Vec2 A, Vec2 B)
        {
            return new Vec2(A.X - B.X, A.Y - B.Y);
        }

        public static bool operator ==(Vec2 A, Vec2 B)
        {
            if (A.x == B.x && A.y == B.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Vec2 A, Vec2 B)
        {
            if (A.x == B.x && A.y == B.y)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Vec2 Mul(float F)
        {
            x *= F;
            y *= F;

            return this;
        }

        public static float Dot(Vec2 a, Vec2 b)
        {
            return a.X * b.X + a.Y * b.y;
        }

        public float Length()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public int Xi
        {
            get { return (int)x; }
            set { x = value; }
        }

        public int Yi
        {
            get { return (int)y; }
            set { y = value; }
        }
    }
}
