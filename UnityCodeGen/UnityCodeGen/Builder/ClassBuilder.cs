using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityCodeGen.Ast;
using UnityCodeGen.Extensions;

namespace UnityCodeGen.Builder
{
    public class ClassBuilder
    {
        private string _name;
        private AccessType _visibility;
        private bool _isPartial { get; set; }
        private readonly List<PropertyBuilder> _properties = new List<PropertyBuilder>();
        private readonly List<FieldBuilder> _fields = new List<FieldBuilder>();
        private readonly List<MethodBuilder> _methods = new List<MethodBuilder>();

        public ClassBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ClassBuilder IsPartial(bool value)
        {
            _isPartial = value;
            return this;
        }

        public ClassBuilder WithVisibility(AccessType visibility)
        {
            _visibility = visibility;
            return this;
        }

        public PropertyBuilder WithProperty()
        {
            var propertyBuilder = new PropertyBuilder();
            _properties.Add(propertyBuilder);
            return propertyBuilder;
        }

        public FieldBuilder WithField()
        {
            var fieldBuilder = new FieldBuilder();
            _fields.Add(fieldBuilder);
            return fieldBuilder;
        }

        public MethodBuilder WithMethod()
        {
            var methodBuilder = new MethodBuilder();
            _methods.Add(methodBuilder);
            return methodBuilder;
        }

        public ClassNode Build()
        {
            return new ClassNode
            {
                Name = _name,
                Visibility = _visibility,
                IsPartial = _isPartial,
                Properties = _properties.Map(p => p.Build()).ToArray(),
                Fields = _fields.Map(f => f.Build()).ToArray(),
                Methods = _methods.Map(m => m.Build()).ToArray(),
            };
        }
    }
}
