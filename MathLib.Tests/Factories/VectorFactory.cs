// <copyright file="VectorFactory.cs">Copyright ©  2008</copyright>

using System;
using Microsoft.Pex.Framework;
using MathLib.Matrices;
using Microsoft.Pex.Framework.Explorable;
using System.Diagnostics.Contracts;

namespace MathLib.Matrices
{
    /// <summary>A factory for MathLib.Matrices.Vector`1[System.Int32] instances</summary>
    [ContractVerification(false)]
    public static partial class VectorFactory
    {
        /// <summary>A factory for MathLib.Matrices.Vector`1[System.Int32] instances</summary>
        [PexFactoryMethod(typeof(Vector<int>))]
        public static Vector<int> Create(
            int _rows_i,
            int _columns_i1,
            int[,] _values_ints,
            int _rowStart_i2,
            int _colStart_i3
        )
        {
            PexAssume.IsTrue(_rows_i < 10 && _columns_i1 < 10);

            Vector<int> vector = PexInvariant.CreateInstance<Vector<int>>();
            PexInvariant.SetField<int>((object)vector, "_rows", _rows_i);
            PexInvariant.SetField<int>((object)vector, "_columns", _columns_i1);
            PexInvariant.SetField<int[,]>((object)vector, "_values", _values_ints);
            PexInvariant.SetField<int>((object)vector, "_rowStart", _rowStart_i2);
            PexInvariant.SetField<int>((object)vector, "_colStart", _colStart_i3);
            PexInvariant.CheckInvariant((object)vector);
            return vector;

            // TODO: Edit factory method of Vector`1<Int32>
            // This method should be able to configure the object in all possible ways.
            // Add as many parameters as needed,
            // and assign their values to each field by using the API.
        }
        /// <summary>A factory for MathLib.Matrices.Vector instances</summary>
        [PexFactoryMethod(typeof(Vector))]
        public static Vector Create(
            int _rows_i,
            int _columns_i1,
            double[,] _values_ds,
            int _rowStart_i2,
            int _colStart_i3
        )
        {
            PexAssume.IsTrue(_values_ds.GetLength(0) <= 3 && _values_ds.GetLength(1) <= 3);
            Vector vector = PexInvariant.CreateInstance<Vector>();
            PexInvariant.SetField<int>((object)vector, "m_rows", _rows_i);
            PexInvariant.SetField<int>((object)vector, "m_columns", _columns_i1);
            PexInvariant.SetField<double[,]>((object)vector, "m_values", _values_ds);
            PexInvariant.SetField<int>((object)vector, "m_rowStart", _rowStart_i2);
            PexInvariant.SetField<int>((object)vector, "m_colStart", _colStart_i3);
            PexInvariant.CheckInvariant((object)vector);
            return vector;

            // TODO: Edit factory method of Vector
            // This method should be able to configure the object in all possible ways.
            // Add as many parameters as needed,
            // and assign their values to each field by using the API.
        }
    }
}
