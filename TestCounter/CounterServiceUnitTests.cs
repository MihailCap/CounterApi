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
        var options = new DbContextOptionsBuilder<CounterDb>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        context = new CounterDb(options);
        context.AddRange(TestDataHelper.GetFakeCountersList());
        context.SaveChanges();
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
    /// Test get one
    /// </summary>
    [Test]
    public void TestGet()
    {
        ICounterService service = new CounterService(context);
        Assert.Multiple(() =>
        {
            Assert.That(service.Get("test1"), Is.Not.Null);
            Assert.That(service.Get("test2"), Is.Not.Null);
            Assert.That(service.Get("test3"), Is.Not.Null);
        });
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

        Assert.That(service.Create("test1"),Is.Null);
    }

    [Test]
    public void TestUpdateNull()
    {
        ICounterService service = new CounterService(context);

        var counter = service.Update("test1", null, null, null, null);
        
        Assert.Multiple(() =>
        {
            Assert.That(counter, Is.Not.Null);
        });
        
        counter = service.Get("test1");
        
        Assert.Multiple(() =>
        {
            Assert.That(counter?.Name, Is.EqualTo("test1"));
            Assert.That(counter?.Min, Is.Null);
            Assert.That(counter?.Max, Is.Null);
            Assert.That(counter?.Step, Is.EqualTo(1));
            Assert.That(counter?.Value, Is.EqualTo(0));
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
            Assert.That(counter, Is.Not.Null);
            Assert.That(service.GetAll().Count(x => x.Name == "updated"), Is.EqualTo(1));
        });
    }

    [Test]
    public void TestUpdateStep()
    {
        ICounterService service = new CounterService(context);

        var counter = service.Update("test1", null, null, 2, null);
        
        Assert.Multiple(() =>
        {
            Assert.That(counter, Is.Not.Null);
        });
        
        counter = service.Get("test1");
        
        Assert.Multiple(() =>
        {
            Assert.That(counter?.Step, Is.EqualTo(2));
        });
    }

    [Test]
    public void TestUpdateStepNull()
    {
        ICounterService service = new CounterService(context);

        var counter = service.Update("test1", null, null, 2, null);
        counter = service.Update(counter?.Name, null, null, null, null);
        
        Assert.Multiple(() =>
        {
            Assert.That(counter, Is.Not.Null);
        });
        
        counter = service.Get("test1");
        
        Assert.Multiple(() =>
        {
            Assert.That(counter?.Step, Is.EqualTo(2));
        });
    }

    [Test]
    public void TestUpdateStepFail()
    {
        ICounterService service = new CounterService(context);

        var counter = service.Update("test1", null, null, -2, null);
        
        Assert.Multiple(() =>
        {
            Assert.That(counter, Is.Null);
        });
    }

    [Test]
    public void TestUpdateMinMax()
    {
        ICounterService service = new CounterService(context);

        var counter = service.Update("test1", 2, 1, null, null);
        
        Assert.Multiple(() =>
        {
            Assert.That(counter, Is.Not.Null);
        });
        
        counter = service.Get("test1");
        
        Assert.Multiple(() =>
        {
            Assert.That(counter?.Max, Is.EqualTo(2));
            Assert.That(counter?.Min, Is.EqualTo(1));
        });
    }

    [Test]
    public void TestUpdateMinMaxFail()
    {
        ICounterService service = new CounterService(context);

        var counter = service.Update("test1", 1, 2, null, null);
        
        Assert.Multiple(() =>
        {
            Assert.That(counter, Is.Null);
        });
    }

    [Test]
    public void TestIncrement()
    {
        ICounterService service = new CounterService(context);
        Assert.That(service.Increment("test2")?.Value, Is.EqualTo(1));
    }

    [Test]
    public void TestDecrement()
    {
        ICounterService service = new CounterService(context);
        Assert.That(service.Decrement("test3")?.Value, Is.EqualTo(-1));
    }

    [Test]
    public void TestReset()
    {
        ICounterService service = new CounterService(context);
        Assert.That(service.Reset("test3")?.Value, Is.EqualTo(0));
    }

    [Test]
    public void TestDelete()
    {
        ICounterService service = new CounterService(context);
        Assert.Multiple(() =>
        {
            Assert.That(service.Delete("test3"), Is.True);
            Assert.That(service.GetAll().Count(), Is.EqualTo(2));
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