using EastCoastEducation.Model;

namespace EastCoastEducation.Interfaces
{
    public interface ICompetenceRepository
    {
        ICollection<Competence> GetCompetences();
        Competence GetCompetence(int id);
        bool CompetenceExists(int id); 
    }
}
