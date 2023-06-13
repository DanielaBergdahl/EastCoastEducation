using EastCoastEducation.Data;
using EastCoastEducation.Interfaces;
using EastCoastEducation.Model;
using Microsoft.EntityFrameworkCore;

namespace EastCoastEducation.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;
        public TeacherRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Teacher CreateTeacher(Teacher teacher)
            => _context.Teachers.Add(teacher).Entity;

        public async Task<Teacher?> GetTeacher(int id)
            => await _context.Teachers.FindAsync(id);

        public async Task<IEnumerable<Teacher>> GetTeachers()
            => await _context.Teachers.ToListAsync();

        public async Task Save()
            => await _context.SaveChangesAsync();

        public async Task<bool> TeacherExists(int id)
        {
            var result = await _context.Teachers.FindAsync(id);
            if (result is null)
            {
                return false;
            }
            return true;
        }

        public async Task UpdateTeacher(Teacher teacher)
        {
            if (GetTeacher(teacher.TeacherId) is null)
            {
                return;
            }

            _context.Entry(teacher).State = EntityState.Modified;

            await Save();
        }

        public void Delete(Teacher teacher)
            => _context.Teachers.Remove(teacher);
    }
}
