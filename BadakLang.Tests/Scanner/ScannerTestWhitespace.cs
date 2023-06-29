using BadakLang.Scanner;
using FluentAssertions;
using Xunit;

namespace BadakLang.Tests.Scanner;

public class ScannerTestWhitespace
{
    public static IEnumerable<object[]> SpaceData => new List<object[]>
    {
        new object[]
        {
            " ",
            new Token(TokenType.Whitespace, " ", new TokenPosition(1, 1, 0))
        },
        new object[]
        {
            "  ",
            new Token(TokenType.Whitespace, " ", new TokenPosition(1, 1, 0)),
            new Token(TokenType.Whitespace, " ", new TokenPosition(2, 1, 1))
        },
        new object[]
        {
            "   ",
            new Token(TokenType.Whitespace, " ", new TokenPosition(1, 1, 0)),
            new Token(TokenType.Whitespace, " ", new TokenPosition(2, 1, 1)),
            new Token(TokenType.Whitespace, " ", new TokenPosition(3, 1, 2))
        },
    };
    [Theory]
    [MemberData(nameof(SpaceData))]
    public void Space(string source, params Token[] expectedTokens)
    {
        var scanner = new BadakLang.Scanner.Scanner(source);
        foreach (var expectedToken in expectedTokens)
        {
            scanner.Next().Should().Be(expectedToken);
        }
    }
    
    public static IEnumerable<object[]> TabData => new List<object[]>
    {
        new object[]
        {
            "\t",
            new Token(TokenType.Whitespace, "\t", new TokenPosition(1, 1, 0))
        },
        new object[]
        {
            "\t\t",
            new Token(TokenType.Whitespace, "\t", new TokenPosition(1, 1, 0)),
            new Token(TokenType.Whitespace, "\t", new TokenPosition(2, 1, 1))
        },
        new object[]
        {
            "\t\t\t",
            new Token(TokenType.Whitespace, "\t", new TokenPosition(1, 1, 0)),
            new Token(TokenType.Whitespace, "\t", new TokenPosition(2, 1, 1)),
            new Token(TokenType.Whitespace, "\t", new TokenPosition(3, 1, 2))
        },
    };
    [Theory]
    [MemberData(nameof(TabData))]
    public void Tab(string source, params Token[] expectedTokens)
    {
        var scanner = new BadakLang.Scanner.Scanner(source);
        foreach (var expectedToken in expectedTokens)
        {
            scanner.Next().Should().Be(expectedToken);
        }
    }
    
    public static IEnumerable<object[]> ReturnData => new List<object[]>
    {
        new object[]
        {
            "\r",
            new Token(TokenType.Whitespace, "\r", new TokenPosition(1, 1, 0))
        },
        new object[]
        {
            "\r\r",
            new Token(TokenType.Whitespace, "\r", new TokenPosition(1, 1, 0)),
            new Token(TokenType.Whitespace, "\r", new TokenPosition(2, 1, 1))
        },
        new object[]
        {
            "\r\r\r",
            new Token(TokenType.Whitespace, "\r", new TokenPosition(1, 1, 0)),
            new Token(TokenType.Whitespace, "\r", new TokenPosition(2, 1, 1)),
            new Token(TokenType.Whitespace, "\r", new TokenPosition(3, 1, 2))
        },
    };
    [Theory]
    [MemberData(nameof(TabData))]
    public void Return(string source, params Token[] expectedTokens)
    {
        var scanner = new BadakLang.Scanner.Scanner(source);
        foreach (var expectedToken in expectedTokens)
        {
            scanner.Next().Should().Be(expectedToken);
        }
    }
    
    public static IEnumerable<object[]> NewLineData => new List<object[]>
    {
        new object[]
        {
            "\n",
            new Token(TokenType.Whitespace, "\n", new TokenPosition(1, 1, 0))
        },
        new object[]
        {
            "\n\n",
            new Token(TokenType.Whitespace, "\n", new TokenPosition(1, 1, 0)),
            new Token(TokenType.Whitespace, "\n", new TokenPosition(1, 2, 1))
        },
        new object[]
        {
            "\n\n\n",
            new Token(TokenType.Whitespace, "\n", new TokenPosition(1, 1, 0)),
            new Token(TokenType.Whitespace, "\n", new TokenPosition(1, 2, 1)),
            new Token(TokenType.Whitespace, "\n", new TokenPosition(1, 3, 2))
        },
    };
    [Theory]
    [MemberData(nameof(NewLineData))]
    public void NewLine(string source, params Token[] expectedTokens)
    {
        var scanner = new BadakLang.Scanner.Scanner(source);
        foreach (var expectedToken in expectedTokens)
        {
            scanner.Next().Should().Be(expectedToken);
        }
    }
    
    public static IEnumerable<object[]> CombinationData => new List<object[]>
    {
        new object[]
        {
            " \t ",
            new Token(TokenType.Whitespace, " ", new TokenPosition(1, 1, 0)),
            new Token(TokenType.Whitespace, "\t", new TokenPosition(2, 1, 1)),
            new Token(TokenType.Whitespace, " ", new TokenPosition(3, 1, 2))
        },
        new object[]
        {
            "\t \t\r\n",
            new Token(TokenType.Whitespace, "\t", new TokenPosition(1, 1, 0)),
            new Token(TokenType.Whitespace, " ", new TokenPosition(2, 1, 1)),
            new Token(TokenType.Whitespace, "\t", new TokenPosition(3, 1, 2)),
            new Token(TokenType.Whitespace, "\r", new TokenPosition(4, 1, 3)),
            new Token(TokenType.Whitespace, "\n", new TokenPosition(5, 1, 4)),
        },
        new object[]
        {
            "  \t\n  \r\n\t ",
            new Token(TokenType.Whitespace, " ", new TokenPosition(1, 1, 0)),
            new Token(TokenType.Whitespace, " ", new TokenPosition(2, 1, 1)),
            new Token(TokenType.Whitespace, "\t", new TokenPosition(3, 1, 2)),
            new Token(TokenType.Whitespace, "\n", new TokenPosition(4, 1, 3)),
            new Token(TokenType.Whitespace, " ", new TokenPosition(1, 2, 4)),
            new Token(TokenType.Whitespace, " ", new TokenPosition(2, 2, 5)),
            new Token(TokenType.Whitespace, "\r", new TokenPosition(3, 2, 6)),
            new Token(TokenType.Whitespace, "\n", new TokenPosition(4, 2, 7)),
            new Token(TokenType.Whitespace, "\t", new TokenPosition(1, 3, 8)),
            new Token(TokenType.Whitespace, " ", new TokenPosition(2, 3, 9)),
        },
    };
    [Theory]
    [MemberData(nameof(CombinationData))]
    public void Combination(string source, params Token[] expectedTokens)
    {
        var scanner = new BadakLang.Scanner.Scanner(source);
        foreach (var expectedToken in expectedTokens)
        {
            scanner.Next().Should().Be(expectedToken);
        }
    }
}