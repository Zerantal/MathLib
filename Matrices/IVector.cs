
// ReSharper disable UnusedMemberInSuper.Global
// ReSharper disable UnusedMember.Global

namespace MathLib.Matrices
{
    public interface IVector<TVector, TValue> where TVector : IVector<TVector, TValue>
    {
        VectorType Orientation { get; }

        int Length { get; }

        TValue this[int index] { get; set; }

        TVector ArrayMultiplication(TVector rhs);
    }  
}
