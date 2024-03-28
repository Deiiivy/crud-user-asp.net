using Microsoft.AspNetCore.Mvc;
using user_crud_asp.net.Models;

namespace user_crud_asp.net.Controllers
{
    public class UserController : Controller
    {
        public readonly UserCrudContext _context; 
        public UserController(UserCrudContext context) { _context = context; }

        public IActionResult Index()
        {
            var user = _context.Users.ToList();
            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(user_crud_asp.net.Models.User user)
        {
           if(ModelState.IsValid) { 
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
           }
            return View(user);
        }

        public IActionResult Edit(int id)
        {
            var userId = _context.Users.Find(id);

            if(userId == null)
            {
                return NotFound();
            }
            return View("Edit", userId);
        }

        [HttpPost]
        public IActionResult Edit(user_crud_asp.net.Models.User user)
        {
            if(ModelState.IsValid)
            {
                _context.Users.Update(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var userID = _context.Users.Find(id);
            if(userID == null)
            {
                return NotFound();
            }
            _context.Users.Remove(userID);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
