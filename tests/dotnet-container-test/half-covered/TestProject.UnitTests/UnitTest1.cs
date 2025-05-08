namespace TestProject.UnitTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var result = Program.Covered("test");
        Assert.Equal("test", result);
    }
}