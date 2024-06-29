using Microsoft.AspNetCore.Mvc;
using MvcCoreDemoprj.Models;

namespace MvcCoreDemoprj.Controllers
{
    public class employeeController : Controller
    {
        private readonly MVCAssigementContext context;

        public employeeController(MVCAssigementContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var data = context.TblUserRegisters.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Create(TblUserRegister objuser)
        {
            context.TblUserRegisters.Add(objuser);
            context.SaveChanges();  
            return RedirectToAction("Index");
        }

        public IActionResult Details(int Id)
        {
            var userData=context.TblUserRegisters.FirstOrDefault(x => x.UserId == Id);

            return View(userData);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var userData = context.TblUserRegisters.FirstOrDefault(x => x.UserId == Id);

            return View(userData);
        }

        [HttpPost]
        public IActionResult Edit(int Id, TblUserRegister objuser)
        {
            context.TblUserRegisters.Update(objuser);
            context.SaveChanges();
            return RedirectToAction("Index");

            
        }
        public IActionResult Delete(int Id)
        {
            var userData = context.TblUserRegisters.FirstOrDefault(x => x.UserId == Id);

            return View(userData);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            var userdata = context.TblUserRegisters.Find(Id);
            context.TblUserRegisters.Remove(userdata);
            context.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
