using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrownAIO.Models;

namespace CrownAIO.Controllers.api
{
    public class UserTasksController : ApiController
    {
        private ApplicationDbContext _context { get; set; }
        public UserTasksController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/userTasks
        public IEnumerable<UserTask> GetUserTasks()
        {
            var tasks = _context.UserTasks.ToList();
            if (tasks == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return tasks;
        }

        // POST /api/userTasks
        [HttpPost]
        public UserTask CreateUserTask(UserTask userTask)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.UserTasks.Add(userTask);
            _context.SaveChanges();

            return userTask;
        }

        // PUT /api/userTasks/profileId
        [HttpPut]
        public UserTask EditUserTask(int profileId, [FromBody] UserTask userTask)
        {
            var userTaskInDb = _context.UserTasks.SingleOrDefault(u => u.ProfileId == profileId);
            if (userTaskInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            userTaskInDb.EditDateTime = DateTime.Now;
            userTaskInDb.Product = userTask.Product;
            userTaskInDb.Size = userTask.Size;
            userTaskInDb.Status = userTask.Status;
            userTaskInDb.Store = userTask.Store;

            _context.SaveChanges();

            return userTask;
        }

        // DELETE /api/userTasks/profileId
        [HttpDelete]
        public HttpResponseMessage DeleteUserTask(int profileId)
        {
            var userTaskInDb = _context.UserTasks.SingleOrDefault(u => u.ProfileId == profileId);
            if (userTaskInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.UserTasks.Remove(userTaskInDb);
            _context.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
