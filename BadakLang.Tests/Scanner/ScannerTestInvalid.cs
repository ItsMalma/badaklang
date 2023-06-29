using BadakLang.Scanner;
using FluentAssertions;
using Xunit;

namespace BadakLang.Tests.Scanner;

public class ScannerTestInvalid
{
    public static IEnumerable<object[]> SpaceData => new List<object[]>
    {
        new object[]
        {
            "$",
            new Token(TokenType.Invalid, "$", new TokenPosition(1, 1, 0))
        },
        new object[]
        {
            "$#",
            new Token(TokenType.Invalid, "$", new TokenPosition(1, 1, 0)),
            new Token(TokenType.Invalid, "#", new TokenPosition(2, 1, 1))
        },
        new object[]
        {
            "$#^",
            new Token(TokenType.Invalid, "$", new TokenPosition(1, 1, 0)),
            new Token(TokenType.Invalid, "#", new TokenPosition(2, 1, 1)),
            new Token(TokenType.Invalid, "^", new TokenPosition(3, 1, 2))
        },
    };
    [Theory]
    [MemberData(nameof(SpaceData))]
    public void Invalid(string source, params Token[] expectedTokens)
    {
        var scanner = new BadakLang.Scanner.Scanner(source);
        foreach (var expectedToken in expectedTokens)
        {
            scanner.Next().Should().Be(expectedToken);
        }
    }
}