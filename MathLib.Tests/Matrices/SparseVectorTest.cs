// <copyright file="SparseVectorTest.cs">Copyright ©  2008</copyright>

using System;
using MathLib.Matrices;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.Contracts;

namespace MathLib.Matrices
{
    [TestClass]
    [PexClass(typeof(SparseVector))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [ContractVerification(false)]
    public partial class SparseVectorTest
    {
        #region Functional Tests

        [TestMethod]
        public void InfinityNormTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void OneNormTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void NormTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void NormSquaredTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void AddSubtractTest()
        {

        }

        [TestMethod]
        public void SubtractTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void AddTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void NegateTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void MultiplyTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void DivideTest()
        {
            Assert.Inconclusive();
        }
      
        #endregion

        [PexMethod]
        public SparseVector Constructor01(int dimension, VectorType orientation)
        {
            SparseVector target = new SparseVector(dimension, orientation);
            return target;
            // TODO: add assertions to method SparseVectorTest.Constructor01(Int32, VectorType)
        }
    }
}
