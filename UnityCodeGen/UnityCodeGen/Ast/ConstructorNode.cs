using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityCodeGen.Ast
{
    public class ConstructorNode
    {
        public AccessType Visibility { get; set; }
        public MethodBodyNode Body { get; set; }
        public ParameterNode[] Parameters { get; set; }
    }
}
