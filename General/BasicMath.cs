
// ReSharper disable UnusedMember.Global

namespace MathLib.General
{
    /// <summary>
    /// Basic math routines
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    public static class BasicMath
    {
        public static double Sqr(double n)
        {
            return n * n;
        }

        public static bool IsPowerOf2(int arg)
        {
            // // Contract.Requires(arg >= 0);
            return (arg & (arg - 1)) == 0;
        }
    }
}
