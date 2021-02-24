using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrownAIO.Models;

namespace CrownAIO.Controllers.api
{
    public class RecentUserTasksController : ApiController
    {
        private ApplicationDbContext _context { get; set; }
        public RecentUserTasksController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/RecentUserTasks
        public IEnumerable<RecentUserTask> GetRecentUserTasks()
        {
            var tasks = _context.RecentUserTasks.ToList();
            if (tasks == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return tasks;
        }

        // POST /api/RecentUserTasks
        [HttpPost]
        public RecentUserTask CreateRecentUserTask(RecentUserTask task)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.RecentUserTasks.Add(task);
            _context.SaveChanges();

            return task;
        }


        // PUT /api/RecentUserTasks/profileId
        [HttpPut]
        public RecentUserTask EditRecentUserTasks(int profileId, [FromBody] RecentUserTask task)
        {
            var taskInDb = _context.RecentUserTasks.SingleOrDefault(t => t.ProfileId == profileId);
            if (taskInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            taskInDb.EditDateTime = task.EditDateTime;
            taskInDb.DateTime = task.DateTime;
            taskInDb.Product = task.Product;
            taskInDb.ProxyId = task.ProxyId;
            taskInDb.Size = task.Size;
            taskInDb.Status = task.Status;
            taskInDb.Store = task.Store;

            _context.SaveChanges();

            return task;
        }

        // DELETE /api/RecentUserTasks/profileId
        [HttpDelete]
        public HttpResponseMessage DeleteRecentUserTask(int profileId)
        {
            var taskInDb = _context.RecentUserTasks.SingleOrDefault(t => t.ProfileId == profileId);
            if (taskInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.RecentUserTasks.Remove(taskInDb);
            _context.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
