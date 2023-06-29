using BadakLang.Scanner;
using FluentAssertions;
using Xunit;

namespace BadakLang.Tests.Scanner;

public class ScannerTestEof
{
    public static IEnumerable<object[]> SpaceData => new List<object[]>
    {
        new object[]
        {
            "",
            new Token(TokenType.Eof, "\0", new TokenPosition(1, 1, 0))
        },
        new object[]
        {
            " ",
            new Token(TokenType.Whitespace, " ", new TokenPosition(1, 1, 0)),
            new Token(TokenType.Eof, "\0", new TokenPosition(2, 1, 1))
        },
        new object[]
        {
            " \n",
            new Token(TokenType.Whitespace, " ", new TokenPosition(1, 1, 0)),
            new Token(TokenType.Whitespace, "\n", new TokenPosition(2, 1, 1)),
            new Token(TokenType.Eof, "\0", new TokenPosition(1, 2, 2))
        },
    };
    [Theory]
    [MemberData(nameof(SpaceData))]
    public void Eof(string source, params Token[] expectedTokens)
    {
        var scanner = new BadakLang.Scanner.Scanner(source);
        foreach (var expectedToken in expectedTokens)
        {
            scanner.Next().Should().Be(expectedToken);
        }
    }
}