using Hospital_Management_System.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Hospital_Management_System.Controllers
{
    public class AppointmentMarkerController : Controller
    {
        AppointmentMarkerContext markerContext = new AppointmentMarkerContext();
        AppointmentContext apmntDbContext = new AppointmentContext();
        [Authorize(Roles = "Doctor,Admin")]

        // GET: AppointmentMarker
        public ActionResult Index()
        {
            var appointments = apmntDbContext.appointments.ToList();
            return View(appointments);
        }

        [HttpPost]
        [Authorize(Roles = "Doctor,Admin")]

        public ActionResult Mark(int appointmentId, string status)
        {
            var apmnt = apmntDbContext.appointments.Find(appointmentId);
            if (apmnt != null)
            {
                var marker = new AppointmentMarker
                {
                    Appointment_Id = apmnt.Appointment_Id,
                    Doctor_Id = apmnt.Doctor_Id,
                    Patient_Id = apmnt.Patient_Id,
                    Appointment_Date = apmnt.Appointment_Date,
                    Information = apmnt.Information,
                    status = status
                };

                markerContext.appointmentMarkers.Add(marker);
                markerContext.SaveChanges();
                // Set popup and selected status
                TempData["Success"] = "Appointment marked successfully.";
                TempData["MarkedId"] = appointmentId;
                TempData["MarkedStatus"] = status;
            }

            return RedirectToAction("Index");
        }
    }
}
