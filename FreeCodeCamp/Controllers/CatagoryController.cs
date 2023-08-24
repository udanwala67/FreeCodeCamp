using FreeCodeCamp.Data;
using FreeCodeCamp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreeCodeCamp.Controllers
{

    public class CatagoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CatagoryController(ApplicationDbContext applicationDbContext)
        {

            _dbContext = applicationDbContext;

        }
        public IActionResult Index()
        {
            IEnumerable<Catagory> ObjectCatagoryList = _dbContext.Catagories.ToList();
            return View(ObjectCatagoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Catagory catagory)
        {
            if (catagory.Name == catagory.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Name and Displayorder feilds can not exactly match");
            }
            if (ModelState.IsValid)
            {
                _dbContext.Catagories.Add(catagory);
                _dbContext.SaveChanges();
                TempData["success"] = "Catagory Created Succesfully!";
                return RedirectToAction("Index", "Catagory");
            }
            else
            {
                return View(catagory);
            }
        }

        public IActionResult Edit(int? Id)
        {

            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            else
            {
                var data = _dbContext.Catagories.FirstOrDefault(u => u.Id == Id);
                if (data == null)
                {
                    return NotFound();
                }
                return View(data);

            }
        }

        [HttpPost]

        public IActionResult Edit(Catagory catagory)
        {

            if (catagory.Name == catagory.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Name and Displayorder feilds can not exactly match");
            }
            if (ModelState.IsValid)
            {
                catagory.UpdatedAt = DateTime.Now;
                _dbContext.Catagories.Update(catagory);
                _dbContext.SaveChanges();
                TempData["success"] = "Catagory Updated Succesfully!";
                return RedirectToAction("Index", "Catagory");
            }
            else
            {
                return View(catagory);
            }

        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            else
            {
                var data = _dbContext.Catagories.FirstOrDefault(u => u.Id == Id);
                if (data == null)
                {
                    return NotFound();
                }
                return View(data);

            }
        }

        [HttpPost]

        public IActionResult Delete(Catagory catagory)
        {
            if (catagory == null)
            {
                return NotFound();
            }
            else
            {
                _dbContext.Catagories.Remove(catagory);
                _dbContext.SaveChanges();
                TempData["success"] = "Catagory Deleted Succesfully!";
                return RedirectToAction("Index", "Catagory");

            }
        }

    }
}
