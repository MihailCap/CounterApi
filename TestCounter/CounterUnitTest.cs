using CounterApi.Domain;

namespace TestCounter;

public class Tests
{
    /// <summary>
    /// Test counter creation
    ///
    /// Initial value == 0
    /// Initial max == null
    /// Initial min == null
    /// Initial step == 1
    /// </summary>
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

    /// <summary>
    /// Test increment
    ///
    /// Increment() => value == 1
    /// </summary>
    [Test]
    public void TestIncrement()
    {
        ICounter counter = new Counter();
        counter.Increment();
        Assert.That(counter.Value, Is.EqualTo(1));
    }

    /// <summary>
    /// Test decrement
    ///
    /// Decrement() => value == -1
    /// </summary>
    [Test]
    public void TestDecrement()
    {
        ICounter counter = new Counter();
        counter.Decrement();
        Assert.That(counter.Value, Is.EqualTo(-1));
    }

    /// <summary>
    /// Test update min value
    ///
    /// value can't go lower than min
    /// </summary>
    [Test]
    public void TestMin()
    {
        ICounter counter = new Counter();
        counter.Update(0, counter.Max, counter.Step);
        counter.Decrement();
        Assert.That(counter.Value, Is.EqualTo(0));
    }

    /// <summary>
    /// Test update max value
    ///
    /// value can't go higher than max
    /// </summary>
    [Test]
    public void TestMax()
    {
        ICounter counter = new Counter();
        counter.Update(counter.Min, 0, counter.Step);
        counter.Increment();
        Assert.That(counter.Value, Is.EqualTo(0));
    }

    /// <summary>
    /// Test step
    ///
    /// Set step to 2
    /// Increment() => value == 2
    /// </summary>
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

    /// <summary>
    /// Test reset
    ///
    /// Reset() => value == 0
    /// </summary>
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

    /// <summary>
    /// Test update negative step
    ///
    /// Throws Exception
    /// </summary>
    [Test]
    public void TestUpdateNegativeStep()
    {
        ICounter counter = new Counter();

        Assert.Throws<Exception>(() => counter.Update(counter.Min, counter.Max, -1));
    }

    /// <summary>
    /// Test incoherent min max update
    ///
    /// Throws Exception
    /// </summary>
    [Test]
    public void TestUpdateMaxLowerOrEqualThanMin()
    {
        ICounter counter = new Counter();
        Assert.Throws<Exception>(() => counter.Update(1, 0, counter.Step));
        Assert.Throws<Exception>(() => counter.Update(1, 1, counter.Step));
    }
}