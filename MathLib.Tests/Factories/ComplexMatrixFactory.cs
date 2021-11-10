using System;
using Microsoft.Pex.Framework;
using MathLib.Matrices;
using Microsoft.Pex.Framework.Explorable;
using System.Numerics;

namespace MathLib.Matrices
{
    /// <summary>A factory for MathLib.Matrices.ComplexMatrix instances</summary>
    public static partial class ComplexMatrixFactory
    {

        /// <summary>A factory for MathLib.Matrices.ComplexMatrix instances</summary>
        [PexFactoryMethod(typeof(ComplexMatrix))]
        public static ComplexMatrix Create(
            int _rows_i,
            int _columns_i1,
            Complex[,] _values_complexs,
            int _rowStart_i2,
            int _colStart_i3
        )
        {
            PexAssume.IsTrue(_rows_i <= 10 && _columns_i1 <= 10);

            ComplexMatrix complexMatrix = PexInvariant.CreateInstance<ComplexMatrix>();
            PexInvariant.SetField<int>((object)complexMatrix, "m_rows", _rows_i);
            PexInvariant.SetField<int>((object)complexMatrix, "m_columns", _columns_i1);
            PexInvariant.SetField<Complex[,]>
                ((object)complexMatrix, "m_values", _values_complexs);
            PexInvariant.SetField<int>((object)complexMatrix, "m_rowStart", _rowStart_i2);
            PexInvariant.SetField<int>((object)complexMatrix, "m_colStart", _colStart_i3);
            PexInvariant.CheckInvariant((object)complexMatrix);
            return complexMatrix;
        }
    }
}
