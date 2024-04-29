using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Json.Controllers

{
    public class StudentController : Controller
    {
        StudentContext context = new StudentContext();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        //creating a post for new student
        [HttpPost]

        public ActionResult CreateStudent(Student std)
        {
            context.Students.Add(std);
            context.SaveChanges();
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        public JsonResult GetStudent(string id)
        {
            List<Student> students = new List<Student>();
            students = context.Students.ToList();
            return Json(students, JsonRequestBehavior.AllowGet);
        }
    }

}