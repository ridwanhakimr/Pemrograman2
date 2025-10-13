using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1_gudangOOP.Models
{
    public class Barang
    {
        public string KodeBarang;
        public string NamaBarang;
        public int JumlahStok;
        public string Kategori;
        public Barang(string kode, string nama, int stok, string kategori)
        {
            KodeBarang = kode;
            NamaBarang = nama;
            JumlahStok = stok;
            Kategori = kategori;
        }
        public void TampilkanInfo()
        {
            Console.WriteLine($"[{KodeBarang}] {NamaBarang} - Stok: {JumlahStok}, Kategori: {Kategori}");
        }
        public string StatusStok()
        {
            return JumlahStok > 50 ? "Stok Aman" : "Perlu Reorder";
        }
        public Barang()
        {
            KodeBarang = "UNKNOWN";
            NamaBarang = "Barang Baru";
            JumlahStok = 0;
            Kategori = "Umum";
        }
    }
}
