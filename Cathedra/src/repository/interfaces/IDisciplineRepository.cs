using Microsoft.AspNetCore.Mvc;
using Cathedra.model;

namespace Cathedra.repository;

public interface IDisciplineRepository 
{
    Discipline? getDisciplineById(int id);
    
    string? getAllDisciplines();
    
    Discipline? getDisciplineByName(string name);
    
    void addDiscipline(Discipline discipline);
    
    void updateDiscipline(Discipline discipline);
    
    void deleteDiscipline(Discipline discipline);
}