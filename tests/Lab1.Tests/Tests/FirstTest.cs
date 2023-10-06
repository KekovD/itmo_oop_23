using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests.Tests;

public class FirstTest
{
    public static bool IsOddNumber(int number)
    {
        return number % 2 != 0;
    }

    [Theory]
    [InlineData(5, 2, 3, 9)]
    [InlineData(7, 1, 5, 3)]
    public void AllNumbersAreOddWithInlineData(int a, int b, int c, int d)
    {
        Assert.True(IsOddNumber(a));
        Assert.True(IsOddNumber(b));
        Assert.True(IsOddNumber(c));
        Assert.True(IsOddNumber(d));
    }
}