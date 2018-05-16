using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityCodeGen.Ast
{
    public class ClassNode
    {
        public string Name { get; set; }
        public AccessType Visibility { get; set; }
        public bool IsPartial { get; set; }
        public ConstructorNode Constructor { get; set; }
        public PropertyNode[] Properties { get; set; }
        public FieldNode[] Fields { get; set; }
        public MethodNode[] Methods { get; set; }
    }
}
