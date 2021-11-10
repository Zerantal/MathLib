// <copyright file="VectorTValueTypeTest.cs">Copyright ©  2008</copyright>

using System;
using MathLib.Matrices;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Diagnostics.Contracts;

using Util;

namespace MathLib.Matrices
{
    [TestClass]
    [PexClass(typeof(Vector<>))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [ContractVerification(false)]
    public partial class VectorTValueTypeTest
    {
        #region Functional tests
      
        [TestMethod]
        public void ArrayMultiplicationTest()
        {
            int length = 5;
            Random r = new Random();
            VectorType orientation;
            Vector<int> A;
            Vector<int> B;

            if (r.Next(2) % 2 == 0)
                orientation = VectorType.RowVector;
            else
                orientation = VectorType.ColumnVector;

            A = new Vector<int>(length, orientation);
            B = new Vector<int>(length, orientation);

            Vector<int> C;

            for (int i = 0; i < length; i++)
            {
                A[i] = r.Next(1000);
                B[i] = r.Next(1000);
            }

            C = A.ArrayMultiplication(B);

            for (var i = 0; i < length; i++)
                Assert.IsTrue(C[i] == A[i] * B[i]);
        }
        

        [TestMethod]
        public void SubtractTest()
        {
            Vector<int> A = new Vector<int>(new int[] {5, 23, 1, 4});
            Vector<int> B = new Vector<int>(new int[] { -12, 432, 12, 1 });
            Vector<int> AMinusB = new Vector<int>(new int[] {17, -409, -11, 3});
            Vector<int> result = A - B;

            Assert.AreEqual(AMinusB, result);
        }

        [TestMethod]
        public void AddTest()
        {
            Vector<int> A = new Vector<int>(new int[] {1, 9, 8, 2});
            Vector<int> B = new Vector<int>(new int[] {3, -5, 2, 12});
            Vector<int> APlusB = new Vector<int>(new int[] {4, 4, 10, 14});
            Vector<int> result = A + B;

            Assert.AreEqual(APlusB, result);
        }

        [TestMethod]
        public void NegateTest()
        {
            Vector<int> A = new Vector<int>(new int[] {1, 2, 3});
            Vector<int> Anegated = new Vector<int>(new int[] {-1, -2, -3});
            Vector<int> result = -A;

            Assert.AreEqual(Anegated, result);
        }

        [TestMethod]
        public void MultiplyTest()
        {
            Vector<int> A = new Vector<int>(new int[] {1, 2, 3});
            Vector<int> B = new Vector<int>(new int[] {6, 4, 2}, VectorType.ColumnVector);
            int dotProduct = 20;
            int result = A * B;

            Assert.AreEqual(dotProduct, result);

            Vector<int> Ax2 = new Vector<int>(new int[] {2, 4, 6});
            Vector<int> actual;

            actual = A * 2;
            Assert.AreEqual(Ax2, actual);
        }

        [TestMethod]
        public void DivideTest()
        {
            Vector<int> A = new Vector<int>(new int[] {12, 33, 6});
            Vector<int> ADiv3 = new Vector<int>(new int[] {4, 11, 2});
            Vector<int> result = A / 3;

            Assert.AreEqual(ADiv3, result);
        }

        [TestMethod]
        public void ItemTest()
        {
            int length = 25;
            int numTestNumbers = 10;
            Vector<int> v = new Vector<int>(length, VectorType.ColumnVector);
            Dictionary<int, int>  testValues = new Dictionary<int, int>();
            Random r = new Random();
            int idx;
            int val;

            for (int i = 0; i < numTestNumbers; i++)
            {
                idx = r.Next(length);
                val = r.Next(100);
                if (!testValues.ContainsKey(idx))
                {
                    testValues.Add(idx, val);
                    v[idx] = val;
                }
            }

            foreach (KeyValuePair<int, int> kvp in testValues)
            {
                Assert.AreEqual(v[kvp.Key], kvp.Value);
            }
        }

        #endregion

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public VectorType OrientationGet<TValueType>([PexAssumeUnderTest]Vector<TValueType> target)
        {
            VectorType result = target.Orientation;
            return result;
            // TODO: add assertions to method VectorTValueTypeTest.OrientationGet(Vector`1<!!0>)
        }
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public int LengthGet<TValueType>([PexAssumeUnderTest]Vector<TValueType> target)
        {
            int result = target.Length;
            return result;
            // TODO: add assertions to method VectorTValueTypeTest.LengthGet(Vector`1<!!0>)
        }
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public void ItemSet<TValueType>(
            [PexAssumeUnderTest]Vector<TValueType> target,
            int index,
            TValueType value
        )
        {
            target[index] = value;
            // TODO: add assertions to method VectorTValueTypeTest.ItemSet(Vector`1<!!0>, Int32, !!0)
        }
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public TValueType ItemGet<TValueType>([PexAssumeUnderTest]Vector<TValueType> target, int index)
        {
            TValueType result = target[index];
            return result;
            // TODO: add assertions to method VectorTValueTypeTest.ItemGet(Vector`1<!!0>, Int32)
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public Vector<TValueType> Constructor03<TValueType>(TValueType[] values)
        {
            Vector<TValueType> target = new Vector<TValueType>(values);
            return target;
            // TODO: add assertions to method VectorTValueTypeTest.Constructor03(!!0[])
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public Vector<TValueType> Constructor01<TValueType>(
            int dimension,
            VectorType orientation,
            TValueType initialValue
        )
        {
            Vector<TValueType> target = new Vector<TValueType>(dimension, orientation, initialValue);
            return target;
            // TODO: add assertions to method VectorTValueTypeTest.Constructor01(Int32, VectorType, !!0)
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod, PexAllowedException(typeof(SizeMismatchException))]
        public Vector<TValueType> Subtract<TValueType>(Vector<TValueType> lhs, Vector<TValueType> rhs)
        {            
            Vector<TValueType> result = Vector<TValueType>.Subtract(lhs, rhs);
            return result;
            // TODO: add assertions to method VectorTValueTypeTest.Subtract(Vector`1<!!0>, Vector`1<!!0>)
        }
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public Vector<TValueType> op_UnaryNegation<TValueType>(Vector<TValueType> arg)
        {
            Vector<TValueType> result = -arg;
            return result;
            // TODO: add assertions to method VectorTValueTypeTest.op_UnaryNegation(Vector`1<!!0>)
        }
        [PexGenericArguments(typeof(int))]
        [PexMethod, PexAllowedException(typeof(SizeMismatchException))]
        public Vector<TValueType> op_Subtraction<TValueType>(Vector<TValueType> lhs, Vector<TValueType> rhs)
        {
            Vector<TValueType> result = lhs - rhs;
            return result;
            // TODO: add assertions to method VectorTValueTypeTest.op_Subtraction(Vector`1<!!0>, Vector`1<!!0>)
        }
        [PexGenericArguments(typeof(int))]
        [PexMethod, PexAllowedException(typeof(SizeMismatchException))]
        public TValueType op_Multiply<TValueType>(Vector<TValueType> lhs, Vector<TValueType> rhs)
        {
            TValueType result = lhs * rhs;
            return result;
            // TODO: add assertions to method VectorTValueTypeTest.op_Multiply(Vector`1<!!0>, Vector`1<!!0>)
        }
        [PexGenericArguments(typeof(int))]
        [PexMethod, PexAllowedException(typeof(SizeMismatchException))]
        public Vector<TValueType> op_Addition<TValueType>(Vector<TValueType> lhs, Vector<TValueType> rhs)
        {
            Vector<TValueType> result = lhs + rhs;
            return result;
            // TODO: add assertions to method VectorTValueTypeTest.op_Addition(Vector`1<!!0>, Vector`1<!!0>)
        }
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public Vector<TValueType> Negate<TValueType>(Vector<TValueType> arg)
        {
            Vector<TValueType> result = Vector<TValueType>.Negate(arg);
            return result;
            // TODO: add assertions to method VectorTValueTypeTest.Negate(Vector`1<!!0>)
        }
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public Vector<TValueType> Multiply02<TValueType>(TValueType lhs, Vector<TValueType> rhs)
        {
            Vector<TValueType> result = Vector<TValueType>.Multiply(lhs, rhs);
            return result;
            // TODO: add assertions to method VectorTValueTypeTest.Multiply02(!!0, Vector`1<!!0>)
        }
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public Vector<TValueType> Multiply01<TValueType>(Vector<TValueType> lhs, TValueType rhs)
        {
            Vector<TValueType> result = Vector<TValueType>.Multiply(lhs, rhs);
            return result;
            // TODO: add assertions to method VectorTValueTypeTest.Multiply01(Vector`1<!!0>, !!0)
        }
        [PexGenericArguments(typeof(int))]
        [PexMethod, PexAllowedException(typeof(SizeMismatchException))]
        public TValueType Multiply<TValueType>(Vector<TValueType> lhs, Vector<TValueType> rhs)
        {
            TValueType result = Vector<TValueType>.Multiply(lhs, rhs);
            return result;
            // TODO: add assertions to method VectorTValueTypeTest.Multiply(Vector`1<!!0>, Vector`1<!!0>)
        }
        [PexGenericArguments(typeof(int))]
        [PexMethod, PexAllowedException(typeof(DivideByZeroException))]
        public Vector<TValueType> Divide<TValueType>(Vector<TValueType> lhs, TValueType rhs)
        {
            Vector<TValueType> result = Vector<TValueType>.Divide(lhs, rhs);
            return result;
            // TODO: add assertions to method VectorTValueTypeTest.Divide(Vector`1<!!0>, !!0)
        }
        [PexGenericArguments(typeof(int))]
        [PexMethod, PexAllowedException(typeof(SizeMismatchException))]
        public Vector<TValueType> Add<TValueType>(Vector<TValueType> lhs, Vector<TValueType> rhs)
        {
            Vector<TValueType> result = Vector<TValueType>.Add(lhs, rhs);
            return result;
            // TODO: add assertions to method VectorTValueTypeTest.Add(Vector`1<!!0>, Vector`1<!!0>)
        }
    }
}
