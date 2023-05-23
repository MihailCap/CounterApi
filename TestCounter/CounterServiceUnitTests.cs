using CounterApi.Domain;
using CounterApi.Persistence;
using CounterApi.Service;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Moq.Language.Flow;

namespace TestCounter;

public class CounterServiceUnitTests
{
    private CounterDb context;

    /// <summary>
    /// Initialize tests
    /// </summary>
    [SetUp]
    public void Init()
    {
        var mockContext = new Mock<CounterDb>();
        mockContext.Setup<DbSet<Counter>>(x => x.Counters).ReturnsDbSet(TestDataHelper.GetFakeCountersList());
        context = mockContext.Object;
    }

    /// <summary>
    /// Test get all counters
    /// </summary>
    [Test]
    public void TestGetAll()
    {
        ICounterService service = new CounterService(context);

        Assert.That(service.GetAll().Count(), Is.EqualTo(3));
    }

    /// <summary>
    /// Test create counter
    /// </summary>
    [Test]
    public void TestCreate()
    {
        ICounterService service = new CounterService(context);

        var counter = service.Create("counter");
        Assert.Multiple(() =>
        {
            Assert.That(counter.Name, Is.EqualTo("counter"));
            Assert.That(service.GetAll().Count(), Is.EqualTo(4));
        });
    }

    /// <summary>
    /// Test create counter
    /// </summary>
    [Test]
    public void TestCreateDuplicate()
    {
        ICounterService service = new CounterService(context);

        Assert.Throws<Exception>(()=>service.Create("test1"));
    }

    [Test]
    public void TestUpdateNull()
    {
        ICounterService service = new CounterService(context);

        var counter = service.Update("test1", null, null, null);
        
        Assert.Multiple(() =>
        {
            Assert.That(counter.Name, Is.EqualTo("test1"));
            Assert.That(counter.Min, Is.Null);
            Assert.That(counter.Max, Is.Null);
            Assert.That(counter.Step, Is.EqualTo(1));
            Assert.That(counter.Value, Is.EqualTo(0));
            Assert.That(service.GetAll().Count(), Is.EqualTo(3));
        });
    }

    [Test]
    public void TestUpdateName()
    {
        ICounterService service = new CounterService(context);

        var counter = service.Update("test1", null, null, null, "updated");
        
        Assert.Multiple(() =>
        {
            Assert.That(service.GetAll().Where(x => x.Name == "updated").Count(), Is.EqualTo(1));
        });
    }
}

public static class TestDataHelper
{
    public static IEnumerable<Counter> GetFakeCountersList()
    {
        return new List<Counter>
        {
            new("test1"),
            new("test2"),
            new("test3")
        };
    }
}