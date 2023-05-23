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
        Assert.Multiple(() =>
        {
            Assert.That(counter.Value, Is.EqualTo(0));
            Assert.That(counter.Max, Is.Null);
            Assert.That(counter.Min, Is.Null);
            Assert.That(counter.Step, Is.EqualTo(1));
        });
    }

    [Test]
    public void TestIncrement()
    {
        ICounter counter = new Counter();
        counter.Increment();
        Assert.That(counter.Value, Is.EqualTo(1));
    }

    [Test]
    public void TestDecrement()
    {
        ICounter counter = new Counter();
        counter.Decrement();
        Assert.That(counter.Value, Is.EqualTo(-1));
    }

    [Test]
    public void TestMin()
    {
        ICounter counter = new Counter();
        counter.Update(0, counter.Max, counter.Step);
        counter.Decrement();
        Assert.That(counter.Value, Is.EqualTo(0));
    }

    [Test]
    public void TestMax()
    {
        ICounter counter = new Counter();
        counter.Update(counter.Min, 0, counter.Step);
        counter.Increment();
        Assert.That(counter.Value, Is.EqualTo(0));
    }

    [Test]
    public void TestStep()
    {
        ICounter counter = new Counter();
        counter.Update(counter.Min, counter.Max, 2);
        counter.Increment();
        Assert.That(counter.Value, Is.EqualTo(2));
        counter.Decrement();
        Assert.That(counter.Value, Is.EqualTo(0));
    }

    [Test]
    public void TestReset()
    {
        ICounter counter = new Counter();
        counter.Increment();
        counter.Increment();
        counter.Increment();
        Assert.That(counter.Value, Is.EqualTo(3));
        counter.Reset();
        Assert.That(counter.Value, Is.EqualTo(0));
    }
}