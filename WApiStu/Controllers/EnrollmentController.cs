 using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WApiStu.Models;

namespace WApiStu.Controllers
{
    public class EnrollmentController : ApiController
    {
        private StudMgmtEntities db = new StudMgmtEntities();

        // GET: api/Enrollment
        public IQueryable<Enrollment> GetEnrollments()
        {
            return db.Enrollments;
        }

        // POST: api/Enrollment
        [ResponseType(typeof(Enrollment))]
        public IHttpActionResult PostEnrollment(Enrollment enro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Enrollments.Add(enro);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = enro.EnrollmentId }, enro);
        }

    }
}