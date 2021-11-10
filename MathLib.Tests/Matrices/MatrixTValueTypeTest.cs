// <copyright file="MatrixTValueTypeTest.cs">Copyright ©  2008</copyright>
using System;
using System.Collections.Generic;
using MathLib.Matrices;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using Microsoft.Pex.Framework.Generated;
using Microsoft.Pex.Framework.Explorable;
using Microsoft.ExtendedReflection.DataAccess;
using System.Linq;
using System.Diagnostics.Contracts;

using Util;

namespace MathLib.Matrices
{
    [ContractVerification(false)]
    class MatrixElementComparer : IEqualityComparer<Tuple<int, int, int>>
    {

        #region IEqualityComparer<Tuple<int,int,Complex>> Members

        public bool Equals(Tuple<int, int, int> x, Tuple<int, int, int> y)
        {
            if (x.Item1 == y.Item1 && x.Item2 == y.Item2)
                return true;

            return false;            
        }

        public int GetHashCode(Tuple<int, int, int> obj)
        {
            return obj.Item1 ^ obj.Item2;
        }

        #endregion
    }

    /// <summary>This class contains parameterized unit tests for Matrix`1</summary>
    [PexClass(typeof(Matrix<>))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    [ContractVerification(false)]
    public partial class MatrixTValueTypeTest
    {

        #region Functional Tests

        [TestMethod]
        public void EqualityAndInequalityTest()
        {
            Matrix<Complex> A = MatrixData.CM_A.DeepClone() as Matrix<Complex>;
            Matrix<Complex> A2 = MatrixData.CM_A.DeepClone() as Matrix<Complex>;

            Assert.IsTrue(A == A2);
            Assert.IsFalse(A != A2);

            A2[0, 2] = new Complex(3, -5.23);

            Assert.IsFalse(A == A2);
            Assert.IsTrue(A != A2);
        }

        [TestMethod]
        public void SubtractTest()
        {
            Matrix<Complex> A = MatrixData.CM_A;
            Matrix<Complex> B = MatrixData.CM_B;
            Matrix<Complex> expected = MatrixData.CM_AMinusB;
            Matrix<Complex> actual = A - B;

            Assert.IsTrue(actual.IsEqualTo(expected));
        }


        [TestMethod]
        public void AddTest()
        {
            Matrix<Complex> A = MatrixData.CM_A;
            Matrix<Complex> B = MatrixData.CM_B;
            Matrix<Complex> expected = MatrixData.CM_APlusB;
            Matrix<Complex> actual = A + B;

            Assert.IsTrue(actual.IsEqualTo(expected));
        }

        [TestMethod]
        public void NegateTest()
        {
            Matrix<Complex> A = MatrixData.CM_A;
            Matrix<Complex> expected = MatrixData.CM_ANegated;
            Matrix<Complex> actual = -A;

            Assert.IsTrue(actual.IsEqualTo(expected));
        }


        // matrix * matrix, matrix*complex, complex*matrix
        [TestMethod]
        public void MultiplyTest()
        {
            Matrix<Complex> A = MatrixData.CM_A;
            Matrix<Complex> C = MatrixData.CM_C;
            Matrix<Complex> expected = MatrixData.CM_ATimesC;

            Matrix<Complex> actual = A * C;
            Assert.IsTrue(actual.IsEqualTo(expected));

            Complex D = MatrixData.Complex_D;
            expected = MatrixData.CM_ATimesD;
            actual = A * D;
            Assert.IsTrue(actual.IsEqualTo(expected));

            actual = D * A;
            Assert.IsTrue(actual.IsEqualTo(expected));
        }

        // Matrix / Complex
        [TestMethod]
        public void DivideTest()
        {
            Matrix<Complex> A = MatrixData.CM_A;
            Complex D = MatrixData.Complex_D;
            Matrix<Complex> expected = MatrixData.CM_ADivideD;

            Matrix<Complex> actual = A / D;
            Assert.IsTrue(actual.IsEqualTo(expected));
        }

        [TestMethod]
        public void ItemTest()
        {
            int rows = 15, cols = 10;
            int numTestNumbers = 10;
            Matrix<int> m = new Matrix<int>(rows, cols, 0);
            List<Tuple<int, int, int>> testValues = new List<Tuple<int, int, int>>();
            IEnumerable<Tuple<int, int, int>> distinctValues;
            Random r = new Random();
            Tuple<int, int, int> val;            

            for (int i = 0; i < numTestNumbers; i++)
            {
                val = new Tuple<int, int, int>(r.Next(rows), r.Next(cols), r.Next(100));
                testValues.Add(val);
            }

            distinctValues = testValues.Distinct(new MatrixElementComparer());

            foreach (Tuple<int, int, int> t in distinctValues)
                m[t.Item1, t.Item2] = t.Item3;

            foreach (Tuple<int, int, int> t in distinctValues)
            {
                Assert.AreEqual(m[t.Item1, t.Item2], t.Item3);
            }
        }

        [TestMethod]
        public void GetRowtest()
        {
            Matrix<int> m = new Matrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            Vector<int> expected = new Vector<int>(new int[] {4, 5, 6}, VectorType.RowVector);
            Vector<int> actual = m.GetRow(1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetColumnTest()
        {
            Matrix<int> m = new Matrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            Vector<int> expected = new Vector<int>(new int[] {3, 6, 9}, VectorType.ColumnVector);
            Vector<int> actual = m.GetColumn(2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetRowTest()
        {
            Matrix<int> m = new Matrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            Vector<int> expected = new Vector<int>(new int[] {88, 33, 44}, VectorType.RowVector);
            m.SetRow(1, expected);

            Vector<int> actual = m.GetRow(1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetColumnTest()
        {
            Matrix<int> m = new Matrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            Vector<int> expected = new Vector<int>(new int[] {88, 33, 44}, VectorType.ColumnVector);
            m.SetColumn(1, expected);

            Vector<int> actual = m.GetColumn(1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]        
        public void RowEnumeratorTest()
        {
            Matrix<Complex> C = MatrixData.CM_C;
            int rowCount = 0;

            foreach (Vector<Complex> row in C.RowEnumerator)
            {
                Assert.AreEqual(C.GetRow(rowCount), row);
                rowCount++;
            }
        }

        [TestMethod]
        public void ColumnEnumeratorTest()
        {
            Matrix<Complex> A = MatrixData.CM_A;
            int colCount = 0;

            foreach (Vector<Complex> col in A.ColumnEnumerator)
            {
                Assert.AreEqual(A.GetColumn(colCount), col);
                colCount++;
            }
        }

        [TestMethod]
        public void TransposeTest()
        {
            Matrix<Complex> A = MatrixData.CM_A;
            Matrix<Complex> expected = MatrixData.CM_ATransposed;
            Matrix<Complex> actual = A.Transpose();

            Assert.AreEqual(expected, actual);
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
        public void AsVectorTest()
        {
            int [,] values = new int[,] { { 1, 2, 3, 4, 5, 6 } };
            Matrix<int> target = new Matrix<int>(values);
            Vector<int> expected = new Vector<int>(new int[] {1, 2, 3, 4, 5, 6}, VectorType.RowVector);
            Vector<int> actual = target.AsVector();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CopyToTest()
        {
            Matrix<int> destMatrix = new Matrix<int>(new int[,] {
                {1, 2, 3, 4}, {5, 6, 7, 8}, {9, 10, 11, 12}, {13, 14, 15, 16}});
            Matrix<int> expected = new Matrix<int>(new int[,] {
                {1, 2, 3, 4}, {5, 6, 7, 8}, {9, 11, 22, 12}, {13, 33, 44, 16}});
            Matrix<int> target = new Matrix<int>(new int[,] { { 11, 22 }, { 33, 44 } });

            target.CopyTo(destMatrix, 2, 1);

            Assert.AreEqual(expected, destMatrix);            
        }

        [TestMethod]
        public void ArrayMultiplicationTest()
        {
            int rows = 3, cols = 3;
            Matrix<int> A = new Matrix<int>(rows,cols);
            Matrix<int> B = new Matrix<int>(rows, cols);
            Random rand = new Random();
            Matrix<int> C;

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                {
                    A[r, c] = rand.Next(1000);
                    B[r,c] = rand.Next(1000);
                }

            C = A.ArrayMultiplication(B);

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    Assert.IsTrue(C[r, c] == A[r, c] * B[r, c]);
        }

        #endregion



        /// <summary>Test stub for Clone()</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public object Clone<TValueType>([PexAssumeUnderTest]Matrix<TValueType> target)
        {
            object clone = target.DeepClone();
            Matrix<TValueType> result = clone as Matrix<TValueType>;

            Assert.IsNotNull(result);
            Assert.AreEqual(target, result);
            Assert.AreNotSame(target, result);

            return result;
        }

        /// <summary>Test stub for .ctor(Int32, Int32, !0)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public Matrix<TValueType> Constructor01<TValueType>(
            int rows,
            int columns,
            TValueType initialValue
        )
        {
            Matrix<TValueType> target = new Matrix<TValueType>(rows, columns, initialValue);
            Assert.AreEqual(rows, target.Rows);
            Assert.AreEqual(columns, target.Columns);

            return target;
        }

        /// <summary>Test stub for .ctor(!0[,])</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public Matrix<TValueType> Constructor02<TValueType>(TValueType[,] values)
        {
            Matrix<TValueType> target = new Matrix<TValueType>(values);

            Assert.AreEqual(values.GetLength(0), target.Rows);
            Assert.AreEqual(values.GetLength(1), target.Columns);

            return target;
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public bool Equals02<TValueType>([PexAssumeUnderTest]Matrix<TValueType> target, Matrix<TValueType> m)
        {
            bool result = target.Equals(m);
            return result;
            // TODO: add assertions to method MatrixTValueTypeTest.Equals02(Matrix`1<!!0>, Matrix`1<!!0>)
        }
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public bool Equals01<TValueType>([PexAssumeUnderTest]Matrix<TValueType> target, object obj)
        {
            bool result = target.Equals(obj);
            return result;
            // TODO: add assertions to method MatrixTValueTypeTest.Equals01(Matrix`1<!!0>, Object)
        }
    }
}
