using System;
using Modul7_GudangOOP.Models;
using Modul7_GudangOOP.Services;
using Modul7_GudangOOP.Interfaces;

// [Langkah 3, Bagian 3 PDF]
class Program
{
    static void Main()
    {
        // 1. Inisialisasi semua servis yang kita butuhkan
        InputBarang inputService = new InputBarang();
        PenyimpanBarang penyimpanService = new PenyimpanBarang();
        
        // Gunakan Interface untuk deklarasi (OCP)
        IBarangPrinter printerService = new PencetakBarang(); 

        // 2. Persiapkan file
        penyimpanService.InisialisasiFile();

        Console.WriteLine("=== SISTEM GUDANG (MODUL 7: SOLID) ===");

        try
        {
            // 3. Panggil servis input
            Barang barangBaru = inputService.AmbilInput();

            if (barangBaru != null)
            {
                // 4. Panggil servis simpan
                penyimpanService.Simpan(barangBaru);

                // 5. Panggil servis cetak
                printerService.Cetak(barangBaru);
            }
        }
        catch (Exception ex)
        {
            // Menangkap error tak terduga
            Console.WriteLine($"[ERROR UTAMA] Terjadi kesalahan: {ex.Message}");
        }

        // 6. Tampilkan hasil akhir dari file
        penyimpanService.TampilkanSemuaIsiFile();
    }
}