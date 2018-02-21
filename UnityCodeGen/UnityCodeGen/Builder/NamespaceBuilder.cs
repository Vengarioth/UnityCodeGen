using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityCodeGen.Ast;
using UnityCodeGen.Extensions;

namespace UnityCodeGen.Builder
{
    public class NamespaceBuilder
    {
        private string _name;
        private readonly List<ClassBuilder> _classBuilder = new List<ClassBuilder>();

        public ClassBuilder WithClass()
        {
            var classBuilder = new ClassBuilder();
            _classBuilder.Add(classBuilder);
            return classBuilder;
        }

        public NamespaceBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public NamespaceNode Build()
        {
            return new NamespaceNode
            {
                Name = _name,
                Classes = _classBuilder.Map(c => c.Build()).ToArray(),
            };
        }
    }
}
