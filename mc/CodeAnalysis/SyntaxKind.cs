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