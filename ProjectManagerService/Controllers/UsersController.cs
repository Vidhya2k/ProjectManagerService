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
    public class UsersController : ApiController
    {
        private readonly UserManager _userManager = new UserManager();

        // GET: api/Users
        public IEnumerable<IUser> GetUsers()
        {
            return _userManager.GetAllUsers().ToList();
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            var user = _userManager.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.User_Id)
            {
                return BadRequest();
            }

            try
            {
                _userManager.UpdateUser(id, user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _userManager.AddUser(user);


            return CreatedAtRoute("DefaultApi", new { id = user.User_Id }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            var user = _userManager.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            _userManager.DeleteUser(user);

            return Ok(user);
        }

        private bool UserExists(int id)
        {
            return _userManager.GetUserById(id) != null;
        }
    }
}