// <copright file="MatrixTest.cs">Copyright ©  2008</copyright>
using System;
using MathLib.Matrices;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.Contracts;

using MathLib.Statistics;

namespace MathLib.Matrices
{
    /// <summary>This class contains parameterized unit tests for Matrix</summary>
    [PexClass(typeof(Matrix))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    [ContractVerification(false)]
    public partial class MatrixTest
    {
        #region Functional Tests

        [TestMethod]
        public void GetRowTest()
        {
            Matrix m = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            Vector expected = new Vector(new double[] { 4, 5, 6 }, VectorType.RowVector);
            Vector actual = m.GetRow(1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RowNormsTest()
        {
            Assert.Inconclusive();

        }

        [TestMethod]
        public void IsEqualsToTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void CloneTest()
        {
            Matrix A = new Matrix(new double[2, 3] { { 1, 2, 3 }, { 1, 2, 3 } });
            Matrix A2 = A.DeepClone();

            A2[1, 1] = 666;
            Assert.AreNotEqual(A, A2);
        }

        #endregion       
    }
}
