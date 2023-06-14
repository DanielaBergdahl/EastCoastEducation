using EastCoastEducation.Model;

namespace EastCoastEducation.Interfaces
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetTeachers();
        Task<Teacher?> GetTeacher(int id);
        Task<bool> TeacherExists(int id);
        bool CreateTeacher(Teacher teacher);
        bool UpdateTeacher(Teacher teacher);
        bool Save();
        void Delete(Teacher teacher);
    }
}
