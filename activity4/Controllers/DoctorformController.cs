using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using activity4.Data;
using activity4.Models;
using Microsoft.AspNetCore.Identity;

namespace activity4.Controllers
{
    public class DoctorformController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DoctorformController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult DoctorsList()
        {
            var doclist = _context.Doctorsforms.Include(d => d.User).ToList();
            var model = new DoctorViewModel
            {
                DoctorsList = doclist
            };
            return View(model);
        }
        public IActionResult Doctors()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Doctors(DoctorViewModel record)
        {
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            var user = new ApplicationUser
            {
                FirstName = record.FirstName,
                LastName = record.LastName,
                Email = record.Email,
                EmailConfirmed = true,
                PhoneNumber = record.ContactNo,
                UserType = 2
            };
            user.PasswordHash = passwordHasher.HashPassword(user, "temppassword");

            var doctor = new Doctorsform
            {
                 User = user,
                 DoctorType = record.DoctorType,
                 Schedule = record.Schedule,
                 MOP = record.MOP
            };

            _context.Users.Add(user);
            _context.Doctorsforms.Add(doctor);
            _context.SaveChanges();

            return RedirectToAction("DoctorsList");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("DoctorsList");
            }

            var doctor = _context.Doctorsforms.Include(o => o.User).Where(o => o.DoctorID == id).SingleOrDefault();

            if (doctor == null)
            {
                return RedirectToAction("DoctorsList");
            }

            var model = new DoctorViewModel()
            {
                DoctorID = doctor.DoctorID,
                FirstName = doctor.User.FirstName,
                LastName = doctor.User.LastName,
                Email = doctor.User.Email,
                ContactNo = doctor.User.PhoneNumber,
                DoctorType = doctor.DoctorType,
                Schedule = doctor.Schedule,
                MOP = doctor.MOP
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(int? id, DoctorViewModel record)
        {
            var doctor = _context.Doctorsforms.Include(d => d.User).Where(d => d.DoctorID == id).SingleOrDefault();
            var user = _context.Users.Where(u => u.Id == doctor.User.Id).SingleOrDefault();

            doctor.DoctorType = record.DoctorType;
            doctor.Schedule = record.Schedule;
            doctor.MOP = record.MOP;
            _context.Doctorsforms.Update(doctor);

            user.FirstName = record.FirstName;
            user.LastName = record.LastName;
            user.Email = record.Email;
            user.PhoneNumber = record.ContactNo;
            _context.Users.Update(user);

            _context.SaveChanges();
            return RedirectToAction("DoctorsList");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("DoctorsList");
            }
            var form = _context.Doctorsforms.Where(o => o.DoctorID == id).SingleOrDefault();
            if (form == null)
            {
                return RedirectToAction("DoctorsList");
            }
            _context.Doctorsforms.Remove(form);
            _context.SaveChanges();

            return RedirectToAction("DoctorsList");

        }
    }
}
