// using System;
// using System.Collections.Generic;
// using System.Linq;
namespace Minsk.CodeAnalysis
{
    public enum SyntaxKind
    {
        //Tokens
        BadToken,
        EndOfFileToken,
        WhitespaceToken,
        LiteralToken,
        PlusToken,
        MinusToken,
        StarToken,
        SlashToken,
        OpenParenthesisToken,
        ClosedParenthesisToken,
        //Expressions
        LiteralExpression,
        BinaryExpression,
        ParenthesizedExpression
    }
}