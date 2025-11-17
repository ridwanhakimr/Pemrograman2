using System;

namespace Modul6_GudangOOP.Models
{
    public abstract class ItemGudang
    {
        public string Kode { get; set; }
        public string Nama { get; set; }

        public ItemGudang(string kode, string nama)
        {
            Kode = kode;
            Nama = nama;
        }

        public void CetakInfo()
        {
            Console.WriteLine($"[{Kode}] {Nama}");
        }

        public abstract string EvaluasiResiko();
    }
}