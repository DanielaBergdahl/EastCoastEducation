﻿using EastCoastEducation.Data;
using EastCoastEducation.Interfaces;
using EastCoastEducation.Model;
using SQLitePCL;

namespace EastCoastEducation.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context) 
        {
            _context = context; 
        }

        public ICollection<Course> GetAllCourses() 
        {
            return _context.Courses.OrderBy(c => c.CourseId).ToList();
        }

        public Course GetCourse(int id)
        {
            return _context.Courses.Where(c => c.CourseId == id).FirstOrDefault();
        }

        public Course GetCourse(string title)
        {
            return _context.Courses.Where(c => c.CourseTitle == title).FirstOrDefault();
        }

        public Course GetCourseByCategory(string category)
        {
            return _context.Courses.Where(c => c.Category == category).FirstOrDefault();
        }

        public Course GetCourseByDetails(string details)
        {
            return _context.Courses.Where(c => c.CourseDetails == details).FirstOrDefault();
        }

        public Course GetCourseByNumber(int number)
        {
            return _context.Courses.Where(c => c.CourseNumber == number).FirstOrDefault(); 
        }

        public Course GetCourseByLength(string length)
        {
            return _context.Courses.Where(c => c.CourseLength == length).FirstOrDefault();
        }

        public bool CourseExists(int courseId) 
        {
            return _context.Courses.Any(c => c.CourseId == courseId);
        }
    }
}
