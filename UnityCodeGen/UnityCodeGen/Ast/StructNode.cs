using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityCodeGen.Ast
{
    public class StructNode
    {
        public string Name { get; set; }
        public AccessType Visibility { get; set; }
        public FieldNode[] Fields { get; set; }
    }
}
