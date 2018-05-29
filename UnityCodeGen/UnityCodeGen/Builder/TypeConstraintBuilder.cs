using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityCodeGen.Ast;

namespace UnityCodeGen.Builder
{
    public class TypeConstraintBuilder
    {
        private string _typeParameterName;
        private bool _hasStructConstraint;
        private List<string> _constraints = new List<string>();

        public TypeConstraintBuilder WithTypeParameterName(string typeParameterName)
        {
            _typeParameterName = typeParameterName;
            return this;
        }

        public TypeConstraintBuilder WithStructConstraint()
        {
            _hasStructConstraint = true;
            return this;
        }

        public TypeConstraintBuilder WithConstraint(string constraint)
        {
            _constraints.Add(constraint);
            return this;
        }

        public TypeConstraintNode Build()
        {
            return new TypeConstraintNode
            {
                TypeParameterName = _typeParameterName,
                HasStructConstraint = _hasStructConstraint,
                Constraints = _constraints.ToArray(),
            };
        }
    }
}
