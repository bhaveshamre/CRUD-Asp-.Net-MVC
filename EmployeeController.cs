using CRUD7.Data;
using CRUD7.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD7.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        // GET: EmployeeController
        public async Task<IActionResult> Index()
        {
            var emp = await _context.Employees.ToListAsync();
            return View(emp);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeView employeeView)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeView); // Return the view to show validation errors
            }
            var emp = new Employee
            {
                name = employeeView.name,
                email = employeeView.email,
                contactNo = employeeView.contactNo,
                address = employeeView.address
            };

            await _context.Employees.AddAsync(emp);
            await _context.SaveChangesAsync();
            return View();
        }

        // GET: EmployeeController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            return View(emp);
        }
        


        // POST: EmployeeController/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Employee view)
        {
            var emp = await _context.Employees.FindAsync(view.empId);

            if(emp != null)
            {
                emp.name = view.name;
                emp.email = view.email;
                emp.contactNo= view.contactNo;
                emp.address = view.address;

                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Employee");
            }
            else { return NotFound(); }
            
            
        }

        // GET: EmployeeController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            // Fetch the employee to be deleted
            var emp = await _context.Employees.FindAsync(id);

            // Check if the employee exists
            if (emp == null)
            {
                return NotFound(); // Return a 404 if the employee is not found
            }

            // Pass the employee to the view for confirmation
            return View(emp);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Employee empl)
        {
          
            var emp = await _context.Employees.FindAsync(empl.empId);

            // Check if the employee exists
            if (emp == null)
            {
                return NotFound(); 
            }

            // Remove the employee from the context
            _context.Employees.Remove(emp);

            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Redirect to the Index page after deletion
            return RedirectToAction("Index", "Employee");
        }



    }
}
