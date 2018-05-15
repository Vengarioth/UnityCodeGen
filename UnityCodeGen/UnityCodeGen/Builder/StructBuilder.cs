using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityCodeGen.Ast;
using UnityCodeGen.Extensions;

namespace UnityCodeGen.Builder
{
    public class StructBuilder
    {
        private string _name;
        private AccessType _visibility;
        private readonly List<FieldBuilder> _fields = new List<FieldBuilder>();

        public StructBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public StructBuilder WithVisibility(AccessType visibility)
        {
            _visibility = visibility;
            return this;
        }
        public FieldBuilder WithField()
        {
            var fieldBuilder = new FieldBuilder();
            _fields.Add(fieldBuilder);
            return fieldBuilder;
        }

        public StructNode Build()
        {
            return new StructNode
            {
                Name = _name,
                Visibility = _visibility,
                Fields = _fields.Map(f => f.Build()).ToArray(),
            };
        }
    }
}
