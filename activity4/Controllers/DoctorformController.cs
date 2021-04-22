using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using activity4.Data;
using activity4.Models;



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
            var doclist = _context.Doctorsforms.ToList();
            return View(doclist);
        }
        public IActionResult Doctors()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Doctors(Doctorsform forms)
        {
            var form = new Doctorsform()
            {
                DoctorName = forms.DoctorName,
                DoctorType = forms.DoctorType,
                ContactNum = forms.ContactNum,
                Schedule = forms.Schedule,
                MOP = forms.MOP
            };
            _context.Doctorsforms.Add(form);
            _context.SaveChanges();

            return RedirectToAction("DoctorsList");
        }
        public IActionResult Edit(int? id)
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
            return View(form);
        }
        [HttpPost]
        public IActionResult Edit(int? id, Doctorsform forms)
        {
            var form = _context.Doctorsforms.Where(o => o.DoctorID == id).SingleOrDefault();
            form.DoctorName = forms.DoctorName;
            form.DoctorType = forms.DoctorType;
            form.ContactNum = forms.ContactNum;
            form.Schedule = forms.Schedule;
            form.MOP = forms.MOP;

            _context.Doctorsforms.Update(form);
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
