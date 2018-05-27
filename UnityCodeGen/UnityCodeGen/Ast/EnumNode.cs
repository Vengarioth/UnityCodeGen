using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityCodeGen.Ast
{
    public class EnumNode
    {
        public string Name { get; set; }
        public AccessType Visibility { get; set; }
        public string[] Options { get; set; }
    }
}
