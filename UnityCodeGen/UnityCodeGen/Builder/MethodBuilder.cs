using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityCodeGen.Ast;
using UnityCodeGen.Extensions;

namespace UnityCodeGen.Builder
{
    public class MethodBuilder
    {
        private string _name;
        private string _returnType;
        private bool _isStatic;
        private bool _isAbstract;
        private bool _isVirtual;
        private AccessType _visibility;
        private MethodBodyBuilder _body = new MethodBodyBuilder();
        private List<ParameterBuilder> _parameters = new List<ParameterBuilder>();
        private List<string> _typeParameters = new List<string>();
        private List<TypeConstraintBuilder> _typeConstraints = new List<TypeConstraintBuilder>();

        public MethodBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public MethodBuilder WithReturnType(string returnType)
        {
            _returnType = returnType;
            return this;
        }

        public MethodBuilder WithVisibility(AccessType visibility)
        {
            _visibility = visibility;
            return this;
        }

        public MethodBuilder WithTypeParameter(string name)
        {
            _typeParameters.Add(name);
            return this;
        }

        public TypeConstraintBuilder WithTypeConstraint()
        {
            var typeConstraintBuilder = new TypeConstraintBuilder();
            _typeConstraints.Add(typeConstraintBuilder);
            return typeConstraintBuilder;
        }

        public MethodBuilder IsStatic(bool value)
        {
            _isStatic = value;
            return this;
        }

        public MethodBuilder IsAbstract(bool value)
        {
            _isAbstract = value;
            return this;
        }

        public MethodBuilder IsVirtual(bool value)
        {
            _isVirtual = value;
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

        public MethodNode Build()
        {
            return new MethodNode
            {
                IsAbstract = _isAbstract,
                IsStatic = _isStatic,
                IsVirtual = _isVirtual,
                Name = _name,
                ReturnType = _returnType,
                Visibility = _visibility,
                Parameters = _parameters.Map(p => p.Build()).ToArray(),
                TypeParameters = _typeParameters.ToArray(),
                TypeConstraints = _typeConstraints.Map(t => t.Build()).ToArray(),
                Body = _body.Build(),
            };
        }
    }
}
