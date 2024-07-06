Minsk Compiler
This project is a simple compiler written in C#. It includes a lexer, parser, syntax tree, and an evaluator for basic arithmetic expressions.

Features
Lexical analysis
Parsing
Syntax tree generation
Expression evaluation
Parse tree visualization
Supported Expressions
The compiler currently supports basic arithmetic expressions involving:

Addition (+)
Subtraction (-)
Multiplication (*)
Division (/)
Parentheses for grouping (())
Usage
Running the Compiler
Clone the repository.
Open the solution in Visual Studio or any other C# IDE.
Build and run the project.
Interactive Mode
The compiler runs in an interactive mode. After running the program, you can type in arithmetic expressions to be evaluated.

Commands
#showTree: Toggle the display of the parse tree.
#cls: Clear the console.
Example
markdown
Copy code
> 1 + 2 * 3
7

> #showTree
Showing parse trees.

> 1 + 2 * 3
└── BinaryExpression
    ├── NumberToken 1
    ├── PlusToken +
    └── BinaryExpression
        ├── NumberToken 2
        ├── StarToken *
        └── NumberToken 3
7
Code Overview
Main Program
The Main method in Program.cs handles reading user input, toggling the display of the parse tree, and evaluating expressions.

PrettyPrint
The PrettyPrint method recursively prints the syntax tree for visualization.

Lexer
The Lexer class is responsible for breaking the input text into a sequence of tokens.

Parser
The Parser class processes the tokens produced by the lexer and constructs a syntax tree.

Syntax Tree
The syntax tree is represented by various classes inheriting from SyntaxNode, including:

SyntaxToken
ExpressionSyntax
NumberExpressionSyntax
BinaryExpressionSyntax
ParenthesizedExpressionSyntax
Evaluator
The Evaluator class walks the syntax tree and computes the value of the expression.

Future Improvements
Support for more complex expressions and additional operators.
Improved error handling and diagnostics.
Optimization passes on the syntax tree.
Additional features such as variable assignments and functions.
Contributing
Contributions are welcome! Please fork the repository and submit pull requests.

License
This project is licensed under the MIT License. See the LICENSE file for more details.

Acknowledgments
Inspired by the Minsk series by @terrajobst.