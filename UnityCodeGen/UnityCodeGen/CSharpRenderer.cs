﻿using System;
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
        private string _currentClassName;
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
            AppendIndentation();
            Append("using ");
            Append(node.NamespaceName);
            Append(";");
            AppendLineEnding();
            base.VisitUsingNode(node);
        }

        protected override void VisitNamespaceNode(NamespaceNode node)
        {
            AppendIndentation();
            Append("namespace ");
            Append(node.Name);
            AppendLineEnding();
            AppendLine("{");
            ++_indentation;

            base.VisitNamespaceNode(node);

            --_indentation;
            AppendLine("}");
        }

        protected override void VisitStructNode(StructNode node)
        {
            AppendIndentation();
            AppendAccesType(node.Visibility);

            Append("struct ");
            Append(node.Name);
            AppendLineEnding();

            AppendLine("{");
            ++_indentation;

            base.VisitStructNode(node);

            --_indentation;
            AppendLine("}");
            AppendLineEnding();
        }

        protected override void VisitClassNode(ClassNode node)
        {
            _currentClassName = node.Name;

            AppendIndentation();

            AppendAccesType(node.Visibility);

            if (node.IsPartial)
                Append("partial ");
            
            Append("class ");
            Append(node.Name);
            AppendLineEnding();

            AppendLine("{");
            ++_indentation;

            base.VisitClassNode(node);

            --_indentation;
            AppendLine("}");
            AppendLineEnding();
        }

        protected override void VisitConstructorNode(ConstructorNode node)
        {
            AppendIndentation();
            AppendAccesType(node.Visibility);

            Append(_currentClassName);
            Append("(");

            if (node.Parameters != null)
            {
                var isFirst = true;
                foreach (var p in node.Parameters)
                {
                    if (!isFirst)
                        Append(", ");

                    VisitParameterNode(p);

                    isFirst = false;
                }
            }

            Append(")");
            AppendLineEnding();

            AppendLine("{");
            ++_indentation;

            VisitMethodBody(node.Body);

            --_indentation;
            AppendLine("}");
            AppendLineEnding();
        }

        protected override void VisitFieldNode(FieldNode node)
        {
            AppendIndentation();

            AppendAccesType(node.Visibility);
            Append(node.Type);
            Append(" ");
            Append(node.Name);
            Append(";");

            base.VisitFieldNode(node);

            AppendLineEnding();
        }

        protected override void VisitPropertyNode(PropertyNode node)
        {
            AppendIndentation();

            AppendAccesType(node.Visibility);
            Append(node.Type);
            Append(" ");
            Append(node.Name);
            Append(" ");
            Append("{ get; ");

            if(node.Visibility != node.SetVisibility)
                AppendAccesType(node.SetVisibility);

            Append("set; }");

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

            if (string.IsNullOrEmpty(node.ReturnType))
                Append("void");
            else
                Append(node.ReturnType);

            Append(" ");
            Append(node.Name);
            Append("(");

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

            AppendLine("{");
            ++_indentation;

            VisitMethodBody(node.Body);

            --_indentation;
            AppendLine("}");
            AppendLineEnding();
        }

        protected override void VisitParameterNode(ParameterNode node)
        {
            Append(node.Type);
            Append(" ");
            Append(node.Name);
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

        private void Append(string value)
        {
            _result.Append(value);
        }

        private void AppendLine(string line)
        {
            AppendIndentation();
            Append(line);
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
