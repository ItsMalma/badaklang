namespace BadakLang.Scanner;

public sealed class Scanner
{
    private readonly string _source;
    private int _index = -1, _column, _line = 1;
    private char _current = '\0';
    
    public Scanner(string source)
    {
        _source = source;
    }

    private void Advance()
    {
        _column++;
        _current = ++_index < _source.Length ? _source[_index] : '\0';
    }

    private bool IsWhitespace()
    {
        return _current is ' ' or '\r' or '\t' or '\n';
    }

    private Token CreateWhitespaceToken()
    {
        var token = new Token(
            TokenType.Whitespace,
            _current.ToString(),
            new TokenPosition(_column, _line, _index));
        if (token.Value == "\n")
        {
            _column = 0;
            ++_line;
        }

        return token;
    }

    private Token CreateInvalidToken()
    {
        return new Token(
            TokenType.Invalid,
            _current.ToString(),
            new TokenPosition(_column, _line, _index));
    }

    private Token CreateEofToken()
    {
        return new Token(
            TokenType.Eof,
            _current.ToString(),
            new TokenPosition(_column, _line, _index));
    }

    public Token Next()
    {
        Advance();
        while (_current != '\0')
        {
            if (IsWhitespace()) return CreateWhitespaceToken();
            return CreateInvalidToken();
        }
        return CreateEofToken();
    }
}