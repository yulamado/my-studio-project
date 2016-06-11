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
    public class OrganizersController : Controller
    {
        private ApplicationDbContext _db;
        public OrganizersController(ApplicationDbContext db)
        {
            this._db = db;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return (from s in _db.Students

                    select new Student
                    {
                        Id = s.Id,
                        Rhythm = s.Rhythm,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Hour = s.Hour,
                        Room = s.Room,
                        Instructor = s.Instructor
                    }).ToList();

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Student studentToReturn = _db.Students.FirstOrDefault(s => s.Id == id);
            if (studentToReturn == null)
            {
                return NotFound();
            }

            return Ok(studentToReturn);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            if (student.Id == 0)
            {

                var rhythm = (from r in _db.Rhythms where r.Id == student.Rhythm.Id select r).FirstOrDefault();

                var instructor = (from u in _db.Users where u.FullName == student.Instructor.FullName select u).FirstOrDefault();

                var studentToAdd = new Student
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Room = student.Room,
                    Rhythm = rhythm,
                    Hour = student.Hour,
                    Instructor = instructor
                };

                _db.Students.Add(studentToAdd);
                _db.SaveChanges();

                var Student = (from t in _db.Students orderby t.Id descending select t).FirstOrDefault();

                var instructorWithStudent = new InstructorStudent
                {
                    InstructorId = instructor.Id,
                    Instructor = instructor,
                    Student = Student,
                    StudentId = Student.Id,
                };
                _db.InstructorStudents.Add(instructorWithStudent);
                _db.SaveChanges();

                return Ok(student);
            } 
            else
            {

                var originalStudent = _db.Students.FirstOrDefault(s => s.Id == student.Id);
                originalStudent.FirstName = student.FirstName;
                originalStudent.LastName = student.LastName;
                originalStudent.Hour = student.Hour;
                originalStudent.Room = student.Room;                               
                _db.SaveChanges();              
            }
            return Ok(student);
        }
    


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Student studentToDelete = _db.Students.FirstOrDefault(m => m.Id == id);
            if (studentToDelete == null)
            {
                return NotFound();
            }
            _db.Students.Remove(studentToDelete);
            _db.SaveChanges();
            return Ok();
        }
    }
}

