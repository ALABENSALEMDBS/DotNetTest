using System.Numerics;
using AM.ApplicationCore.domain;
using AM.ApplicationCore.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Am.web.Controllers
{
    public class FlightController : Controller
    {
        IFlightMethods sf;
        IServicePlane pl;


        public FlightController(IFlightMethods sf, IServicePlane pl)
        {
            this.sf = sf;
            this.pl = pl;
        }



        // GET: FlightController
        public ActionResult Index(DateTime? dateDepart)
        {
            if (dateDepart == null)
                        return View(sf.GetAll().ToList());
            else
                       return View(sf.GetMany(f => f.FlightDate.Date.Equals(dateDepart)).ToList());

               // return View(sf.GetAll());

        }

        

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            ViewBag.planefk=new SelectList(pl.GetAll(), "PlaneId", "Capacity");
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight flight, IFormFile PilotImage)

        {


            try

            {

                if (PilotImage != null)

                {

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", PilotImage.FileName);

                    Stream stream = new FileStream(path, FileMode.Create);

                    PilotImage.CopyTo(stream);

                    flight.Pilot = PilotImage.FileName;

                }

                sf.Add(flight);

                sf.Commit();

                return RedirectToAction(nameof(Index));

            }

            catch

            {

                return View();

            }

        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FlightController/Edit/5
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

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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


        public ActionResult Sort()

        {
            return View("Index", sf.SortFlights());
        }
    }
}
