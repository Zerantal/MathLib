// <copyright file="MatrixExtensionsTest.cs">Copyright ©  2008</copyright>

using System;
using MathLib.Matrices;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using System.Diagnostics.Contracts;

namespace MathLib.Matrices
{
    [ContractVerification(false)]
    [TestClass]
    [PexClass(typeof(MatrixExtensions))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class MatrixExtensionsTest
    {
        [TestMethod]
        public void AsComplexMatrixTest()
        {
            int rows = 3, cols = 3;
            Matrix<Complex> testMatrix = new Matrix<Complex>(rows, cols);
            Random rand = new Random();

            for (int r = 0; r < testMatrix.Rows; r++)
                for (int c = 0; c < testMatrix.Columns; c++)
                    testMatrix[r, c] = new Complex(rand.NextDouble(), rand.NextDouble());

            ComplexMatrix result = testMatrix.AsComplexMatrix();

            for (int r = 0; r < testMatrix.Rows; r++)
                for (int c = 0; c < testMatrix.Columns; c++)
                    Assert.AreEqual(testMatrix[r, c], result[r, c]);
        }

        [TestMethod]
        public void IsEqualToTest()
        {
            int rows = 3, cols = 3;
            Matrix<Complex> testMatrix = new Matrix<Complex>(rows, cols);
            Random rand = new Random();
            double tolerance = 0.001;
            Matrix<Complex> testMatrixClone;

            for (int r = 0; r < testMatrix.Rows; r++)
                for (int c = 0; c < testMatrix.Columns; c++)
                    testMatrix[r, c] = new Complex(rand.NextDouble(), rand.NextDouble());

            testMatrixClone = testMatrix.DeepClone();

            Assert.IsTrue(testMatrix.IsEqualTo(testMatrixClone));

            Complex val = testMatrixClone[0, 0];
            testMatrixClone[0, 0] = new Complex(val.Real + (tolerance / 2), val.Imaginary + (tolerance / 2));
            Assert.IsTrue(testMatrix.IsEqualTo(testMatrixClone, tolerance));

            testMatrixClone[0, 0] = new Complex(val.Real + (tolerance * 2), val.Imaginary + (tolerance * 2));
            Assert.IsFalse(testMatrix.IsEqualTo(testMatrixClone, tolerance));
        }
        [PexMethod]
        public bool IsEqualTo(
            Matrix<Complex> m1,
            Matrix<Complex> m2,
            double errorTolerance
        )
        {
            bool result = MatrixExtensions.IsEqualTo(m1, m2, errorTolerance);
            return result;
            // TODO: add assertions to method MatrixExtensionsTest.IsEqualTo(Matrix`1<Complex>, Matrix`1<Complex>, Double)
        }
        [PexMethod]
        public ComplexMatrix AsComplexMatrix(Matrix<Complex> m)
        {
            ComplexMatrix result = MatrixExtensions.AsComplexMatrix(m);
            return result;
            // TODO: add assertions to method MatrixExtensionsTest.AsComplexMatrix(Matrix`1<Complex>)
        }
    }
}
