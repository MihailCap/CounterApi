using CounterApi;

namespace TestCounter;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestCreate()
    {
        ICounter counter = new Counter();
        Assert.AreEqual(0, counter.Value);
    }
}