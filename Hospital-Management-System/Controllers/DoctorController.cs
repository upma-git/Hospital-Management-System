using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_Management_System.Controllers
{
    public class DoctorController : Controller
    {
        DoctorContext doctorContext = new DoctorContext();
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Index()
        {
            var allDoctors = doctorContext.Doctors.ToList();
            return View(allDoctors);
        }

        [HttpPost]
        public ActionResult Create(Doctor d)

        {
            if(ModelState.IsValid)
            {
                doctorContext.Doctors.Add(d);
                doctorContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(d);

        }
        [HttpPost]
        public ActionResult Update(Doctor updatedDoctor)
        {
            var existingDoctor = doctorContext.Doctors.Find(updatedDoctor.doctor_id);
            existingDoctor.doctor_name = updatedDoctor.doctor_name;
            existingDoctor.doctor_qualification = updatedDoctor.doctor_qualification;
            existingDoctor.doctor_age = updatedDoctor.doctor_age;
            existingDoctor.specialization = updatedDoctor.specialization;
            doctorContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Doctor d = doctorContext.Doctors.Find(id);
            if (d == null)
            {
                return HttpNotFound();
            }
            return View(d);
        }
        public ActionResult Delete(int id)
        {
            Doctor d = doctorContext.Doctors.Find(id);
            if(d != null)
            {
                doctorContext.Doctors.Remove(d);
                doctorContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}