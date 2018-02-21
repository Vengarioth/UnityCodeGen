using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityCodeGen.Ast
{
    public class NamespaceNode
    {
        public string Name { get; set; }
        public ClassNode[] Classes { get; set; }
    }
}
