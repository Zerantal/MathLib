using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
// ReSharper disable UnusedMember.Global


namespace MathLib.Matrices
{
    public class ComplexSparseVector : ComplexSparseMatrix, IVector<ComplexSparseVector, Complex>
    {
        #region Constructors

        public ComplexSparseVector(int dimension, VectorType orientation)
            : base(orientation == VectorType.RowVector ? 1 : dimension, orientation == VectorType.RowVector ? dimension : 1)

        {
            // // Contract.Requires(dimension > 0);
            // // Contract.Requires(dimension < int.MaxValue);
            throw new NotImplementedException();
        }

        public ComplexSparseVector(int dimension, VectorType orientation, IEnumerable<Tuple<int, Complex>> initialValues)
            : base(orientation == VectorType.RowVector ? 1 : dimension, orientation == VectorType.RowVector ? dimension : 1, initialValues.Select(
                t => new Tuple<int, int, Complex>(t.Item1, 0, t.Item2)))

        {
            // // Contract.Requires(dimension > 0);
            // // Contract.Requires(dimension < int.MaxValue);
            // // Contract.Requires(initialValues != null);
            // // Contract.Requires(// Contract.ForAll<Tuple<int, Complex>>
                //(initialValues, new Predicate<Tuple<int, Complex>>(delegate(Tuple<int, Complex> t)
                //{ return (t != null && t.Item1 < dimension && t.Item1 >= 0); })));

            throw new NotImplementedException();
        }

        #endregion

        #region IVector<ComplexSparseVector,Complex> Members

        public VectorType Orientation => throw new NotImplementedException();

        public int Length => throw new NotImplementedException();

        public Complex this[int index]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public ComplexSparseVector ArrayMultiplication(ComplexSparseVector rhs)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
