using System.Diagnostics.CodeAnalysis;

namespace MathLib.Statistics
{    
    [ExcludeFromCodeCoverage]
    public class ConstantGenerator : INumberGenerator
    {
        public ConstantGenerator(double constant)
        {
            Number = constant;
        }

        public double Number { get; }

        #region IDeepCloneable<INumberGenerator> Members

        public INumberGenerator DeepClone()
        {
            return new ConstantGenerator(Number);            
        }

        #endregion
    }
}
