namespace MathLib.Matrices
{
    public interface INumericMatrix<in TMatrixType, out TVectorType, in TValueType>
        where TMatrixType : INumericMatrix<TMatrixType, TVectorType, TValueType>
        where TVectorType : INumericVector
    {
        // ReSharper disable once UnusedMember.Global
        bool IsEqualTo(TMatrixType arg, TValueType errorTolerance);

        // ReSharper disable once UnusedMember.Global
        TVectorType RowNorms();
    }
}
