using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityCodeGen.Ast;

namespace UnityCodeGen.Builder
{
    public class ParameterBuilder
    {
        public string Name { get { return _name; } }
        public string Type { get { return _type; } }

        private string _type;
        private string _name;

        public ParameterBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ParameterBuilder WithType(string type)
        {
            _type = type;
            return this;
        }

        public ParameterNode Build()
        {
            return new ParameterNode
            {
                Name = _name,
                Type = _type,
            };
        }
    }
}
