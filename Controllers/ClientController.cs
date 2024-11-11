using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wedding.Models;
using Wedding.Repositories.Interfaces;

namespace Wedding.Controllers
{
    public class ClientController : Controller
    {
        private readonly IRepositoryManager repository;
        

        public ClientController(IRepositoryManager repository)
        {
            this.repository = repository;
           
        }
        // GET: ClientController
        public ActionResult Index()
        {
            return View(repository.ClientRepository.GetAll());
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                if (id == 0)
                {
                    TempData["msg"] = "Enter The Entity Number To Get Details ..  ";
                    return RedirectToAction("Index");
                }
                else
                {
                    var obj = repository.ClientRepository.GetById(id);
                    if (obj == null)
                    {
                        TempData["msg"] = " Enter The Enity Number Correctly .. ";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(obj);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"------ Details Exp -------");
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.ClientRepository.Add(obj);
                    repository.unitOfWork.SaveChanges();
                    TempData["msg"] = "Added Successfully ..";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(obj);
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "Unexpected Error";
                return View(obj);
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                TempData["error"] = "Enter The Entity Number";
                return RedirectToAction(nameof(Index));
            }
            var item = repository.ClientRepository.GetById(id);

            if (item == null)
            {
                TempData["error"] = " Enter a Correct Number";
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Client obj)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var res = repository.ClientRepository.Update(obj);
                    if (res != null)
                    {
                        repository.unitOfWork.SaveChanges();
                        TempData["msg"] = "Edited Successfully ..";
                        return RedirectToAction(nameof(Index));

                    }

                    TempData["msg"] = "Not Edited ";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(obj);
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View(obj);
            }
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                TempData["error"] = "Enter The Entity Number";
                return RedirectToAction(nameof(Index));
            }
            var item = repository.ClientRepository.GetById(id);

            if (item == null)
            {
                TempData["error"] = " Enter a Correct Number";
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Client obj)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var res = repository.ClientRepository.Delete(obj);
                    if (res)
                    {
                        repository.unitOfWork.SaveChanges();
                        TempData["msg"] = "Deleted Successfully ..";
                        return RedirectToAction(nameof(Index));
                    }

                    TempData["msg"] = "Not Deleted ";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(obj);
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View(obj);
            }
        }
       
    }
}
