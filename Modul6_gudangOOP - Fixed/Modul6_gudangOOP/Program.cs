using System;
using System.Collections.Generic;
using System.IO; // [PENTING] Diperlukan untuk operasi file
using Modul6_GudangOOP.Models;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== MODUL 6: EXCEPTION HANDLING & FILE I/O ===\n");

        // --- BAGIAN 1: DEMO EXCEPTION HANDLING ---
        Console.WriteLine("[Demo Input Barang Baru]");
        try
        {
            // [Langkah 1 Modul 6] Menangkap error format input (misal user ketik teks untuk stok)
            Console.Write("Masukkan Nama Barang: ");
            string nama = Console.ReadLine();

            Console.Write("Masukkan Jumlah Stok (angka): ");
            int stok = int.Parse(Console.ReadLine()); // Berpotensi error FormatException

            // Membuat objek barang (berpotensi error StokNegatifException jika stok < 0)
            Barang barangBaru = new Barang("NEW001", nama, stok, "Umum");
            Console.WriteLine("\nBarang berhasil dibuat:");
            barangBaru.TampilkanInfo();
        }
        catch (FormatException)
        {
            // Menangkap error jika input bukan angka
            Console.WriteLine("\n[ERROR] Input stok harus berupa angka!");
        }
        catch (StokNegatifException ex)
        {
            // Menangkap error khusus stok negatif
            Console.WriteLine($"\n[ERROR] Validasi Gagal: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Menangkap error lain yang tidak terduga
            Console.WriteLine($"\n[ERROR] Terjadi kesalahan: {ex.Message}");
        }

        Console.WriteLine("\n------------------------------------------------\n");

        // --- BAGIAN 2: DEMO FILE I/O ---
        string pathFile = "data_barang.txt";

        // [Langkah 3 Modul 6] Menyimpan data ke File
        Console.WriteLine("[Menyimpan Data ke File...]");

        // Menyiapkan data dummy sesuai modul
        List<Barang> daftarBarang = new List<Barang>
        {
            new Barang("B001", "Laptop", 30, "Elektronik"),
            new Barang("B002", "Smartphone", 60, "Elektronik"),
            new Barang("B003", "Kulkas", 20, "Elektronik"),
            new Barang("B004", "Televisi", 10, "Elektronik"),
            new Barang("B005", "Mesin Cuci", 5, "Elektronik")
        };

        try
        {
            // Menulis header file (menimpa file lama jika ada)
            File.WriteAllText(pathFile, "Kode\tNama\tStok\n");

            // Menambahkan data barang satu per satu
            foreach (var b in daftarBarang)
            {
                string barisData = $"{b.KodeBarang}\t{b.NamaBarang}\t{b.JumlahStok}\n";
                File.AppendAllText(pathFile, barisData);
            }

            Console.WriteLine($"Berhasil menyimpan {daftarBarang.Count} data ke '{pathFile}'");
            // Menampilkan path lengkap agar mudah dicari
            Console.WriteLine($"Lokasi file: {Path.GetFullPath(pathFile)}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"[ERROR] Gagal menyimpan file: {ex.Message}");
        }

        Console.WriteLine("\n------------------------------------------------\n");

        // [Langkah 4 Modul 6] Membaca data dari File
        Console.WriteLine("[Membaca Data dari File...]\n");
        if (File.Exists(pathFile))
        {
            try
            {
                string[] semuaBaris = File.ReadAllLines(pathFile);
                foreach (string baris in semuaBaris)
                {
                    Console.WriteLine(baris);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"[ERROR] Gagal membaca file: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("[WARNING] File tidak ditemukan!");
        }
    }
}