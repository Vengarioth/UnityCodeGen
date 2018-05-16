using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityCodeGen.Ast;
using UnityCodeGen.Extensions;

namespace UnityCodeGen.Builder
{
    public class ConstructorBuilder
    {
        private AccessType _visibility;
        private MethodBodyBuilder _body = new MethodBodyBuilder();
        private List<ParameterBuilder> _parameters = new List<ParameterBuilder>();

        public ConstructorBuilder WithVisibility(AccessType visibility)
        {
            _visibility = visibility;
            return this;
        }

        public ParameterBuilder WithParameter()
        {
            var builder = new ParameterBuilder();
            _parameters.Add(builder);
            return builder;
        }

        public MethodBodyBuilder WithBody()
        {
            return _body;
        }

        public ConstructorNode Build()
        {
            return new ConstructorNode
            {
                Visibility = _visibility,
                Parameters = _parameters.Map(p => p.Build()).ToArray(),
                Body = _body.Build(),
            };
        }
    }
}
