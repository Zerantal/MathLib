// <copyright file="FourierTest.cs">Copyright ©  2008</copyright>

using System;
using MathLib;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.Contracts;
using System.Numerics;
using System.Collections.Generic;
using System.IO;

using Microsoft.Pex.Framework.Explorable;
using Microsoft.Pex.Framework.Generated;
using MathLib.Matrices;
using Microsoft.ExtendedReflection.DataAccess;

using MathLib.SignalAnalysis;

namespace MathLib
{
    [TestClass]
    [PexClass(typeof(Fourier))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [ContractVerification(false)]
    public partial class FourierTest
    {
        [PexMethod]
        public ComplexMatrix IFFT2D(ComplexMatrix data)
        {
            ComplexMatrix result = Fourier.Ifft2D(data);
            ComplexMatrix inverse = Fourier.Fft2D(result);

            Assert.IsTrue(data.IsEqualTo(inverse, 0.0001));

            return result;
        }
        [PexMethod]
        public ComplexVector IFFT(ComplexVector data)
        {
            ComplexVector result = Fourier.Ifft(data);
            ComplexMatrix inverse = Fourier.Fft(result);

            Assert.IsTrue(data.IsEqualTo(inverse, 0.0001));
            return result;
        }
        [PexMethod]
        public ComplexMatrix FFT2D(ComplexMatrix data)
        {
            ComplexMatrix result = Fourier.Fft2D(data);
            ComplexMatrix inverse = Fourier.Ifft2D(result);

            Assert.IsTrue(data.IsEqualTo(inverse, 0.0001));
            return result;
        }
        [PexMethod]
        public ComplexVector FFT(ComplexVector data)
        {
            ComplexVector result = Fourier.Fft(data);
            ComplexMatrix inverse = Fourier.Ifft(result);

            Assert.IsTrue(data.IsEqualTo(inverse, 0.0001));
            return result;
        }

        private ComplexVector ReadComplexVector(string fileName)
        {
            Contract.Requires(fileName != null);

            TextReader tr = new StreamReader(fileName);

            string line = tr.ReadLine();
            string[] numbers;
            List<Complex> data = new List<Complex>();

            while (line != null)
            {
                numbers = line.Split(new char[] { '\t' });
                data.Add(new Complex(Double.Parse(numbers[0]), Double.Parse(numbers[1])));
                line = tr.ReadLine();
            }
            tr.Dispose();
            return new ComplexVector(data.ToArray());
        }

        private ComplexMatrix ReadComplexMatrix(string fileName)
        {
            Contract.Requires(fileName != null);

            TextReader tr = new StreamReader(fileName);
            ComplexMatrix data;
            int rows, columns;
            char[] delimeter = new char[] { '\t' };

            string line = tr.ReadLine();
            string[] numbers = line.Split(delimeter);  // retrieve dimensions of 2d data
            rows = int.Parse(numbers[0]);
            columns = int.Parse(numbers[1]);
            data = new ComplexMatrix(rows, columns);

            for (int rc = 0; rc < rows; rc++)
            {
                line = tr.ReadLine();
                numbers = line.Split(delimeter);
                for (int cc = 0; cc < columns; cc++)
                {
                    data[rc, cc] = new Complex(Double.Parse(numbers[cc]), Double.Parse(numbers[cc + columns]));
                }
            }

            tr.Dispose();
            return data;
        }


        /// <summary>
        ///A test for FFT
        ///</summary>
        [TestMethod()]
        public void FFTTest()
        {
            ComplexVector data = ReadComplexVector("testData1.txt");
            ComplexVector expected = ReadComplexVector("fftOfTestData1.txt");
            ComplexVector actual;
            actual = this.FFT(data);

            Assert.IsTrue(actual.IsEqualTo(expected, 0.0001));

            data = ReadComplexVector("testData2.txt");
            expected = ReadComplexVector("fftOfTestData2.txt");
            actual = this.FFT(data);

            Assert.IsTrue(actual.IsEqualTo(expected, 0.0001));
        }

        /// <summary>
        ///A test for IFFT
        ///</summary>
        [TestMethod()]
        public void IFFTTest()
        {
            ComplexVector data = ReadComplexVector("fftOfTestData1.txt");
            ComplexVector expected = ReadComplexVector("testData1.txt");
            ComplexVector actual;
            actual = this.IFFT(data);

            Assert.IsTrue(actual.IsEqualTo(expected, 0.0001));
        }

        /// <summary>
        ///A test for FFT2D
        ///</summary>
        [TestMethod()]
        public void FFT2DTest()
        {
            ComplexMatrix data = ReadComplexMatrix("testData2D.txt");
            ComplexMatrix expected = ReadComplexMatrix("fftOfTestData2D.txt");
            ComplexMatrix actual;
            actual = this.FFT2D(data);

            Assert.IsTrue(actual.IsEqualTo(expected, 0.0001));
        }

        /// <summary>
        ///A test for IFFT2D
        ///</summary>
        [TestMethod()]
        public void IFFT2DTest()
        {
            ComplexMatrix data = ReadComplexMatrix("fftOfTestData2D.txt");
            ComplexMatrix expected = ReadComplexMatrix("testData2D.txt");
            ComplexMatrix actual;
            actual = this.IFFT2D(data);

            Assert.IsTrue(actual.IsEqualTo(expected, 0.0001));
        }
      
    }
}
