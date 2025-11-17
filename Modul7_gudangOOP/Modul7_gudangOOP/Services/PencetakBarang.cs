using Modul7_GudangOOP.Interfaces; // Implementasi interface
using Modul7_GudangOOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul7_GudangOOP.Services
{
    // [Langkah 3, Bagian 2 PDF]
    public class PencetakBarang : IBarangPrinter
    {
        public void Cetak(Barang barang)
        {
            Console.WriteLine("=== INFORMASI BARANG ===");
            Console.WriteLine($"Kode    : {barang.KodeBarang}");
            Console.WriteLine($"Nama    : {barang.NamaBarang}");
            Console.WriteLine($"Stok    : {barang.JumlahStok}");
            Console.WriteLine($"Kategori: {barang.Kategori}");
            Console.WriteLine("========================");
        }
    }
}
