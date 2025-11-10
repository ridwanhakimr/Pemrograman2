using System;
using System.Collections.Generic;
// Pastikan namespace ini sesuai dengan yang Anda ubah di langkah 1
using Modul5_GudangOOP.Models;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== LANGKAH 1: List<T> ===");
        // [Langkah 1] Simpan Banyak Objek Barang ke dalam List<Barang>
        List<Barang> daftarBarang = new List<Barang>();
        daftarBarang.Add(new Barang("BRG001", "Karton", 100, "Kemasan"));
        daftarBarang.Add(new Barang("BRG002", "Peti", 50, "Penyimpanan"));
        // Menambahkan variasi barang lain untuk uji coba
        daftarBarang.Add(new BarangElektronik("EL001", "Laptop", 5, "Elektronik", 65));

        // Loop dan tampilkan semua barang
        foreach (var barang in daftarBarang)
        {
            barang.TampilkanInfo();
        }
        Console.WriteLine();

        Console.WriteLine("=== LANGKAH 2: Pencarian dengan .Find() ===");
        // [Langkah 2] Cari Barang dengan LINQ / .Find()
        Console.Write("Mencari BRG002... ");
        var hasilCari = daftarBarang.Find(b => b.KodeBarang == "BRG002");
        if (hasilCari != null)
        {
            Console.WriteLine("Ditemukan!");
            hasilCari.TampilkanInfo();
        }
        else
        {
            Console.WriteLine("Tidak ditemukan.");
        }
        Console.WriteLine();

        Console.WriteLine("=== LANGKAH 3: Dictionary<K,V> ===");
        // [Langkah 3] Gunakan Dictionary<string, Barang> untuk indeksasi cepat
        Dictionary<string, Barang> indeksBarang = new Dictionary<string, Barang>();

        // Mengisi dictionary dari list yang sudah ada agar efisien
        foreach (var b in daftarBarang)
        {
            indeksBarang[b.KodeBarang] = b;
        }

        // Penggunaan Dictionary untuk akses cepat berdasarkan kunci (KodeBarang)
        string kodeCari = "BRG001";
        Console.Write($"Mengakses {kodeCari} via Dictionary... ");
        if (indeksBarang.ContainsKey(kodeCari))
        {
            Console.WriteLine("Ditemukan!");
            indeksBarang[kodeCari].TampilkanInfo();
        }
        else
        {
            Console.WriteLine($"Barang dengan kode {kodeCari} tidak ditemukan di Dictionary.");
        }
        Console.WriteLine();

        Console.WriteLine("=== LANGKAH 4: Generic Method ===");
        // [Langkah 4] Penggunaan Method Generic CariData<T>
        Console.Write("Mencari barang kategori 'Penyimpanan' dengan Generic Method... ");
        // Contoh 1: Mencari Barang
        Barang hasilGeneric = CariData(daftarBarang, b => b.Kategori == "Penyimpanan");
        if (hasilGeneric != null)
        {
            Console.WriteLine("Ditemukan!");
            hasilGeneric.TampilkanInfo();
        }

        // Contoh 2: Demonstrasi fleksibilitas generic (misal mencari angka di List<int>)
        List<int> angka = new List<int> { 10, 20, 30, 50 };
        int angkaLebih30 = CariData(angka, n => n > 30);
        Console.WriteLine($"Hasil pencarian angka > 30: {angkaLebih30}");
    }

    // [Langkah 4] Definisi Method Generic
    // Method ini bisa digunakan untuk Tipe T apapun (Barang, int, string, dll)
    public static T CariData<T>(List<T> list, Func<T, bool> predicate)
    {
        // Fixed: List<T>.Find expects a Predicate<T>; convert the Func<T,bool> to a Predicate<T> using a lambda.
        return list.Find(item => predicate(item));
    }
}