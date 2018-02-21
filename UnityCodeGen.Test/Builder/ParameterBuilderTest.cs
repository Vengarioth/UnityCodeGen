using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnityCodeGen.Builder;

namespace UnityCodeGen.Test.Builder
{
    [TestClass]
    public class ParameterBuilderTest
    {
        [TestMethod]
        public void TestWithName()
        {
            var builder = new ParameterBuilder();
            builder.WithName("FooBar");

            var result = builder.Build();

            Assert.AreEqual("FooBar", result.Name);
        }

        [TestMethod]
        public void TestWIthType()
        {
            var builder = new ParameterBuilder();
            builder.WithType("FooBar");

            var result = builder.Build();

            Assert.AreEqual("FooBar", result.Type);
        }
    }
}
