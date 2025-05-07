using AM.ApplicationCore.domain;
using AM.ApplicationCore.interfaces;
using AM.ApplicationCore.Interfaces;
using AM.infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Am.web.Controllers
{
    public class PlaneController : Controller
    {
        IServicePlane sp;

        public PlaneController(IServicePlane sp)
        {
            this.sp = sp;
        }

        // GET: PlaneController
        public ActionResult Index()
        {
            return View(sp.GetAll());
        }

        // GET: PlaneController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlaneController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlaneController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Plane p)
        {
            try
            {sp.Add(p);
                sp.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlaneController/Edit/5
        public ActionResult Edit(int id)
        {
            var plane = sp.GetById(id);
            if (plane == null)
            {
                return NotFound();
            }
            return View(plane);
        }

        // POST: PlaneController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        //public ActionResult Edit(int id, Plane updatedPlane)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            sp.Update(updatedPlane); // mise à jour
        //            sp.Commit();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(updatedPlane);
        //    }
        //    catch
        //    {
        //        return View(updatedPlane);
        //    }
        //}



        // GET: PlaneController/Delete/5
        public ActionResult Delete(int id)
        {
          //  return View();

            var plane = sp.GetById(id);
            if (plane == null)
                return NotFound();
            return View(plane);

        }

        // POST: PlaneController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            //try
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
            var plane = sp.GetById(id);
            if (plane != null)
            {
                sp.Delete(plane);
                sp.Commit();
            }
            return RedirectToAction(nameof(Index));



        }
    }
}
