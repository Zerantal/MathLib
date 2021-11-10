// <copyright file="ComplexMatrixTest.cs">Copyright ©  2008</copyright>
using System;
using System.Collections.Generic;
using System.Numerics;
using MathLib.Matrices;
using MathLib.Statistics;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.Contracts;

namespace MathLib.Matrices
{    
    /// <summary>This class contains parameterized unit tests for ComplexMatrix</summary>
    [PexClass(typeof(ComplexMatrix))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    [ContractVerification(false)]
    public partial class ComplexMatrixTest
    {
        #region Functional tests

        [TestMethod]
        public void CloneTest()
        {
            ComplexMatrix A = MatrixData.CM_A.AsComplexMatrix();
            ComplexMatrix A2 = A.DeepClone() as ComplexMatrix;

            Assert.AreEqual(A, A2);
            Assert.AreNotSame(A, A2);

            A2[1, 1] = new Complex(1241251235, 125623623);
            Assert.AreNotEqual(A, A2);
        }

        #endregion
    }
}
