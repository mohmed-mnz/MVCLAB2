using Microsoft.AspNetCore.Mvc;
using MVCLAB2.Models;
using MVCLAB2.viewmodel;

namespace MVCLAB2.Controllers
{
    public class InstructorController : Controller
    {
        DB_ITI_Context db;
        public InstructorController()
        {
            db = new DB_ITI_Context();
        }
        public IActionResult Index()
        {
            var ins=db.Instructors.ToList();
            return View(ins);
        }

        public IActionResult Detail(int id)
        {
            Instructor ins =db.Instructors.SingleOrDefault(x => x.Id == id);
            Department Dept=db.Departments.SingleOrDefault(y => y.Id ==ins.DeptId);
            Course crs= db.Courses.SingleOrDefault(c => c.Id == ins.CourseId);
            InsDeptCrs MD=new InsDeptCrs();
            MD.Ins_Id = ins.Id;
            MD.Ins_Name = ins.Name;
            MD.Ins_Image = ins.image;
            MD.Ins_Address = ins.Address;
            MD.Ins_Salary = ins.Salary;
            MD.Ins_Department = Dept.Name;
            MD.Ins_Course = crs.Name;
            return View(MD);
        }
    }
}
