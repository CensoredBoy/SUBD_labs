using Cathedra.config;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Cathedra.model;

namespace Cathedra.repository;

public class DisciplineRepository : IDisciplineRepository
{
    private readonly ApplicationDbContext _context;

    public DisciplineRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public Discipline? getDisciplineById(int id)
    {
        return _context.Disciplines.Find(id);
    }

    public string? getAllDisciplines()
    {
       return _context.Disciplines.ToString();
    }

    public string? getAllDisciplinesByName(string name)
    {
        throw new NotImplementedException();
    }

    public Discipline? getDisciplineByName(string name)
    {
        return _context.Disciplines.FirstOrDefault(t => t.name.Equals(name));
    }

    public string? GetAllTracksByArtistName(string artistName)
    {
        return _context.Disciplines.Find(artistName)?.ToString();
    }

    public void addDiscipline(Discipline discipline)
    {
            _context.Disciplines.Add(discipline);
            _context.SaveChanges();   
    }

    public void updateDiscipline(Discipline discipline)
    {
        _context.Disciplines.Update(discipline);
        _context.SaveChanges();
    }

    public void deleteDiscipline(Discipline discipline)
    {
        _context.Disciplines.Remove(discipline);
        _context.SaveChanges();
    }
}