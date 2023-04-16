using EducationPlatform_GraduationProject.Data;
using EducationPlatform_GraduationProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducationPlatform_GraduationProject.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        // id class
        public IActionResult GetAllStudent(int id)
        {
            List<Student> students = new List<Student>();
            if (id > 0)
            {
                var clsID = _context.Classes.Where(x => x.ClassId == id).FirstOrDefault();
                if (clsID != null)
                {
                    students = _context.Students.Where(x => x.ClassID == id).ToList();
                }
                // ارجع لصفحة الخطأ

            }
            return View(students);
        }

        [HttpGet]
        public IActionResult UpdateStudent(int id)
        {
            Student student;
            if (id > 0)
            {
                student = _context.Students.Where(x => x.StId == id).FirstOrDefault();
                if (student != null)
                {
                    return View(student);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult UpdateStudent(Student student)
        {
            if (student != null)
            {
                var st = _context.Students.Where(x => x.StId == student.StId).FirstOrDefault();
                st.StName = student.StName;
                st.StId = student.StId;
                st.Address = student.Address;
                st.RegistedDate = student.RegistedDate;
                st.ClassID = student.ClassID;
                st.Phone = student.Phone;
                st.IdentityUserId = student.IdentityUserId;
                _context.SaveChanges();
                return RedirectToAction("GetAllStudent", new { id = student.ClassID });
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            Student student;
            if (id > 0)
            {
                student = _context.Students.Where(x => x.StId == id).FirstOrDefault();
                if (student != null)
                {
                    return View(student);
                }
            }
            return View();
        }
        [HttpPost , ActionName("DeleteStudent")]
        public IActionResult ConfirmDeleteStudent(int id)
        {
            Student student;
            if (id > 0)
            {
                student = _context.Students.Where(x => x.StId == id).FirstOrDefault();
                if (student != null)
                {
                    var msgs = _context.Messages.Where(x => x.StID == id).ToList();
                    _context.Messages.RemoveRange(msgs);
                    _context.SaveChanges();
                    _context.Students.Remove(student);
                    _context.SaveChanges();
                    return RedirectToAction("GetAllStudent", new { id = student.ClassID });
                }
            }
            return View();            
        }
    }
}
