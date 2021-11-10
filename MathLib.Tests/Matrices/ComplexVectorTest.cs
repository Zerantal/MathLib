// <copyright file="ComplexVectorTest.cs">Copyright ©  2008</copyright>

using System;
using MathLib.Matrices;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLib.Statistics;
using System.Numerics;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace MathLib.Matrices
{
    [TestClass]
    [PexClass(typeof(ComplexVector))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [ContractVerification(false)]
    public partial class ComplexVectorTest
    {
        #region Functional tests

        [TestMethod]
        public void CloneTest()
        {
            ComplexVector A = new ComplexVector(new Complex[] {
                new Complex(1, 2), new Complex(3, 4), new Complex(5, 6)});
            ComplexVector A2 = A.DeepClone() as ComplexVector;

            Assert.AreEqual(A, A2);
            Assert.AreNotSame(A, A2);

            A2[1] = new Complex(1241251235, 125623623);
            Assert.AreNotEqual(A, A2);
        }

        [TestMethod]
        public void ItemTest()
        {
            int length = 25;
            int numTestNumbers = 10;
            ComplexVector v = new ComplexVector(length, VectorType.ColumnVector);
            Dictionary<int, Complex>  testValues = new Dictionary<int, Complex>();
            Random r = new Random();
            int idx;
            Complex val;

            for (int i = 0; i < numTestNumbers; i++)
            {
                idx = r.Next(length);
                val = new Complex(r.Next(100), r.Next(100)-50);
                if (!testValues.ContainsKey(idx))
                {
                    testValues.Add(idx,  val);
                    v[idx] = val;
                }
            }

            foreach (KeyValuePair<int, Complex> kvp in testValues)
            {
                Assert.AreEqual(v[kvp.Key], kvp.Value);
            }
        }

        #endregion

        [PexMethod]
        public ComplexVector Constructor04(
            int dimension,
            INumberGenerator realNumberGenerator,
            INumberGenerator imaginaryNumberGenerator,
            VectorType orientation
        )
        {
            ComplexVector target
       = new ComplexVector(dimension, realNumberGenerator, imaginaryNumberGenerator, orientation);
            return target;
            // TODO: add assertions to method ComplexVectorTest.Constructor04(Int32, INumberGenerator, INumberGenerator, VectorType)
        }
        [PexMethod]
        public ComplexVector Constructor03(Complex[] values)
        {
            ComplexVector target = new ComplexVector(values);
            return target;
            // TODO: add assertions to method ComplexVectorTest.Constructor03(Complex[])
        }
        [PexMethod]
        public ComplexVector Constructor02(VectorType orientation, Complex[] values)
        {
            ComplexVector target = new ComplexVector(values, orientation);
            return target;
            // TODO: add assertions to method ComplexVectorTest.Constructor02(VectorType, Complex[])
        }
        [PexMethod]
        public ComplexVector Constructor01(
            int dimension,
            VectorType orientation,
            Complex initialValue
        )
        {
            ComplexVector target = new ComplexVector(dimension, orientation, initialValue);
            return target;
            // TODO: add assertions to method ComplexVectorTest.Constructor01(Int32, VectorType, Complex)
        }

    }
}
