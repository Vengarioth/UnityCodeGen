using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityCodeGen.Ast;

namespace UnityCodeGen.Builder
{
    public class UsingBuilder
    {
        private string _namespaceName;

        public UsingBuilder WithNamespaceName(string namespaceName)
        {
            _namespaceName = namespaceName;
            return this;
        }

        public UsingNode Build()
        {
            return new UsingNode
            {
                NamespaceName = _namespaceName,
            };
        }
    }
}
