using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityCodeGen.Ast;
using UnityCodeGen.Builder;

namespace UnityCodeGen.Test
{
    [TestClass]
    public class CSharpRendererTest
    {
        [TestMethod]
        public void Test()
        {
            var builder = new AstBuilder();

            builder.WithUsing()
                .WithNamespaceName("System");

            var namespaceBuilder = builder.WithNamespace()
                .WithName("TestNamespace");

            var classBuilder = namespaceBuilder.WithClass()
                .WithName("FooBar")
                .WithVisibility(AccessType.Public)
                .IsPartial(true);

            classBuilder.WithProperty()
                .WithName("Foo")
                .WithType("int")
                .WithVisibility(AccessType.Public)
                .WithSetVisibility(AccessType.Public);

            classBuilder.WithProperty()
                .WithName("Bar")
                .WithType("int")
                .WithVisibility(AccessType.Public)
                .WithSetVisibility(AccessType.Private);


            classBuilder = namespaceBuilder.WithClass()
                .WithName("FooBar")
                .WithVisibility(AccessType.Public)
                .IsPartial(true);

            classBuilder.WithField()
                .WithName("BarFoo")
                .WithVisibility(AccessType.Public)
                .WithType("int");

            var methodBuilder = classBuilder.WithMethod()
                .WithVisibility(AccessType.Public)
                .WithReturnType("void")
                .WithName("Serialize");

            methodBuilder.WithParameter()
                .WithName("buffer")
                .WithType("IWriteableBuffer");

            methodBuilder.WithParameter()
                .WithName("anotherBuffer")
                .WithType("IWriteableBuffer");

            methodBuilder = classBuilder.WithMethod()
                .WithVisibility(AccessType.Public)
                .WithReturnType("void")
                .WithName("Deserialize");

            methodBuilder.WithParameter()
                .WithName("buffer")
                .WithType("IReadableBuffer");

            var structBuilder = namespaceBuilder.WithStruct()
                .WithName("FooStruct")
                .WithVisibility(AccessType.Public);

            structBuilder.WithField()
                .WithName("Foo")
                .WithType("int")
                .WithVisibility(AccessType.Public);

            var ast = builder.Build();

            var renderer = new CSharpRenderer();

            var result = renderer.Render(ast);

            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            System.IO.File.WriteAllText(location + ".result.cs", result);
        }

        [TestMethod]
        public void Test2()
        {
            var builder = new AstBuilder();

            builder.WithUsing()
                .WithNamespaceName("System");

            var namespaceBuilder = builder.WithNamespace()
                .WithName("TestNamespace");

            var classBuilder = namespaceBuilder.WithClass()
                .WithName("FooBar")
                .WithVisibility(AccessType.Public)
                .IsPartial(true);

            var fooProperty = classBuilder.WithProperty()
                .WithName("Foo")
                .WithType("int")
                .WithVisibility(AccessType.Public)
                .WithSetVisibility(AccessType.Public);

            var methodBuilder = classBuilder.WithMethod()
                .WithVisibility(AccessType.Public)
                .WithReturnType("void")
                .WithName("Serialize");

            var bufferParameter = methodBuilder.WithParameter()
                .WithName("buffer")
                .WithType("IWriteableBuffer");

            var body = methodBuilder.WithBody()
                .WithLine("{1}.WriteInt32({0});", fooProperty.Name, bufferParameter.Name);

            methodBuilder = classBuilder.WithMethod()
                .WithVisibility(AccessType.Public)
                .WithReturnType("void")
                .WithName("Deserialize");

            bufferParameter = methodBuilder.WithParameter()
                .WithName("buffer")
                .WithType("IReadableBuffer");


            body = methodBuilder.WithBody()
                .WithLine("{0} = {1}.ReadInt32();", fooProperty.Name, bufferParameter.Name);

            var ast = builder.Build();

            var renderer = new CSharpRenderer();

            var result = renderer.Render(ast);

            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            System.IO.File.WriteAllText(location + ".result2.cs", result);
        }
    }
}
