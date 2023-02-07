namespace TrackTheRobot.Tests;

public class RobotTests
{
    [Theory]
    [InlineData(new string[] { "right 10", "up 50", "left 30", "down 10" }, new int[] { -20, 40 })]
    [InlineData(new string[] { }, new int[] { 0, 0 })]
    [InlineData(new string[] { "left 10", "left 100", "left 1000", "left 10000" }, new int[] { -11110, 0 })]
    [InlineData(new string[] { "right 100", "right 100", "up 500", "up 10000" }, new int[] { 200, 10500 })]
    [InlineData(new string[] { "left 10", "right 10", "down 10", "up 10" }, new int[] { 0, 0 })]
    public void TestWalkSuccess(string[] instructions, int[] resultExpected)
    {
        Assert.Equal(resultExpected, new Robot().Walk(instructions));
    }
}