using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnityCodeGen.Builder;

namespace UnityCodeGen.Test.Builder
{
    [TestClass]
    public class UsingBuilderTest
    {
        [TestMethod]
        public void ItBuildsWithCorrectNamespaceName()
        {
            var builder = new UsingBuilder();
            builder.WithNamespaceName("FooBar");

            var result = builder.Build();

            Assert.AreEqual("FooBar", result.NamespaceName);
        }
    }
}
