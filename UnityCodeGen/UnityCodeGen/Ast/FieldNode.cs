using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityCodeGen.Ast
{
    public class FieldNode
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public AccessType Visibility { get; set; }
    }
}
