using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_Management_System.Controllers
{
    public class PatientController : Controller
    {
        //List<Patient> patientsList = new List<Patient>();
        // GET: Patient
        

        PatientContext patientContext = new PatientContext();
        [Authorize(Roles = "Patient,Admin")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "Patient,Admin")]
        public ActionResult Index()
        {
            var allpatients = patientContext.Patients.ToList();
            return View(allpatients);
        }
       
        [HttpPost]
        [Authorize(Roles = "Patient,Admin")]
        public ActionResult Create(Patient p)
        {
            if(ModelState.IsValid)
            {
                patientContext.Patients.Add(p);
                patientContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
            
        }
        [HttpPost]
        [Authorize(Roles = "Patient,Admin")]
        public ActionResult Update(Patient updatedPatient)
        {
            var existingPatient = patientContext.Patients.Find(updatedPatient.Patient_id);
            existingPatient.Patient_name = updatedPatient.Patient_name;
            existingPatient.Patient_age = updatedPatient.Patient_age;
            existingPatient.Illness = updatedPatient.Illness;
            existingPatient.Blood_group = updatedPatient.Blood_group;
            patientContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize(Roles = "Patient,Admin")]
        public ActionResult Update(int id)
        {
            Patient d = patientContext.Patients.Find(id);
            if (d == null)
            {
                return HttpNotFound();
            }
            return View(d);
        }
        [Authorize(Roles = "Patient,Admin")]
        public ActionResult Delete(int id)
        {
            Patient d = patientContext.Patients.Find(id);
            if (d != null)
            {
                patientContext.Patients.Remove(d);
                patientContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}