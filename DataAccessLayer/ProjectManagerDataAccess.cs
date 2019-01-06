using System;
using System.Data.Entity;
using System.Linq;
using Entities;

namespace DataAccessLayer
{
    public class ProjectManagerDataAccess : IProjectManagerDataAccess
    {
        private readonly ProjectManagementEntities _projectContext = new ProjectManagementEntities();

        public ProjectManagerDataAccess()
        {
        }

        public IQueryable<IProject> GetAllProjects()
        {
            return _projectContext.Projects;
        }

        public IProject GetProjectById(int id)
        {
            return _projectContext.Projects.Find(id);
        }

        public void UpdateProject(int id, IProject project)
        {
            _projectContext.Entry(project).State = EntityState.Modified;
            _projectContext.SaveChanges();
        }

        public void AddProject(IProject project)
        {
            _projectContext.Projects.Add((Project)project);
            _projectContext.SaveChanges();
        }

        public void DeleteProject(IProject project)
        {
            _projectContext.Projects.Remove((Project)project);
            _projectContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_projectContext != null)
                {
                    _projectContext.Dispose();
                }
            }
        }
    }
}
