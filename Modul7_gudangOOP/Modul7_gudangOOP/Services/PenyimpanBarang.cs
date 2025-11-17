using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul7_GudangOOP.Models;

namespace Modul7_GudangOOP.Services
{
    public class PenyimpanBarang
    {
        private readonly string _pathFile = "data_barang.txt";

        private const int LebarKode = 10;
        private const int LebarNama = 20;
        private const int LebarStok = 10;
        private const int LebarKategori = 15;

        // 1. Cek dan buat header jika file belum ada
        public void InisialisasiFile()
        {
            if (!File.Exists(_pathFile))
            {
                try
                {
                    // [PERUBAHAN] Ganti \t dengan PadRight
                    string header = "Kode".PadRight(LebarKode) +
                                    "Nama".PadRight(LebarNama) +
                                    "Stok".PadRight(LebarStok) +
                                    "Kategori".PadRight(LebarKategori);

                    // [TAMBAHAN] Buat garis pemisah
                    string separator = new string('-', LebarKode + LebarNama + LebarStok + LebarKategori);

                    File.WriteAllText(_pathFile, header + "\n" + separator + "\n"); // Tulis header + pemisah
                    Console.WriteLine($"[INFO] File baru '{_pathFile}' berhasil dibuat.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR] Gagal membuat file: {ex.Message}");
                }
            }
        }

        // 2. Simpan (append) barang baru
        public void Simpan(Barang barang)
        {
            try
            {
                // Format agar sejajar dengan header menggunakan PadRight
                string line = (barang.KodeBarang ?? string.Empty).PadRight(LebarKode) +
                              (barang.NamaBarang ?? string.Empty).PadRight(LebarNama) +
                              barang.JumlahStok.ToString().PadRight(LebarStok) +
                              (barang.Kategori ?? string.Empty).PadRight(LebarKategori);

                // true = mode Append (tambah di akhir)
                using (StreamWriter sw = new StreamWriter(_pathFile, true))
                {
                    sw.WriteLine(line);
                }
                Console.WriteLine("\n[SUKSES] Data berhasil disimpan permanen ke file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[ERROR] Terjadi kesalahan saat menyimpan: {ex.Message}");
            }
        }

        // 3. Tampilkan semua isi file
        public void TampilkanSemuaIsiFile()
        {
            Console.WriteLine($"\n--- Isi File '{_pathFile}' Saat Ini ---");
            if (File.Exists(_pathFile))
            {
                string[] semuaBaris = File.ReadAllLines(_pathFile);
                foreach (string baris in semuaBaris)
                {
                    Console.WriteLine(baris);
                }
            }
            Console.WriteLine("-------------------------------------------");
        }
    }
}
