using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mhsApp1.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mhsApp1.Controllers
{

    public class DosenController : Controller
    {
        private readonly DosenAppContext daContext;

        public DosenController(DosenAppContext _daContext)
        {
            this.daContext = _daContext;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            return View(await daContext.NilaiMhsses.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(
            [Bind("NameMhs,Matkul,Nilai,Catatan")] NilaiMhss mhss)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    daContext.NilaiMhsses.Add(mhss);
                    await daContext.SaveChangesAsync();
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists " +
                "see your system administrator.");
            }

            return RedirectToAction("Index");

        }


        public async Task<IActionResult> Detail(int id)
        {
            return View(await daContext.NilaiMhsses.FirstOrDefaultAsync(m => m.Id == id));
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await daContext.NilaiMhsses.FirstOrDefaultAsync(m => m.Id == id));
        }

        [HttpPost]
        public IActionResult Edit(NilaiMhss mhss)
        {
            daContext.NilaiMhsses.Update(mhss);
            daContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mhss = await daContext.NilaiMhsses
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mhss == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return RedirectToAction("Index");

        }
    }
}
