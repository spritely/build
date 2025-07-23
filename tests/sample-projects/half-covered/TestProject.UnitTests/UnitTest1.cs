namespace TestProject.UnitTests;

public class UnitTest1
{
    [Fact]
    public void TestClass1Covered()
    {
        var result = Class1.Covered("test");
        Assert.Equal("test", result);
    }

    [Fact]
    public void TestProgramCovered()
    {
        var result = Program.Covered("test");
        Assert.Equal("test", result);
    }
}
