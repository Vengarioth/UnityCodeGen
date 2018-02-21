using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnityCodeGen.Builder;

namespace UnityCodeGen.Test.Builder
{
    [TestClass]
    public class AstBuilderTest
    {
        [TestMethod]
        public void ItBuildsWithAUsing()
        {
            var builder = new AstBuilder();
            builder.WithUsing();

            var result = builder.Build();

            Assert.AreEqual(1, result.Usings.Length);
        }

        [TestMethod]
        public void ItBuildsWithAClass()
        {
            var builder = new AstBuilder();
            builder.WithClass();

            var result = builder.Build();

            Assert.AreEqual(1, result.Classes.Length);
        }

        [TestMethod]
        public void ItBuildsWithANamespace()
        {
            var builder = new AstBuilder();
            builder.WithNamespace();

            var result = builder.Build();

            Assert.AreEqual(1, result.Namespaces.Length);
        }
    }
}
