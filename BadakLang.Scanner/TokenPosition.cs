namespace BadakLang.Scanner;

public sealed class TokenPosition
{
    private readonly int _column;
    public int Column => _column;
    
    private readonly int _line;
    public int Line => _line;

    private readonly int _indexSource;
    public int IndexSource => _indexSource;

    public TokenPosition(int column, int line, int indexSource)
    {
        _column = column;
        _line = line;
        _indexSource = indexSource;
    }

    public override bool Equals(object? obj)
    {
        if (obj is TokenPosition tokenPosition)
        {
            return _column == tokenPosition._column && _line == tokenPosition._line &&
                   _indexSource == tokenPosition._indexSource;
        }
        return false;
    }
}