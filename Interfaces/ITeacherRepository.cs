using EastCoastEducation.Model;

namespace EastCoastEducation.Interfaces
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetTeachers();
        Task<Teacher?> GetTeacher(int id);
        Task<bool> TeacherExists(int id);
        Teacher CreateTeacher(Teacher teacher);
        Task UpdateTeacher(Teacher teacher);
        Task Save();
        void Delete(Teacher teacher);
    }
}
