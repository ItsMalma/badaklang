namespace BadakLang.Scanner;

public enum TokenType
{
    IntegerLiteral,
    FloatingPointLiteral,
    StringLiteral,
    BooleanLiteral,
    NullLiteral,
    
    Operator,
    Punctuation,
    
    Whitespace,
    Comment,

    Keyword,
    Identifier,
    
    Invalid,
    Eof
}