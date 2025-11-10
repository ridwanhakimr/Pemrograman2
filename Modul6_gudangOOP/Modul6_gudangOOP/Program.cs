using System;
using System.Collections.Generic;
using System.IO;
using Modul6_GudangOOP.Models;

class Program
{
    static void Main()
    {
        string pathFile = "data_barang.txt";

        Console.WriteLine("=== SISTEM GUDANG: INPUT & SIMPAN PERMANEN ===\n");

        // [PERUBAHAN PENTING 1] Cek apakah file sudah ada.
        // Jika belum ada, baru kita buat dan tulis header-nya.
        // Jika sudah ada, kita biarkan agar data lama tidak hilang.
        if (!File.Exists(pathFile))
        {
            try
            {
                File.WriteAllText(pathFile, "Kode\tNama\tStok\tKategori\n");
                Console.WriteLine("[INFO] File baru 'data_barang.txt' berhasil dibuat.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Gagal membuat file: {ex.Message}");
            }
        }

        // --- BAGIAN INPUT DATA ASLI DARI USER ---
        Console.WriteLine("Silakan input barang baru untuk disimpan ke file.");
        try
        {
            // Meminta input kode agar dinamis
            Console.Write("Masukkan Kode Barang (misal B001): ");
            string kode = Console.ReadLine();

            Console.Write("Masukkan Nama Barang: ");
            string nama = Console.ReadLine();

            Console.Write("Masukkan Jumlah Stok (angka): ");
            int stok = int.Parse(Console.ReadLine()); // Bisa error jika bukan angka

            Console.Write("Masukkan Kategori: ");
            string kategori = Console.ReadLine();

            // Membuat objek barang
            Barang barangBaru = new Barang(kode, nama, stok, kategori);

            // [PERUBAHAN PENTING 2] Langsung simpan data inputan ini ke file
            // Menggunakan true pada StreamWriter untuk mode 'Append' (tambah data di akhir)
            using (StreamWriter sw = new StreamWriter(pathFile, true))
            {
                sw.WriteLine($"{barangBaru.KodeBarang}\t{barangBaru.NamaBarang}\t{barangBaru.JumlahStok}\t{barangBaru.Kategori}");
            }

            Console.WriteLine("\n[SUKSES] Data berikut berhasil disimpan permanen ke file:");
            barangBaru.TampilkanInfo();
        }
        catch (FormatException)
        {
            Console.WriteLine("\n[ERROR] Input stok harus berupa angka bulat!");
        }
        catch (StokNegatifException ex)
        {
            Console.WriteLine($"\n[ERROR] Validasi Gagal: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n[ERROR] Terjadi kesalahan saat menyimpan: {ex.Message}");
        }

        Console.WriteLine("\n------------------------------------------------\n");

        // --- BAGIAN MEMBACA SEMUA DATA DARI FILE ---
        Console.WriteLine("[Isi File 'data_barang.txt' Saat Ini]");
        if (File.Exists(pathFile))
        {
            string[] semuaBaris = File.ReadAllLines(pathFile);
            foreach (string baris in semuaBaris)
            {
                Console.WriteLine(baris);
            }
        }
    }
}