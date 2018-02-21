# UnityCodeGen

A code generation library for Unity3d.

## Example

```csharp
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

var result = new CSharpRenderer().Render(ast);
```

Results in

```csharp
using System;

namespace TestNamespace
{
    public partial class FooBar
    {
        public int Foo { get; set; }
        public int Bar { get; private set; }
    }

    public partial class FooBar
    {
        public void Serialize(IWriteableBuffer buffer, IWriteableBuffer anotherBuffer)
        {
            // TODO method body
        }

        public void Deserialize(IReadableBuffer buffer)
        {
            // TODO method body
        }

    }

}

```

## Bootstrapping & proof of concept

The first goal is to generate this library's own _builders_ from it's _ast nodes_. After that i will mainly use it to generate de/serializers for networking protocols.

## FAQ

### I'm getting errors while using the dll

The dll's are built against .NET 4.5 and thus require the currently experimental .NET upgrade in unity.

### Concerning Roslyn

While Roslyn fully implements a lot of components needed for code generation, namely a C# parser, AST and the visitor patterns over it, it cannot currently run within the unity editor (please open an issue if you found out a way). This would be fine if all you want is generating some extra code after parsing your existing source code, but cannot help you if you want to compile something like Unreal's blueprints from within the editor. It is also a pretty heavy dependency.

### Concerning Protobuf

If you are looking for a way to generate serialization code of your networking messages, this library is a great alternative to protobuf if those tradeoffs are what you looking for:

#### Pro

* Protobuf's de/serialization is _usually_ more CPU intensive as generating de/serializers.

#### Con

* Protobuf can handle compatibility across multiple versions.

#### Neutral

* Message binary size depends on the compression / tricks you implement yourself. Protobuf's VarInt encoding is great, but sometimes you want to pack things on a bit level.

## Licence

MIT, open an issue if you need it licenced under another one.
