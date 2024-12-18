using Cathedra.model;

namespace Cathedra.repository;

public interface ILessonsRepository
{
    Lesson? getLessonById(long id);
    
    string? getAllLessons();
    
    void addLesson(Lesson? lesson);
    
    void updateLesson(Lesson lesson);
    
    void deleteLesson(Lesson lesson);
    
    Lesson? getLessonByName(long name);
}