using System;

namespace Modul7_GudangOOP.Models
{
    public class BarangElektronik : Barang
    {
        public int DayaListrik { get; set; }

        public BarangElektronik(string kode, string nama, int stok, string kategori, int daya)
            : base(kode, nama, stok, kategori)
        {
            DayaListrik = daya;
        }

        public override void TampilkanInfo()
        {
            base.TampilkanInfo();
            Console.WriteLine($"Daya: {DayaListrik} Watt");
        }
    }
}
