using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityCodeGen.Ast;
using UnityCodeGen.Extensions;

namespace UnityCodeGen
{
    /// <summary>
    /// Visitor pattern for the AST
    /// On each node Visit is called, then Walk whereby Walk invokes Visit on the node's children
    /// Override the Visit methods to process a given node and don't forget to call the base Method.
    /// </summary>
    public abstract class AstVisitor
    {
        protected virtual void VisitAstNode(AstNode ast)
        {
            WalkAstNode(ast);
        }
        protected void WalkAstNode(AstNode ast)
        {
            ast.Usings?.ForEach(u => VisitUsingNode(u));
            ast.Classes?.ForEach(c => VisitClassNode(c));
            ast.Namespaces?.ForEach(n => VisitNamespaceNode(n));
        }

        protected virtual void VisitUsingNode(UsingNode node)
        {
        }

        protected virtual void VisitNamespaceNode(NamespaceNode node)
        {
            WalkNamespaceNode(node);
        }
        protected void WalkNamespaceNode(NamespaceNode node)
        {
            node.Classes?.ForEach(c => VisitClassNode(c));
        }

        protected virtual void VisitClassNode(ClassNode node)
        {
            WalkClassNode(node);
        }
        protected void WalkClassNode(ClassNode node)
        {
            node.Properties?.ForEach(p => VisitPropertyNode(p));
            node.Methods?.ForEach(m => VisitMethodNode(m));
        }

        protected virtual void VisitPropertyNode(PropertyNode node) { }

        protected virtual void VisitMethodNode(MethodNode node)
        {
            WalkMethodNode(node);
        }
        protected void WalkMethodNode(MethodNode node)
        {
            node.Parameters?.ForEach(p => VisitParameterNode(p));
        }

        protected virtual void VisitParameterNode(ParameterNode node) { }
    }
}
