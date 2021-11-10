// <copyright file="ComplexVectorFactory.cs">Copyright ©  2008</copyright>

using System;
using Microsoft.Pex.Framework;
using MathLib.Matrices;
using Microsoft.Pex.Framework.Explorable;
using System.Numerics;

namespace MathLib.Matrices
{
    /// <summary>A factory for MathLib.Matrices.ComplexVector instances</summary>
    public static partial class ComplexVectorFactory
    {
        /// <summary>A factory for MathLib.Matrices.ComplexVector instances</summary>
        [PexFactoryMethod(typeof(ComplexVector))]
        public static ComplexVector Create(
            int _rows_i,
            int _columns_i1,
            Complex[,] _values_complexs,
            int _rowStart_i2,
            int _colStart_i3
        )
        {
            ComplexVector complexVector = PexInvariant.CreateInstance<ComplexVector>();
            PexInvariant.SetField<int>((object)complexVector, "_rows", _rows_i);
            PexInvariant.SetField<int>((object)complexVector, "_columns", _columns_i1);
            PexInvariant.SetField<Complex[,]>
                ((object)complexVector, "_values", _values_complexs);
            PexInvariant.SetField<int>((object)complexVector, "_rowStart", _rowStart_i2);
            PexInvariant.SetField<int>((object)complexVector, "_colStart", _colStart_i3);
            PexInvariant.CheckInvariant((object)complexVector);
            return complexVector;

            // TODO: Edit factory method of ComplexVector
            // This method should be able to configure the object in all possible ways.
            // Add as many parameters as needed,
            // and assign their values to each field by using the API.
        }
    }
}
