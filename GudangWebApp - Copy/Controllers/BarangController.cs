using Microsoft.AspNetCore.Mvc;
using GudangWebApp.Models; // PENTING: Agar controller mengenali class Barang
using System.Collections.Generic; // Untuk menggunakan List

namespace GudangWebApp.Controllers
{
    public class BarangController : Controller
    {
        public IActionResult Index()
        {
            // 1. Siapkan Data (Seolah-olah mengambil dari Database)
            var daftarBarang = new List<Barang>
            {
                new Barang { Kode = "BRG001", Nama = "Box Kardus", Stok = 120, Kategori = "Kemasan" },
                new Barang { Kode = "BRG002", Nama = "Scanner Barcode", Stok = 20, Kategori = "Elektronik" },
                new Barang { Kode = "BRG003", Nama = "Lakban Bening", Stok = 50, Kategori = "Kemasan" }
            };

            // 2. Kirim data ke View sebagai parameter
            return View(daftarBarang);
        }
    }
}