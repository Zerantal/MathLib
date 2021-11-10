// <copyright file="VectorTest.cs">Copyright ©  2008</copyright>
using System;
using MathLib.Matrices;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using MathLib.Statistics;

namespace MathLib.Matrices
{
    /// <summary>This class contains parameterized unit tests for Vector</summary>
    [PexClass(typeof(Vector))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    [ContractVerification(false)]
    public partial class VectorTest
    {
        #region Functional Tests

        [TestMethod]
        public void DotProductTest()
        {
            Vector A = new Vector(new double[] {6, 2, 4});
            Vector B = new Vector(new double[] {434.2, -99, 1.3});
            double ans = 2412.40000000000;

            Assert.IsTrue(ans.IsEqualTo(Vector.DotProduct(A, B)));
        }

        [TestMethod]
        public void CloneTest()
        {
            Vector A = new Vector(new double[] { 5, 23, -25, 6 });
            Vector Aclone = A.DeepClone();

            Assert.AreEqual(A, Aclone);
        }

        [TestMethod]
        public void InfinityNormTest()
        {
            Vector A = new Vector(new double[] { 5, 23, -25, 6 });
            double expected = 25;
            double actual = A.InfinityNorm;

            Assert.IsTrue(expected.IsEqualTo(actual));
        }

        [TestMethod]
        public void OneNormTest()
        {
            Vector A = new Vector(new double[] { 1, -2, 3, -4 });
            double expected = 10;
            double actual = A.OneNorm;

            Assert.IsTrue(expected.IsEqualTo(actual));
        }

        [TestMethod]
        public void NormTest()
        {
            Vector v = new Vector(new double[] { 1, 2, 3 });
            double expected = 3.7416573867739413855837487323165;

            Assert.IsTrue(v.Norm.IsEqualTo(expected));
        }

        [TestMethod]
        public void NormSquaredTest()
        {
            Vector v = new Vector(new double[] { 1, 2, 3 });
            double expected = 14;
            Assert.IsTrue(v.NormSquared.IsEqualTo(expected));
        }

        [TestMethod]
        public void SubtractTest()
        {
            Vector A = new Vector(new double[] { 5, 23, 1, 4 });
            Vector B = new Vector(new double[] { -12, 432, 12, 1 });
            Vector AMinusB = new Vector(new double[] { 17, -409, -11, 3 });
            Vector result = A - B;

            Assert.AreEqual(AMinusB, result);
        }

        [TestMethod]
        public void AddTest()
        {
            Vector A = new Vector(new double[] { 1, 9, 8, 2 });
            Vector B = new Vector(new double[] { 3, -5, 2, 12 });
            Vector APlusB = new Vector(new double[] { 4, 4, 10, 14 });
            Vector result = A + B;

            Assert.AreEqual(APlusB, result);
        }

        [TestMethod]
        public void NegateTest()
        {
            Vector A = new Vector(new double[] { 1, 2, 3 });
            Vector Anegated = new Vector(new double[] { -1, -2, -3 });
            Vector result = -A;

            Assert.AreEqual(Anegated, result);
        }

        [TestMethod]
        public void MultiplyTest()
        {
            Vector A = new Vector(new double[] { 1, 2, 3 });
            Vector B = new Vector(new double[] { 6, 4, 2 }, VectorType.ColumnVector);
            double dotProduct = 20;
            double result = A * B;

            Assert.AreEqual(dotProduct, result);

            Vector Ax2 = new Vector(new double[] { 2, 4, 6 });
            Vector actual;

            actual = A * 2;
            Assert.AreEqual(Ax2, actual);
        }

        [TestMethod]
        public void DivideTest()
        {
            Vector A = new Vector(new double[] { 12, 33, 6 });
            Vector ADiv3 = new Vector(new double[] { 4, 11, 2 });
            Vector result = A / 3;

            Assert.AreEqual(ADiv3, result);
        }

        #endregion

        /// <summary>Test stub for .ctor(VectorType, Double[])</summary>
        [PexMethod]
        public Vector Constructor02(VectorType orientation, double[] values)
        {
            Vector target = new Vector(values, orientation);
            return target;
            // TODO: add assertions to method VectorTest.Constructor02(VectorType, Double[])
        }

        /// <summary>Test stub for .ctor(Double[])</summary>
        [PexMethod]
        public Vector Constructor03(double[] values)
        {
            Vector target = new Vector(values);
            return target;
            // TODO: add assertions to method VectorTest.Constructor03(Double[])
        }

        /// <summary>Test stub for get_Item(Int32)</summary>
        [PexMethod]
        public double ItemGet([PexAssumeUnderTest]Vector target, int index)
        {
            double result = target[index];
            return result;
            // TODO: add assertions to method VectorTest.ItemGet(Vector, Int32)
        }

        /// <summary>Test stub for set_Item(Int32, Double)</summary>
        [PexMethod]
        public void ItemSet(
            [PexAssumeUnderTest]Vector target,
            int index,
            double value
        )
        {
            target[index] = value;
            // TODO: add assertions to method VectorTest.ItemSet(Vector, Int32, Double)
        }

        /// <summary>Test stub for get_Length()</summary>
        [PexMethod]
        public int LengthGet([PexAssumeUnderTest]Vector target)
        {
            int result = target.Length;
            return result;
            // TODO: add assertions to method VectorTest.LengthGet(Vector)
        }

        /// <summary>Test stub for get_Orientation()</summary>
        [PexMethod]
        public VectorType OrientationGet([PexAssumeUnderTest]Vector target)
        {
            VectorType result = target.Orientation;
            return result;
            // TODO: add assertions to method VectorTest.OrientationGet(Vector)
        }
        [PexMethod, PexAllowedException(typeof(SizeMismatchException))]
        public Vector Subtract(Vector lhs, Vector rhs)
        {
            Vector result = Vector.Subtract(lhs, rhs);
            return result;
            // TODO: add assertions to method VectorTest.Subtract(Vector, Vector)
        }
        [PexMethod]
        public Vector op_UnaryNegation(Vector arg)
        {
            Vector result = -arg;
            return result;
            // TODO: add assertions to method VectorTest.op_UnaryNegation(Vector)
        }
        [PexMethod, PexAllowedException(typeof(SizeMismatchException))]
        public Vector op_Subtraction(Vector lhs, Vector rhs)
        {
            Vector result = lhs - rhs;
            return result;
            // TODO: add assertions to method VectorTest.op_Subtraction(Vector, Vector)
        }
        [PexMethod]
        public Vector op_Multiply02(double lhs, Vector rhs)
        {
            Vector result = lhs * rhs;
            return result;
            // TODO: add assertions to method VectorTest.op_Multiply02(Double, Vector)
        }
        [PexMethod]
        public Vector op_Multiply01(Vector lhs, double rhs)
        {
            Vector result = lhs * rhs;
            return result;
            // TODO: add assertions to method VectorTest.op_Multiply01(Vector, Double)
        }
        [PexMethod, PexAllowedException(typeof(SizeMismatchException))]
        public double op_Multiply(Vector lhs, Vector rhs)
        {
            double result = lhs * rhs;
            return result;
            // TODO: add assertions to method VectorTest.op_Multiply(Vector, Vector)
        }
        [PexMethod]
        public Vector op_Division(Vector lhs, double rhs)
        {
            Vector result = lhs / rhs;
            return result;
            // TODO: add assertions to method VectorTest.op_Division(Vector, Double)
        }
        [PexMethod, PexAllowedException(typeof(SizeMismatchException))]
        public Vector op_Addition(Vector lhs, Vector rhs)
        {
            Vector result = lhs + rhs;
            return result;
            // TODO: add assertions to method VectorTest.op_Addition(Vector, Vector)
        }
        [PexMethod]
        public double OneNormGet([PexAssumeUnderTest]Vector target)
        {
            double result = target.OneNorm;
            return result;
            // TODO: add assertions to method VectorTest.OneNormGet(Vector)
        }
        [PexMethod]
        public double NormSquaredGet([PexAssumeUnderTest]Vector target)
        {
            double result = target.NormSquared;
            return result;
            // TODO: add assertions to method VectorTest.NormSquaredGet(Vector)
        }
        [PexMethod]
        public double NormGet([PexAssumeUnderTest]Vector target)
        {
            double result = target.Norm;
            return result;
            // TODO: add assertions to method VectorTest.NormGet(Vector)
        }
        [PexMethod]
        public Vector Negate(Vector arg)
        {
            Vector result = Vector.Negate(arg);
            return result;
            // TODO: add assertions to method VectorTest.Negate(Vector)
        }
        [PexMethod]
        public Vector Multiply02(double lhs, Vector rhs)
        {
            Vector result = Vector.Multiply(lhs, rhs);
            return result;
            // TODO: add assertions to method VectorTest.Multiply02(Double, Vector)
        }
        [PexMethod]
        public Vector Multiply01(Vector lhs, double rhs)
        {
            Vector result = Vector.Multiply(lhs, rhs);
            return result;
            // TODO: add assertions to method VectorTest.Multiply01(Vector, Double)
        }
        [PexMethod, PexAllowedException(typeof(SizeMismatchException))]
        public double Multiply(Vector lhs, Vector rhs)
        {
            double result = Vector.Multiply(lhs, rhs);
            return result;
            // TODO: add assertions to method VectorTest.Multiply(Vector, Vector)
        }
        [PexMethod]
        public double InfinityNormGet([PexAssumeUnderTest]Vector target)
        {
            double result = target.InfinityNorm;
            return result;
            // TODO: add assertions to method VectorTest.InfinityNormGet(Vector)
        }
        [PexMethod]
        public IEnumerator<double> GetEnumerator([PexAssumeUnderTest]Vector target)
        {
            IEnumerator<double> result = target.GetEnumerator();
            return result;
            // TODO: add assertions to method VectorTest.GetEnumerator(Vector)
        }
        [PexMethod]
        public Vector Divide(Vector lhs, double rhs)
        {
            Vector result = Vector.Divide(lhs, rhs);
            return result;
            // TODO: add assertions to method VectorTest.Divide(Vector, Double)
        }
        [PexMethod, PexAllowedException(typeof(SizeMismatchException))]
        public Vector Add(Vector lhs, Vector rhs)
        {
            Vector result = Vector.Add(lhs, rhs);
            return result;
            // TODO: add assertions to method VectorTest.Add(Vector, Vector)
        }

        [PexMethod]
        public Vector Clone([PexAssumeUnderTest]Vector target)
        {
            Vector result = target.DeepClone();
            return result;
            // TODO: add assertions to method VectorTest.Clone(Vector)
        }
        [PexMethod]
        public Vector Constructor(
            int dimension,
            VectorType orientation,
            INumberGenerator numberSource
        )
        {
            Vector target = new Vector(dimension, orientation, numberSource);
            return target;
            // TODO: add assertions to method VectorTest.Constructor(Int32, VectorType, INumberGenerator)
        }
    }
}
