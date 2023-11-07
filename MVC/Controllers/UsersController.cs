#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using DataAccess.Entities;
using Business;
using DataAccess.Enums;
using Business.Results.Basis;

//Generated from Custom Template.
namespace MVC.Controllers
{
    public class UsersController : Controller
    {
        // Add service injections here
        
        private readonly IUserService _userService;//Business da Yarattık
        private readonly IRoleService _roleService;//Role için business yarattık
        public UsersController(IUserService userService, IRoleService roleService)
        {
            _roleService = roleService;
            _userService = userService;
        }

        // GET: Users
        public IActionResult List()
        {
            /********/
            // TODO: Add get list service logic here //Business da Yarattık
            /********/
            List<UserModel> userList = _userService.Query().ToList();
            //List<UserModel> userList = null;
            return View("Index", userList);
        }

        //Bu method JSON dönecek
        public JsonResult ListJson()
        {
            var userList = _userService.Query().ToList();
            return Json(userList);
        }

        // GET: Users/Details/5
        public IActionResult Details(int id)
        {

            //UserModel user = _userService.Query().FirstOrDefault(u => u.Id == id);
            //UserModel user = _userService.Query().LastOrDefault(u => u.Id == id);


            //bi user a id üzerinden detaylı ulaşabiliriz.
            //single tek kayıt çekmesi demek
            //Sinle() --> uymayan her koşulda error alıyoruz
            //SingleOrDefault() birden çok kayıt vara error atıyo yoksa null atıyo
            //default varsa null atar yoksa exception atar.
            UserModel user = _userService.Query().SingleOrDefault(u => u.Id == id);
            //UserModel user = null; // TODO: Add get item service logic here 
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        //[HttpGet]
        public IActionResult Create()
        {
			// Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
			//ViewData["RoleId"] = new SelectList(null, "Id", "Id");
			ViewData["Roles"] = new SelectList(_roleService.Query().ToList(), "Id", "Name");
			return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost] /*ACTİON METHOD (Attribute)*/
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserModel user)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert service logic here
                //ekleme islemini yapicaz
                //servis uzerinden islem yapicaz
                Result result = _userService.Add(user);
                //return RedirectToAction(nameof(Index));
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(List));
                }

                //Way 1: carrying data fro the action with view data.
                //ViewBag.Message = result.Message;
                //Way 2: sends data to the views summary ModelState
                ModelState.AddModelError("", result.Message); //--> bu yolla direkt ModelState ten gosterebiliriz.
			}
			// Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
			//Way 1:
			ViewBag.Roles = new SelectList(_roleService.Query().ToList(), "Id", "Name", user.RoleId);
			//way 2:
			//zorunlu değiliz seçili göndersin RoleId yi
			//ViewBag.Roles = new SelectList(_roleService.Query().ToList(), "Id", "Name");
			return View(user);
        }


        //way 2 for create (post)
        //public IActionResult Create(string UserName, string Password, bool IsActive, Stasuses Status, int RoleId)
        //{
        //}



        // GET: Users/Edit/5
        public IActionResult Edit(int id)
        {
            UserModel user = _userService.Query().SingleOrDefault(u => u.Id == id); // TODO: Add get item service logic here
            if (user == null)
            {
                return NotFound(); // 404 http status code!
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewBag.RoleId = new SelectList(_roleService.Query().ToList(), "Id", "Name");
            return View(user);
        }

        // POST: Users/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserModel user)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update service logic here
                var result = _userService.Update(user);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(List));
                }
                ModelState.AddModelError("", result.Message);
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["RoleId"] = new SelectList(_roleService.Query().ToList(), "Id", "Name");
            return View(user);
        }

        // GET: Users/Delete/5
        public IActionResult Delete(int id)
        {
            UserModel user = _userService.Query().SingleOrDefault(u => u.Id == id); // TODO: Add get item service logic here
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Add delete service logic here
            var result = _userService.DeleteUser(id);

            TempData["Message"] = result.Message;
            
            return RedirectToAction(nameof(Index));
        }
	}
}
