using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnityCodeGen.Ast;
using UnityCodeGen.Builder;

namespace UnityCodeGen.Test.Builder
{
    [TestClass]
    public class MethodBuilderTest
    {
        [TestMethod]
        public void TestIsAbstract()
        {
            var builder = new MethodBuilder();
            builder.IsAbstract(true);

            var result = builder.Build();

            Assert.AreEqual(true, result.IsAbstract);
        }

        [TestMethod]
        public void TestIsStatic()
        {
            var builder = new MethodBuilder();
            builder.IsStatic(true);

            var result = builder.Build();

            Assert.AreEqual(true, result.IsStatic);
        }

        [TestMethod]
        public void TestIsVirtual()
        {
            var builder = new MethodBuilder();
            builder.IsVirtual(true);

            var result = builder.Build();

            Assert.AreEqual(true, result.IsVirtual);
        }

        [TestMethod]
        public void TestWithName()
        {
            var builder = new MethodBuilder();
            builder.WithName("FooBar");

            var result = builder.Build();

            Assert.AreEqual("FooBar", result.Name);
        }

        [TestMethod]
        public void TestWithReturnType()
        {
            var builder = new MethodBuilder();
            builder.WithReturnType("FooBar");

            var result = builder.Build();

            Assert.AreEqual("FooBar", result.ReturnType);
        }

        [TestMethod]
        public void TestWithVisibility()
        {
            var builder = new MethodBuilder();
            builder.WithVisibility(AccessType.Internal);

            var result = builder.Build();

            Assert.AreEqual(AccessType.Internal, result.Visibility);
        }

        [TestMethod]
        public void TestWithParameter()
        {
            var builder = new MethodBuilder();
            builder.WithParameter();

            var result = builder.Build();

            Assert.AreEqual(1, result.Parameters.Length);
        }
    }
}
