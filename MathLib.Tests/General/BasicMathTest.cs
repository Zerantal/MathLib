// <copyright file="BasicMathTest.cs">Copyright ©  2008</copyright>

using System;
using MathLib;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework.Generated;
using System.Diagnostics.Contracts;

namespace MathLib
{
    [ContractVerification(false)]
    [TestClass]
    [PexClass(typeof(BasicMath))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class BasicMathTest
    {
        [PexMethod]
        public double Sqr(double n)
        {
            double result = BasicMath.Sqr(n);

            Assert.AreEqual(n * n, result);

            return result;
        }

        [PexMethod]
        public bool IsPowerOf2(int arg)
        {
            bool result = BasicMath.IsPowerOf2(arg);
            return result;
        }
        [TestMethod]
        public void Sqr510()
        {
            double n, nSquared, result;
            n = 65.12745;
            nSquared = 4241.5847435025;
            result = this.Sqr(n);
            Assert.AreEqual<double>(result, nSquared);
        }
        [TestMethod]
        public void IsPowerOf2821()
        {
            bool result;
            result = this.IsPowerOf2(65536);
            Assert.IsTrue(result);

            result = this.IsPowerOf2(432);
            Assert.IsFalse(result);
        }
    }
}
