using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityCodeGen.Ast
{
    public class TypeConstraintNode
    {
        public string TypeParameterName { get; set; }
        public bool HasStructConstraint { get; set; }
        public string[] Constraints { get; set; }
    }
}
