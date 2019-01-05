
using System.Linq;
using DataAccessLayer;
using Entities;

namespace BusinessLogicLayer
{
    public class ProjectManager : IProjectManager
    {
        private readonly IProjectManagerDataAccess _projectManagerDataAccess = new ProjectManagerDataAccess();

        public ProjectManager(IProjectManagerDataAccess projectManagerDataAccess)
        {
            _projectManagerDataAccess = projectManagerDataAccess;
        }

        public ProjectManager()
        {
            
        }

        public IQueryable<IProject> GetAllProjects()
        {
            return _projectManagerDataAccess.GetAllProjects();
        }

        public IProject GetProjectById(int id)
        {
            return _projectManagerDataAccess.GetProjectById(id);
        }

        public void UpdateProject(int id, IProject project)
        {
            _projectManagerDataAccess.UpdateProject(id, project);
        }

        public void AddProject(IProject project)
        {
            _projectManagerDataAccess.AddProject(project);
        }

        public void DeleteProject(IProject project)
        {
            _projectManagerDataAccess.DeleteProject(project);
        }
    }
}
