using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityCodeGen.Ast;

namespace UnityCodeGen.Builder
{
    public class MethodBodyBuilder
    {
        private List<string> _lines = new List<string>();

        public MethodBodyBuilder WithLine(string format, params object[] args)
        {
            _lines.Add(string.Format(format, args));
            return this;
        }

        public MethodBodyNode Build()
        {
            return new MethodBodyNode
            {
                Lines = _lines.ToArray(),
            };
        }
    }
}
