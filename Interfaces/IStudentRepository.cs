using EastCoastEducation.Model;

namespace EastCoastEducation.Interfaces
{
    public interface IStudentRepository
    {
        ICollection<Student> GetStudents();
        Student GetStudent(int id); // details, för att kunna se lista på kurser som studenten köpt

    }
}
