using Cathedra.dto;
using Cathedra.model;

namespace Cathedra.repository;

public interface IWorkerRepository
{
    Worker getWorkertById(int id);

    Worker getWorkerByName(string name);
    
    string? getAllWorkers();
    
    void addWorker(Worker? worker);
    
    void updateWorker(Worker worker);
    
    void deleteWorker(Worker worker);

    Worker? getWorkerByNameAndLastName(string name, string lastName);

}