using Cathedra.config;
using Cathedra.dto;
using Cathedra.model;

namespace Cathedra.repository;

public class WorkerRepository : IWorkerRepository
{
    
    private readonly ApplicationDbContext _context;
    
    public WorkerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Worker getWorkertById(int id)
    {
        return _context.Worker.Find(id);
    }

    public Worker getWorkerByName(string name)
    {
        return _context.Worker.FirstOrDefault(a => a.name == name);
    }

    public Worker? getWorkerByNameAndLastName(string name, string lastName)
    {
        return _context.Worker.FirstOrDefault(a => a.name == name && a.lastName == lastName);
    }

    public string? getAllWorkers()
    {
        return _context.Worker.ToString();
    }

    public void addWorker(Worker? worker)
    {
        _context.Worker.Add(worker);
        _context.SaveChanges();
    }

    public void addWorkers(Worker? worker)
    {
        var found = _context.Worker.FirstOrDefault(a => a.name == worker.name);
        if (found != null && (found.lastName == worker.lastName && found.type != worker.type))
        {
            _context.Worker.Add(worker);
            _context.SaveChanges();   
        }
    }

    public void updateWorker(Worker worker)
    {
        _context.Worker.Update(worker);
        _context.SaveChanges();
    }

    public void deleteWorker(Worker worker)
    {
        _context.Worker.Remove(worker);
        _context.SaveChanges();
    }
    
}