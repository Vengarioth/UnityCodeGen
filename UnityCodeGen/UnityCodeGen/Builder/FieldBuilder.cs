using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityCodeGen.Ast;

namespace UnityCodeGen.Builder
{
    public class FieldBuilder
    {
        public string Name { get { return _name; } }

        private string _name;
        private string _type;
        private AccessType _visibility;

        public FieldBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public FieldBuilder WithType(string type)
        {
            _type = type;
            return this;
        }

        public FieldBuilder WithVisibility(AccessType visibility)
        {
            _visibility = visibility;
            return this;
        }

        public FieldNode Build()
        {
            return new FieldNode
            {
                Name = _name,
                Visibility = _visibility,
                Type = _type,
            };
        }
    }
}
