using Cathedra.config;
using Cathedra.model;
using Microsoft.EntityFrameworkCore;

namespace Cathedra.repository;

public class LessonRepository : ILessonsRepository
{
    
    private readonly ApplicationDbContext _context;
    
    public LessonRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public Lesson? getLessonByName(long name)
    {
        return _context.Lessons.FirstOrDefault(t => t.disciplineId.Equals(name));
    }

    public Lesson? getLessonById(long id)
    {
        return _context.Lessons.Find(id);
    }

    public string? getAllLessons()
    {
        return _context.Lessons.ToString();
    }

    public void addLesson(Lesson? lesson)
    {
        var found = this.getLessonByName(lesson.disciplineId);
        if (found == null)
        {
            _context.Lessons.Add(lesson);
            _context.SaveChanges();
        }
    }

    public void updateLesson(Lesson lesson)
    {
        Console.WriteLine(lesson.disciplineId + " | " + lesson.startTime);
        _context.Lessons.Update(lesson);  
        _context.SaveChanges();
    }

    public void deleteLesson(Lesson lesson)
    {
        _context.Lessons.Remove(lesson);    
        _context.SaveChanges();
    }
}