using Microsoft.AspNetCore.Mvc;
using EmployeeAppManagement.Models;

namespace EmploypeeAppManagement.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult FacultyList()
        {
            return View(EmployeeData.Faculty);
        }

        [HttpGet]
        public IActionResult StaffList()
        {
            return View(EmployeeData.Staff);
        }

                [HttpGet]
        public IActionResult AddFaculty()
        {
            var facultyCount = EmployeeData.Faculty.Count;
            var nextEmployeeId = facultyCount + 1;
            ViewBag.NextEmployeeId = nextEmployeeId;

            EmployeeViewModel model = new EmployeeViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddFaculty(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                EmployeeData.Faculty.Add(model);
            }
            return RedirectToAction("FacultyList");
        }


        [HttpGet]
        public IActionResult AddStaff()
        {
            EmployeeViewModel model = new EmployeeViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddStaff(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                EmployeeData.Staff.Add(model);
            }
            return RedirectToAction("StaffList");
        }


        [HttpGet]
        public IActionResult DetailEmployee(int EmployeeID, String EmpCategory)
        {
            EmployeeViewModel model = new EmployeeViewModel();
            ViewBag.Category = EmpCategory;

            if (EmpCategory.Equals("Faculty"))
            {
               model = EmployeeData.Faculty.FirstOrDefault(Faculty => Faculty.EmployeeId == EmployeeID);                
            }

            if (EmpCategory.Equals("Staff"))
            {
                model = EmployeeData.Staff.FirstOrDefault(Staff => Staff.EmployeeId == EmployeeID);
            }

            if (model == null)
            {
                return NotFound(); 
            }

            return View(model);
        }



        [HttpGet]
        public IActionResult Edit(int EmployeeID, String EmpCategory)
        {
            EmployeeViewModel model = new EmployeeViewModel();
            ViewBag.Category = EmpCategory;

            if (EmpCategory.Equals("Faculty"))
            {
                model = EmployeeData.Faculty.FirstOrDefault(Faculty => Faculty.EmployeeId == EmployeeID);
            }

            if (EmpCategory.Equals("Staff"))
            {
                model = EmployeeData.Staff.FirstOrDefault(Staff => Staff.EmployeeId == EmployeeID);
            }

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeViewModel model, string employeeCategory)
        {
            EmployeeViewModel empmodel = new EmployeeViewModel();
            String redirect = employeeCategory + "List";

            if (ModelState.IsValid)
            {
                if (employeeCategory.Equals("Faculty"))
                {
                    empmodel = EmployeeData.Faculty.FirstOrDefault(Faculty => Faculty.EmployeeId == model.EmployeeId);
                }

                if (employeeCategory.Equals("Staff"))
                {
                    empmodel = EmployeeData.Staff.FirstOrDefault(Staff => Staff.EmployeeId == model.EmployeeId);
                }


                if (empmodel == null)
                {
                    return NotFound();
                }

                // Update employee details
                empmodel.FirstName = model.FirstName;
                empmodel.LastName = model.LastName;
                empmodel.Email = model.Email;
                empmodel.OfficePhone = model.OfficePhone;
                empmodel.PhotoURL = model.PhotoURL;
                                

                return RedirectToAction(redirect);
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Delete(int EmployeeID, String EmpCategory)
        {
            EmployeeViewModel model = new EmployeeViewModel();
            ViewBag.Category = EmpCategory;

            if (EmpCategory.Equals("Faculty"))
            {
                model = EmployeeData.Faculty.FirstOrDefault(Faculty => Faculty.EmployeeId == EmployeeID);
            }

            if (EmpCategory.Equals("Staff"))
            {
                model = EmployeeData.Staff.FirstOrDefault(Staff => Staff.EmployeeId == EmployeeID);
            }

            if (model == null)
            {
                return NotFound();
            }           

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int EmployeeID, String EmpCategory)
        {
            EmployeeViewModel empmodel = new EmployeeViewModel();
            String redirect = EmpCategory + "List";

            if (ModelState.IsValid)
            {
                if (EmpCategory.Equals("Faculty"))
                {
                    empmodel = EmployeeData.Faculty.FirstOrDefault(Faculty => Faculty.EmployeeId == EmployeeID);
                    EmployeeData.Faculty.Remove(empmodel);
                }

                if (EmpCategory.Equals("Staff"))
                {
                    empmodel = EmployeeData.Staff.FirstOrDefault(Staff => Staff.EmployeeId == EmployeeID);
                    EmployeeData.Staff.Remove(empmodel);
                }


                if (empmodel == null)
                {
                    return NotFound();
                }
            }

            return RedirectToAction(redirect); 
        }        





    }

    
}
