// using System;
using System.Collections.Generic;
// using System.Linq;
// using Minsk.CodeAnalysis; // Import the namespace if needed
namespace Minsk.CodeAnalysis
{

    internal sealed class Parser
    {
        private readonly SyntaxToken[] _tokens;

        private List<string> _diagnostics = new List<string>();
        private int _position;
        public Parser(string text)
        {
            var tokens = new List<SyntaxToken>();
            var lexer = new Lexer(text);
            SyntaxToken token;
            do{
                token = lexer.Lex();
                if(token.Kind != SyntaxKind.WhitespaceToken && token.Kind != SyntaxKind.BadToken){
                    tokens.Add(token);
                }
            }while(token.Kind !=SyntaxKind.EndOfFileToken);
            _tokens = tokens.ToArray();
            _diagnostics.AddRange(lexer.Diagnostics);
        }
        public IEnumerable<string> Diagnostics=>_diagnostics;
        private SyntaxToken Peek(int offset)
        {
            var index = _position + offset;
            if(index>= _tokens.Length)
            {
                return _tokens[_tokens.Length -1];
            }
            return _tokens[index];
        }
        private SyntaxToken Current => Peek(0);

        private SyntaxToken Lex()
        {
             var current=Current;
             _position++;
             return current;
        }

        private SyntaxToken MatchToken(SyntaxKind kind)
        {
             if(Current.Kind == kind)
             {
                return Lex();
             }
             _diagnostics.Add($"Error: Unexpected token <{Current.Kind}>, expected <{kind}>");
             return new SyntaxToken(kind, Current.Position,null,null);
        }

        public SyntaxTree Parse()
        {
            var expression = ParseExpression();
            var endOfFileToken=MatchToken(SyntaxKind.EndOfFileToken);
            return new SyntaxTree(_diagnostics,expression,endOfFileToken);
        }
        // private ExpressionSyntax ParseExpression()
        // {
        //     return ParseTerm();
        // }
       
       private ExpressionSyntax ParseExpression(int parentPrecedence = 0)
       {
        var left = ParsePrimaryExpression();

        while(true)
        {
            var precedence = Current.Kind.GetBinaryOperatorPrecedence();
            if(precedence == 0 || precedence<=parentPrecedence)
            {
                break;
            }
            var operatorToken = Lex();
            var right = ParseExpression(precedence);
            left = new BinaryExpressionSyntax(left,operatorToken,right);
        }
        return left;
       }

      
        // private ExpressionSyntax ParseTerm()
        // {
        //     var left = ParseFactor();

        //     while (Current.Kind == SyntaxKind.PlusToken || Current.Kind == SyntaxKind.MinusToken)
        //     {
        //         var operatorToken = Lex();
        //         var right = ParseFactor();
        //         left = new BinaryExpressionSyntax(left, operatorToken, right);
        //     }
        //     return left;
        // }
        // private ExpressionSyntax ParseFactor()
        // {
        //     var left = ParsePrimaryExpression();

        //     while (Current.Kind ==SyntaxKind.StarToken || Current.Kind == SyntaxKind.SlashToken)
        //     {
        //         var operatorToken = Lex();
        //         var right = ParsePrimaryExpression();
        //         left = new BinaryExpressionSyntax(left, operatorToken, right);
        //     }
        //     return left;
        // }
        private ExpressionSyntax ParsePrimaryExpression()
        {
            if(Current.Kind == SyntaxKind.OpenParenthesisToken)
            {
                var left = Lex();
                var expression = ParseExpression();
                var right = MatchToken(SyntaxKind.ClosedParenthesisToken);
                return new ParenthesizedExpressionSyntax(left,expression,right);
            }
            var literalToken = MatchToken(SyntaxKind.LiteralToken);
            return new LiteralExpressionSyntax(literalToken);
        }
    }
}