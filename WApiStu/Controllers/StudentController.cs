using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WApiStu.Models;

namespace WApiStu.Controllers
{
    public class StudentController : ApiController
    {
        private StudMgmtEntities db = new StudMgmtEntities();

        // GET: api/Student
        public IQueryable<StudentMaster> GetStudents()
        {
            return db.StudentMasters;
        }

        // GET: api/Student/5
        [ResponseType(typeof(StudentMaster))]
        public IHttpActionResult GetStudent(int id)
        {
            StudentMaster student = db.StudentMasters.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Student/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(int id, StudentMaster student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.StudentId)
            {
                return BadRequest();
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Student
        [ResponseType(typeof(StudentMaster))]
        public IHttpActionResult PostStudent(StudentMaster student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StudentMasters.Add(student);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = student.StudentId }, student);
        }

        // DELETE: api/Student/5
        [ResponseType(typeof(StudentMaster))]
        public IHttpActionResult DeleteStudent(int id)
        {
            StudentMaster student = db.StudentMasters.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            db.StudentMasters.Remove(student);
            db.SaveChanges();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return db.StudentMasters.Count(e => e.StudentId == id) > 0;
        }

    }
}