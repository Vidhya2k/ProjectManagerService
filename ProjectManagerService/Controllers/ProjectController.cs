using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using BusinessLogicLayer;
using Entities;

namespace ProjectManagerService.Controllers
{
    public class ProjectController : ApiController
    {
        private readonly ProjectManager _projectManager = new ProjectManager();

        // GET: api/Project
        public IEnumerable<IProject> GetProjects()
        {
            return _projectManager.GetAllProjects().ToList();
        }

        // GET: api/Project/5
        [ResponseType(typeof(Project))]
        public IHttpActionResult GetProject(int id)
        {
            var project = _projectManager.GetProjectById(id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // PUT: api/Project/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProject(int id, Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project.Project_Id)
            {
                return BadRequest();
            }
            
            try
            {
                _projectManager.UpdateProject(id, project);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    return NotFound();
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Project
        [ResponseType(typeof(Project))]
        public IHttpActionResult PostProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _projectManager.AddProject(project);

            return CreatedAtRoute("DefaultApi", new { id = project.Project_Id }, project);
        }

        // DELETE: api/Project/5
        [ResponseType(typeof(Project))]
        public IHttpActionResult DeleteProject(int id)
        {
            var project = _projectManager.GetProjectById(id);

            if (project == null)
            {
                return NotFound();
            }

            _projectManager.DeleteProject(project);

            return Ok(project);
        }

        private bool ProjectExists(int id)
        {
            return _projectManager.GetProjectById(id) != null;
        }
    }
}