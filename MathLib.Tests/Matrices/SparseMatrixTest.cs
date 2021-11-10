// <copyright file="SparseMatrixTest.cs">Copyright ©  2008</copyright>

using System;
using MathLib.Matrices;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.Contracts;

namespace MathLib.Matrices
{
    [TestClass]
    [PexClass(typeof(SparseMatrix))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [ContractVerification(false)]
    public partial class SparseMatrixTest
    {
        [PexMethod]
        public SparseMatrix Constructor02(
            int rows,
            int columns,
            Tuple<int, int, double>[] values
        )
        {
            SparseMatrix target = new SparseMatrix(rows, columns, values);
            return target;
            // TODO: add assertions to method SparseMatrixTest.Constructor02(Int32, Int32, Tuple`3<Int32,Int32,Double>[])
        }
        [PexMethod]
        public SparseMatrix Constructor01(int rows, int columns)
        {
            SparseMatrix target = new SparseMatrix(rows, columns);
            return target;
            // TODO: add assertions to method SparseMatrixTest.Constructor01(Int32, Int32)
        }
    }
}
