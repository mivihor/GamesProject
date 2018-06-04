using System;
using System.Collections.Generic;
using System.Text;

namespace Vector
{
    class Vector
    {
        public static Random rnd = new Random();
        public double[] x;

        public Vector(int n)
        {
            x = new double[n];
        }

        public double this[int i]
        {
            get
            {
                return x[i];
            }
            set
            {
                x[i] = value;
            }
        }

        public override string ToString()
        {
            return String.Join(' ', x);
        }

        public void FillRnd(int from, int to)
        {
            for(int i=0; i<x.Length; i++)
            {
                x[i] = rnd.Next(from, to);
            }
        }

        public double getLength()
        {
            double sum = 0;
            for(int i=0; i<x.Length; i++)
            {
                sum += x[i] * x[i];
            }
            return Math.Sqrt(sum);
        }

        public int Rank
        {
            get
            {
                return x.Length;
            }
        }

       public static Vector operator+(Vector a, Vector b)
        {
            if(a.Rank != b.Rank)
            {
                throw new Exception("Impossible to add vectors of different sizes");
            }
            Vector c = new Vector(a.Rank);
            for (int i = 0; i < c.Rank; i++) c[i] = a[i] + b[i];
            return c;
        }

        public static double ScalarProduct(Vector a, Vector b)
        {
            if (a.Rank != b.Rank) throw new Exception("The rank is different operation impossible to proceed");
            double product=0;
            for(int i=0; i<a.Rank; i++)
            {
                product += a[i]*b[i];
            }
            return product;
        }
    }

}
