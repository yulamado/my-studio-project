using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStudioProject.Data;
using MyStudioProject.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStudioProject.API
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private ApplicationDbContext _db;
        public StudentsController(ApplicationDbContext db)
        {
            this._db = db;
        } 
        // GET: api/values
        [HttpGet]
        public IEnumerable<Student> Get()

        {
           
                return (from s in _db.Students
                        where s.InstructorStudents.Any(si => si.Instructor.UserName == User.Identity.Name)
                        select new Student
                        {
                            Id = s.Id,
                            Rhythm = s.Rhythm,
                            FirstName = s.FirstName,
                            LastName = s.LastName,
                            Hour = s.Hour,
                            Room = s.Room,                           
                        }).ToList();
                       
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Student student)
        {          
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
