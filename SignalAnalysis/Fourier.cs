using System;
using System.Numerics;
using MathLib.Matrices;
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace MathLib.SignalAnalysis
{
    /// <summary>
    /// Routines for performing a fast fourier transform on data
    /// </summary>
    [CLSCompliant(false)]
    public static class Fourier
    {
        public static ComplexVector Fft(ComplexVector data)
        {
            // // Contract.Requires(data != null);
            // // Contract.Requires(BasicMath.IsPowerOf2(data.Length));
            
            // //Contract.Ensures(// Contract.Result<ComplexVector>().Length == data.Length);

            ComplexVector transform = data.DeepClone();
            Ditfft2(ref transform, 1);

            return transform;            
        }

        public static ComplexVector Ifft(ComplexVector data)
        {
            // // Contract.Requires(data != null);
            // // Contract.Requires(BasicMath.IsPowerOf2(data.Length));
            
            // //Contract.Ensures(// Contract.Result<ComplexVector>().Length == data.Length);

            ComplexVector result = data.DeepClone();

            Ditfft2(ref result, -1);

            return result;          
        }

        public static ComplexMatrix Fft2D(ComplexMatrix data)
        {
            // // Contract.Requires(data != null);
            // // Contract.Requires(BasicMath.IsPowerOf2(data.Rows) && (BasicMath.IsPowerOf2(data.Columns)));
            // //Contract.Ensures((// Contract.Result<ComplexMatrix>().Rows == data.Rows) && (// Contract.Result<ComplexMatrix>().Columns == data.Columns));

            ComplexMatrix transform = data.DeepClone();
            ComplexVector v;
            // Transform the rows
            for (int r = 0; r < data.Rows; r++)
            {
                v = transform.GetRow(r);
                Ditfft2(ref v, 1);
                transform.SetRow(r, v);
            }
            // Transform the columns
            for (int c = 0; c < data.Columns; c++)
            {
                v = transform.GetColumn(c);
                Ditfft2(ref v, 1);
                transform.SetColumn(c, v);
            }

            return transform;            
        }

        public static ComplexMatrix Ifft2D(ComplexMatrix data)
        {
            // // Contract.Requires(data != null);
            // // Contract.Requires(BasicMath.IsPowerOf2(data.Rows) && (BasicMath.IsPowerOf2(data.Columns)));
            // //Contract.Ensures((// Contract.Result<ComplexMatrix>().Rows == data.Rows) && (// Contract.Result<ComplexMatrix>().Columns == data.Columns));

            ComplexMatrix transform = data.DeepClone();
            ComplexVector v;
            // Transform the rows
            for (int r = 0; r < data.Rows; r++)
            {
                v = transform.GetRow(r);
                Ditfft2(ref v, -1);
                transform.SetRow(r, v);
            }
            // Transform the columns
            for (int c = 0; c < data.Columns; c++)
            {
                v = transform.GetColumn(c);
                Ditfft2(ref v, -1);
                transform.SetColumn(c, v);
            }

            return transform;              
        }
        
        /// <summary>
        /// decimation in time, radix-2.
        /// </summary>
        /// <param name="data">data to transform</param>
        /// <param name="dir">direction of transform. dir = 1 to find the fourier transform. 
        /// dir = -1 to find the inverse fourier transform.</param>
        /// <remarks>This is an in-place implementation adapted from an implementation by
        /// Douglas L. Jones, University of Illinois at Urbana-Champaign (Jan 19, 1992)</remarks>
        private static void Ditfft2(ref ComplexVector data, int dir)
        {
            // // Contract.Requires(data != null);
            // // Contract.Requires(BasicMath.IsPowerOf2(data.Length));           
            // // Contract.Requires(dir == -1 || dir == 1);
            // //Contract.Ensures(data != null);

            int n = data.Length;
            int m = (int)Math.Round(Math.Log(n, 2));   // n = 2^m

            int i;
            int n1;
            Complex t;            

            int j = 0;
            int n2 = n/2;
            for (i=1; i < n - 1; i++)
            {
                n1 = n2;
                while ( j >= n1 )
                {
                    j -= n1;
                    n1 /= 2;
                }
                j += n1;

                if (i >= j) continue;

                t = data[i];
                data[i] = data[j];
                data[j] = t;
            }

            n2 = 1;
                                             
            for (i=0; i < m; i++)
            {
                n1 = n2;
                n2 += n2;
                double e = -1 * dir * 6.283185307179586/n2;
                double a = 0.0;
                                             
                for (j=0; j < n1; j++)
                {
                    double c = Math.Cos(a);
                    double s = Math.Sin(a);
                    a += e;

                    int k;
                    for (k=j; k < n; k += n2)
                    {                                               
                        t = new Complex(c * data[k + n1].Real - s * data[k + n1].Imaginary, s * data[k + n1].Real + c * data[k + n1].Imaginary);
                        data[k + n1] = data[k] - t;
                        data[k] += t;                        
                    }
                }
            }

            if (dir != -1) return;

            for (int z = 0; z < n; z++)
                data[z] /= n;
        }
    }
}
