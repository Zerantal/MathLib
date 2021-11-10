using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace MathLib.Matrices
{
    [TestClass]
    [ContractVerification(false)]
    public static class MatrixData
    {               
        private static Matrix<Complex> _cmA;
        private static Matrix<Complex> _cmATransposed;
        private static Matrix<Complex> _cmB;
        private static Matrix<Complex> _cmC;
        private static Matrix<Complex> _cmAPlusB;
        private static Matrix<Complex> _cmAMinusB;
        private static Matrix<Complex> _cmATimesC;
        private static Matrix<Complex> _cmATimesD;
        private static Matrix<Complex> _cmADivideD;
        private static Matrix<Complex> _cmANegated;

        public static Matrix<Complex> CM_A { get { return _cmA; } }
        public static Matrix<Complex> CM_ATransposed { get { return _cmATransposed; } }
        public static Matrix<Complex> CM_B { get { return _cmB; } }
        public static Matrix<Complex> CM_C { get { return _cmC; } }
        public static Complex Complex_D { get { return new Complex(Math.PI, -Math.E); } }
        public static Matrix<Complex> CM_AMinusB { get { return _cmAMinusB; } }
        public static Matrix<Complex> CM_APlusB { get { return _cmAPlusB; } }
        public static Matrix<Complex> CM_ANegated { get { return _cmANegated; } }
        public static Matrix<Complex> CM_ATimesC { get { return _cmATimesC; } }
        public static Matrix<Complex> CM_ATimesD { get { return _cmATimesD; } }
        public static Matrix<Complex> CM_ADivideD { get { return _cmADivideD; } }

        [AssemblyInitialize]
        public static void LoadTestDataFromFiles(TestContext context)
        {
            try
            {
                _cmA = ReadComplexMatrix("CM_A.csv");
                _cmATransposed = ReadComplexMatrix("CM_ATransposed.csv");
                _cmB = ReadComplexMatrix("CM_B.csv");
                _cmC = ReadComplexMatrix("CM_C.csv");
                _cmAPlusB = ReadComplexMatrix("CM_APlusB.csv");
                _cmAMinusB = ReadComplexMatrix("CM_AMinusB.csv");
                _cmATimesC = ReadComplexMatrix("CM_ATimesC.csv");
                _cmATimesD = ReadComplexMatrix("CM_ATimesD.csv");
                _cmADivideD = ReadComplexMatrix("CM_ADivideD.csv");
                _cmANegated = ReadComplexMatrix("CM_ANegated.csv");
                //_E = ReadDenseMatrix("MatE.csv");
                //_ERepeated3x2 = ReadDenseMatrix("MatERepeated3x2.csv");
            }
            catch (IOException)
            {
                Debug.WriteLine("Error reading data files for testing");
            }
        }


        private static Matrix<Complex> ReadComplexMatrix(string fileName)
        {                       
            TextReader tr = new StreamReader(fileName);

            string line = tr.ReadLine();
            string[] numbers;
            Complex[,] values;
            int rows = 0, cols;

            numbers = line.Split(new Char[] { ',' });
            cols = numbers.Length;
            while (line != null)
            {
                rows++;
                line = tr.ReadLine();
            }
            values = new Complex[rows, cols];
            tr.Dispose();
            tr.Close();

            tr = new StreamReader(fileName);
            line = tr.ReadLine();
            int r = 0;  // row counter
            string[] numElements;
            double re, im;  // real and imaginary components of complex numbers
            while (line != null)
            {
                numbers = line.Split(new char[] { ',' });
                for (int c = 0; c < numbers.Length; c++)
                {
                    numElements = numbers[c].Split(new char[] { ' ' });
                    re = Double.Parse(numElements[0]);
                    im = Double.Parse(numElements[2].Replace("i", ""));
                    if (numElements[1].Equals("-"))
                        im *= -1;

                    values[r, c] = new Complex(re, im);
                }
                line = tr.ReadLine();
                r++;
            }
            tr.Dispose();
            tr.Close();

            return new Matrix<Complex>(values);
        }
        /*
        private static Matrix ReadDenseMatrix(string fileName)
        {
            TextReader tr = new StreamReader(fileName);

            string line = tr.ReadLine();
            string[] numbers;
            double[,] values;
            int rows = 0, cols;

            numbers = line.Split(new Char[] { ',' });
            cols = numbers.Length;
            while (line != null)
            {
                rows++;
                line = tr.ReadLine();
            }
            values = new double[rows, cols];
            tr.Dispose();
            tr.Close();

            tr = new StreamReader(fileName);
            line = tr.ReadLine();
            int r = 0;  // row counter
            string[] numElements;            
            while (line != null)
            {
                numbers = line.Split(new char[] { ',' });
                for (int c = 0; c < numbers.Length; c++)
                {               
                    values[r, c] = Double.Parse(numbers[c]);
                }
                line = tr.ReadLine();
                r++;
            }
            tr.Dispose();
            tr.Close();

            return new Matrix(values);
        }
        */
        /*
        private static SparseMatrix ReadSparseMatrix(string fileName)
        {
            TextReader tr = new StreamReader(fileName);

            string line = tr.ReadLine();
            string[] numbers;
            List<Tuple<int, int, double>> sm = new List<Tuple<int, int, double>>();

            while (line != null)
            {
                numbers = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                sm.Add(new Tuple<int, int, double>((int)Double.Parse(numbers[0]), (int)Double.Parse(numbers[1]), Double.Parse(numbers[2])));
                line = tr.ReadLine();
            }
            tr.Dispose();
            tr.Close();
            return new SparseMatrix(sm.ToArray());
        }

        private static SparseVector ReadSparseVector(string fileName, int dimension, VectorType type)
        {
            TextReader tr = new StreamReader(fileName);

            string line = tr.ReadLine();
            string[] numbers;
            List<Tuple<int, double>> sv = new List<Tuple<int, double>>();

            while (line != null)
            {
                numbers = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                sv.Add(new Tuple<int, double>((int)Double.Parse(numbers[0]), Double.Parse(numbers[1])));
                line = tr.ReadLine();
            }
            tr.Dispose();
            tr.Close();
            return new SparseVector(dimension, type, sv.ToArray());
        }*/
    }
}
