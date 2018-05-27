using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityCodeGen.Ast;

namespace UnityCodeGen.Builder
{
    public class EnumBuilder
    {
        private string _name;
        private AccessType _visibility;
        private List<string> _options = new List<string>();

        public EnumBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public EnumBuilder WithOption(string optionName)
        {
            _options.Add(optionName);
            return this;
        }

        public EnumBuilder WithVisibility(AccessType visibility)
        {
            _visibility = visibility;
            return this;
        }

        public EnumNode Build()
        {
            return new EnumNode
            {
                Name = _name,
                Visibility = _visibility,
                Options = _options.ToArray(),
            };
        }
    }
}
