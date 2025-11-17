using Modul7_GudangOOP.Helpers; // Gunakan helper
using Modul7_GudangOOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul7_GudangOOP.Services
{
    // [Modifikasi dari Langkah 1 PDF]
    public class InputBarang
    {
        public Barang AmbilInput()
        {
            // Gunakan helper untuk input yang rapi
            string kode = InputHelper.AmbilString("Masukkan Kode Barang: ");
            string nama = InputHelper.AmbilString("Masukkan Nama Barang: ");

            // Gunakan helper untuk validasi stok
            int stok = InputHelper.AmbilStokValid();

            string kategori = InputHelper.AmbilString("Masukkan Kategori: ");

            // Menggunakan try-catch dari Bab 6 untuk validasi NamaBarang
            try
            {
                Barang barangBaru = new Barang(kode, nama, stok, kategori);
                return barangBaru;
            }
            catch (ArgumentException ex)
            {
                // Menangkap error validasi dari Model Barang (misal nama > 15 karakter)
                Console.WriteLine($"[ERROR Validasi Model] {ex.Message}");
                return null; // Gagal membuat barang
            }
            catch (StokNegatifException ex)
            {
                // Harusnya sudah ditangani InputHelper, tapi untuk keamanan
                Console.WriteLine($"[ERROR Validasi Model] {ex.Message}");
                return null;
            }
        }
    }
}
