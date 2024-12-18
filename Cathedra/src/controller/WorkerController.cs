using Cathedra.dto;
using Cathedra.model;
using Cathedra.repository;
using Microsoft.AspNetCore.Mvc;

namespace Cathedra.controller;

[ApiController]
[Route("/api/worker")]
public class WorkerController : ControllerBase
{
    private readonly IWorkerRepository _workerRepository;

    public WorkerController(IWorkerRepository workerRepository)
    {
        _workerRepository = workerRepository;
    }


    [HttpPost("create")]
    public IActionResult addWorker([FromBody] WorkerDto? worker)
    {
        if (worker == null)
        {
            return BadRequest("Request body is empty");
        } 
        _workerRepository.addWorker(new Worker(worker.name, worker.lastname, worker.type));
        return Ok(new {status = "Worker added"});
    }

    [HttpGet("get/{name}")]
    public IActionResult findWorker(string name)
    {
        var found = _workerRepository.getWorkerByName(name);
        return Ok(new {name = found.name, lastname = found.lastName, type = found.type});
    }

    [HttpPut("update")]
    public IActionResult updateWorker([FromBody] WorkerDto? worker)
    {
        var workerForUpdate = _workerRepository.getWorkerByNameAndLastName(worker.name, worker.lastname);
        workerForUpdate.type = worker.type;
        _workerRepository.updateWorker(workerForUpdate);
        return Ok(new {status = "Worker updated"});
    }

    [HttpDelete("delete")]
    public IActionResult deleteWorker([FromBody] WorkerDto? worker)
    {
        _workerRepository.deleteWorker(_workerRepository.getWorkerByNameAndLastName(worker.name, worker.lastname));
        return Ok(new {status = "Worker deleted"});
    }
}