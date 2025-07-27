using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_Management_System.Controllers
{
    public class AppointmentController : Controller
    {
        AppointmentContext appointmentContext = new AppointmentContext();
        // GET: Appointment
        [Authorize(Roles = "Patient,Admin")]
        public ActionResult Index()
        {
            return View(appointmentContext.appointments.ToList());
        }
        [Authorize(Roles = "Patient,Admin")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Patient,Admin")]
        public ActionResult Create(Appointment ap)
        {
            if(ModelState.IsValid)
            {
                appointmentContext.appointments.Add(ap);
                appointmentContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ap);
        }
        [HttpPost]
        [Authorize(Roles = "Patient,Admin")]
        public ActionResult Update(Appointment updatedApmnt)
        {
            var existingApmnt = appointmentContext.appointments.Find(updatedApmnt.Appointment_Id);
            existingApmnt.Doctor_Id = updatedApmnt.Doctor_Id;
            existingApmnt.Patient_Id = updatedApmnt.Patient_Id;
            existingApmnt.Information = updatedApmnt.Information;
            existingApmnt.Appointment_Date = updatedApmnt.Appointment_Date;
            appointmentContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Patient,Admin")]
        public ActionResult Update(int id)
        {
            Appointment apmnt = appointmentContext.appointments.Find(id);
            if (apmnt == null)
            {
                return HttpNotFound();
            }
            return View(apmnt);
        }
        [Authorize(Roles = "Patient,Admin")]
        public ActionResult Delete(int id)
        {
            Appointment apmnt = appointmentContext.appointments.Find(id);
            if (apmnt != null)
            {
                appointmentContext.appointments.Remove(apmnt);
                appointmentContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}