// <copyright file="MatrixFactory.cs">Copyright ©  2008</copyright>

using System;
using Microsoft.Pex.Framework;
using MathLib.Matrices;
using Microsoft.Pex.Framework.Explorable;
using System.Numerics;

namespace MathLib.Matrices
{
    /// <summary>A factory for MathLib.Matrices.Matrix`1[System.Int32] instances</summary>
    public static partial class MatrixFactory
    {
        /*
        /// <summary>A factory for MathLib.Matrices.Matrix`1[System.Int32] instances</summary>
        [PexFactoryMethod(typeof(Matrix<int>))]
        public static Matrix<int> Create(int[,] _values_ints, int rows, int cols, int rowStart, int colStart)
        {
            Matrix<int> tmp = new Matrix<int>(_values_ints);
            Matrix<int> matrix = new Matrix<int>(tmp, rows, cols, rowStart, colStart);

            return matrix;
        }*/

        /// <summary>A factory for MathLib.Matrices.Matrix instances</summary>
        [PexFactoryMethod(typeof(Matrix))]
        public static Matrix Create(
            int _rows_i,
            int _columns_i1,
            double[,] _values_ds,
            int _rowStart_i2,
            int _colStart_i3
        )
        {
            Matrix matrix = PexInvariant.CreateInstance<Matrix>();
            PexInvariant.SetField<int>((object)matrix, "m_rows", _rows_i);
            PexInvariant.SetField<int>((object)matrix, "m_columns", _columns_i1);
            PexInvariant.SetField<double[,]>((object)matrix, "m_values", _values_ds);
            PexInvariant.SetField<int>((object)matrix, "m_rowStart", _rowStart_i2);
            PexInvariant.SetField<int>((object)matrix, "m_colStart", _colStart_i3);
            PexInvariant.CheckInvariant((object)matrix);
            return matrix;

            // TODO: Edit factory method of Matrix
            // This method should be able to configure the object in all possible ways.
            // Add as many parameters as needed,
            // and assign their values to each field by using the API.
        }
    }
}
