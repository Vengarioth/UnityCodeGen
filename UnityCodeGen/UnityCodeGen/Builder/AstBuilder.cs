using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityCodeGen.Ast;
using UnityCodeGen.Extensions;

namespace UnityCodeGen.Builder
{
    public class AstBuilder
    {
        private readonly List<UsingBuilder> _usingBuilder = new List<UsingBuilder>();
        private readonly List<ClassBuilder> _classBuilder = new List<ClassBuilder>();
        private readonly List<NamespaceBuilder> _namespaceBuilder = new List<NamespaceBuilder>();

        public UsingBuilder WithUsing()
        {
            var usingBuilder = new UsingBuilder();
            _usingBuilder.Add(usingBuilder);
            return usingBuilder;
        }

        public ClassBuilder WithClass()
        {
            var classBuilder = new ClassBuilder();
            _classBuilder.Add(classBuilder);
            return classBuilder;
        }

        public NamespaceBuilder WithNamespace()
        {
            var namespaceBuilder = new NamespaceBuilder();
            _namespaceBuilder.Add(namespaceBuilder);
            return namespaceBuilder;
        }

        public AstNode Build()
        {
            return new AstNode
            {
                Usings = _usingBuilder.Map(u => u.Build()).ToArray(),
                Classes = _classBuilder.Map(c => c.Build()).ToArray(),
                Namespaces = _namespaceBuilder.Map(n => n.Build()).ToArray(),
            };
        }
    }
}
