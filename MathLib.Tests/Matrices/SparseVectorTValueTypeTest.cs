// <copyright file="SparseVectorTValueTypeTest.cs">Copyright ©  2008</copyright>

using System;
using MathLib.Matrices;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.Contracts;

namespace MathLib.Matrices
{
    [TestClass]
    [PexClass(typeof(SparseVector<>))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [ContractVerification(false)]
    public partial class SparseVectorTValueTypeTest
    {
        #region Functional Tests

        private Tuple<int, int>[] GenerateVectorTuples(int length, int numValues)
        {
            List<Tuple<int, int>> values = new List<Tuple<int, int>>();
            Random r = new Random();

            for (int i = 0; i < numValues; i++)
            {
                values.Add(new Tuple<int, int>(r.Next(length), r.Next(int.MinValue, int.MaxValue)));
            }

            return values.ToArray();
        }

        [TestMethod]
        public void ValueEnumeratorTest()
        {
            int length = 20000;            
            int numValues = 100;
            Tuple<int, int>[] values;
            List<Tuple<int, int>> expectedValues = new List<Tuple<int, int>>(numValues);
            Random r = new Random();
            VectorType vecType;
            SparseVector<int> sv;

            if (r.Next(2) == 0)
                vecType = VectorType.RowVector;
            else
                vecType = VectorType.ColumnVector;

            do
            {
                values = GenerateVectorTuples(length, numValues);
                sv = new SparseVector<int>(length, vecType, values);
            }
            while (sv.NumberOfNonzeroElements != numValues);

            foreach (Tuple<int, int> v in sv.ValueEnumerator)
                expectedValues.Add(v);

            List<int> sl1, sl2; // sorted versions of the two lists to compare
            sl1 = new List<int>(values.Select<Tuple<int, int>, int>(i => i.Item2));
            sl1.Sort();
            sl2 = new List<int>(expectedValues.Select<Tuple<int, int>, int>(i => i.Item2));
            sl2.Sort();
                       
            Assert.IsTrue(sl1.SequenceEqual<int>(sl2)); 

        }

        [TestMethod]
        public void SubtractAddTest()
        {
            Assert.Inconclusive();
            /*
            int vectorLength = 10000;
            int numValues = 10;
            Random r = new Random();
            VectorType vecType = r.Next(2) == 0 ? VectorType.RowVector : VectorType.ColumnVector;
            SparseVector<int> A = new SparseVector<int>(vectorLength, vecType, GenerateVectorTuples(vectorLength, numValues));
            SparseVector<int> B = new SparseVector<int>(vectorLength, vecType, GenerateVectorTuples(vectorLength, numValues));
            SparseVector<int> APlusB = A + B;
            SparseVector<int> APlusBMinusB = APlusB - B;

            Assert.AreEqual(APlusBMinusB, A);
             * */
        }
        
        [TestMethod]
        public void NegateTest()
        {
            Assert.Inconclusive();
            //Vector<int> A = new Vector<int>(new int[] { 1, 2, 3 });
            //Vector<int> Anegated = new Vector<int>(new int[] { -1, -2, -3 });
            //Vector<int> result = -A;

            //Assert.AreEqual(Anegated, result);
        }

        [TestMethod]
        public void MultiplyTest()
        {
            Assert.Inconclusive();
            //Vector<int> A = new Vector<int>(new int[] { 1, 2, 3 });
            //Vector<int> B = new Vector<int>(new int[] { 6, 4, 2 }, VectorType.ColumnVector);
            //int dotProduct = 20;
            //int result = A * B;

            //Assert.AreEqual(dotProduct, result);

            //Vector<int> Ax2 = new Vector<int>(new int[] { 2, 4, 6 });
            //Vector<int> actual;

            //actual = A * 2;
            //Assert.AreEqual(Ax2, actual);
        }

        [TestMethod]
        public void DivideTest()
        {
            Assert.Inconclusive();
            //Vector<int> A = new Vector<int>(new int[] { 12, 33, 6 });
            //Vector<int> ADiv3 = new Vector<int>(new int[] { 4, 11, 2 });
            //Vector<int> result = A / 3;

            //Assert.AreEqual(ADiv3, result);
        }

        [TestMethod]
        public void ItemTest()
        {
            Assert.Inconclusive();
            //int length = 25;
            //int numTestNumbers = 10;
            //Vector<int> v = new Vector<int>(length, VectorType.ColumnVector);
            //Dictionary<int, int>  testValues = new Dictionary<int, int>();
            //Random r = new Random();
            //int idx;
            //int val;

            //for (int i = 0; i < numTestNumbers; i++)
            //{
            //    idx = r.Next(length);
            //    val = r.Next(100);
            //    if (!testValues.ContainsKey(idx))
            //    {
            //        testValues.Add(idx, val);
            //        v[idx] = val;
            //    }
            //}

            //foreach (KeyValuePair<int, int> kvp in testValues)
            //{
            //    Assert.AreEqual(v[kvp.Key], kvp.Value);
            //}
        }


        #endregion

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public VectorType OrientationGet<TValueType>([PexAssumeUnderTest]SparseVector<TValueType> target)
        {
            VectorType result = target.Orientation;
            return result;
            // TODO: add assertions to method SparseVectorTValueTypeTest.OrientationGet(SparseVector`1<!!0>)
        }
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public int LengthGet<TValueType>([PexAssumeUnderTest]SparseVector<TValueType> target)
        {
            int result = target.Length;
            return result;
            // TODO: add assertions to method SparseVectorTValueTypeTest.LengthGet(SparseVector`1<!!0>)
        }
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public void ItemSet<TValueType>(
            [PexAssumeUnderTest]SparseVector<TValueType> target,
            int index,
            TValueType value
        )
        {
            target[index] = value;
            // TODO: add assertions to method SparseVectorTValueTypeTest.ItemSet(SparseVector`1<!!0>, Int32, !!0)
        }
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public TValueType ItemGet<TValueType>([PexAssumeUnderTest]SparseVector<TValueType> target, int index)
        {
            TValueType result = target[index];
            return result;
            // TODO: add assertions to method SparseVectorTValueTypeTest.ItemGet(SparseVector`1<!!0>, Int32)
        }
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public SparseVector<TValueType> Constructor01<TValueType>(int dimension, VectorType orientation)
        {
            SparseVector<TValueType> target = new SparseVector<TValueType>(dimension, orientation);
            return target;
            // TODO: add assertions to method SparseVectorTValueTypeTest.Constructor01(Int32, VectorType)
        }
    }
}
