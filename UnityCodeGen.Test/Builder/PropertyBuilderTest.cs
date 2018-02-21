using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityCodeGen.Ast;
using UnityCodeGen.Builder;

namespace UnityCodeGen.Test.Builder
{
    [TestClass]
    public class PropertyBuilderTest
    {
        [TestMethod]
        public void ItBuildsWithCorrectName()
        {
            var builder = new PropertyBuilder();
            builder.WithName("FooBar");

            var result = builder.Build();

            Assert.AreEqual("FooBar", result.Name);
        }

        [TestMethod]
        public void ItBuildsWithCorrectGetAccess()
        {
            var builder = new PropertyBuilder();
            builder.WithVisibility(AccessType.Public);

            var result = builder.Build();

            Assert.AreEqual(AccessType.Public, result.Visibility);
        }

        [TestMethod]
        public void ItBuildsWithCorrectSetAccess()
        {
            var builder = new PropertyBuilder();
            builder.WithSetVisibility(AccessType.Public);

            var result = builder.Build();

            Assert.AreEqual(AccessType.Public, result.SetVisibility);
        }

        [TestMethod]
        public void ItBuildsWithCorrectType()
        {
            var builder = new PropertyBuilder();
            builder.WithType("FooBar");

            var result = builder.Build();

            Assert.AreEqual("FooBar", result.Type);
        }
    }
}
