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
    public class ClassBuilderTest
    {
        [TestMethod]
        public void ItBuildsWithCorrectIsPartial()
        {
            var builder = new ClassBuilder();
            builder.IsPartial(true);

            var result = builder.Build();

            Assert.AreEqual(true, result.IsPartial);
        }

        [TestMethod]
        public void ItBuildsWithCorrectName()
        {
            var builder = new ClassBuilder();
            builder.WithName("FooBar");

            var result = builder.Build();

            Assert.AreEqual("FooBar", result.Name);
        }

        [TestMethod]
        public void ItBuildsWithAProperty()
        {
            var builder = new ClassBuilder();
            builder.WithProperty();

            var result = builder.Build();

            Assert.AreEqual(1, result.Properties.Length);
        }

        [TestMethod]
        public void ItBuildsWithAMethod()
        {
            var builder = new ClassBuilder();
            builder.WithMethod();

            var result = builder.Build();

            Assert.AreEqual(1, result.Methods.Length);
        }

        [TestMethod]
        public void ItBuildsWithCorrectVisibility()
        {
            var builder = new ClassBuilder();
            builder.WithVisibility(AccessType.Public);

            var result = builder.Build();

            Assert.AreEqual(AccessType.Public, result.Visibility);
        }
    }
}
