using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityCodeGen.Ast;
using UnityCodeGen.Extensions;

namespace UnityCodeGen
{
    public class CSharpRenderer : AstVisitor
    {
        private readonly StringBuilder _result;
        private int _indentation = 0;

        public CSharpRenderer()
        {
            _result = new StringBuilder();
        }

        protected override void VisitAstNode(AstNode ast)
        {
            ast.Usings?.ForEach(u => VisitUsingNode(u));

            AppendLineEnding();

            ast.Classes?.ForEach(c => VisitClassNode(c));
            ast.Namespaces?.ForEach(n => VisitNamespaceNode(n));
        }

        protected override void VisitUsingNode(UsingNode node)
        {
            AppendLine("using {0};", node.NamespaceName);
            base.VisitUsingNode(node);
        }

        protected override void VisitNamespaceNode(NamespaceNode node)
        {
            AppendLine("namespace {0}", node.Name);
            AppendLine("{{");
            ++_indentation;

            base.VisitNamespaceNode(node);

            --_indentation;
            AppendLine("}}");
        }

        protected override void VisitClassNode(ClassNode node)
        {
            AppendIndentation();

            AppendAccesType(node.Visibility);

            if (node.IsPartial)
                Append("partial ");
            
            Append("class {0}", node.Name);
            AppendLineEnding();

            AppendLine("{{");
            ++_indentation;

            base.VisitClassNode(node);

            --_indentation;
            AppendLine("}}");
            AppendLineEnding();
        }

        protected override void VisitPropertyNode(PropertyNode node)
        {
            AppendIndentation();

            AppendAccesType(node.Visibility);
            Append("{0} {1} {{ get; ", node.Type, node.Name);

            if(node.Visibility != node.SetVisibility)
                AppendAccesType(node.SetVisibility);

            Append("set; }}");

            base.VisitPropertyNode(node);

            AppendLineEnding();
        }

        protected override void VisitMethodNode(MethodNode node)
        {
            AppendIndentation();
            AppendAccesType(node.Visibility);

            if (node.IsStatic)
                Append("static");

            if (node.IsAbstract)
                Append("abstract");

            if (node.IsVirtual)
                Append("virtual");

            Append("{0} {1}(", node.ReturnType, node.Name);

            if(node.Parameters != null)
            {
                var isFirst = true;
                foreach(var p in node.Parameters)
                {
                    if (!isFirst)
                        Append(", ");

                    VisitParameterNode(p);

                    isFirst = false;
                }
            }

            Append(")");
            AppendLineEnding();

            AppendLine("{{");
            ++_indentation;

            VisitMethodBody(node.Body);

            --_indentation;
            AppendLine("}}");
            AppendLineEnding();
        }

        protected override void VisitParameterNode(ParameterNode node)
        {
            Append("{0} {1}", node.Type, node.Name);
            base.VisitParameterNode(node);
        }

        protected override void VisitMethodBody(MethodBodyNode node)
        {
            foreach(var line in node.Lines)
            {
                AppendLine(line);
            }
        }

        public string Render(AstNode ast)
        {
            _result.Clear();
            VisitAstNode(ast);
            return _result.ToString();
        }

        private void AppendIndentation()
        {
            for (var i = 0; i < _indentation; i++)
                _result.Append("    ");
        }

        private void Append(string format, params object[] param)
        {
            _result.AppendFormat(format, param);
        }

        private void AppendLine(string format, params object[] param)
        {
            AppendIndentation();
            Append(format, param);
            AppendLineEnding();
        }

        private void AppendLineEnding()
        {
            _result.AppendLine();
        }

        private void AppendAccesType(AccessType accessType, bool appendSpace = true)
        {
            switch(accessType)
            {
                case AccessType.Private:
                    _result.Append("private");
                    break;
                case AccessType.Protected:
                    _result.Append("protected");
                    break;
                case AccessType.Internal:
                    _result.Append("internal");
                    break;
                case AccessType.Public:
                    _result.Append("public");
                    break;
            }

            if(appendSpace)
                _result.Append(" ");
        }
    }
}
