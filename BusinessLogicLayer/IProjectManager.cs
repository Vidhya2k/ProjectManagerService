using System.Linq;
using Entities;

namespace BusinessLogicLayer
{
    public interface IProjectManager
    {
        IQueryable<IProject> GetAllProjects();
        IProject GetProjectById(int id);
        void UpdateProject(int id, IProject project);
        void AddProject(IProject project);
        void DeleteProject(IProject project);
    }
}