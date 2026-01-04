using Microsoft.AspNetCore.Mvc;
using GudangWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GudangWebApp.Controllers
{
    // [ApiController] otomatis mengaktifkan validasi model (misal: Cek [Required] di Model Barang)
    [ApiController]
    [Route("api/[controller]")] // URL akan menjadi: https://localhost:xxxx/api/barangapi
    public class BarangApiController : ControllerBase // PERHATIKAN: Warisannya ControllerBase, bukan Controller biasa
    {
        private readonly ApplicationDbContext _context;

        public BarangApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BarangApi
        [HttpGet]
        public IActionResult GetAll()
        {
            // Mengambil semua data dan mengubahnya jadi JSON
            return Ok(_context.Barang.ToList());
        }

        // GET: api/BarangApi/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var barang = _context.Barang.Find(id);

            if (barang == null)
            {
                return NotFound(); // Return 404 jika ID tidak ada
            }

            return Ok(barang); // Return 200 + Data JSON
        }

        // POST: api/BarangApi
        [HttpPost]
        public IActionResult Create([FromBody] Barang barang)
        {
            // Validasi ModelState otomatis jalan karena atribut [ApiController]
            // Namun, logika bisnis (Business Logic) tetap harus kita jaga:

            _context.Barang.Add(barang);
            _context.SaveChanges();

            // Best Practice REST: Kembalikan status 201 Created beserta lokasi URL data barunya
            return CreatedAtAction(nameof(GetById), new { id = barang.Id }, barang);
        }

        // PUT: api/BarangApi/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Barang barang)
        {
            // KRITIS: Pastikan ID di URL sama dengan ID di body JSON
            if (id != barang.Id)
            {
                return BadRequest("ID di URL tidak cocok dengan ID di body request.");
            }

            var existingBarang = _context.Barang.Find(id);
            if (existingBarang == null)
            {
                return NotFound();
            }

            // Update field
            existingBarang.KodeBarang = barang.KodeBarang;
            existingBarang.NamaBarang = barang.NamaBarang;
            existingBarang.JumlahStok = barang.JumlahStok;
            existingBarang.Kategori = barang.Kategori;

            _context.SaveChanges();

            return NoContent(); // 204 No Content (Sukses update, tidak ada data yang dikembalikan)
        }

        // DELETE: api/BarangApi/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var barang = _context.Barang.Find(id);
            if (barang == null)
            {
                return NotFound();
            }

            _context.Barang.Remove(barang);
            _context.SaveChanges();

            return Ok(new { message = "Data berhasil dihapus" }); // Memberi feedback JSON
        }
    }
}