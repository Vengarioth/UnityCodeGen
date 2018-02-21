using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityCodeGen.Ast
{
    public class AstNode
    {
        public UsingNode[] Usings { get; set; }
        public ClassNode[] Classes { get; set; }
        public NamespaceNode[] Namespaces { get; set; }
    }
}
