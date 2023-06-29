namespace BadakLang.Scanner;

public sealed class Token
{
    private readonly TokenType _type;
    public TokenType Type => _type;
    
    private readonly string _value;
    public string Value => _value;

    private readonly TokenPosition _position;
    public TokenPosition Position => _position;

    public Token(TokenType type, string value, TokenPosition position)
    {
        _type = type;
        _value = value;
        _position = position;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Token tok)
        {
            return _type == tok._type && _value == tok._value && _position.Equals(tok._position);
        }
        return false;
    }
}