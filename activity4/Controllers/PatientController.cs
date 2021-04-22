using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using activity4.Data;
using activity4.Models;

namespace activity4.Controllers
{
    public class PatientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult PatientList()
        {
            var list = _context.Patients.ToList();
            return View(list);
        }

        public IActionResult PatientCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PatientCreate(Patient record)
        {
            var item = new Patient()
            {
                Username = record.Username,
                Password = record.Password,
                FirstName = record.FirstName,
                LastName = record.LastName,
                Age = record.Age,
                Type = record.Type,
                Email = record.Email,
                ContactNumber = record.ContactNumber,
                BirthDate = record.BirthDate.Date,
                Address = record.Address
            };

            _context.Patients.Add(item);
            _context.SaveChanges();

            return RedirectToAction("PatientList");
        }

        public IActionResult PatientEdit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("PatientList");
            }

            var item = _context.Patients.Where(i => i.PatientID == id).SingleOrDefault();
            if (item == null)
            {
                return RedirectToAction("PatientList");
            }

            return View(item);
        }

        [HttpPost]
        public IActionResult PatientEdit(int? id, Patient record)
        {
             var item = _context.Patients.Where(i => i.PatientID == id).SingleOrDefault();
            item.Username = record.Username;
            item.Password = record.Password;
            item.FirstName = record.FirstName;
            item.LastName = record.LastName;
            item.Age = record.Age;
            item.Type = record.Type;
            item.Email = record.Email;
            item.ContactNumber = record.ContactNumber;
            item.BirthDate = record.BirthDate.Date;
            item.Address = record.Address;

            _context.Patients.Update(item);
            _context.SaveChanges();

            return RedirectToAction("PatientList");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("PatientList");
            }

            var item = _context.Patients.Where(i => i.PatientID == id).SingleOrDefault();
            if (item == null)
            {
                return RedirectToAction("PatientList");
            }

            _context.Patients.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("PatientList");
        }


    }
}
