using Cathedra.config;
using Cathedra.model;
using Cathedra.repository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Cathedra.test;

[TestFixture]
public class WorkerRepoTest
{
    private DbContextOptions<ApplicationDbContext> _options; 
    private ApplicationDbContext _context; 
    private WorkerRepository _repository;

    [SetUp]
    public void Setup()
    {
        _options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        _context = new ApplicationDbContext(_options);
        _repository = new WorkerRepository(_context);
    }
    
    [TearDown]
    public void Teardown()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }

    [Test]
    public void AddWorker_ShouldAddWorker_WhenWorkerDoesNotExist()
    {
        var worker = new Worker ( "Test name", "Test lastname", "test type");

        _repository.addWorker(worker);

        var result = _context.Worker.FirstOrDefault(w => w.name == "Test name" && w.lastName == "Test lastname");
        Assert.That(result, Is.Not.Null);
        Assert.That(result.name, Is.EqualTo("Test name"));
    }

    [Test]
    public void AddWorker_ShouldNotAddDuplicateWorker()
    {
        var worker = new Worker("Test name","Test lastname", "Test type");
        _context.Worker.Add(worker);
        _context.SaveChanges();

        // _repository.addWorker(worker);

        var count = _context.Worker.Count(a => a.name == "Test name" && a.lastName == "Test lastname");
        Assert.That(count, Is.EqualTo(1));
    }

    [Test]
    public void GetWorkerByName_ShouldReturnWorker_WhenWorkerExists()
    {
        var worker = new Worker("Test name", "Test lastname", "Test type");
        _context.Worker.Add(worker);
        _context.SaveChanges();

        var result = _repository.getWorkerByNameAndLastName("Test name", "Test lastname");

        Assert.That(result, Is.Not.Null);
        Assert.That(result.name, Is.EqualTo("Test name"));
    }

    [Test]
    public void GetWorkerByName_ShouldReturnNull_WhenWorkerDoesNotExist()
    {
        var result = _repository.getWorkerByName("Nonexistent Artist");
        Assert.That(result, Is.Null);
    }

    [Test]
    public void UpdateWorker_ShouldUpdateArtistDetails()
    {
        var worker = new Worker("Test name", "Test lastname", "Test type");
        _context.Worker.Add(worker);
        _context.SaveChanges();

        worker.type = "Updated type";
        _repository.updateWorker(worker);

        var updatedArtist = _context.Worker.FirstOrDefault(a => a.id == 1);
        Assert.That(updatedArtist.type, Is.EqualTo("Updated type"));
    }

    [Test]
    public void DeleteWorker_ShouldRemoveWorker() 
    {
        var worker = new Worker("Test name", "Test lastname", "Test type");
        _context.Worker.Add(worker);
        _context.SaveChanges();

        _repository.deleteWorker(worker);

        var result = _context.Worker.FirstOrDefault(a => a.id == 1); 
        Assert.That(result, Is.Null);
    }
}