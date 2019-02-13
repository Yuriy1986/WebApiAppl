using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiAppl.EF;
using WebApiAppl.Models;
using Newtonsoft.Json;

namespace WebApiAppl.Controllers
{
    public class UsersController : ApiController
    {
       private Context db = new Context();

        // GET: api/Users
        public UsersAndPositionViewModel GetUsers()
        {
            UsersAndPositionViewModel model = new UsersAndPositionViewModel
            {
                PositionAll = db.Positions.ToList(),
                UsersAll = db.Users.ToList()
            };

            return model;
        }

        // GET: api/Users/5
        public IHttpActionResult GetPosition(int id)
        {
            var userCurrent = db.Users.FirstOrDefault(x => x.Id == id);

            if (userCurrent != null)
                return Ok(db.Positions.FirstOrDefault(x => x.Id == userCurrent.PositionId).PositionName);

            return NotFound();
        }

        // POST: api/Users
        [HttpPost]
        public IHttpActionResult AddUser([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User userCurrent = db.Users.FirstOrDefault(x => x.Email == user.Email);
            if (userCurrent != null)
            {
                ModelState.AddModelError("user.Email", "User with the same Email already exists.");
                return BadRequest(ModelState);
            }

            user.Name = user.Name.Trim();
            user.SecondName = user.SecondName.Trim();
            user.Address = user.Address.Trim();

            db.Users.Add(user);
            db.Entry(user).State = EntityState.Added;
            db.SaveChanges();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}