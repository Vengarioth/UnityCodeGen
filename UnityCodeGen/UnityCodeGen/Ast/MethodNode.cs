using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityCodeGen.Ast
{
    public class MethodNode
    {
        public string Name { get; set; }
        public string ReturnType { get; set; }
        public AccessType Visibility { get; set; }
        public bool IsStatic { get; set; }
        public bool IsAbstract { get; set; }
        public bool IsVirtual { get; set; }
        public MethodBodyNode Body { get; set; }
        public ParameterNode[] Parameters { get; set; }
        public string[] TypeParameters { get; set; }
        public TypeConstraintNode[] TypeConstraints { get; set; }
    }
}
