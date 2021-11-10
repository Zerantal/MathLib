// <copyright file="SparseMatrixTValueTypeTest.cs">Copyright ©  2008</copyright>
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
    /// <summary>This class contains parameterized unit tests for SparseMatrix`1</summary>
    [PexClass(typeof(SparseMatrix<>))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    [ContractVerification(false)]
    public partial class SparseMatrixTValueTypeTest
    {

        #region Functional Tests

        static Random r;

        [TestInitialize]
        public void initRandom()
        {
            r = new Random();
        }

        private Tuple<int, int, int>[] GenerateMatrixTuples(int rows, int cols, int numValues)
        {
            List<Tuple<int, int, int>> values = new List<Tuple<int, int, int>>();
            

            while (values.Count() != numValues)
            {
                for (int i = values.Count(); i < numValues; i++)
                    values.Add(new Tuple<int, int, int>(r.Next(rows), r.Next(cols), r.Next(int.MinValue, int.MaxValue)));

                values = values.Distinct<Tuple<int, int, int>>(new MatrixElementComparer()).ToList();
            }

            return values.ToArray();
        }

        [TestMethod]
        public void EqualityAndInequalityTest()
        {
            int rows = 100;
            int cols = 150;
            int numValues = 20;
            Tuple<int, int, int>[] matrixValues = GenerateMatrixTuples(rows, cols, numValues);
            SparseMatrix<int> A = new SparseMatrix<int>(rows, cols, matrixValues);
            SparseMatrix<int> A2 = new SparseMatrix<int>(rows, cols, matrixValues);
            Assert.IsTrue(A == A2);
            Assert.IsFalse(A != A2);

            A2[rows / 2, cols / 2] = 66666;

            Assert.IsFalse(A == A2);
            Assert.IsTrue(A != A2);
        }

        [TestMethod]
        public void ValueEnumeratorTest()
        {
            int rows = 20000;
            int cols = 20000;
            int numValues = 100;
            Tuple<int, int, int>[] values = GenerateMatrixTuples(rows, cols, numValues);
            List<Tuple<int, int, int>> expectedValues = new List<Tuple<int, int, int>>(numValues);

            SparseMatrix<int> sm = new SparseMatrix<int>(rows, cols, values);

            foreach (Tuple<int, int, int> v in sm.ValueEnumerator)
                expectedValues.Add(v);

            List<int> sl1, sl2; // sorted versions of the two lists to compare
            sl1 = new List<int>(values.Select<Tuple<int, int, int>, int>(i => i.Item3));
            sl1.Sort();
            sl2 = new List<int>(expectedValues.Select<Tuple<int, int, int>, int>(i => i.Item3));
            sl2.Sort();

            Assert.IsTrue(sl1.SequenceEqual<int>(sl2));
        }

        [TestMethod]
        public void GetRowtest()
        {            
            int rows = 10, cols = 10, numValues = 20;
            Tuple<int, int, int>[] matrixValues = GenerateMatrixTuples(rows, cols, numValues);
            SparseMatrix<int> sm = new SparseMatrix<int>(rows, cols, matrixValues);
            SparseVector<int> expected = new SparseVector<int>(cols, VectorType.RowVector);
            int testRow = rows / 2;

            SparseVector<int> actual = sm.GetRow(testRow);

            foreach (Tuple<int, int, int> val in matrixValues)
                if (val.Item1 == testRow)
                    expected[val.Item2] = val.Item3;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetColumnTest()
        {            
            int rows = 10, cols = 10, numValues = 20;
            Tuple<int, int, int>[] matrixValues = GenerateMatrixTuples(rows, cols, numValues);
            SparseMatrix<int> sm = new SparseMatrix<int>(rows, cols, matrixValues);
            SparseVector<int> expected = new SparseVector<int>(cols, VectorType.ColumnVector);
            int testColumn = cols / 2;

            SparseVector<int> actual = sm.GetColumn(testColumn);

            foreach (Tuple<int, int, int> val in matrixValues)
                if (val.Item2 == testColumn)
                    expected[val.Item1] = val.Item3;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetRowTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void SetColumnTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void RowEnumeratorTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void ColumnEnumeratorTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void TransposeTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void RepeatTest()
        {
            Matrix<int> m = new Matrix<int>(new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } });
            Matrix<int> expected = new Matrix<int>(new int[6, 6] {
                {1, 2, 3, 1, 2, 3},
                {4, 5, 6, 4, 5, 6},
                {1, 2, 3, 1, 2, 3},
                {4, 5, 6, 4, 5, 6},
                {1, 2, 3, 1, 2, 3},
                {4, 5, 6, 4, 5, 6}
            });

            Matrix<int> actual = m.Repeat(3, 2);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void ItemTest()
        {            
            int rows = 20015, cols = 20010;
            int numTestNumbers = 20;
            Tuple<int, int, int>[] testValues1 = GenerateMatrixTuples(rows, cols, numTestNumbers);
            Tuple<int, int, int>[] testValues2 = GenerateMatrixTuples(rows, cols, numTestNumbers);

            // create combinedTestValues using testValues2 and elements of testValues1 that don't appear in testValues2
            Tuple<int, int, int>[] combinedTestValues = testValues2.Concat(
                testValues1.Where<Tuple<int, int, int>>(t => !testValues2.Contains(t))).ToArray();

            SparseMatrix<int> sm = new SparseMatrix<int>(rows, cols, testValues1);

            foreach (Tuple<int, int, int> t in testValues2)
                sm[t.Item1, t.Item2] = t.Item3;

            foreach (Tuple<int, int, int> t in combinedTestValues)
                Assert.AreEqual(t.Item3, sm[t.Item1, t.Item2]);

        }

        [TestMethod]
        public void NumberOfNonzeroElementsTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void AsVectorTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void CopyToTest()
        {
            Assert.Inconclusive();
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

        [TestMethod]
        public void CloneTest()
        {

        }

        [TestMethod]
        public void EqualsMatrixTest()
        {

        }
        #endregion

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public SparseMatrix<TValueType> Constructor02<TValueType>(
            int rows,
            int columns,
            Tuple<int, int, TValueType>[] values
        )
        {
            SparseMatrix<TValueType> target = new SparseMatrix<TValueType>(rows, columns, values);
            return target;
            // TODO: add assertions to method SparseMatrixTValueTypeTest.Constructor02(Int32, Int32, Tuple`3<Int32,Int32,!!0>[])
        }
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public SparseMatrix<TValueType> Constructor01<TValueType>(int rows, int columns)
        {
            SparseMatrix<TValueType> target = new SparseMatrix<TValueType>(rows, columns);
            return target;
            // TODO: add assertions to method SparseMatrixTValueTypeTest.Constructor01(Int32, Int32)
        }
    }
}
