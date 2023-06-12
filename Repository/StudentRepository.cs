﻿using EastCoastEducation.Data;
using EastCoastEducation.Interfaces;
using EastCoastEducation.Model;
using SQLitePCL;

namespace EastCoastEducation.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET METHODS
        public ICollection<Student> GetStudents()
        {
            return _context.Students.OrderBy(s => s.StudentId).ToList();

        }
        public Student GetStudent(int id)
        {
            return _context.Students.Where(s => s.StudentId == id).FirstOrDefault();
        }


        public bool StudentExists(int studentId)
        {
            return _context.Students.Any(s => s.StudentId == studentId);
        }

        //POST METHODS
        //public bool CreateStudent(int courseId, Student student)
        public bool CreateStudent(Student student)
        {
            //var studentCourseEntity = _context.Courses.Where
            //    (a => a.CourseId == courseId).FirstOrDefault();

            //var studentCourse = new StudentCourse()
            //{
            //    Course = studentCourseEntity,
            //    Student = student,
            //};

            //_context.Add(studentCourse); // Gör att ´även kopplingstabellen populeras

            _context.Add(student);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
