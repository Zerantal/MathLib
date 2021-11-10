// <copyright file="MathExtensionsTest.cs">Copyright ©  2008</copyright>
using System;
using System.Numerics;
using MathLib;
using MathLib.Matrices;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathLib
{
    /// <summary>This class contains parameterized unit tests for MathExtensions</summary>
    [PexClass(typeof(MathExtensions))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class MathExtensionsTest
    {
        [PexMethod]
        public bool IsEqualTo(
            double d1,
            double d2,
            double errorTolerance
        )
        {
            bool result = MathExtensions.IsEqualTo(d1, d2, errorTolerance);
            return result;
            // TODO: add assertions to method MathExtensionsTest.IsEqualTo(Double, Double, Double)
        }
    }
}
