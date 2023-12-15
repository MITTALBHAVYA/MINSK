using System;
using System.Collections.Generic;
using System.Linq;
namespace Minsk.CodeAnalysis
{
    public abstract class SyntaxNode
    {
        public abstract SyntaxKind Kind{get;}
        public abstract IEnumerable<SyntaxNode> GetChildren();
    }
}