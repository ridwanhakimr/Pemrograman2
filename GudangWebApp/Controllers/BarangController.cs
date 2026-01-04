using Microsoft.AspNetCore.Mvc;
using GudangWebApp.Models;

namespace GudangWebApp.Controllers
{
    public class BarangController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor Injection untuk DbContext
        public BarangController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Menampilkan daftar barang dari database
        public IActionResult Index()
        {
            var data = _context.Barang.ToList();
            return View(data);
        }

        // Menampilkan form tambah barang
        public IActionResult Create()
        {
            return View();
        }

        // Memproses data yang dikirim dari form Create
        [HttpPost]
        public IActionResult Create(Barang barang)
        {
            if (ModelState.IsValid)
            {
                _context.Barang.Add(barang);
                _context.SaveChanges(); // Menyimpan ke database
                return RedirectToAction("Index");
            }
            return View(barang);
        }

        // GET: Barang/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var barangFromDb = _context.Barang.Find(id);

            if (barangFromDb == null)
            {
                return NotFound();
            }

            return View(barangFromDb);
        }

        // POST: Barang/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Barang barang)
        {
            if (ModelState.IsValid)
            {
                _context.Barang.Update(barang);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(barang);
        }

        // GET: Barang/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var barangFromDb = _context.Barang.Find(id);

            if (barangFromDb == null)
            {
                return NotFound();
            }

            return View(barangFromDb);
        }

        // POST: Barang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _context.Barang.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.Barang.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}